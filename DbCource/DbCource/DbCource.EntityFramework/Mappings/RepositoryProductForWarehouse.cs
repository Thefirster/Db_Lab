using DbCource.Contracts;
using DbCource.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCource.EntityFramework.Repository;

public class RepositoryProductForWarehouse : BaseRepository<ProductForWarehource> , IRepositoryProductForWarehouse
{
    public RepositoryProductForWarehouse(DbCourceContext repositoryContext) : base(repositoryContext)
    {

    }

    public async Task<ProductForWarehource?> GetProductForWarehourceByName(string Name)
    {
        return await FindByCondition(p => 
                p.ProductName == Name)
            .FirstOrDefaultAsync();
    }

}
