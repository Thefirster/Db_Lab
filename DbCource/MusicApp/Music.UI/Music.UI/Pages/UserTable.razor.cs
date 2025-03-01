using BootstrapBlazor.Components;
using Music.Entity;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;

namespace Music.UI.Pages;
public partial class UserTable : ComponentBase
{
    [Inject]
    private HttpClient Http { get; set; }

    private async Task<QueryData<User>> OnQueryAsync(QueryPageOptions options)
    {
        var suppliers = await Http.PostAsJsonAsync("/getAllUser", "a");
        var supplierForUI = await suppliers.Content.ReadFromJsonAsync<List<User>>();

        return new QueryData<User>
        {
            Items = supplierForUI,
            TotalCount = supplierForUI.Count
        };
    }
    private async Task<bool> OnSaveAsync(User user, ItemChangedType type)
    {
        if (type == ItemChangedType.Update)
        {
            var response = await Http.PostAsJsonAsync("/updateUser", user);
            return response.IsSuccessStatusCode;
        }
        else
        {
            var response = await Http.PostAsJsonAsync("/CreateUser", user);
            return response.IsSuccessStatusCode;
        }
    }
    private async Task<bool> OnDeleteAsync(IEnumerable<User> foos)
    {
        foreach (var foo in foos)
        {
            var response = await Http.PostAsJsonAsync("/deleteUser", foo);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
        }
        return true;
    }
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
}
