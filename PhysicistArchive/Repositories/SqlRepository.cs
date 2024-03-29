
using Microsoft.EntityFrameworkCore;
using PhysicistArchive.Entities;


namespace PhysicistArchive.Repositories;


public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;

    public SqlRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemDelete;
    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }
    public void Add(T item)
    {
        _dbSet.Add(item);
        ItemAdded?.Invoke(this, item);
    }
    public void Remove(T item)
    {
        _dbSet.Remove(item);
        ItemDelete?.Invoke(this, item);
    }
    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }
}
