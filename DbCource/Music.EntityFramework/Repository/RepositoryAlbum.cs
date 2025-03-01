using Music.Contracts;
using Music.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.EntityFramework.Repository;

public class RepositoryAlbum : BaseRepository<Album>, IRepositoryAlbum
{
    public RepositoryAlbum(MusicContext repositoryContext) : base(repositoryContext)
    {

    }
}
