namespace src;

public class Music
{
    private static long _lastId = 0;
    
    public long Id { get; }
    public string Lyrics { get; }
    public string Name { get; }
    public long Length { get; }
    public Gender Gender { get; }
    public Author Author { get; }
    public string? FilePath { get; }

    public Music(string lyrics, string name, long length, Gender gender, Author author)
    {
        _lastId++;
        Id = _lastId;
        Lyrics = lyrics;
        Name = name;
        Length = length;
        Gender = gender;
        Author = author;
    }
    
    public Music(string lyrics, string name, long length, Gender gender, Author author, string filePath) 
    {
        _lastId++;
        Id = _lastId;
        Lyrics = lyrics;
        Name = name;
        Length = length;
        Gender = gender;
        Author = author;
        FilePath = filePath;
    }
}