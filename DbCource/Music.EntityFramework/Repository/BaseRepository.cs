using System.Linq.Expressions;
using Music.Entity;
using Music.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Music.EntityFramework.Repository;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected MusicContext courceContext { get; set; }

    protected BaseRepository(MusicContext repositoryContext)
    {
        courceContext = repositoryContext;
    }
    public IQueryable<T> FindAll()
    {
        return courceContext.Set<T>().AsNoTracking();
    }
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return courceContext.Set<T>().Where(expression).AsNoTracking();
    }
    public void Create(T entity)
    {
        courceContext.Set<T>().Add(entity);
    }
    public void Update(T entity)
    {
        courceContext.Set<T>().Update(entity);
    }
    public void Delete(T entity)
    {
        courceContext.Set<T>().Remove(entity);
    }
}
