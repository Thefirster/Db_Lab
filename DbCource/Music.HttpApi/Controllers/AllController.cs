using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.CodeAnalysis;
using SQLitePCL;
using Music.EntityFramework;
using Music.HttpApi.Extensions;
using Music.Contracts;
using Music.Entity;
using BootstrapBlazor.Components;
using static System.Net.WebRequestMethods;
using System.Diagnostics.Contracts;
using Music.UI.Dtos;

namespace Music.HttpApi.Controllers;

[Route("api")]
[ApiController]
public class AllController : ControllerBase
{
    private readonly IRepositoryWrapper _repository;
    private readonly ILogger<AllController> _logger;
    public AllController(IRepositoryWrapper repository,
                            ILogger<AllController> logger
                            )
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpPost("/getAllSinger")]
    public async Task<List<Singer>> GetAllSinger()
    {
        return await _repository.Singer.FindAll().ToListAsync();
    }
    [HttpPost("/updateSinger")]
    public async Task<IActionResult> UpdateSinger([FromBody]Singer singer)
    {
        try
        {
            _repository.Singer.Update(singer);
            await _repository.Save();
            return Ok("更改成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/createSinger")]
    public async Task<IActionResult> CreateSinger([FromBody]Singer singer)
    {
        try
        {
            _repository.Singer.Create(singer);
            await _repository.Save();
            return Ok("创建成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/deleteSinger")]
    public async Task<IActionResult> DeleteSinger([FromBody]Singer singer)
    {
        try
        {
            _repository.Singer.Delete(singer);
            await _repository.Save();
            return Ok("删除成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/getAllAlbumBySinger")]
    public async Task<List<Album>> GetAllAlbumBySinger([FromBody]Singer singer)
    {
        return await _repository.Album.FindAll().Where(p => p.SingerID == singer.SingerID).ToListAsync();
    }
    [HttpPost("/updateAlbum")]
    public async Task<IActionResult> UpdateAlbum([FromBody]Album album)
    {
        try
        {
            _repository.Album.Update(album);
            await _repository.Save();
            return Ok("更改成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/createAlbum")]
    public async Task<IActionResult> CreateAlbum([FromBody] Album album)
    {
        try
        {
            album.singer = null;
            _repository.Album.Create(album);
            await _repository.Save();
            return Ok("创建成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/deleteAlbum")]
    public async Task<IActionResult> DeleteAlbum([FromBody] Album album)
    {
        try
        {
            _repository.Album.Delete(album);
            await _repository.Save();
            return Ok("删除成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/getAllMusicByAlbum")]
    public async Task<List<Musicc>> GetAllMusicByAlbum([FromBody] Album album)
    {
        return await _repository.Music.FindAll().Where(p => p.AlbumID == album.AlbumID).ToListAsync();
    }
    [HttpPost("/updateMusic")]
    public async Task<IActionResult> UpdateMusic([FromBody] Musicc musicc)
    {
        try
        {
            _repository.Music.Update(musicc);
            await _repository.Save();
            return Ok("更改成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/createMusic")]
    public async Task<IActionResult> CreateMusic([FromBody] Musicc musicc)
    {
        try
        {
            musicc.album = null;
            _repository.Music.Create(musicc);
            await _repository.Save();
            return Ok("创建成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/deleteMusic")]
    public async Task<IActionResult> DeleteMusic([FromBody] Musicc musicc)
    {
        try
        {
            _repository.Music.Delete(musicc);
            await _repository.Save();
            return Ok("删除成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/getAllUser")]
    public async Task<List<User>> GetAllUser()
    {
        return await _repository.User.FindAll().ToListAsync();
    }
    [HttpPost("/updateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        try
        {
            _repository.User.Update(user);
            await _repository.Save();
            return Ok("更改成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/createUser")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        try
        {
            _repository.User.Create(user);
            await _repository.Save();
            return Ok("创建成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/deleteUser")]
    public async Task<IActionResult> DeleteUser([FromBody] User user)
    {
        try
        {
            _repository.User.Delete(user);
            await _repository.Save();
            return Ok("删除成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/getAllSongTableByUser")]
    public async Task<List<SongTable>> GetAllSongTableByUser([FromBody] User user)
    {
        return await _repository.SongTable.FindAll().Where(p => p.UserID == user.UserID).ToListAsync();
    }
    [HttpPost("/updateSongTable")]
    public async Task<IActionResult> UpdateSongTable([FromBody] SongTable songTable)
    {
        try
        {
            _repository.SongTable.Update(songTable);
            await _repository.Save();
            return Ok("更改成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/createSongTable")]
    public async Task<IActionResult> CreateSongTable([FromBody] SongTable songTable)
    {
        try
        {
            _repository.SongTable.Create(songTable);
            await _repository.Save();
            return Ok("创建成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/deleteSongTable")]
    public async Task<IActionResult> DeleteSongTable([FromBody] SongTable songTable)
    {
        try
        {
            _repository.SongTable.Delete(songTable);
            await _repository.Save();
            return Ok("删除成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/getAllSongBySongTable")]
    public async Task<List<Song>> GetAllSongBySongTable([FromBody] SongTable songTable)
    {
        return await _repository.Song.FindAll().Where(p => p.SongTableID == songTable.SongTableID).ToListAsync();
    }
    [HttpPost("/updateSong")]
    public async Task<IActionResult> UpdateSong([FromBody] Song song)
    {
        try
        {
            var musicc = await _repository.Music.FindAll().Where(p => p.MusicID == song.MusicID).FirstOrDefaultAsync();

            song.Name = musicc.Name;
            song.Style = musicc.Style;
            song.Lyricist = musicc.Lyricist;
            song.Composer = musicc.Composer;

            _repository.Song.Update(song);
            await _repository.Save();
            return Ok("更改成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/createSong")]
    public async Task<IActionResult> CreateSong([FromBody] Song song)
    {
        try
        {
            var musicc = await _repository.Music.FindAll().Where(p => p.MusicID == song.MusicID).FirstOrDefaultAsync();

            song.Name = musicc.Name;
            song.Style = musicc.Style;
            song.Lyricist = musicc.Lyricist;
            song.Composer = musicc.Composer;

            _repository.Song.Create(song);
            await _repository.Save();
            return Ok("创建成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/deleteSong")]
    public async Task<IActionResult> DeleteSong([FromBody] Song song)    
    {
        try
        {
            _repository.Song.Delete(song);
            await _repository.Save();
            return Ok("删除成功");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/getUser")]
    public async Task<User> GetUser([FromBody] User user)
    {
        var retUser = await _repository.User.FindAll().Where(p => p.Name == user.Name && p.Password == user.Password).FirstOrDefaultAsync();
        return retUser;
    }
    [HttpPost("/addLikeSong")]
    public async Task<IActionResult> AddLikeSongs([FromBody] AddLikeSong addLikeSong)
    {
        var songTable = await _repository.SongTable.FindAll().Where(p => p.Name == addLikeSong.SongTableName).FirstOrDefaultAsync();
        var musicc = await _repository.Music.FindAll().Where(p => p.MusicID == addLikeSong.MusicID).FirstOrDefaultAsync();

        if (songTable == null)
        {
            SongTable createSongTable = new SongTable()
            {
                SongTableID = new Guid(),
                UserID = addLikeSong.UserID,
                Name = addLikeSong.SongTableName,
            };
            Song createSong = new Song()
            {
                Uri = musicc.Uri,
                MusicID = addLikeSong.MusicID,
                SongTableID = createSongTable.SongTableID,
                Composer = musicc.Composer,
                Lyricist = musicc.Lyricist,
                Name = musicc.Name,
                Style = musicc.Style,
            };

            createSongTable.user = null;
            createSong.songTable = null;

            _repository.SongTable.Create(createSongTable);
            await _repository.Save();
            _repository.Song.Create(createSong);
            await _repository.Save();
            return Ok(200);
        }
        else
        {
            var song__ = await _repository.Song.FindAll().Where(p => p.MusicID == addLikeSong.MusicID && p.SongTableID == songTable.SongTableID).FirstOrDefaultAsync();

            if (song__ == null)
            {
                Song createSong = new Song()
                {
                    MusicID = addLikeSong.MusicID,
                    SongTableID = songTable.SongTableID,
                    Composer = musicc.Composer,
                    Lyricist = musicc.Lyricist,
                    Name = musicc.Name,
                    Style = musicc.Style,
                };
                createSong.songTable = null;
                _repository.Song.Create(createSong);
                await _repository.Save();
                return Ok(200);
            }
            else
            {
                return Ok(200);
            }


        }
    }

}
