using BootstrapBlazor.Components;
using Music.Entity;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;

namespace Music.UI.Pages;
public partial class SingerTable : ComponentBase
{
    [Inject]
    private HttpClient Http { get; set; }

    private async Task<QueryData<Singer>> OnQueryAsync(QueryPageOptions options)
    {
        var suppliers = await Http.PostAsJsonAsync("/getAllSinger", "a");
        var supplierForUI = await suppliers.Content.ReadFromJsonAsync<List<Singer>>();

        return new QueryData<Singer>
        {
            Items = supplierForUI,
            TotalCount = supplierForUI.Count
        };
    }
    private async Task<bool> OnSaveAsync(Singer singer, ItemChangedType type)
    {
        if (type == ItemChangedType.Update)
        {
            var response = await Http.PostAsJsonAsync("/updateSinger", singer);
            return response.IsSuccessStatusCode;
        }
        else
        {
            var response = await Http.PostAsJsonAsync("/createSinger", singer);
            return response.IsSuccessStatusCode;
        }
    }
    private async Task<bool> OnDeleteAsync(IEnumerable<Singer> foos)
    {
        foreach (var foo in foos)
        {
            var response = await Http.PostAsJsonAsync("/deleteSinger", foo);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
        }
        return true;
    }
    private async Task<QueryData<Album>> OnQueryProductAsync(QueryPageOptions options, Singer singer)
    {
        var products = await Http.PostAsJsonAsync("/getAllAlbumBySinger", singer);
        var productForUI = await products.Content.ReadFromJsonAsync<List<Album>>();

        return new QueryData<Album>
        {
            Items = productForUI,
            TotalCount = productForUI.Count
        };
    }
    private async Task<bool> OnSaveProductAsync(Singer singer, Album album, ItemChangedType type)
    {
        album.singer = singer;
        album.SingerID = singer.SingerID;
        if (type == ItemChangedType.Update)
        {
            var response = await Http.PostAsJsonAsync("/updateAlbum", album);
            return response.IsSuccessStatusCode;
        }
        else
        {
            var response = await Http.PostAsJsonAsync("/createAlbum", album);
            return response.IsSuccessStatusCode;
        }
    }
    private async Task<bool> OnDeleteProductAsync(IEnumerable<Album> albums, Singer singer)
    {
        foreach (var album in albums)
        {
            album.singer = singer;

            var response = await Http.PostAsJsonAsync("/deleteAlbum", album);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
        }
        return true;
    }
    private async Task<QueryData<Musicc>> OnQueryContractAsync(QueryPageOptions options, Singer singer, Album album)
    {
        album.singer = singer;
        var contracts = await Http.PostAsJsonAsync("/getAllMusicByAlbum", album);
        var contractForUI = await contracts.Content.ReadFromJsonAsync<List<Musicc>>();

        return new QueryData<Musicc>
        {
            Items = contractForUI,
            TotalCount = contractForUI.Count
        };
    }
    private async Task<bool> OnSaveContractAsync(Musicc musicc, ItemChangedType type, Singer singer, Album album)
    {
        musicc.album = album;
        musicc.AlbumID = album.AlbumID;
        if (type == ItemChangedType.Update)
        {
            var response = await Http.PostAsJsonAsync("/updateMusic", musicc);
            return response.IsSuccessStatusCode;
        }
        else
        {
            var response = await Http.PostAsJsonAsync("/createMusic", musicc);
            return response.IsSuccessStatusCode;
        }
    }
    private async Task<bool> OnDeleteContractAsync(IEnumerable<Musicc> musiccs, Singer singer, Album album)
    {
        foreach (var musicc in musiccs)
        {
            musicc.album = album;
            var response = await Http.PostAsJsonAsync("/deleteMusic", musicc);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
        }
        return true;
    }
}
