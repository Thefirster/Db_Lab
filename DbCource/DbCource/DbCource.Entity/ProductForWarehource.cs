using BootstrapBlazor.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCource.Entity;
public class ProductForWarehource
{
    [Display(Name = "主键")]
    [AutoGenerateColumn(Ignore = true)]
    public Guid ProductID { get; set; }


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    [Display(Name = "产品名字")]
    public string? ProductName { get; set; }         //产品名字

    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
    [Display(Name = "产品类型")]
    public string? ProductType { get; set; }         //产品类型

    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 3, Filterable = true, Searchable = true)]
    [Display(Name = "产品数量")]
    public int? Number { get; set; }              //产品数量


}
