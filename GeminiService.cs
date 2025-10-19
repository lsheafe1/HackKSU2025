using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GenerativeAI.Types;
using System.Windows.Forms;
using Newtonsoft.Json;
using GenerativeAI;
using System.Text.RegularExpressions;
using HackKSU2025;
using System.Diagnostics;

public class GeminiService
{
    GoogleAi googleAI;
    GenerativeModel model;
    GenerativeModel wordsModel;
    ChatSession chatSession;
    ScenarioPage scenarioPage;


    public GeminiService(ScenarioPage page)
    {
        scenarioPage = page;
        var _apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY")
                  ?? throw new Exception("Set GEMINI_API_KEY environment variable");
        googleAI = new GoogleAi(_apiKey);

        model = googleAI.CreateGenerativeModel("models/gemini-2.5-flash", new GenerationConfig
        {
            Temperature = 1.4f
        });
        wordsModel = googleAI.CreateGenerativeModel("models/gemini-2.5-flash", new GenerationConfig
        {
            Temperature = .7f
        });
        chatSession = model.StartChat();


    }
    public async Task<string> GenerateChatMessage(string prompt)
    {
        try
        {
            var response = await chatSession.GenerateContentAsync(prompt);

            return response.Text;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null!;
        }
    }
    public async Task<bool> CheckGoal(string prompt)
    {
        try
        {
            var response = await chatSession.GenerateContentAsync(prompt);
            Debug.WriteLine("Goal: " + response.Text);
            return bool.Parse(response.Text);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
    public async Task<string> GenerateMessage(string prompt)
    {
        try
        {
            var response = await wordsModel.GenerateContentAsync(prompt);

            return response.Text;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null!;
        }
    }
    public async Task<string> GenerateAdviceMessage(string prompt)
    {
        try
        {
            var response = await model.GenerateContentAsync(prompt);

            return response.Text;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null!;
        }
    }

    public async Task<string> GenerateAdvice(string prompt)
    {
        

        Debug.WriteLine("HISTORY: " +GetHistory());
        return await GenerateAdviceMessage(prompt + GetHistory());
    }

    public async Task<string> InitializeConversation(string prompt)
    {
        Debug.WriteLine(prompt);
        try
        {
            var response = await chatSession.GenerateContentAsync(prompt);

            return response.Text;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null!;
        }
    }
    public async Task<Dictionary<string, string>> GetHarmfulWords(string prompt, string userText)
    {
        System.Diagnostics.Debug.WriteLine("Getting harmful words");

        string output = await GenerateMessage(prompt + GetHistory() + "THIS NEXT IS THE USER INPUT, ONLY RETURN HARMFUL WORDS FROM HERE:\n" + userText);
        if (string.IsNullOrWhiteSpace(output))
            return new Dictionary<string, string>();
        string json = ExtractJson(output);

        try
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return dict ?? new Dictionary<string, string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine("JSON parsing error: " + ex.Message);
            return new Dictionary<string, string>();
        }
    }
    private static string ExtractJson(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return "{}";

        Match match = Regex.Match(text, "{.*}", RegexOptions.Singleline);
        return match.Success ? match.Value : "{}";
    }
    private string GetHistory()
    {
        var historyBuilder = new StringBuilder();

        foreach (var message in chatSession.History)
        {
            historyBuilder.AppendLine($"[{message.Role}]");
            foreach (var part in message.Parts)
            {
                if (part.Text is not null)
                {
                    historyBuilder.AppendLine(part.Text);
                }
            }
            historyBuilder.AppendLine();
        }

       return historyBuilder.ToString();
    }

}
