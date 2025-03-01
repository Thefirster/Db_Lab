using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Routing;
using Music.UI.Pages;

namespace Music.UI.Layout
{
    public partial class MainLayout
    {
        private bool UseTabSet { get; set; } = true;

        private string Theme { get; set; } = "";

        private bool IsOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedTabHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem>? Menus { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Menus = GetIconSideMenuItems();
        }

        private static List<MenuItem> GetIconSideMenuItems()
        {
            var menus = new List<MenuItem>
            {
                //new() { Text = "返回组件库", Icon = "fa-solid fa-fw fa-home", Url = "https://www.blazor.zone/components" },
                new() { Text = "Index", Icon = "fa-solid fa-fw fa-flag", Url = "/" , Match = NavLinkMatch.All},
                new() { Text = "歌手管理界面", Icon = "fa-solid fa-fw fa-table", Url = "/singerTable" ,},
                new() { Text = "用户管理界面", Icon = "fa-solid fa-fw fa-table", Url = "/userTable" ,},
            };

            return menus;
        }

        private Task OnSideChanged(bool v)
        {
            IsFullSide = v;
            StateHasChanged();
            return Task.CompletedTask;
        }
    }
}
