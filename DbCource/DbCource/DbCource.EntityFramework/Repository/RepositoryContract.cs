using DbCource.Contracts;
using DbCource.Entity;
using DbCource.EntityFramework;

namespace DbCource.EntityFramework.Repository;
public class RepositoryContract : BaseRepository<Contract> ,IRepositoryContract
{
    public RepositoryContract(DbCourceContext repositoryContext) : base(repositoryContext)
    {

    }
}
