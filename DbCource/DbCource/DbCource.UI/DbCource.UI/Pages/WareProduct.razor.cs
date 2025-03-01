using BootstrapBlazor.Components;
using DbCource.Entity;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DbCource.UI.Pages;

public partial class WareProduct : ComponentBase
{
    [Inject]
    private HttpClient Http { get; set; }

    private async Task<QueryData<ProductForWarehource>> OnQueryAsync(QueryPageOptions options)
    {
        var contracts = await Http.PostAsJsonAsync("/getAllWareProduct", "a");
        var contractsForUI = await contracts.Content.ReadFromJsonAsync<List<ProductForWarehource>>();

        return new QueryData<ProductForWarehource>
        {
            Items = contractsForUI,
            TotalCount = contractsForUI.Count,
        };
    }
    private async Task<bool> OnSaveAsync(ProductForWarehource productForWarehource, ItemChangedType type)
    {
        if (type == ItemChangedType.Update)
        {
            return false;
        }
        else
        {
            return false;
        }
    }
    private async Task<bool> OnDeleteAsync(IEnumerable<ProductForWarehource> foos)
    {
        return false;
    }
    private async Task<QueryData<Outbound>> OnQueryOutboundAsync(ProductForWarehource productForWarehource, QueryPageOptions options)
    {
        var outbounds = await Http.PostAsJsonAsync("/getAllOutbound", productForWarehource);
        var outboundForUI = await outbounds.Content.ReadFromJsonAsync<List<Outbound>>();

        return new QueryData<Outbound>
        {
            Items = outboundForUI,
            TotalCount = outboundForUI.Count
        };
    }
    private async Task<bool> OnSaveOutboundAsync(ProductForWarehource productForWarehource, Outbound outbound, ItemChangedType type)
    {

        if (type == ItemChangedType.Update)
        {
            var response = await Http.PostAsJsonAsync("/updateOutbound", outbound);
            return response.IsSuccessStatusCode;
        }
        else
        {
            var response = await Http.PostAsJsonAsync("/createOutbound", outbound);
            return response.IsSuccessStatusCode;
        }
    }
    private async Task<bool> OnDeleteOutboundAsync(IEnumerable<Outbound> outbounds, ProductForWarehource productForWarehource)
    {
        foreach (var outbound in outbounds)
        {
            var response = await Http.PostAsJsonAsync("/deleteOutbound", outbound);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
        }
        return true;
    }

}
