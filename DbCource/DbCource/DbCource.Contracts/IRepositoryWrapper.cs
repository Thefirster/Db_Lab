using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCource.Contracts;

public interface IRepositoryWrapper
{
    IRepositoryContract Contract { get; }
    IRepositoryInbound Inbound { get; }
    IRepositoryProduct Product { get; }
    IRepositorySupplier Supplier { get; }
    IRepositoryUser User { get; }
    IRepositoryProductForWarehouse ProductForWarehouse { get; }
    IRepositoryOutbound Outbound { get; }
    Task<int> Save();
}
