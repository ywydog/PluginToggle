using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ClassIsland.Core;
using ClassIsland.Core.Abstractions.Controls;
using ClassIsland.Core.Abstractions.Services;
using ClassIsland.Core.Models.Plugin;
using PluginToggle.Models;

namespace PluginToggle;

public partial class PluginToggleActionSettingsControl : ActionSettingsControlBase<PluginToggleActionSettings>
{
    public PluginToggleActionSettingsControl()
    {
        InitializeComponent();
    }

    protected override void OnAttachedToVisualTree(Avalonia.VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        RefreshPluginList();
    }

    private void ButtonRefreshPlugins_OnClick(object? sender, RoutedEventArgs e)
    {
        RefreshPluginList();
    }

    /// <summary>
    /// 用当前已加载的本地插件刷新下拉框。
    /// </summary>
    private void RefreshPluginList()
    {
        var list = new List<PluginInfo>(IPluginService.LoadedPlugins);
        PluginComboBox.ItemsSource = list;

        // 默认选中当前设置对应的插件，没有则保持现状
        if (!string.IsNullOrWhiteSpace(Settings.PluginId))
        {
            var hit = list.FirstOrDefault(p =>
                string.Equals(p.Manifest.Id, Settings.PluginId, System.StringComparison.OrdinalIgnoreCase));
            if (hit != null)
            {
                PluginComboBox.SelectedValue = hit.Manifest.Id;
            }
        }
    }
}
