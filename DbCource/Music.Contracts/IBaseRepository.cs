using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Contracts;
public interface IBaseRepository<T>
{
    IQueryable<T> FindAll();
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);

}
