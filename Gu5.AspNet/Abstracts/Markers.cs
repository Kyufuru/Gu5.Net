namespace Gu5.AspNet.Abstracts
{
    /// <summary>
    /// 通过实现该接口或派生接口, 自动扫描注入对象
    /// </summary>
    public interface IInject { }

    /// <summary>
    /// 全局单例标记
    /// </summary>
    public interface ISingleton : IInject { }

    /// <summary>
    /// 作用域单例标记
    /// </summary>
    public interface IScoped : IInject { }

    /// <summary>
    /// 瞬态实例标记
    /// </summary>
    public interface ITransient : IInject { }
}
