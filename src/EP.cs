namespace src;

public class EP : MediaType
{
    public List<Music> Musics { get; }
    
    public EP(string year, string name, long length, Author author) : base(year, name, author, length)
    {
        Musics = new List<Music>();
    }
    
    public EP(string year, string name, long length, Author author, List<Music> music) : base(year, name, author, length)
    {
        Musics = music;
    }

    public void addMusic(Music music)
    {
        Musics.Add(music);
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}