using Microsoft.AspNetCore.Components;
using BootstrapBlazor.Components;
using Music.Entity;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;
using System.Reflection.PortableExecutable;
using Music.UI.Dtos;

namespace Music.UI.Pages;
public partial class LikeMusic : ComponentBase
{
    [Inject]
    private HttpClient Http { get; set; }
    private Guid userGuid { get; set; } = new Guid();
    private bool IsTable { get; set; } = false;
    private string SongTableName { get; set; } = "歌单名";

    private User user = new User();

    private async Task<QueryData<SongTable>> OnQueryProductAsync(QueryPageOptions options, User user)
    {
        var products = await Http.PostAsJsonAsync("/getAllSongTableByUser", user);
        var productForUI = await products.Content.ReadFromJsonAsync<List<SongTable>>();

        return new QueryData<SongTable>
        {
            Items = productForUI,
            TotalCount = productForUI.Count
        };
    }
    private async Task<bool> OnSaveProductAsync(User user, SongTable songTable, ItemChangedType type)
    {
        songTable.UserID = user.UserID;
        if (type == ItemChangedType.Update)
        {
            var response = await Http.PostAsJsonAsync("/updateSongTable", songTable);
            return response.IsSuccessStatusCode;
        }
        else
        {
            var response = await Http.PostAsJsonAsync("/createSongTable", songTable);
            return response.IsSuccessStatusCode;
        }
    }
    private async Task<bool> OnDeleteProductAsync(IEnumerable<SongTable> songTables, User user)
    {
        foreach (var songTable in songTables)
        {
            songTable.UserID = user.UserID;
            var response = await Http.PostAsJsonAsync("/deleteSongTable", songTable);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
        }
        return true;
    }
    private async Task<QueryData<Song>> OnQueryContractAsync(QueryPageOptions options, User user, SongTable songTable)
    {
        var contracts = await Http.PostAsJsonAsync("/getAllSongBySongTable", songTable);
        var contractForUI = await contracts.Content.ReadFromJsonAsync<List<Song>>();

        return new QueryData<Song>
        {
            Items = contractForUI,
            TotalCount = contractForUI.Count
        };
    }
    private async Task<bool> OnSaveContractAsync(Song song, ItemChangedType type, User user, SongTable songTable)
    {
        song.SongTableID = songTable.SongTableID;
        if (type == ItemChangedType.Update)
        {
            var response = await Http.PostAsJsonAsync("/updateSong", song);
            return response.IsSuccessStatusCode;
        }
        else
        {
            var response = await Http.PostAsJsonAsync("/createSong", song);
            return response.IsSuccessStatusCode;
        }
    }
    private async Task<bool> OnDeleteContractAsync(IEnumerable<Song> songs, User user, SongTable songTable)
    {
        foreach (var song in songs)
        {
            var response = await Http.PostAsJsonAsync("/deleteSong", song);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
        }
        return true;
    }
    private async Task Find()
    {
        user.UserID = userGuid;
        IsTable = true;
    }

    private readonly PlayerOptions _audioOptions = new();

    private bool _audioEnabled = false;


    private async Task Listen(SongTable songTable,Song song)
    {

        _audioOptions.Source.Type = PlayerMode.Audio;
        _audioOptions.Source.Sources.AddRange(new PlayerSources[]
        {
            new() { Url = song.Uri, Type = "audio/mp3" },
        });
        _audioEnabled = true;
    }
}
