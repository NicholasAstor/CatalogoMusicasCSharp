using src;
using src.crud.Repositories;

namespace TestProject;

public class Tests
{
    private MusicRepo _musicRepo;
    private Author _author;
    private Music _music;
    
    [SetUp]
    public void Setup()
    {
        _musicRepo = new MusicRepo();
        _author = new Author("default", "default", false, "default");
        _music = new Music("", "default", 250, Gender.Pop, _author, "1990");
    }

    [Test]
    public void SaveMusicTest()
    {
        _musicRepo.Save(_music);
        List<Music> list = _musicRepo.GetAll();
        Assert.That(list, (Has.Exactly(1).EqualTo(_music)));
    }

    [Test]
    public void DeleteMusicTest()
    {
        _musicRepo.Save(_music);
        _musicRepo.DeleteById(1);
        List<Music> list = _musicRepo.GetAll();
        Assert.That(list, (Has.Exactly(0).EqualTo(_music)));
    }

    [Test]
    public void GetMusicByIdTest()
    {
        _musicRepo.Save(_music);
        Music musicFound = _musicRepo.GetById(1);
        Assert.That(musicFound == _music);
    }
    
    [Test]
    public void GetByAuthorTest()
    {
        _musicRepo.Save(_music);
        var listMusicsFound = _musicRepo.GetByAuthor("default");
        Assert.That(listMusicsFound, (Has.Exactly(1).EqualTo(_music)));
    }

    [Test]
    public void GetMusicByName()
    {
        _musicRepo.Save(_music);
        Music musicFound = _musicRepo.GetByName("default");
        Assert.That(musicFound == _music);
    }
}