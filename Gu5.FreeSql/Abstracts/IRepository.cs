using System.Collections.Generic;

namespace Gu5.FreeSql.Abstracts
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TKey">标识类型</typeparam>
    public interface IRepository<T, TKey>
        where T : class, new()
    {
        /// <summary>
        /// 数据库对象
        /// </summary>
        IFreeSql Dbo { get; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="l">列表</param>
        /// <returns></returns>
        void Add(IEnumerable<T> l);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        T AddOne(T d);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="l">列表</param>
        void Del(IEnumerable<T> l);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">标识</param>
        void DelOne(TKey id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="l">列表</param>
        void SetAll(IEnumerable<T> l);

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns>列表</returns>
        List<T> GetAll();

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns>列表</returns>
        List<TR> GetAll<TR>();

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>对象</returns>
        T GetOne(TKey id);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>对象</returns>
        TR GetOne<TR>(TKey id);
    }

    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IRepository<T> : IRepository<T, int> where T : class, new() { }
}
