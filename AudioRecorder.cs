using System;
using System.Diagnostics;
using System.IO;
using NAudio.Wave;

public class AudioRecorder
{
    private WaveInEvent waveIn;
    private WaveFileWriter writer;
    private bool isRecording = false;
    private string outputFilePath;

    public string OutputFilePath => outputFilePath;
    public bool IsRecording => isRecording;

    public void StartRecording()
    {
        if (isRecording) return;

        outputFilePath = Path.Combine(Path.GetTempPath(), "audio.mp3");
        waveIn = new WaveInEvent();
        writer = new WaveFileWriter(outputFilePath, waveIn.WaveFormat);

        waveIn.DataAvailable += (s, a) =>
        {
            writer.Write(a.Buffer, 0, a.BytesRecorded);
        };
            
        waveIn.RecordingStopped += (s, a) =>
        {
            writer?.Dispose();
            waveIn?.Dispose();
            Debug.WriteLine($"Recording saved to {outputFilePath}");
        };

        waveIn.StartRecording();
        isRecording = true;
        Debug.WriteLine("Recording started...");
    }

    public void StopRecording()
    {
        if (!isRecording) return;

        waveIn.StopRecording();
        isRecording = false;
        Debug.WriteLine("Recording stopped.");
    }
}
