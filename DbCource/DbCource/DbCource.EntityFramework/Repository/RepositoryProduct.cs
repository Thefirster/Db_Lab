using DbCource.Contracts;
using DbCource.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCource.EntityFramework.Repository;

public class RepositoryProduct : BaseRepository<Product>, IRepositoryProduct
{
    public RepositoryProduct(DbCourceContext repositoryContext) : base(repositoryContext)
    {

    }
    public void CreateProduct(Product entity)
    {
        Create(entity);
    }
    public async Task<Product?> GetProductBySupplierAndName(string ProductName, string SupplierName)
    {
        return await FindByCondition(p =>
                    p.ProductName == ProductName && 
                    p.Supplier.Name == SupplierName)
                    .FirstOrDefaultAsync();
    }


}
