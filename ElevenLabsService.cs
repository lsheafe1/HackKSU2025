using System;
using System.Diagnostics;

class ElevenLabsService
{
    public static string Transcribe()
    {

        string pythonPath = GetPythonPath();
        //string pythonPath = @"C:\Users\Blake Ebner\AppData\Local\Programs\Python\Python312\python.exe";

        string scriptPath = Path.Combine(AppContext.BaseDirectory,"Data", "Text_To_Speech.py");

        //string scriptPath = @"C:\Users\Blake Ebner\OneDrive\Documents\K-State hackathon\HackKSU2025\Text_To_Speech.py";

        string arguments = "";

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
            return output;

        }
        string GetPythonPath()
        {
            var psi = new ProcessStartInfo("py", "-c \"import sys;print(sys.executable)\"")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using var p = Process.Start(psi);
            string result = p.StandardOutput.ReadToEnd().Trim();
            p.WaitForExit();
            return result;
        }
    }

}
