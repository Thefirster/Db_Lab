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

public class Album
{
    [Display(Name = "主键")]
    [AutoGenerateColumn(Ignore = true)]
    public Guid AlbumID { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    [Display(Name = "专辑名称")]
    public string Name { get; set; } = "专辑名称";


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    [Display(Name = "专辑简介")]
    public string Profile { get; set; } = "专辑简介";


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 3, FormatString = "yyyy-MM-dd", Width = 180, Filterable = true)]
    [Display(Name = "专辑发行时间")]
    public DateTime? ReleaseTime { get; set; } = DateTime.Now;    //专辑发行时间


    [AutoGenerateColumn(Ignore = true)]
    public Guid? SingerID { get; set; } = null;

    [AutoGenerateColumn(Ignore = true)]
    [ForeignKey(nameof(SingerID))]
    public Singer? singer { get; set; } = null;


    [AutoGenerateColumn(Ignore = true)]
    public List<Musicc>? musics { get; set; } //有多个歌曲


}
