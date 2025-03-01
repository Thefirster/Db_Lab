using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbCource.Entity;

namespace DbCource.Contracts;

public interface IRepositorySupplier : IBaseRepository<Supplier>
{
    public Task<Supplier?> GetSupplierByName(string Name);
}
