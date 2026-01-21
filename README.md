# Gu5.Net

.NET 通用工具库

## 安装与使用

```Bash
dotnet add package Gu5.Net
```

```CSharp
// .NET 8
using Gu5.Net.Core

// .NET Framework 4.6.1
using Gu5.Framework.Core
```

### 功能列表

#### 函数式编程

- **Then** / **Else** 条件执行

```CSharp
(value > 0)
    .Then(() => Console.WriteLine("OK"))
    .Else(() => Console.WriteLine("NG"));
```

- **Also** / **With** 条件赋值
```CSharp
var rs = new Object()
    .Also(x => x.Init())
    .Also(x => x.Validate());

var len = text.With(x => x.Length);
```

- **Find** / **ForEach** 集合操作扩展
- **Sample** 随机采样
- **At** / **Range** / **Mod** 安全索引
- **GetDescription** 枚举描述

#### 时间序列

- **RangeFrom** 获取时间轴
```CSharp
var timeline = RangeFrom(start, end);
```

- **Resample** 重采样(Pandas `resample` + `last`)
```CSharp
var dict = data.Resample(x => x.Timestamp);
```

- **FFill** Pandas `ffill`
```CSharp
var values = dict.FFill(keys, lim: 3);
```

#### 依赖注入

```CSharp
using Gu5.Framework.Core.DependencyInjection;
```

- **AddImplOf** 扫描注册所有实现
```CSharp
services.AddImplOf<IMyService>(
    (services, serviceType, implType) =>
        services.AddSingleton(serviceType, implType),
    typeof(IMyService).Assembly
);
```

- **AddSingletonOf** / **AddScopedOf** / **AddTransientOf** 全局/实例/单次 生命周期
```CSharp
var asm = typeof(T).Assembly;

services.AddSingletonOf<T>(asm);
services.AddScopedOf<T>(asm);
services.AddTransientOf<T>(asm);
```

### 任务调度
- **Interval**
```CSharp
var sche = new Interval(async () => 
{
    // Task to run
}, 60000);

// 启动
sche.Start();

// 关闭
sche.Stop();
```