using Music.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Contracts;

public interface IRepositoryWrapper
{
    IRepositoryAlbum Album { get; }
    IRepositoryMusic Music { get; }
    IRepositorySinger Singer { get; }
    IRepositorySong Song { get; }
    IRepositorySongTable SongTable { get; }
    IRepositoryUser User { get; }
    Task<int> Save();
}
