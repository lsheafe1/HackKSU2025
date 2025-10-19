using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using NAudio.Wave;

public class AudioRecorder
{
    private WaveInEvent waveIn;
    private WaveFileWriter writer;
    private bool isRecording = false;
    private string outputFilePath;
    private TaskCompletionSource<bool> recordingStoppedTcs;

    public string OutputFilePath => outputFilePath;
    public bool IsRecording => isRecording;

    /// <summary>
    /// Starts recording from the default microphone.
    /// </summary>
    public void StartRecording()
    {
        if (isRecording) return;

        outputFilePath = Path.Combine(Path.GetTempPath(), "audio.wav");
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
            recordingStoppedTcs?.TrySetResult(true);
            Debug.WriteLine($"Recording saved to {outputFilePath}");
        };

        waveIn.StartRecording();
        isRecording = true;
        Debug.WriteLine("Recording started...");
    }

    /// <summary>
    /// Stops the recording and waits until the file is safely written.
    /// </summary>
    public async Task StopRecordingAsync()
    {
        if (!isRecording) return;

        recordingStoppedTcs = new TaskCompletionSource<bool>();
        waveIn.StopRecording(); // triggers RecordingStopped
        await recordingStoppedTcs.Task; // wait until file finalized

        isRecording = false;
        Debug.WriteLine("Recording stopped and file finalized.");
    }
}
