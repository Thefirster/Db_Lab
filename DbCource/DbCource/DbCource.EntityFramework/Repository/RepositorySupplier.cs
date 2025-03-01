using DbCource.Contracts;
using DbCource.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCource.EntityFramework.Repository;
public class RepositorySupplier : BaseRepository<Supplier>, IRepositorySupplier
{
    public RepositorySupplier(DbCourceContext repositoryContext) : base(repositoryContext)
    {

    }
    public async Task<Supplier?> GetSupplierByName(string Name)
    {
        return await FindByCondition(p =>
                p.Name == Name).FirstOrDefaultAsync();
    }

}
