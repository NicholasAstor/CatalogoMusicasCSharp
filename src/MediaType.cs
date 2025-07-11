namespace src;

public abstract class MediaType
{
    public string Year { get; }

    public string Name { get; }

    //duration
    public Author Author { get; } // a person or band

    public long Length { get; set; } //  Length of an album in seconds

    public MediaType(string year, string name, Author author)
    {
        Year = year;
        Name = name;
        Author = author;
    }

    public abstract string ToString();
}

