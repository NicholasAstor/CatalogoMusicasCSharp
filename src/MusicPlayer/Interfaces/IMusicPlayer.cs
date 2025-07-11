namespace src.MusicPlayer.Interfaces;

public interface IMusicPlayer
{
    void Play(Music music);
    void Pause();
    void Stop();
}