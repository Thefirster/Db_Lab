using System.ComponentModel.DataAnnotations;
using BootstrapBlazor.Components;
using System.Diagnostics.Contracts;
namespace DbCource.Entity;

public class Supplier
{
    [Display(Name = "主键")]
    [AutoGenerateColumn(Ignore = true)]
    public Guid SupplierID { get; set; } = Guid.NewGuid();


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    [Display(Name = "公司名")]
    public string Name { get; set; } = "公司名";


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = false)]
    [Display(Name = "电话")]
    public string Phone { get; set; } = "电话";


    [Display(Name = "地址")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 3, Filterable = true, Searchable = false)]
    public string Address { get; set; } = "地址";


    [Display(Name = "电子邮箱")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 4, Filterable = true, Searchable = false)]
    public string Email { get; set; } = "电子邮箱";


    [Display(Name = "规模")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 5, Filterable = true, Searchable = false)]
    public string FirmSize { get; set; } = "规模大小";                        //规模大小


    [Display(Name = "资质类型")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 6, Filterable = true, Searchable = false)]
    public string QuaType { get; set; } = "资质类型";                         //资质类型


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 7, FormatString = "yyyy-MM-dd", Width = 180, Filterable = true)]
    [Display(Name = "资质结束时间")]
    public DateTime? QuaEndTime { get; set; } = DateTime.Now;    //资质结束时间


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 8, Filterable = true, Searchable = false)]
    [Display(Name = "资质颁发机构")]
    public string QuaAuthority { get; set; } = "资质颁发机构";                    //资质颁发机构


    [Required(ErrorMessage = "{0}不能为空")]
    [Display(Name = "成立的时间")]
    [AutoGenerateColumn(Order = 9, Filterable = true, Searchable = false)]
    public DateTime CreateTime { get; set; } = DateTime.Now;    //成立的时间


    [Required(ErrorMessage = "{0}不能为空")]
    [Display(Name = "账户")]
    [AutoGenerateColumn(Ignore = true)]
    public string Account { get; set; } = "账户";


    [Required(ErrorMessage = "{0}不能为空")]
    [Display(Name = "密码")]
    [AutoGenerateColumn(Ignore = true)]
    public string Password { get; set; } = "密码";

    
    [AutoGenerateColumn(Ignore = true)]
    public List<Product>? Products { get; set; }

    [AutoGenerateColumn(Ignore = true)]
    public List<Contract>? Contracts { get; set; }
}
