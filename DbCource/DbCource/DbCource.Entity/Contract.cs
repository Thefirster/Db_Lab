using System.ComponentModel.DataAnnotations;
using BootstrapBlazor.Components;
using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
namespace DbCource.Entity;


public class Contract
{
    [Display(Name = "主键")]
    [AutoGenerateColumn(Ignore = true)]
    public Guid ContractID { get; set; } = Guid.NewGuid();


    [Display(Name = "合同负责人")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    public string? Manager { get; set; } = "123";//合同负责人


    [AutoGenerateColumn(Order = -2, FormatString = "yyyy-MM-dd", Width = 180, Filterable = false)]
    [Display(Name = "合同开始日期")]
    [Required(ErrorMessage = "{0}不能为空")]
    public DateTime EstDate { get; set; } = DateTime.Now;//合同开始日期


    [AutoGenerateColumn(Order = -1, FormatString = "yyyy-MM-dd", Width = 180, Filterable = false)]
    [Display(Name = "合同结束日期")]
    [Required(ErrorMessage = "{0}不能为空")]
    public DateTime ExpDate { get; set; } = DateTime.Now;//合同结束日期


    [Display(Name = "订货量")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 20, Filterable = true, Searchable = false)]
    public int OrderQuantity { get; set; } = 0;//订货量


    [Display(Name = "合同状态")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 20, Filterable = true, Searchable = false)]
    public string Status { get; set; } = "not";//合同状态

    
    [AutoGenerateColumn(Ignore = true)]
    public Guid? SupplierID { get; set; }


    [ForeignKey(nameof(SupplierID))]
    [AutoGenerateColumn(Ignore = true)]
    public Supplier? Supplier { get; set; }


    [AutoGenerateColumn(Ignore = true)]
    public Guid? ProductID { get; set; }


    [ForeignKey(nameof(ProductID))]
    [AutoGenerateColumn(Ignore = true)]
    public Product? Product { get; set; }


    [AutoGenerateColumn(Ignore = true)]
    public Guid? InboundID { get; set; }


    [ForeignKey(nameof(InboundID))]
    [AutoGenerateColumn(Ignore = true)]
    public Inbound? Inbound { get; set; }
}