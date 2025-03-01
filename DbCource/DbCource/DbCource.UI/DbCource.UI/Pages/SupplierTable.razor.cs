using BootstrapBlazor.Components;
using DbCource.Entity;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace DbCource.UI.Pages;
public partial class SupplierTable : ComponentBase
{
    [Inject]
    private HttpClient Http { get; set; }

    private async Task<QueryData<Supplier>> OnQueryAsync(QueryPageOptions options)
    {
        var suppliers = await Http.PostAsJsonAsync("/getAllSupplier", "a");
        var supplierForUI = await suppliers.Content.ReadFromJsonAsync<List<Supplier>>();

        return new QueryData<Supplier>
        {
            Items = supplierForUI,
            TotalCount = supplierForUI.Count
        };
    }
    private async Task<bool> OnSaveAsync(Supplier supplier, ItemChangedType type)
    {
        if (type == ItemChangedType.Update)
        {
            var response = await Http.PostAsJsonAsync("/updateSupplier", supplier);
            return response.IsSuccessStatusCode;
        }
        else
        {
            var response = await Http.PostAsJsonAsync("/CreateSupplier", supplier);
            return response.IsSuccessStatusCode;
        }
    }
    private async Task<bool> OnDeleteAsync(IEnumerable<Supplier> foos)
    {
        foreach (var foo in foos)
        {
            var response = await Http.PostAsJsonAsync("/deleteSupplier", foo);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
        }
        return true;
    }
    private async Task<QueryData<Product>> OnQueryProductAsync(QueryPageOptions options, Supplier supplier)
    {
        var products = await Http.PostAsJsonAsync("/getAllProductBySupplier",supplier);
        var productForUI = await products.Content.ReadFromJsonAsync<List<Product>>();

        return new QueryData<Product>
        {
            Items = productForUI,
            TotalCount = productForUI.Count
        };
    }
    private async Task<bool> OnSaveProductAsync(Supplier supplier, Product product, ItemChangedType type)
    {
        product.Supplier = supplier;

        if (type == ItemChangedType.Update)
        {
            var response = await Http.PostAsJsonAsync("/updateProduct", product);
            return response.IsSuccessStatusCode;
        }
        else
        {
            var response = await Http.PostAsJsonAsync("/CreateProduct", product);
            return response.IsSuccessStatusCode;
        }
    }
    private async Task<bool> OnDeleteProductAsync(IEnumerable<Product> products,Supplier supplier)
    {
        foreach (var product in products)
        {
            product.Supplier = supplier;
            var response = await Http.PostAsJsonAsync("/deleteProduct", product);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
        }
        return true;
    }
    private async Task<QueryData<Contract>> OnQueryContractAsync(QueryPageOptions options, Supplier supplier,Product product)
    {
        product.Supplier = supplier;
        var contracts = await Http.PostAsJsonAsync("/getAllContract",product);
        var contractForUI = await contracts.Content.ReadFromJsonAsync<List<Contract>>();

        return new QueryData<Contract>
        {
            Items = contractForUI,
            TotalCount = contractForUI.Count
        };
    }
    private async Task<bool> OnSaveContractAsync(Contract contract,ItemChangedType type, Supplier supplier, Product product)
    {
        contract.Supplier = supplier;
        contract.Product = product;

        if (type == ItemChangedType.Update)
        {
            var response = await Http.PostAsJsonAsync("/updateContract", contract);
            return response.IsSuccessStatusCode;
        }
        else
        {
            var response = await Http.PostAsJsonAsync("/createContract", contract);
            return response.IsSuccessStatusCode;
        }
    }
    private async Task<bool> OnDeleteContractAsync(IEnumerable<Contract> contracts, Supplier supplier, Product product)
    {
        foreach (var contract in contracts)
        {
            contract.Supplier = supplier;
            contract.Product = product;
            var response = await Http.PostAsJsonAsync("/deleteContract", contract);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
        }
        return true;
    }

}
