using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbCource.Entity;

namespace DbCource.Contracts;
public interface IRepositoryProduct : IBaseRepository<Product>
{
    public void CreateProduct(Product entity);
    public Task<Product?> GetProductBySupplierAndName(string ProductName, string SupplierName);
}
