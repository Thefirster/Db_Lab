using System.ComponentModel.DataAnnotations;
using BootstrapBlazor.Components;
using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace Music.Entity;
public class Singer
{
    [Display(Name = "主键")]
    [AutoGenerateColumn(Ignore = true)]
    public Guid SingerID { get; set; } = Guid.NewGuid();


    [Display(Name = "歌手姓名")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    public string Name { get; set; } = "姓名";


    [Display(Name = "性别")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = false)]
    public string Gender { get; set; } = "性别";


    [Display(Name = "国籍")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 3, Filterable = true, Searchable = false)]
    public string Nationality { get; set; } = "国籍";


    [Display(Name = "电子邮箱")]
    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 4, Filterable = true, Searchable = false)]
    public string Email { get; set; } = "电子邮箱";


    [AutoGenerateColumn(Order = 5, FormatString = "yyyy-MM-dd", Width = 180, Filterable = false)]
    [Display(Name = "出道时间")]
    [Required(ErrorMessage = "{0}不能为空")]
    public DateTime DebutDate { get; set; } = DateTime.Now;


    [AutoGenerateColumn(Order = 6, FormatString = "yyyy-MM-dd", Width = 180, Filterable = false)]
    [Display(Name = "出生日期")]
    [Required(ErrorMessage = "{0}不能为空")]
    public DateTime BirthDate { get; set; } = DateTime.Now;


    [AutoGenerateColumn(Ignore = true)]
    public List<Album>? albums { get; set; } //有多个专辑
}
