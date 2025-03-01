using DbCource.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCource.EntityFramework.Repository;
public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly DbCourceContext _context;
    private IRepositoryContract _contract;
    private IRepositoryInbound _inbound;
    private IRepositoryProduct _product;
    private IRepositorySupplier _supplier;
    private IRepositoryUser _user;
    private IRepositoryProductForWarehouse _productForWarehouse;
    private IRepositoryOutbound _outbound;
    public IRepositoryProductForWarehouse ProductForWarehouse
    {
        get { return _productForWarehouse ??= new RepositoryProductForWarehouse(_context); }
    }
    public IRepositoryOutbound Outbound
    {
        get { return _outbound ??= new RepositoryOutbound(_context); }
    }
    public IRepositoryContract Contract
    {
        get { return _contract ??= new RepositoryContract(_context); }
    }
    public IRepositoryInbound Inbound
    {
        get { return _inbound ??= new RepositoryInbound(_context); }
    }
    public IRepositoryProduct Product
    {
        get { return _product ??= new RepositoryProduct(_context); }
    }
    public IRepositorySupplier Supplier
    {
        get { return _supplier ??= new RepositorySupplier(_context); }
    }
    public IRepositoryUser User
    {
        get { return _user ??= new RepositoryUser(_context); }
    }
    public RepositoryWrapper(DbCourceContext gameDbContext)
    {
        _context = gameDbContext;
    }
    public Task<int> Save()
    {
        return _context.SaveChangesAsync();
    }
}
