using src;

namespace CatalogoMusicas.crud.Repository;

public class Repository<T> where T : Music, IMedia
{
    protected List<T> Repo;

    public Repository()
    {
        this.Repo = new List<T>();
    }

    public void Save(T t)
    {
        this.Repo.Add(t);
    }

    public void DeleteById(long id)
    {
        this.Repo.Where(t => t.Id == id).ToList().ForEach(t => this.Repo.Remove(t));
    }

    public void Update(T type)  
    {
        var match = this.Repo.Find(t => t.Id == type.Id);
        if (match is not null)
        {
            this.Repo.Remove(match);
            this.Repo.Add(type);
        }
        else
        {
            Save(type);
        }
    }

    public T GetById(long id)
    {
        var query = from type in this.Repo
                                 where type.Id == id
                                 select type;
        if(query.Count() > 0)
                return query.First();
        
        return null; //fodase pode dar nullpointer
    }
    
    public List<T> GetAll()
    {
        return Repo;
    }

}