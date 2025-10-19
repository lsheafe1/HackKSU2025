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
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;
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
            string text = await gemini.InitializeConversation(startingPrompt + "Scenario: " + scenario.ScenarioText + "Goal: " + scenario.Goal);
            AppendStartingMessage(text);

        }
        public void AppendAIMessage(string text)
        {
            uxMessageBox.AppendText("\n");

            uxMessageBox.SelectionAlignment = HorizontalAlignment.Left;
            //uxMessageBox.AppendText("AI: ");
            uxMessageBox.AppendText(text);
            uxMessageBox.SelectionStart = uxMessageBox.TextLength;
            uxMessageBox.ScrollToCaret();
            CheckGoal();
        }
        public void AppendStartingMessage(string text)
        {

            uxMessageBox.SelectionAlignment = HorizontalAlignment.Left;
            uxMessageBox.AppendText("");
            uxMessageBox.AppendText(text);
        }


        private List<(int start, int length, string reason)> harmfulWordHighlights = new();

        public void AppendUserMessage(string text, Dictionary<string, string> harmfulWordsWithReason)
        {
            uxMessageBox.AppendText("\n");
            uxMessageBox.SelectionAlignment = HorizontalAlignment.Right;
            uxMessageBox.AppendText("User: ");

            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int lineLength = uxMessageBox.TextLength; 
            int maxLineLength = 25; 

            foreach (string word in words)
            {
                int start = uxMessageBox.TextLength;

                // Remove any leading/trailing punctuation and lowercase
                string cleanWord = Regex.Replace(word, @"^\W+|\W+$", "").ToLowerInvariant();

                // Set color for harmful words
                if (harmfulWordsWithReason.ContainsKey(cleanWord))
                {
                    uxMessageBox.SelectionColor = Color.Red;
                    harmfulWordHighlights.Add((start, word.Length, harmfulWordsWithReason[cleanWord]));
                }
                else
                {
                    uxMessageBox.SelectionColor = Color.Black;
                }

                // Check if adding this word exceeds max line length
                if ((lineLength + word.Length + 1) > maxLineLength) // +1 for space
                {
                    uxMessageBox.AppendText("\n");
                    lineLength = 0;
                }

                uxMessageBox.AppendText(word + " ");
                lineLength += word.Length + 1;
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
            string text = uxUserText.Text.Trim();
            uxUserText.Text = "";
            string str = await gemini.GenerateChatMessage("Below is the users response. Please roleplay as the other person described in the scenario. Remember, you are roleplaying as the" +
                "person who needs help from the user. User: "+ text);
            AppendUserMessage(text, await GetHarmfulWords(text));
            AppendAIMessage(str);
        }
        public void WaitAI()
        {
            uxSpinner.Visible = true;
            uxSendButton.Enabled = false;
            uxSendButton.BackColor = Color.Gray;
            uxRecordButton.BackColor = Color.Gray;

        }
        public void StopWaitAI()
        {
            uxSpinner.Visible = false;
            uxSendButton.Enabled = true;
            uxSendButton.BackColor = Color.AntiqueWhite;
            uxRecordButton.BackColor = Color.AntiqueWhite;

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
        private async void CheckGoal()
        {
            bool goal = await gemini.CheckGoal(goalPrompt);
            if (goal)
            {
                MessageBox.Show("Goal achieved!");
            }
        }

        private async void uxRecordClick(object sender, EventArgs e)
        {
            if(!audioRecorder.IsRecording)
            {
                audioRecorder.StartRecording();

                byte[] imageBytes = Properties.Resources.End_Icon;

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    uxRecordButton.Image = System.Drawing.Image.FromStream(ms);
                }
            }
            else
            {
                await audioRecorder.StopRecordingAsync();
                uxUserText.Text = ElevenLabsService.Transcribe();
            }
        }
    }
}
