using Music.Contracts;
using Music.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.EntityFramework.Repository;

public class RepositorySinger : BaseRepository<Singer>, IRepositorySinger
{
    public RepositorySinger(MusicContext repositoryContext) : base(repositoryContext)
    {

    }
}
