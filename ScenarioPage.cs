using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenerativeAI;
using GenerativeAI.Types;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace HackKSU2025
{
    public enum ScenarioType
    {
        Parent,
        Teacher
    }
    public partial class ScenarioPage : UserControl
    {


        ToolTip? toolTip;
        GeminiService gemini;
        static string startingPrompt;
        static string wordFilterPrompt;
        static string goalPrompt;
        ScenarioManager scenarioManager;
        ScenarioType scenarioType;
        AudioRecorder audioRecorder = new();
        int userMessages = 0;


        public ScenarioPage(ScenarioType scenarioType)
        {
            this.scenarioType = scenarioType;
            InitializeComponent();
            InitializeToolTip();
            InitializeScenario(scenarioType);
        }
        public static void RetrieveStartingPrompt()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "InitialPrompt.txt");
            string wordFilterPromptPath = Path.Combine(AppContext.BaseDirectory, "Data", "WordFlagPrompt.txt");
            string goalPath = Path.Combine(AppContext.BaseDirectory, "Data", "GoalPrompt.txt");
            startingPrompt = File.ReadAllText(filePath);
            wordFilterPrompt = File.ReadAllText(wordFilterPromptPath);
            goalPrompt = File.ReadAllText(goalPath);
        }
        private void InitializeToolTip()
        {
            toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 10;
            toolTip.ReshowDelay = 10000;
            toolTip.ShowAlways = true;
        }
        private async void InitializeScenario(ScenarioType type)
        {
            scenarioManager = new ScenarioManager();
            scenarioManager.LoadScenarios(type);
            Scenario scenario = scenarioManager.GetRandomScenario();
            Debug.WriteLine("Scenario: " + scenario.ScenarioText);
            Debug.WriteLine("Goal: " + scenario.Goal);

            gemini = new GeminiService(this);
            WaitAI();

            string text = await gemini.InitializeConversation(startingPrompt + "Scenario: " + scenario.ScenarioText + "Goal: " + scenario.Goal);
            AppendStartingMessage(text);
            StopWaitAI();

        }
        public void AppendAIMessage(string text)
        {
            uxMessageBox.AppendText("\n\n");

            uxMessageBox.SelectionAlignment = HorizontalAlignment.Left;
            uxMessageBox.AppendText(text.Trim());
            uxMessageBox.SelectionStart = uxMessageBox.TextLength;
            uxMessageBox.ScrollToCaret();
            
        }
        public void AppendStartingMessage(string text)
        {
            uxMessageBox.SelectionAlignment = HorizontalAlignment.Left;
            uxMessageBox.AppendText(text);
        }


        private List<(int start, int length, string reason)> harmfulWordHighlights = new();

        public void AppendUserMessage(string text, Dictionary<string, string> harmfulWordsWithReason)
        {
            userMessages++;
            uxMessageBox.AppendText("\n\n");
            uxMessageBox.SelectionAlignment = HorizontalAlignment.Right;
            uxMessageBox.AppendText("User: ");

            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int currentLineLength = 0;
            int maxLineLength = 80;

            foreach (string word in words)
            {
                int start = uxMessageBox.TextLength;

                // Clean punctuation for matching
                string cleanWord = Regex.Replace(word, @"^\W+|\W+$", "").ToLowerInvariant();

                // Choose color
                if (harmfulWordsWithReason.ContainsKey(cleanWord))
                {
                    uxMessageBox.SelectionColor = Color.Red;
                    harmfulWordHighlights.Add((start, word.Length, harmfulWordsWithReason[cleanWord]));
                }
                else
                {
                    uxMessageBox.SelectionColor = Color.Black;
                }

                // Check if adding this word exceeds line limit
                if (currentLineLength + word.Length + 1 > maxLineLength)
                {
                    uxMessageBox.AppendText("\n");
                    currentLineLength = 0;
                }

                uxMessageBox.AppendText(word + " ");
                currentLineLength += word.Length + 1;
            }

            uxMessageBox.SelectionStart = uxMessageBox.TextLength;
            uxMessageBox.ScrollToCaret();

            foreach (var dic in harmfulWordsWithReason)
            {
                Debug.WriteLine($"Key: {dic.Key}");
            }
        }

        private async Task<Dictionary<string, string>> GetHarmfulWords(string text)
        {
            return await gemini.GetHarmfulWords(wordFilterPrompt, text);
        }

        private void uxMouseMove(object sender, MouseEventArgs e)
        {
            int index = uxMessageBox.GetCharIndexFromPosition(e.Location);

            // Find if index is inside any highlighted word
            foreach (var highlight in harmfulWordHighlights)
            {
                if (index >= highlight.start && index < highlight.start + highlight.length)
                {
                    // Show tooltip near the mouse
                    toolTip?.SetToolTip(uxMessageBox, highlight.reason);
                    return;
                }
            }

            // If not over a harmful word, hide tooltip
            toolTip?.SetToolTip(uxMessageBox, string.Empty);
        }

        private void uxSendClick(object sender, EventArgs e)
        {
            UserInput();
        }

        private void uxSendEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserInput();
            }
        }
        private async void UserInput()
        {
            WaitAI();
            string text = uxUserText.Text.Trim();
            uxUserText.Text = null;
            var aiMessage = gemini.GenerateChatMessage("Below is the users response. Please roleplay as the other person described in the scenario.  User: " + text);
            var advice = gemini.GenerateAdvice("Based on this conversation history, speak directly to the user and give some advice on how to approach what they say next. Keep in mind the goal of the conversation, but dont explicitaly state it. Guide them towards that goal without directly saying, and keep the advice simple and short. If need be, comment on something the user shouldnt have said or said differently. Keep below 275 characters. HISTORY: ");

            var harmfulWords = GetHarmfulWords(text);
            await Task.WhenAll(aiMessage, advice, harmfulWords);

            AppendUserMessage(text, harmfulWords.Result);
            if (userMessages > 2)
            {
                await CheckGoal();
            }
            AppendAIMessage(aiMessage.Result);
            uxAdvice.Text = "Advice: " + advice.Result;
            StopWaitAI();

        }
        public void WaitAI()
        {
            uxSpinner.Visible = true;
            uxSendButton.Enabled = false;
            uxSendButton.BackColor = Color.Gray;
            uxRecordButton.BackColor = Color.Gray;
            uxRecordButton.Enabled = false;
            uxUserText.Enabled = false;

        }
        public void StopWaitAI()
        {
            uxSpinner.Visible = false;
            uxSendButton.Enabled = true;
            uxSendButton.BackColor = Color.White;
            uxRecordButton.BackColor = Color.White;
            uxRecordButton.Enabled = true;
            uxUserText.Enabled = true;
        }

        private void uxBackClick(object sender, EventArgs e)
        {
            MainForm? main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.LoadPage(new MenuPage());
            }
        }
        private void uxNewClick(object sender, EventArgs e)
        {
            MainForm? main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.LoadPage(new ScenarioPage(scenarioType));
            }
        }
        private async void ScenarioPageLoad(object sender, EventArgs e)
        {
            await InternetChecker.EnsureInternetAsync();
        }
        private async Task CheckGoal()
        {
            WaitAI();
            bool goal = await gemini.CheckGoal(goalPrompt);
            if (goal)
            {
                MessageBox.Show("You have passed the scenario! Press ok to see your summary.");
                MainForm? main = this.FindForm() as MainForm;
                if (main != null)
                {
                    WaitAI();
                    main.LoadPage(new SummaryPage(scenarioType, await gemini.GenerateAdvice("Based on this conversation, give a paragraph of advice on how the user approached the sitation and what they could do better, and praise what they did good. Keep the language easy to understand.")));
                }
            }
            StopWaitAI();
        }

        private async void uxRecordClick(object sender, EventArgs e)
        {
            if(!audioRecorder.IsRecording)
            {
                uxSpinner.Visible = true;
                uxSendButton.Enabled = false;
                uxSendButton.BackColor = Color.Gray;
                uxUserText.Enabled = false;
                audioRecorder.StartRecording();

                byte[] imageBytes = Properties.Resources.End_Icon;

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    uxRecordButton.BackgroundImage = System.Drawing.Image.FromStream(ms);
                }
            }
            else
            {
                uxSpinner.Visible = false;
                uxSendButton.Enabled = true;
                uxSendButton.BackColor = Color.White;
                uxUserText.Enabled = true;
                byte[] imageBytes = Properties.Resources.Mic_Icon;

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    uxRecordButton.BackgroundImage = System.Drawing.Image.FromStream(ms);
                }
                await audioRecorder.StopRecordingAsync();
                uxUserText.Text = ElevenLabsService.Transcribe();
            }
        }
    }
}
