using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using FreeSql;
using FreeSql.DataAnnotations;
using FreeSql.Internal;

using Gu5.FreeSql.Abstracts;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gu5.FreeSql
{
    public static class Internal
    {
        /// <summary>
        /// 添加数据库服务
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IServiceCollection AddFreeSql(this IServiceCollection @this, ConfigurationManager cfg)
        {
            Db.Config = cfg
                .GetSection("ConnectionStrings").GetChildren()
                .ToDictionary(x => x.Key, x => $"{x.Value}");

            return @this.AddSingleton(sp => Db.Init(() =>
            {
                Utils.IsStrict = false;
                var db = new FreeSqlCloud<string>();

                foreach (var x in sp.GetServices<IDatabase>())
                    db.Register(x.GetType().Name, () => 
                        x.Register(new FreeSqlBuilder(), Db.Config));

                return db;
            }));
        }

        /// <summary>
        /// 添加任务调度服务
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IServiceCollection AddFreeScheduler(this IServiceCollection @this)
        {
            return @this.AddSingleton(sp =>
            {
                Schedule.FSche = new FreeSchedulerBuilder()
                    .UseTimeZone(TimeSpan.FromHours(8))
                    .OnExecuting(x => Schedule.Jobs[x.Id].OnExecuting(x))
                    .Build();

                foreach (var x in sp.GetServices<ISchedule>())
                    Schedule.Jobs[x.AddTasks(Schedule.FSche)] = x;

                return Schedule.FSche;
            });
        }

        /// <summary>
        /// 判断是否需要同步表结构
        /// </summary>
        /// <returns></returns>
        public static bool CanSyncStructure(this Type @this)
        {
            return !@this
                .GetCustomAttributes<TableAttribute>()
                .Any(x => x.DisableSyncStructure);
        }

        /// <summary>
        /// 执行初始化
        /// </summary>
        public static async Task UseDbSeederAsync(this IApplicationBuilder app)
        {
            var sp = app.ApplicationServices;
            var db = sp.GetRequiredService<FreeSqlCloud<string>>();
            var t = typeof(IDbSeeder<,>);

            foreach (var sv in sp.GetServices<IDbSeeder>())
            {
                var g = sv
                    .GetType()
                    .GetInterfaces()
                    .First(x => 
                        x.IsGenericType && 
                        x.GetGenericTypeDefinition() == t)
                    .GetGenericArguments();

                var td = g[0];
                var te = g[1];

                var fsql = db.Use(td.Name);
                if (te.CanSyncStructure())
                    fsql.CodeFirst.SyncStructure(te);
                await sv.OnInitAsync(fsql);
            }
        }
    }
}
