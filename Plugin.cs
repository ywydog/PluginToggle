using ClassIsland.Core;
using ClassIsland.Core.Abstractions;
using ClassIsland.Core.Attributes;
using ClassIsland.Core.Extensions.Registry;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PluginToggle.Actions;

namespace PluginToggle;

/// <summary>
/// PluginToggle 插件入口。
/// 注册一个自动化行动"开关插件"，用于启用、禁用或切换本地插件的启用状态。
/// </summary>
public class Plugin : PluginBase
{
    public override void Initialize(HostBuilderContext context, IServiceCollection services)
    {
        // 注册"开关插件"行动及对应的设置控件
        services.AddAction<PluginToggleAction, PluginToggleActionSettingsControl>();
    }
}
