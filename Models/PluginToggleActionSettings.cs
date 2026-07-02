using CommunityToolkit.Mvvm.ComponentModel;

namespace PluginToggle.Models;

/// <summary>
/// "开关插件"行动设置。
/// </summary>
public class PluginToggleActionSettings : ObservableRecipient
{
    private string _pluginId = "";

    /// <summary>
    /// 要操作的插件 ID（即 manifest 中的 id）。
    /// </summary>
    public string PluginId
    {
        get => _pluginId;
        set
        {
            if (value == _pluginId) return;
            _pluginId = value;
            OnPropertyChanged();
        }
    }

    private PluginToggleOperation _operation = PluginToggleOperation.Toggle;

    /// <summary>
    /// 操作类型：切换、启用、禁用。
    /// </summary>
    public PluginToggleOperation Operation
    {
        get => _operation;
        set
        {
            if (value == _operation) return;
            _operation = value;
            OnPropertyChanged();
        }
    }

    private bool _restartImmediately = true;

    /// <summary>
    /// 变更后是否立刻重启 ClassIsland 以应用启用/禁用。
    /// </summary>
    public bool RestartImmediately
    {
        get => _restartImmediately;
        set
        {
            if (value == _restartImmediately) return;
            _restartImmediately = value;
            OnPropertyChanged();
        }
    }

    private bool _quietRestart = false;

    /// <summary>
    /// 是否静默重启。关闭主窗口、不弹窗提示。
    /// </summary>
    public bool QuietRestart
    {
        get => _quietRestart;
        set
        {
            if (value == _quietRestart) return;
            _quietRestart = value;
            OnPropertyChanged();
        }
    }
}

/// <summary>
/// "开关插件"行动的操作类型。
/// </summary>
public enum PluginToggleOperation
{
    /// <summary>
    /// 切换：根据当前状态取反。
    /// </summary>
    Toggle = 0,

    /// <summary>
    /// 强制启用。
    /// </summary>
    Enable = 1,

    /// <summary>
    /// 强制禁用。
    /// </summary>
    Disable = 2,
}
