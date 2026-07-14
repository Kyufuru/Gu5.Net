using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using FreeSql;
using FreeSql.Internal.Model;

using Gu5.Core.Http;

using MySqlConnector;

using Npgsql;

namespace Gu5.FreeSql
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 反射获 Orm 值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static object GetValue(this FreeSqlBuilder @this, string name)
        {
            var info = @this.GetType().GetField(name,
                BindingFlags.NonPublic | BindingFlags.Instance)
                ?? throw new ArgumentException($"{name} is null");
            return info.GetValue(@this);
        }

        /// <summary>
        /// 执行数据库命令
        /// </summary>
        /// <param name="this"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(this NpgsqlCommand @this, string sql)
        {
            @this.CommandText = sql;
            return @this.ExecuteScalar();
        }

        /// <summary>
        /// 执行数据库命令
        /// </summary>
        /// <param name="this"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(this NpgsqlCommand @this, string sql)
        {
            @this.CommandText = sql;
            return @this.ExecuteNonQuery();
        }

        /// <summary>
        /// 在 UseConnectionString 配置后调用此方法
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static FreeSqlBuilder UseAutoCreateDatabase(this FreeSqlBuilder @this)
        {
            var tp = (DataType?)@this.GetValue("_dataType");
            var cn = $"{@this.GetValue("_masterConnectionString")}";

            if (tp == DataType.PostgreSQL)
            {
                var bd = new NpgsqlConnectionStringBuilder(cn);

                var q1 = $"SELECT COUNT(*) FROM pg_database WHERE datname = '{bd.Database}'";
                var q2 = $"CREATE DATABASE \"{bd.Database}\" WITH OWNER = \"{bd.Username}\"";
                var s = $"Host={bd.Host};Port={bd.Port};Username={bd.Username};Password={bd.Password};Pooling=true";

                using (var conn = new NpgsqlConnection(s))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        if (Convert.ToInt32($"{cmd.ExecuteScalar(q1)}") <= 0)
                            cmd.ExecuteNonQuery(q2);
                    }
                    return @this;
                }
            }

            if (tp == DataType.MySql)
            {
                var bd = new MySqlConnectionStringBuilder(cn);
                var q = 
                    $"USE mysql;CREATE DATABASE IF NOT EXISTS `{bd.Database}` " +
                    $"CHARACTER SET '{bd.CharacterSet}' COLLATE 'utf8mb4_general_ci'";

                var s = 
                    $"Data Source={bd.Server};Port={bd.Port};" +
                    $"User ID={bd.UserID};Password={bd.Password};" +
                    $"Initial Catalog=mysql;Charset=utf8mb4;SslMode=none;" +
                    $"AllowPublicKeyRetrieval=True;Min pool size=1";

                using (var cnn = new MySqlConnection(s))
                {
                    cnn.Open();
                    using (var cmd = cnn.CreateCommand())
                    {
                        cmd.CommandText = q;
                        cmd.ExecuteNonQuery();
                    }
                    return @this;
                }
            }

            return @this;
        }

        /// <summary>
        /// 级联操作
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="this">数据库</param>
        /// <param name="casc">是否级联</param>
        /// <returns></returns>
        public static IBaseRepository<T> Cascade<T>(this IFreeSql @this, bool casc = true) where T : class
        {
            var rs = @this.GetRepository<T>();
            rs.DbContextOptions.EnableCascadeSave = casc;
            return rs;
        }

        /// <summary>
        /// 打印查询语句
        /// </summary>
        /// <param name="this"></param>
        /// <param name="f">打印方法</param>
        /// <returns></returns>
        public static IFreeSql PrintSql(this IFreeSql @this, Action<string> f)
        {
            @this.Aop.CurdBefore += (s, e) =>
            {
                if (f != null) f($"\n{e.Sql}"); 
                else Console.WriteLine($"\n{e.Sql}");
            };
            return @this;
        }

        /// <summary>
        /// 转数据库分页
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static BasePagingInfo ToDbPage(this PageReq @this) =>
            new BasePagingInfo()
            {
                PageNumber = @this.Current,
                PageSize = @this.PageSize,
                Count = @this.Count,
            };

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="this">查询对象</param>
        /// <param name="page">分页实体</param>
        /// <param name="total">总数</param>
        /// <returns></returns>
        public static ISelect<T> Page<T>(this ISelect<T> @this,
            PageReq page, out long total)
        {
            @this.Count(out total);
            if (page.Current < 0) return @this;
            return @this.Page(page.ToDbPage());
        }

        /// <summary>
        /// 判断字段是否在筛选集合中
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <typeparam name="TCol">字段类型</typeparam>
        /// <param name="flt">筛选集合</param>
        /// <param name="sel">字段</param>
        /// <returns></returns>
        public static ISelect<T> WhereIn<T, TCol>(this ISelect<T> @this,
            Expression<Func<T, TCol>> sel, IEnumerable<TCol> flt)
        {

            if (flt is null || !flt.Any()) return @this;

            var exp = Expression.Call
            (
                typeof(Enumerable),
                nameof(Enumerable.Contains),
                new Type[] { typeof(TCol) },
                Expression.Constant(flt),
                sel.Body
            );

            var w = Expression.Lambda<Func<T, bool>>(exp, sel.Parameters[0]);

            return @this.Where(w);
        }

        /// <summary>
        /// 模糊查询判断字段
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <typeparam name="TCol">字段类型</typeparam>
        /// <param name="flt">筛选集合</param>
        /// <param name="sel">字段</param>
        /// <returns></returns>
        public static ISelect<T> WhereLike<T, TCol>(this ISelect<T> @this,
            Expression<Func<T, TCol>> sel, IEnumerable<TCol> flt)
        {
            if (flt is null || !flt.Any()) return @this;

            var p0 = sel.Parameters[0];
            var col = sel.Body;

            Expression exp = null;

            foreach (var x in flt)
            {
                var exp11 = Expression.Constant(x, typeof(string));
                var exp12 = typeof(string).GetMethod
                (
                    nameof(string.Contains),
                    new Type[] { typeof(string) }
                );

                var exp1 = Expression.Call(col, exp12, exp11);

                if (exp is null) exp = exp1;
                else exp = Expression.OrElse(exp, exp1);
            }

            var w = Expression.Lambda<Func<T, bool>>(exp, p0);
            return @this.Where(w);
        }

        /// <summary>
        /// 判断关键词是否在查询字段中
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sel">查询字段</param>
        /// <param name="query">关键词</param>
        /// <returns></returns>
        public static ISelect<T> WhereLike<T>(this ISelect<T> @this,
            Expression<Func<T, string>> sel, string query)
        {
            if (sel == null || string.IsNullOrEmpty(query)) return @this;
            if (!typeof(string).IsAssignableFrom(sel.Body.Type)) return @this;

            var exp1 = Expression.NotEqual(sel.Body,
                    Expression.Constant(null, typeof(string)));

            var exp2 = Expression.Call
            (
                sel.Body,
                typeof(string).GetMethod
                (
                    nameof(string.Contains), 
                    new Type[] { typeof(string) }
                ),
                Expression.Constant(query)
            );

            var exp = Expression.AndAlso(exp1, exp2);
            var w = Expression.Lambda<Func<T, bool>>(exp, sel.Parameters[0]);

            return @this.Where(w);
        }

        /// <summary>
        /// 判断关键词是否在查询字段中
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <typeparam name="TCol">字段类型</typeparam>
        /// <param name="cond">前置条件</param>
        /// <param name="sel">查询字段</param>
        /// <param name="flt">筛选器</param>
        /// <returns></returns>
        public static ISelect<T> WhereLikeIf<T, TCol>(this ISelect<T> @this, bool cond,
            Expression<Func<T, TCol>> sel, IEnumerable<TCol> flt) =>
            cond ? @this.WhereLike(sel, flt) : @this;

        /// <summary>
        /// 判断关键词是否在查询字段中
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="cond">前置条件</param>
        /// <param name="sel">查询字段</param>
        /// <param name="query">关键词</param>
        /// <returns></returns>
        public static ISelect<T> WhereLikeIf<T>(this ISelect<T> @this, bool cond,
            Expression<Func<T, string>> sel, string query) =>
            cond ? @this.WhereLike(sel, query) : @this;

        /// <summary>
        /// 判断日期是否在日期范围中
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sel">查询字段</param>
        /// <param name="tf">开始时间</param>
        /// <param name="tt">结束时间</param>
        /// <returns></returns>
        public static ISelect<T> WhereBetween<T>(this ISelect<T> @this,
            Expression<Func<T, DateTime>> sel, DateTime tf, DateTime tt)
        {
            if (sel == null) return @this;
            if (tf == DateTime.MinValue || tt == DateTime.MinValue) return @this;

            Expression exp = null;

            var exp1 = Expression.Constant(tf, typeof(DateTime?));
            var exp11 = Expression.GreaterThanOrEqual(sel.Body, exp1);

            exp = exp is null ? exp11 : Expression.AndAlso(exp, exp11);

            var exp2 = Expression.Constant(tt, typeof(DateTime?));
            var exp21 = Expression.LessThanOrEqual(sel.Body, exp2);

            exp = exp is null ? exp21 : Expression.AndAlso(exp, exp21);

            if (exp is null) return @this;

            var w = Expression.Lambda<Func<T, bool>>(exp, sel.Parameters[0]);

            return @this.Where(w);
        }

        /// <summary>
        /// 判断日期是否在日期范围中
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sel">查询字段</param>
        /// <param name="tf">开始时间</param>
        /// <param name="tt">结束时间</param>
        /// <returns></returns>
        public static ISelect<T> WhereBetween<T>(this ISelect<T> @this,
            Expression<Func<T, DateTime?>> sel, DateTime? tf, DateTime? tt)
        {
            if (sel == null) return @this;

            Expression exp = null;

            if (tf.HasValue)
            {
                var e1 = sel.Body;
                var e2 = Expression.Constant(tf, typeof(DateTime?));
                var ge = Expression.GreaterThanOrEqual(e1, e2);

                exp = exp == null ? ge : Expression.AndAlso(exp, ge);
            }

            if (tt.HasValue)
            {
                var e1 = sel.Body;
                var e2 = Expression.Constant(tt, typeof(DateTime?));
                var le = Expression.LessThanOrEqual(e1, e2);

                exp = exp == null ? le : Expression.AndAlso(exp, le);
            }

            if (exp == null) return @this;

            var w = Expression.Lambda<Func<T, bool>>(exp, sel.Parameters[0]);
            return @this.Where(w);
        }
    }
}
