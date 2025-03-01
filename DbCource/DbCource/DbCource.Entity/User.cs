using System.ComponentModel.DataAnnotations;
using BootstrapBlazor.Components;
using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbCource.Entity;

public class User
{
    [Display(Name = "主键")]
    [AutoGenerateColumn(Ignore = true)]
    public Guid UserID { get; set; } = Guid.NewGuid();


    [Display(Name = "用户名(姓名)")]
    [AutoGenerateColumn(Order = 1, Searchable = true)]
    public string UserName { get; set; } = "用户名";


    [Display(Name = "账户权限")]
    [AutoGenerateColumn(Order = 2, Searchable = true)]
    public string Permissions { get; set; } = "账户权限";



    [Display(Name = "账户")]
    [AutoGenerateColumn(Order = 3, Searchable = true)]
    public string Account { get; set; } = "账户";


    [Display(Name = "密码")]
    [AutoGenerateColumn(Ignore = true)]
    public string Password { get; set; } = "密码";

}
