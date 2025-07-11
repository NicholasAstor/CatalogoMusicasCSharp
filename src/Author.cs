using System.Security.Cryptography.X509Certificates;

namespace src;

public class Author
{
    private static long _lastId = 0;
    public long Id { get; }
    public string Name { get; }
    public string Nationality { get; }
    public bool IsBand { get; }
    public string Description { get; }

    public Author(string name, string nationality, bool isBand, string description)
    {
        _lastId++;
        Id = _lastId;
        Name = name;
        Nationality = nationality;
        IsBand = isBand;
        Description = description;
    }

}