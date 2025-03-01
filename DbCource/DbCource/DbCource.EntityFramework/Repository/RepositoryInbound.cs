using DbCource.Contracts;
using DbCource.Entity;
using DbCource.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCource.EntityFramework.Repository;

public class RepositoryInbound : BaseRepository<Inbound>, IRepositoryInbound
{
    public RepositoryInbound(DbCourceContext repositoryContext) : base(repositoryContext)
    {

    }
}
