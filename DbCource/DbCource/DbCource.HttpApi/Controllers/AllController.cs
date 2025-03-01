using AutoMapper;
using DbCource.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DbCource.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.CodeAnalysis;
using SQLitePCL;
namespace DbCource.HttpApi.Controllers;

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
    [HttpPost("/CreateSupplier")]
    public async Task<IActionResult> CreateSupplier([FromBody] Supplier supplier)
    {
        try
        {
            supplier.SupplierID = new Guid();

            _repository.Supplier.Create(supplier);
            await _repository.Save();

            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/updateSupplier")]
    public async Task<IActionResult> UpdateSupplier([FromBody] Supplier supplier)
    {
        try
        {
            var updateSupplier = await _repository.Supplier
                                .FindAll()
                                .Where(p => p.Name == supplier.Name)
                                .FirstOrDefaultAsync();
            if (updateSupplier == null)
            {
                return BadRequest("没有此商家");
            }
            supplier.SupplierID = updateSupplier.SupplierID;
            updateSupplier = supplier;
            _repository.Supplier.Update(updateSupplier);
            await _repository.Save();
            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/getAllSupplier")]
    public async Task<List<Supplier>> GetAllSupplier()
    {
        return await _repository.Supplier.FindAll().ToListAsync();
    }
    [HttpPost("/deleteSupplier")]
    public async Task<IActionResult> DeleteSupplier([FromBody] Supplier supplier)
    {
        try
        {
            var deleteSupplier = await _repository.Supplier.GetSupplierByName(supplier.Name);
            if (deleteSupplier == null)
            {
                return BadRequest("商家不存在");
            }
            var contract = await _repository.Contract.FindAll().ToListAsync();
            foreach (var item in contract)
            {
                if (item.SupplierID == deleteSupplier.SupplierID)
                {
                    return BadRequest("存在该商家的合同，无法删除");
                }
            }
            var product = await _repository.Product.FindAll().ToListAsync();
            foreach (var item in product)
            {
                if (item.SupplierID == deleteSupplier.SupplierID)
                {
                    _repository.Product.Delete(item);
                }
            }
            _repository.Supplier.Delete(deleteSupplier);
            await _repository.Save();
            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/getAllProductBySupplier")]
    public async Task<List<Product>> GetAllProductBySupplier([FromBody] Supplier supplier)
    {
        return await _repository.Product.FindAll().Where(p => p.SupplierID == supplier.SupplierID).ToListAsync();
    }
    [HttpPost("/CreateProduct")]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("无效请求");
            }
            if (product.Supplier.Name is null)
            {
                return BadRequest("没有添加商家");
            }

            product.ProductID = Guid.NewGuid();
            product.SupplierID = product.Supplier.SupplierID;
            product.Supplier = null;
            _repository.Product.Create(product);
            await _repository.Save();

            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/updateProduct")]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
    {
        try
        {
            if (product.ProductName == null)
            {
                return BadRequest("请填入商家名字");
            }
            if (product.Supplier.Name == null)
            {
                return BadRequest("请填入商品名字");
            }
            var updateProduct = await _repository.Product
                                .GetProductBySupplierAndName(
                                product.ProductName,
                                product.Supplier.Name);
            var updateSupplier = await _repository.Supplier.GetSupplierByName(product.Supplier.Name);

            product.ProductID = updateProduct.ProductID;
            product.SupplierID = updateSupplier.SupplierID;
            updateProduct = product;
            updateProduct.Supplier = null;

            _repository.Product.Update(updateProduct);
            await _repository.Save();
            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/deleteProduct")]
    public async Task<IActionResult> DeleteProduct([FromBody] Product product)
    {
        try
        {
            if (product.ProductName == null)
            {
                return BadRequest("请填入商家名字");
            }
            if (product.Supplier.Name == null)
            {
                return BadRequest("请填入商品名字");
            }
            var deleteProduct = await _repository.Product
                .GetProductBySupplierAndName(
                            product.ProductName,
                            product.Supplier.Name);

            var contract = await _repository.Contract.FindAll().ToListAsync();
            foreach (var item in contract)
            {
                if (item.ProductID == deleteProduct.ProductID)
                {
                    return BadRequest("存在该商品的合同，无法删除");
                }
            }
            _repository.Product.Delete(deleteProduct);
            await _repository.Save();
            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/createContract")]
    public async Task<IActionResult> CreateContract([FromBody] Contract contract)
    {
        try
        {
            if (contract.Inbound == null)
            {
                Inbound createInbound = new Inbound();

                createInbound.InboundID = new Guid();
                createInbound.Statues = "not";
                createInbound.Location = "黑龙江仓库";
                createInbound.Manager = contract.Manager;

                contract.Inbound = createInbound;
            }
            contract.ProductID = contract.Product.ProductID;
            contract.Product = null;
            contract.SupplierID = contract.Supplier.SupplierID;
            contract.Supplier = null;
            _repository.Contract.Create(contract);
            await _repository.Save();

            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/deleteContract")]
    public async Task<IActionResult> DeleteContract([FromBody] Contract contract)
    {
        try
        {
            var delete = await _repository.Contract.FindAll().Where(p => p.ContractID == contract.ContractID).FirstOrDefaultAsync();
            var deleteInbound = await _repository.Inbound.FindAll().Where(p => p.InboundID == contract.InboundID).FirstOrDefaultAsync();

            _repository.Contract.Delete(delete);
            _repository.Inbound.Delete(deleteInbound);
            await _repository.Save();
            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/updateContract")]
    public async Task<IActionResult> UpdateContract([FromBody] Contract contract)
    {
        try
        {
            if(contract.Status == "ok")
            {
                var inbound = await _repository.Inbound.FindAll().Where(p => p.InboundID == contract.InboundID).FirstOrDefaultAsync();
                if(inbound != null)
                {
                    inbound.Statues = "doing";
                    _repository.Inbound.Update(inbound);
                    _repository.Contract.Update(contract);
                    await _repository.Save();
                    return StatusCode(200);
                }
                return StatusCode(404);
            }
            else
            {
                _repository.Contract.Update(contract);
                await _repository.Save();
                return StatusCode(200);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/getAllContract")]
    public async Task<List<Contract>> GetAllContract([FromBody] Product product)
    {
        var contracts = _repository.Contract.FindAll().Where(p => p.SupplierID == product.Supplier.SupplierID && p.ProductID == product.ProductID).ToList();
        return contracts;
    }
    [HttpPost("/getAllContractForInbound")]
    public async Task<List<Contract>> GetContract()
    {
        return await _repository.Contract.FindAll().ToListAsync();
    }
    [HttpPost("/getInboundByContract")]
    public async Task<List<Inbound>> GetInboundByContract([FromBody] Contract contract)
    {
        return await _repository.Inbound.FindAll().Where(p => p.InboundID == contract.InboundID).ToListAsync();
    }
    [HttpPost("/updateInbound")]
    public async Task<IActionResult> UpdateInbound([FromBody] Inbound inbound)
    {
        try
        {
            if(inbound.Statues == "ok")
            {
                var contract = await _repository.Contract.FindAll().Where(p => p.InboundID == inbound.InboundID).FirstOrDefaultAsync();
                var product = await _repository.Product.FindAll().Where(p => p.ProductID == contract.ProductID).FirstOrDefaultAsync();

                var wareProduct = await _repository.ProductForWarehouse.FindAll().Where(p => p.ProductName == product.ProductName).FirstOrDefaultAsync();
                if(wareProduct is null)
                {
                    ProductForWarehource productForWarehource = new ProductForWarehource();
                    productForWarehource.Number = contract.OrderQuantity;
                    productForWarehource.ProductName = product.ProductName;
                    productForWarehource.ProductType = product.ProductType;
                    productForWarehource.ProductID = new Guid();

                    _repository.ProductForWarehouse.Create(productForWarehource);
                    await _repository.Save();
                    return StatusCode(200);
                }
                else
                {
                    wareProduct.Number = wareProduct.Number + contract.OrderQuantity;
                    _repository.ProductForWarehouse.Update(wareProduct);
                    await _repository.Save();
                    return StatusCode(200);
                }
            }
            else
            {
                _repository.Inbound.Update(inbound);
                await _repository.Save();
                return StatusCode(200);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/getAllWareProduct")]
    public async Task<List<ProductForWarehource>> GetAllWareProduct()
    {
        return await _repository.ProductForWarehouse.FindAll().ToListAsync();
    }
    [HttpPost("/getAllOutbound")]
    public async Task<List<Outbound>> GetAllOutbound([FromBody] ProductForWarehource productForWarehource)
    {
        var outbounds = await _repository.Outbound.FindAll().Where(p => p.ProductName == productForWarehource.ProductName).ToListAsync();
        return outbounds;
    }
    [HttpPost("/updateOutbound")]
    public async Task<IActionResult> Updatebound([FromBody] Outbound outbound)
    {
        try
        {
            if(outbound.Status == "ok")
            {
                var wareProduct = await _repository.ProductForWarehouse.FindAll().Where(p => p.ProductName == outbound.ProductName).FirstOrDefaultAsync();
                wareProduct.Number = wareProduct.Number - outbound.ProductNumber;
                _repository.ProductForWarehouse.Update(wareProduct);
                _repository.Outbound.Update(outbound);
                await _repository.Save();
                return StatusCode(200);
            }
            else
            {
                _repository.Outbound.Update(outbound);
                 await _repository.Save();
                return StatusCode(200);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/createOutbound")]
    public async Task<IActionResult> CreateOutbound([FromBody] Outbound outbound)
    {
        try
        {
            var wareProduct = await _repository.ProductForWarehouse.FindAll().Where(p => p.ProductName == outbound.ProductName).FirstOrDefaultAsync();
            if(outbound.ProductNumber > wareProduct.Number)
            {
                return StatusCode(404);
            }
            _repository.Outbound.Create(outbound);
            await _repository.Save();

            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
    [HttpPost("/deleteOutbound")]
    public async Task<IActionResult> DeleteOutbound([FromBody] Outbound outbound)
    {
        try
        {
            _repository.Outbound.Delete(outbound);
            await _repository.Save();
            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
}
