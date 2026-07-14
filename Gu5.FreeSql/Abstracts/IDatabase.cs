using System.Collections.Generic;

using FreeSql;

using Gu5.AspNet.Abstracts;

namespace Gu5.FreeSql.Abstracts
{
    /// <summary>
    /// 数据库通过此接口注册
    /// </summary>
    public interface IDatabase : IInject
    {
        /// <summary>
        /// 注册方法
        /// </summary>
        /// <param name="bd">数据库配置</param>
        /// <param name="conns">连接字符串</param>
        /// <returns></returns>
        IFreeSql Register(FreeSqlBuilder bd, Dictionary<string, string> conns);
    }
}
