using BootstrapBlazor.Components;
using DbCource.UI.Pages;
using Microsoft.AspNetCore.Components.Routing;

namespace DbCource.UI.Layout
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
                new() { Text = "商家管理界面", Icon = "fa-solid fa-fw fa-table", Url = "/supplierTable" ,},

                new() { Text = "合同管理界面", Icon = "fa-solid fa-fw fa-table", Url = "/inboundTable" ,},

                new() { Text = "仓库管理界面", Icon = "fa-solid fa-fw fa-table", Url = "/outboundTable" ,},

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
