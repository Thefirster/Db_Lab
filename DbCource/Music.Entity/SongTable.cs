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
public class SongTable
{
    [Display(Name = "主键")]
    [AutoGenerateColumn(Ignore = true)]
    public Guid SongTableID { get; set; } = new Guid();


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    [Display(Name = "歌单名称")]
    public string Name { get; set; } = "歌单名称";        


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
    [Display(Name = "歌单简介")]
    public string Profile { get; set; } = "歌单简介";


    [Required(ErrorMessage = "{0}不能为空")]
    [Display(Name = "创建时间")]
    [AutoGenerateColumn(Order = 3, Filterable = true, Searchable = false)]
    public DateTime CreateTime { get; set; } = DateTime.Now;


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 4, Filterable = true, Searchable = true)]
    [Display(Name = "是否公开")]
    public string IsPublic { get; set; } = "是否公开";


    [AutoGenerateColumn(Ignore = true)]
    public Guid? UserID { get; set; } = null;

    [AutoGenerateColumn(Ignore = true)]
    [ForeignKey(nameof(UserID))]
    public User? user { get; set; } = null;


    [AutoGenerateColumn(Ignore = true)]
    public List<Song>? songs { get; set; } //有多个歌单
}
