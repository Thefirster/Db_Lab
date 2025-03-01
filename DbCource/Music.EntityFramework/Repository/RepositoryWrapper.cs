using Music.Contracts;
using Music.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.EntityFramework.Repository;
public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly MusicContext _context;

    private IRepositoryAlbum _album;
    private IRepositoryMusic _music;
    private IRepositorySinger _singer;
    private IRepositorySong _song;
    private IRepositoryUser _user;
    private IRepositorySongTable _songTable;

    public IRepositoryAlbum Album
    {
        get { return _album ??= new RepositoryAlbum(_context); }
    }
    public IRepositoryMusic Music
    {
        get { return _music ??= new RepositoryMusic(_context); }
    }
    public IRepositorySinger Singer
    {
        get { return _singer ??= new RepositorySinger(_context); }
    }
    public IRepositorySong Song
    {
        get { return _song ??= new RepositorySong(_context); }
    }
    public IRepositorySongTable SongTable
    {
        get { return _songTable ??= new RepositorySongTable(_context); }
    }
    public IRepositoryUser User
    {
        get { return _user ??= new RepositoryUser(_context); }
    }
    public RepositoryWrapper(MusicContext gameDbContext)
    {
        _context = gameDbContext;
    }
    public Task<int> Save()
    {
        return _context.SaveChangesAsync();
    }
}
