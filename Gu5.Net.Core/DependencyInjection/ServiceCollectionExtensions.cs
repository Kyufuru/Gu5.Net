using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace Gu5.Net.Core.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// 扫描注册 <typeparamref name="T"/> 的实现类型
        /// </summary>
        /// <typeparam name="T">接口类型</typeparam>
        /// <param name="this">服务</param>
        /// <param name="f">操作</param>
        /// <param name="l">程序集<code>Typeof(T).Assembly</code></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddImplOf<T>(this IServiceCollection @this,
            Action<IServiceCollection, Type, Type> f, params Assembly[] l)
        {
            ArgumentNullException.ThrowIfNull(@this);
            ArgumentNullException.ThrowIfNull(f);

            if (l == null || l.Length == 0) 
                throw new ArgumentException("必须显式指定程序集");

            var t = typeof(T);

            var rs = l.Distinct().SelectMany(a =>
            {
                try 
                { 
                    return a.GetTypes(); 
                }
                catch (ReflectionTypeLoadException ex) 
                { 
                    return ex.Types.OfType<Type>(); 
                }
                catch
                {
                    return Type.EmptyTypes;
                }
            }).Where(x => 
                !x.IsAbstract && 
                !x.IsInterface && 
                t.IsAssignableFrom(x)
            );

            foreach (var x in rs) f(@this, t, x);

            return @this;
        }

        /// <summary>
        /// 扫描注册 <typeparamref name="T"/> 的实现类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="srvs">服务</param>
        /// <param name="asms">程序集</param>
        /// <returns></returns>
        public static IServiceCollection AddSingletonOf<T>(
            this IServiceCollection srvs, params Assembly[] asms) =>
            srvs.AddImplOf<T>((s, t, x) => s.AddSingleton(t, x), asms);

        /// <summary>
        /// 扫描注册 <typeparamref name="T"/> 的实现类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="srvs">服务</param>
        /// <param name="asms">程序集</param>
        /// <returns></returns>
        public static IServiceCollection AddScopedOf<T>(
            this IServiceCollection srvs, params Assembly[] asms) =>
            srvs.AddImplOf<T>((s, t, x) => s.AddScoped(t, x), asms);

        /// <summary>
        /// 扫描注册 <typeparamref name="T"/> 的实现类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="srvs">服务</param>
        /// <param name="asms">程序集</param>
        /// <returns></returns>
        public static IServiceCollection AddTransientOf<T>(
            this IServiceCollection srvs, params Assembly[] asms) =>
            srvs.AddImplOf<T>((s, t, x) => s.AddTransient(t, x), asms);
    }
}
