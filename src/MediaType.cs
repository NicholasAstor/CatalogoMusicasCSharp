namespace src;

public abstract class MediaType : IMedia
{
    public string Year { get; }

    public string Name { get; }

    //duration
    public Author Author { get; } // a person or band

    public long Length { get; set; } //  Length of an album in seconds

    public MediaType(string year, string name, Author author, long length)
    {
        Year = year;
        Name = name;
        Author = author;
        Length = length;
    }

    public abstract string ToString();
}

