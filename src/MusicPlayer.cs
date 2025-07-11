using NAudio.Wave;

namespace src;

public class MusicPlayer
{ 
    public string FilePath { get; private set; }
    private WaveOutEvent outputDevice;
    private AudioFileReader audioFile;

    public MusicPlayer(string filePath)
    {
        FilePath = filePath;
    }

    public MusicPlayer()
    {
        
    }

    public void Play()
    {
        audioFile = new AudioFileReader(FilePath);
        outputDevice = new WaveOutEvent();
        outputDevice.Init(audioFile);
        outputDevice.Play();
    }
}