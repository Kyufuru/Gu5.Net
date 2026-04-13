using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using FreeSql;
using FreeSql.Internal;

namespace Gu5.FreeSql
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public static class Db
    {
        private static readonly Lazy<FreeSqlCloud<string>> _lazy = new Lazy<FreeSqlCloud<string>>(NewDb);

        /// <summary>
        /// 数据库
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IFreeSql Dbo<T>() => _lazy.Value.Use(typeof(T).Name);


        /// <summary>
        /// 配置
        /// </summary>
        public static Dictionary<string, string> Config { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <returns></returns>
        private static FreeSqlCloud<string> NewDb()
        {
            Utils.IsStrict = false;

            var db = new FreeSqlCloud<string>();

            var tps = Assembly
                .GetExecutingAssembly().GetTypes()
                .Where(t =>
                    typeof(IDb).IsAssignableFrom(t) &&
                    !t.IsInterface && !t.IsAbstract);

            foreach (var x in tps)
            {
                var idb = Activator.CreateInstance(x) as IDb;
                var dbo = idb?.Register(new FreeSqlBuilder(), Config);
                db.Register(x.Name, () => dbo);
            }

            return db;
        }
    }
}
