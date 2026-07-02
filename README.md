# PluginToggle

一个用于 ClassIsland 2.x 的轻量级插件。

## 功能

在 ClassIsland 自动化中添加一个**开关插件**行动。可以：

- 选择当前已安装的任意本地插件；
- 选择**切换 / 强制启用 / 强制禁用**该插件；
- 设置**变更后是否立刻重启 ClassIsland** 让启用/禁用生效（因为 .NET 不支持单独卸载程序集，必须重启才能切换被禁用插件的加载状态）；
- 可选**静默重启**（不弹确认窗）。

## 用法

1. 把本仓库的产物打包为 `.cipx` 插件包，或直接放进 `Plugins/PluginToggle/` 目录；
2. 在 ClassIsland 中打开「自动化」→ 选择/创建一条规则 → 添加行动 → 选择「开关插件」；
3. 在行动设置中选择目标插件、操作类型，并按需勾选「立即重启」。

## 实现说明

- 通过 `IPluginService.LoadedPlugins` 列出本地插件，切换 `PluginInfo.IsEnabled` 即可写 `.disabled` 标记文件；
- 立刻重启走 `AppBase.Current.Restart(quiet)`，与 ClassIsland 自带的「重启 ClassIsland」行动一致。

> ⚠️ 由于 .NET 运行时不支持单独卸载已加载的程序集，本行动**只能让变更在下次启动后生效**。
> 当「立即重启」关闭时，变更会在用户下次自行重启时生效。
