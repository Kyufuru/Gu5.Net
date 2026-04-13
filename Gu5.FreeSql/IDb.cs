using System.Collections.Generic;

using FreeSql;

namespace Gu5.FreeSql
{
    /// <summary>
    /// 数据库通过此接口注册
    /// </summary>
    internal interface IDb
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
