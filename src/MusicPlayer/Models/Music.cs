namespace src;

public class Music : IMedia
{
    private static long _lastId = 0;
    
    public long Id { get; }
    public string Lyrics { get; }
    public string Name { get; }
    public string Year { get; }
    public long Length { get; set; }
    public Gender Gender { get; }
    public Author Author { get; }
    public string? FilePath { get; }

    public Music(string lyrics, string name, long length, Gender gender, Author author, string year)
    {
        _lastId++;
        Id = _lastId;
        Lyrics = lyrics;
        Name = name;
        Length = length;
        Gender = gender;
        Author = author;
        Year = year;
    }
    
    public Music(string lyrics, string name, long length, Gender gender, Author author, string filePath, string year) 
    {
        _lastId++;
        Id = _lastId;
        Lyrics = lyrics;
        Name = name;
        Length = length;
        Gender = gender;
        Author = author;
        Year = year;
        FilePath = filePath;
    }
}