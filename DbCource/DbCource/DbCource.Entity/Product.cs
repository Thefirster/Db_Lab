using System.ComponentModel.DataAnnotations;
using BootstrapBlazor.Components;
using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
namespace DbCource.Entity;
public class Product
{
    [Display(Name = "主键")]
    [AutoGenerateColumn(Ignore = true)]
    public Guid ProductID { get; set; } = new Guid();


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 10, Filterable = true, Searchable = true)]
    [Display(Name = "产品名字")]
    public string ProductName { get; set; } = "产品名字";         //产品名字


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 10, Filterable = true, Searchable = false)]
    [Display(Name = "产品类型")]
    public string ProductType { get; set; } = "产品类型";        //产品类型


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 10, Filterable = true, Searchable = false)]
    [Display(Name = "价格")]
    public int ProductPrice { get; set; } = 0;         //产品价格


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 10, Filterable = true, Searchable = false)]
    [Display(Name = "最大供应量")]
    public int MaxNumber { get; set; } = 0;              //最大供应量


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 10, Filterable = true, Searchable = false)]
    [Display(Name = "产品稳定性")]
    public string ProductStabilityRate { get; set; } = "稳定";//产品稳定性


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 10, Filterable = true, Searchable = false)]
    [Display(Name = "价格幅度")]
    public int? PriceFluctationRange { get; set; } = 0;   //价格幅度

    
    [AutoGenerateColumn(Ignore = true)]
    public Guid? SupplierID { get; set; } = null;


    [AutoGenerateColumn(Ignore = true)]
    [ForeignKey(nameof(SupplierID))]
    public Supplier? Supplier { get; set; } = null;


    [AutoGenerateColumn(Ignore = true)]
    public List<Contract>? Contracts { get; set; }
}
