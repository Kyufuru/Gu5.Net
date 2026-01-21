# Gu5.Framework.Device.Focas

## Fanuc 数控机床数据采集库

### 使用说明

- 下载 [Funac Focas Library](https://github.com/wheeliar/FANUC_Focas_API)
- 添加 dll 到项目根目录

| 环境 | 名称 | 描述 | 必需 |
| --- | --- | --- | --- |
| x64 | Fwlib64.dll | CNC/PMC 控制 | ✅ |
| x64 | fwlibe64.dll | TCP/IP 处理 | ✅ |
| x64 | fwlib30i64.dll | 30i/31i/32i/35i, PMi-A 扩展 | |
| x64 | fwlib0iD64.dll | 0i-D 扩展 | |
| x64 | fwlibNCG64.dll | FS31i/32i/35i NCGuidePro 扩展 | |
| x64 | fwlib0DN64.dll | FS0i-D NCGuidePro 扩展 | |
| x64 | Fwlib64.lib | 导入库 | |
| x86 | Fwlib32.dll | CNC/PMC 控制 | ✅ |
| x86 | fwlibe1.dll | TCP/IP 通信 | ✅ |
| x86 | fwlib30i.dll | 30i/31i/32i/35i, PMi-A 扩展 | |
| x86 | Fwlib150.dll | 150-B 扩展 | |
| x86 | Fwlib15i.dll | 150i 扩展 | |
| x86 | Fwlib160.dll | 160/180/210 扩展 | |
| x86 | Fwlib16W.dll | 160i/180i-W 扩展 | |
| x86 | FWLIB0i.dll | 0i-A 扩展 | |
| x86 | Fwlib0iB.dll | 0i-B 扩展 | |
| x86 | fwlib0iD.dll | 0i-D 扩展 | |
| x86 | Fwlibpm.dll | Power Mate-D/H 扩展 | |
| x86 | Fwlibpmi.dll | Power Mate i-D/H 扩展 | |
| x86 | fwlibNCG.dll | FS31i/32i/35i NCGuidePro 扩展 | |
| x86 | fwlib0DN.dll | FS31i/32i/35i NCGuidePro 扩展 | |
| x86 | Fwlib32.lib | 导入库 | |
| x86 | fwpmcalm.ini | PMC 警告信息 | |

- 连接设备
```CSharp
var conn = new ConnInfo()
{
    Host = "127.0.0.1",
    Port = 8193,
    Timeout = 5000,
};

using (var fnc = Fanuc.Create(conn))
{
    // 操作
}
```

### 主要功能

- **GetStatInfo** 获取机床信息
    - TMMode T/M 模式
    - AutoMode 自动模式
    - RunState 运行状态
    - AxisMoveState 轴运动状态
    - MstbStatus M/S/T/B 功能状态
    - EmergencyStatus 急停状态
    - AlarmStatus 报警状态
    - ProgramEditStatus 程序编辑状态
    - MaxAxis 最大轴数
    - Type 机床型号
    - Program 主程序号
    - SubProgram 子程序号(运行程序号)
- **GetToolInfo** 获取刀具状态
    - FeedRate 进给率(实际切削速度) 毫米/分钟
    - X X 轴坐标
    - Y Y 轴坐标
    - XAbs X 轴绝对坐标
    - YAbs Y 轴绝对坐标
- **GetSpindleInfo** 获取主轴状态
    - RSpeed 转速
    - Load 负载
- **GetProdInfo** 获取加工信息
    - BatchQty 班次加工数量
    - TotalQty 总加工数量
    - TotalPowerTime 总通电时长/分钟
    - TotalWorkTime 总运行时长/秒
    - TotalProcTime 总加工时长
- **ReadParam** 按编号读取机床参数
    - num 参数号