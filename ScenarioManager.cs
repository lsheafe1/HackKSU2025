using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using HackKSU2025;

public class Scenario
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("scenario")]
    public string ScenarioText { get; set; }

    [JsonPropertyName("goal")]
    public string Goal { get; set; }
}

public class ScenarioManager
{
    private List<Scenario> scenarios = new List<Scenario>();
    private Random random = new Random();

    public Dictionary<int, string> ScenarioDictionary { get; private set; } = new Dictionary<int, string>();


    public void LoadScenarios(ScenarioType type)
    {
        string jsonPath;
        if (type == ScenarioType.Parent)
        {
            jsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "ParentScenarios.json");
        }
        else
        {
            jsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "InitialPrompt.txt");

        }
        if (!File.Exists(jsonPath))
            throw new FileNotFoundException($"Scenario file not found: {jsonPath}");

        string jsonContent = File.ReadAllText(jsonPath);
        scenarios = JsonSerializer.Deserialize<List<Scenario>>(jsonContent)
                    ?? new List<Scenario>();

        ScenarioDictionary = scenarios.ToDictionary(s => s.Id, s => s.Goal);
    }

    public Scenario GetRandomScenario()
    {
        if (scenarios.Count == 0)
            throw new InvalidOperationException("No scenarios loaded.");

        int index = random.Next(scenarios.Count);
        return scenarios[index];
    }

}
