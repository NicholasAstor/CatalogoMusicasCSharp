namespace src;

public interface IMedia
{
    public string Year { get; }

    public string Name { get; }

    public Author Author { get; } 

    public long Length { get; set; } 
}