namespace src;

public class Music : IMedia
{
    private static long _lastId = 0;
    
    public long Id { get; }
    public string Lyrics { get; }
    public string Name { get; }
    public string Year { get; }
    public string Length { get; set; }
    public Gender Gender { get; }
    public Author Author { get; }
    public string? FilePath { get; }

    public Music(string lyrics, string name, long length, Gender gender, Author author, string year)
    {
        _lastId++;
        Id = _lastId;
        Lyrics = lyrics;
        Name = name;
        Length = TransformLengthToTheRightFormat(length);
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
        Length = TransformLengthToTheRightFormat(length);
        Gender = gender;
        Author = author;
        Year = year;
        FilePath = filePath;
    }

    private string TransformLengthToTheRightFormat(long seconds)
    {
        long minutes = seconds / 60;
        seconds %= 60;
        return $"{minutes}:{seconds}";
    }

    public override string ToString()
    {
        return $"ID: {Id} | Nome: {Name} | Ano: {Year} | Autor: {Author.Name} | Gênero: {Gender} | Duração: {Length}";
    }
}