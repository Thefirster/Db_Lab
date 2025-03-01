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
public class User
{
    [Display(Name = "主键")]
    [AutoGenerateColumn(Ignore = true)]
    public Guid UserID { get; set; } = Guid.NewGuid();


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
    [Display(Name = "用户名")]
    public string Name { get; set; } = "用户名";


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
    [Display(Name = "密码")]
    public string Password { get; set; } = "密码";


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 3, Filterable = true, Searchable = true)]
    [Display(Name = "性别")]
    public string Gender { get; set; } = "性别";


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 4, Filterable = true, Searchable = true)]
    [Display(Name = "电子邮箱")]
    public string Phone { get; set; } = "电子邮箱";


    [Required(ErrorMessage = "{0}不能为空")]
    [AutoGenerateColumn(Order = 4, Filterable = true, Searchable = true)]
    [Display(Name = "手机号码")]
    public string Email { get; set; } = "手机号码";



    [AutoGenerateColumn(Ignore = true)]
    public List<SongTable>? songTables { get; set; } //有多个歌单

}
