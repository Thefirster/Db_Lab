using BootstrapBlazor.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCource.Entity;
public class Outbound
{
    [Display(Name = "主键")]
    [AutoGenerateColumn(Ignore = true)]
    public Guid OutboundID {  get; set; } = Guid.NewGuid();


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = -3, Filterable = true, Searchable = true)]
    [Display(Name = "出库时间")]
    public DateTime? OutboundTime {  get; set; }


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 3, Filterable = true, Searchable = true)]
    [Display(Name = "出库负责人")]
    public string? ManagerName { get; set; }


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    [Display(Name = "产品名字")]
    public string? ProductName { get; set; }


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
    [Display(Name = "出库数量")]
    public int? ProductNumber { get; set; }


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 4, Filterable = true, Searchable = true)]
    [Display(Name = "运输方式")]
    public string? Transportation { get; set; }


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 5, Filterable = true, Searchable = true)]
    [Display(Name = "任务完成状态")]
    public string? Status { get; set; }


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 6, Filterable = true, Searchable = true)]
    [Display(Name = "到达时间")]
    public DateTime? ArrivalTime { get; set; }


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 7, Filterable = true, Searchable = true)]
    [Display(Name = "运输花费")]
    public int? TranCost { get;set; }
}
