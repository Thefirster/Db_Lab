using BootstrapBlazor.Components;
using DbCource.Entity;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DbCource.UI.Pages;

public partial class InboundTable : ComponentBase
{
    [Inject]
    private HttpClient Http { get; set; }

    private async Task<QueryData<Contract>> OnQueryAsync(QueryPageOptions options)
    {
        var contracts = await Http.PostAsJsonAsync("/getAllContractForInbound", "a");
        var contractsForUI = await contracts.Content.ReadFromJsonAsync<List<Contract>>();

        return new QueryData<Contract>
        {
            Items = contractsForUI,
            TotalCount = contractsForUI.Count
        };
    }
    private async Task<bool> OnSaveAsync(Contract contract, ItemChangedType type)
    {
        if (type == ItemChangedType.Update)
        {
            var response = await Http.PostAsJsonAsync("/updateContract", contract);
            return response.IsSuccessStatusCode;
        }
        else
        {
            return false;
        }
    }
    private async Task<bool> OnDeleteAsync(IEnumerable<Contract> foos)
    {
        foreach (var foo in foos)
        {
            var response = await Http.PostAsJsonAsync("/deleteContract", foo);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
        }
        return true;
    }
    private async Task<QueryData<Inbound>> OnQueryInboundAsync(Contract contract,QueryPageOptions options)
    {
        var Inbounds = await Http.PostAsJsonAsync("/getInboundByContract", contract);
        var InboundForUI = await Inbounds.Content.ReadFromJsonAsync<List<Inbound>>();

        return new QueryData<Inbound>
        {
            Items = InboundForUI,
            TotalCount = InboundForUI.Count
        };
    }
    private async Task<bool> OnSaveInboundAsync(Contract contract, Inbound inbound, ItemChangedType type)
    {

        if (type == ItemChangedType.Update)
        {
            var response = await Http.PostAsJsonAsync("/updateInbound", inbound);
            return response.IsSuccessStatusCode;
        }
        else
        {
            return false;
        }
    }
    private async Task<bool> OnDeleteInboundAsync(IEnumerable<Inbound> products, Contract contracts)
    {
        return false;
    }

}
