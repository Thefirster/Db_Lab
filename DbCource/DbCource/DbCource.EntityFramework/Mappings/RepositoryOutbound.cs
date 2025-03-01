using DbCource.Contracts;
using DbCource.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCource.EntityFramework.Repository;

public class RepositoryOutbound : BaseRepository<Outbound>, IRepositoryOutbound
{
    public RepositoryOutbound(DbCourceContext repositoryContext) : base(repositoryContext)
    {

    }
}
