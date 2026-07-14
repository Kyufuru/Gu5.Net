using System;
using System.Collections.Generic;
using System.Linq;

using FreeSql;
using FreeSql.Internal;

namespace Gu5.FreeSql
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public static class Db
    {
        private static Lazy<FreeSqlCloud<string>> _lazy;

        /// <summary>
        /// 跨数据库对象, 用于注册单例
        /// </summary>
        public static FreeSqlCloud<string> FSql => _lazy?.Value;

        /// <summary>
        /// 数据库
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IFreeSql Dbo<T>() => FSql?.Use(typeof(T).Name);


        /// <summary>
        /// 配置
        /// </summary>
        public static Dictionary<string, string> Config { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <returns></returns>
        public static FreeSqlCloud<string> Init(Func<FreeSqlCloud<string>> f)
        {
            if (_lazy is null) _lazy = new Lazy<FreeSqlCloud<string>>(f);
            return FSql;
        }
    }
}
