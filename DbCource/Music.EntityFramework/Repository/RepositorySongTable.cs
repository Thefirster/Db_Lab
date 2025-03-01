using Music.Contracts;
using Music.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.EntityFramework.Repository;

public class RepositorySongTable : BaseRepository<SongTable>, IRepositorySongTable
{
    public RepositorySongTable(MusicContext repositoryContext) : base(repositoryContext)
    {

    }
}
