using System.ComponentModel.DataAnnotations;
using BootstrapBlazor.Components;
using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbCource.Entity;

public class Inbound
{
    [Display(Name = "主键")]
    [AutoGenerateColumn(Ignore = true)]
    public Guid InboundID { get; set; } = Guid.NewGuid();


    [Display(Name = "入库负责人")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1,Filterable = true,Searchable =true)]
    public string Manager { get; set; } = "入库负责人";


    [Display(Name = "入库时间")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 20, Filterable = true, Searchable = false)]
    public DateTime? InboundTime { get; set; } = DateTime.Now;


    [Display(Name = "入库地点")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 3, Filterable = true, Searchable = true)]
    public string Location { get; set; } = "入库地点";


    [Display(Name = "是否入库")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
    public string Statues { get; set; } = "not";


    [AutoGenerateColumn(Ignore =true)]
    public Contract? Contracts { get; set; }
    
}
