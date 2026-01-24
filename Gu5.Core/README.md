# Gu5.Core

.NET 通用工具库

## 安装与使用

```Bash
dotnet add package Gu5.Core
```

```CSharp
using Gu5.Core
```

### 功能列表

#### 异常

|名称|参数|默认值|
|---|---|---|
|GException|msg,pre,code|操作失败, 发生错误|
|GExiException|prop,msg|数据已存在|
|GSelException|name,msg|未选择数据项|
|GMustException|name,msg|缺少必填项|
|GMissException|name,msg|数据不存在|
|GRuleException|name,msg|规则错误|
|GWrongException|name,msg|数据错误|
|GNopeException|name,msg|功能未实现|

#### 工具

- 计时器扩展

```CSharp
var tw = new TimeWatch();

tw.Start();
// ...Run Task
tw.Stop();

var start = tw.BeginTime;
var end = tw.EndTime;
var dur = tw.Elapsed.TotalMilliseconds;

Console.WriteLine($"{start} - {end}: {dur} ms")
```

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