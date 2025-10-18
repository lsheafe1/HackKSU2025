using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
        ScenarioManager scenarioManager;


        public ScenarioPage(ScenarioType scenarioType)
        {
            InitializeComponent();
            InitializeToolTip();
            InitializeScenario(scenarioType);
        }
        public static void RetrieveStartingPrompt()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "InitialPrompt.txt");
            string wordFilterPromptPath = Path.Combine(AppContext.BaseDirectory, "Data", "WordFlagPrompt.txt");
            startingPrompt = File.ReadAllText(filePath);
            wordFilterPrompt = File.ReadAllText(wordFilterPromptPath);
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
            Debug.WriteLine("Scenario: "+scenario.ScenarioText);
            Debug.WriteLine("Goal: " + scenario.Goal);

            gemini = new GeminiService(this);
            string text = await gemini.InitializeConversation(startingPrompt + "Scenario: " + scenario.ScenarioText + "Goal: " + scenario.Goal);
            AppendStartingMessage(text);

        }
        public void AppendAIMessage(string text)
        {
            uxMessageBox.SelectionAlignment = HorizontalAlignment.Right;
            uxMessageBox.AppendText("AI: ");
            uxMessageBox.AppendText(text);
        }
        public void AppendStartingMessage(string text)
        {
            uxMessageBox.SelectionAlignment = HorizontalAlignment.Left;
            uxMessageBox.AppendText("");
            uxMessageBox.AppendText(text + "\n");
        }


        private List<(int start, int length, string reason)> harmfulWordHighlights = new();

        public void AppendUserMessage(string text, Dictionary<string, string> harmfulWordsWithReason)
        {
            uxMessageBox.SelectionAlignment = HorizontalAlignment.Right;
            uxMessageBox.AppendText("User: ");
            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                int start = uxMessageBox.TextLength; // store starting index

                // Remove punctuation for matching
                string cleanWord = word.Trim(new char[] { '.', ',', '!', '?', ';', ':', '"', '\'' });

                if (harmfulWordsWithReason.ContainsKey(cleanWord))
                {
                    uxMessageBox.SelectionColor = Color.Red;   // harmful word
                                                               // Save position, length, and reason
                    harmfulWordHighlights.Add((start, word.Length, harmfulWordsWithReason[cleanWord]));
                }
                else
                {
                    uxMessageBox.SelectionColor = Color.Black; // normal word
                }

                uxMessageBox.AppendText(word + " ");
            }

            uxMessageBox.AppendText("\r\n"); // Newline at end of message
            uxMessageBox.SelectionStart = uxMessageBox.TextLength;
            uxMessageBox.ScrollToCaret();
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

        private async void uxSendClick(object sender, EventArgs e)
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
            AppendUserMessage(uxUserText.Text, await GetHarmfulWords(uxUserText.Text));
        }
        public void WaitAI()
        {
            uxSpinner.Visible = true;
        }
        public void StopWaitAI()
        {
            uxSpinner.Visible = false;
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
                main.LoadPage(new ScenarioPage(ScenarioType.Parent));
            }
        }
        private async void ScenarioPageLoad(object sender, EventArgs e)
        {
            await InternetChecker.EnsureInternetAsync();
        }
    }
}
