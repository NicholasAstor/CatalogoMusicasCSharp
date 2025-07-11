namespace src;

public class Album : MediaType
{
    public List<Music> Musics { get; } 
    
    public Album(string year, string name, long length, Author author) : base(year, name, author, length)
    {
        Musics = new List<Music>();
    }

    public Album(string year, string name, long length, Author author, List<Music> musics) : base(year, name, author, length)
    {
        Musics = musics;
    }
    
    public void AddMusic(Music music)
    {
        Musics.Add(music);
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}