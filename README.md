# v2rayN 定制版（Windows）

> 基于 [2dust/v2rayN](https://github.com/2dust/v2rayN) 的 Windows 桌面增强版：**出口 IP 归属地显示、网址可达性检测、增强停止按钮、测速链路修复**。
>
> A customized Windows desktop build of v2rayN with exit-IP geolocation, website reachability check, and an enhanced stop button.

---

## ✨ 定制功能

### 1. 出口 IP + 中文归属地
- 测速时自动显示每个节点的**出口 IP 及中文归属地**（省/市）。
- 一眼识别节点真实落地位置，避免"假节点""绕路节点"。

### 2. 网址可达性检测
- 自定义目标网址，一键**批量检测所有节点**对该网址的可达性。
- 适合验证流媒体、特定站点是否解锁，结果一目了然。

### 3. 增强停止按钮
- 测速 / 检测过程中**随时停止**，未完成的行标记"已停止"，不再卡在"测试中…"。
- 完成提示按测试类型区分（延迟 / 真连接 / 速度 / 混合 / 网址可达性）。

### 4. 测速链路修复
- 测速下载走回调、不抛异常，避免整列卡死。
- 默认测速源使用纯 HTTP 的 Hetzner 节点，规避部分机场对 HTTPS 测速站的 SNI 拦截。

---

## 📥 下载

前往 **[Releases](https://github.com/Yangsome/v2rayn-Windows/releases)** 下载最新版：

| 文件 | 说明 |
| --- | --- |
| `v2rayn-custom-win-x64-vX.X.zip` | Windows x64 免安装版，解压即用 |

> 系统要求：Windows 10 / 11 x64。

---

## 🚀 快速开始

1. 解压到任意目录（建议使用**非中文路径**）。
2. 双击运行 `v2rayN.exe`。
3. 添加订阅链接，或手动导入节点。
4. 选中节点 → 右键 → **测试真连接延迟**，验证节点可用。
5. 需要看落地位置时，执行测速即可看到出口 IP 与归属地。

---

## 🔧 从源码构建

需要 **.NET 10 SDK**。

```bash
dotnet publish v2rayN/v2rayN.Desktop -c Release -r win-x64
```

构建产物位于：

```
v2rayN/v2rayN.Desktop/bin/Release/net10.0/win-x64/publish/
```

> ⚠️ 注意：定制 UI 位于 **`v2rayN.Desktop`（Avalonia 工程）**；`v2rayN`（WPF 工程）为上游遗留界面，**不含**本项目的定制功能，请勿用其构建交付版本。

---

## 🧩 项目结构

```
v2rayN/
├── v2rayN.Desktop/     # 定制 UI（Avalonia），构建此工程
├── v2rayN/             # 上游遗留 WPF 界面（不含定制功能）
├── ServiceLib/         # 核心服务库（配置、测速、内核管理）
├── ServiceLib.Tests/   # 单元测试
├── GlobalHotKeys/      # 全局快捷键
└── AmazTool/           # 辅助工具
```

---

## ❓ 常见问题

**Q：真连接测试整列显示 -1？**
A：多为节点 / 机场对探测目标（Google 204）的高频限流，或节点自身 ECH 配置问题。稍等几分钟再测；也可在 **设置 → v2rayN 设置 → 真连接测试地址** 切换为 YouTube 备用目标。

**Q：测速一直没速度？**
A：部分机场会按 SNI 拦截测速网站的 HTTPS。本项目默认已改用纯 HTTP 的 Hetzner 测速源，若仍无速度，可在设置中更换测速地址。

---

## 📄 许可证

本项目基于 [v2rayN](https://github.com/2dust/v2rayN) 修改，遵循 **GNU General Public License v3.0（GPL-3.0）**。详见 [LICENSE](LICENSE)。

## 🙏 致谢

- [2dust/v2rayN](https://github.com/2dust/v2rayN) —— 上游项目
- [XTLS/Xray-core](https://github.com/XTLS/Xray-core)、[SagerNet/sing-box](https://github.com/SagerNet/sing-box) —— 代理内核

---

## ⚠️ 免责声明

本项目仅供**学习与技术研究**使用。请遵守所在地法律法规，勿用于任何非法用途。使用本软件所产生的一切后果由使用者自行承担。
