namespace src;

public class Music
{
    public string Lyrics { get; }
    public string Name { get; }
    public long Length { get; }
    public Gender Gender { get; }
    public Author Author { get; }
    public string FilePath { get; }

    public Music(string lyrics, string name, long length, Gender gender, Author author, string filePath)
    {
        Lyrics = lyrics;
        Name = name;
        Length = length;
        Gender = gender;
        Author = author;
        FilePath = filePath;
    }



}