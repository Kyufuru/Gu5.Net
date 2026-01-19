# Gu5.Framework.Device.Focas

## Fanuc 数控机床数据采集库

### 使用说明

- 下载 [Funac Focas Library](https://github.com/wheeliar/FANUC_Focas_API/tree/main)
- 添加 dll 到指定目录
    a. `C:\\Windows\System32` (32 位)
    b. `C:\\Windows\System` (64 位)

| 名称 | 环境 | 描述 |
| --- | --- | --- |
| fwlib64.dll | x64 | FOCAS1 主库 |
| fwlibe64.dll | x64 | Ethernet 通信支持 |
| fwlib30i64.dll | x64 | 0i-F / 30i / PLUS 系列支持 |
| fwlib32.dll | x86 | FOCAS1 主库 |
| fwlibe1.dll | x86 | Ethernet 通信支持 |
| fwlib30i.dll | x86 | 0i-F / 30i / PLUS 系列支持 |

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