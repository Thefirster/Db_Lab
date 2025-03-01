using DbCource.Contracts;
using DbCource.Entity;
using DbCource.EntityFramework;

namespace DbCource.EntityFramework.Repository;

public class RepositoryUser : BaseRepository<User>, IRepositoryUser
{
    public RepositoryUser(DbCourceContext repositoryContext) : base(repositoryContext)
    {

    }
}