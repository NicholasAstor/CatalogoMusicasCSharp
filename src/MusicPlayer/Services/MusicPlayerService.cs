using src.MusicPlayer.Interfaces;

namespace src.MusicPlayer.Services;
using NAudio.Wave;

public class MusicPlayerService: IMusicPlayer
{ 
    public Music Music{ get; private set; }
    private WaveOutEvent outputDevice;
    private AudioFileReader audioFile;

    public MusicPlayerService(Music music)
    {
        Music = music;
    }

    public void Play()
    { 
        Stop();
        audioFile = new AudioFileReader(Music.FilePath);
        //audioFile.CurrentTime = music.PreviewStart;
        
        outputDevice = new WaveOutEvent();
        outputDevice.Init(audioFile);
        outputDevice.Play();
    }

    public void Pause()
    {
        outputDevice?.Pause();
    }

    public void Resume()
    {
        outputDevice?.Play();
    }

    public void Stop()
    {
        outputDevice?.Stop();
    }
}
