using System.Linq.Expressions;
using DbCource.Contracts;
using DbCource.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DbCource.EntityFramework.Repository;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected DbCourceContext courceContext { get; set; }

    protected BaseRepository(DbCourceContext repositoryContext)
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
