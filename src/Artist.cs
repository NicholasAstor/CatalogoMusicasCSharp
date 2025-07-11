using System.Security.Cryptography.X509Certificates;

namespace src;

public class Author
{
    public string? Name { get; }
    public string? Nationality { get; }
    public bool IsBand { get; }
    public string? Description { get; }

    public Author(string name, string nationality, bool isBand, string description)
    {
        Name = name;
        Nationality = nationality;
        IsBand = isBand;
        Description = description;
    }

}