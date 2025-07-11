namespace src;

public class Single : MediaType
{
    public Music Music { get; }
    
    public Single(string year, string name, long length, Author author) : base(year, name, author, length)
    {
        Music = new Music("default", "default", 100, Gender.Rap, new Author("default", "Brasil", false, "default"), "");
    }
    
    public Single(string year, string name, long length, Author author, Music music) : base(year, name, author, length)
    {
        Music = music;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}