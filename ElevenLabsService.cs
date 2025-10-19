using System;
using System.Diagnostics;

class ElevenLabsService
{
    public static void Transcribe()
    {
        // Path to Python executable
        string pythonPath = @"C:\Users\Blake Ebner\AppData\Local\Programs\Python\Python312\python.exe";

        // Path to your Python script
        string scriptPath = @"C:\Users\Blake Ebner\OneDrive\Documents\K-State hackathon\HackKSU2025\Text_To_Speech.py";

        // Optional arguments to pass to the Python script
        string arguments = "";

        // Configure process
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = pythonPath;
        start.Arguments = $"\"{scriptPath}\" {arguments}";
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.RedirectStandardError = true;
        start.CreateNoWindow = true;

        // Start process
        using (Process process = Process.Start(start))
        {
            // Read output
            string output = process.StandardOutput.ReadToEnd();
            string errors = process.StandardError.ReadToEnd();

            process.WaitForExit();

            Debug.WriteLine("Python output:");
            Debug.WriteLine(output);

            if (!string.IsNullOrEmpty(errors))
            {
                Debug.WriteLine("Python errors:");
                Debug.WriteLine(errors);
            }
        }
    }
}
