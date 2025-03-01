using DbCource.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCource.Contracts;

public interface IRepositoryProductForWarehouse : IBaseRepository<ProductForWarehource>
{
    public Task<ProductForWarehource?> GetProductForWarehourceByName(string Name);
}
