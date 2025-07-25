using CatalogoMusicas.crud.Repository;

namespace src.crud.Repositories;

public class MusicRepo  : Repository<Music>
{
    public List<Music> GetByAuthor(string authorName)
    {
        var query = from music in Repo
                                    where music.Author.Name.ToLower() == authorName
                                    select music;
        return query.ToList();
    }
    public Music GetByName(string musicName)
    {
        var query = from music in Repo
            where music.Name.ToLower() == musicName
            select music;
        return query.ToList().FirstOrDefault(); //can be null
    }
    
    
}