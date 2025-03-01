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
public class Musicc
{
    [Display(Name = "歌曲标识")]
    [AutoGenerateColumn(Order = 0, Filterable = true, Searchable = true)]
    public Guid MusicID { get; set; } = Guid.NewGuid();


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    [Display(Name = "曲名")]
    public string Name { get; set; } = "曲名";


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    [Display(Name = "歌曲风格")]
    public string Style { get; set; } = "歌曲风格";


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    [Display(Name = "歌词作者")]
    public string Lyricist { get; set; } = "歌词作者";


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    [Display(Name = "作曲者")]
    public string Composer { get; set; } = "作曲者";


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    [Display(Name = "发行时间")]
    public DateTime ReleaseTime { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true,Width =100)]
    [Display(Name = "歌曲地址")]
    public string Uri { get; set; } = "https://cdn.plyr.io/static/demo/Kishi_Bashi_-_It_All_Began_With_a_Burst.mp3";

    [AutoGenerateColumn(Ignore = true)]
    public Guid? AlbumID { get; set; } = null;

    [AutoGenerateColumn(Ignore = true)]
    [ForeignKey(nameof(AlbumID))]
    public Album? album { get; set; } = null;


    [AutoGenerateColumn(Ignore = true)]
    public Song? song { get; set; } = null;

}
