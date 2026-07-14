using System.Collections.Generic;

using FreeScheduler;

using Gu5.FreeSql.Abstracts;

namespace Gu5.FreeSql
{
    /// <summary>
    /// 任务调度服务
    /// </summary>
    public static class Schedule
    {
        /// <summary>
        /// 任务调度器
        /// </summary>
        public static Scheduler FSche { get; set; } = new FreeSchedulerBuilder().Build();

        /// <summary>
        /// 任务列表
        /// </summary>
        public static Dictionary<string, ISchedule> Jobs { get; set; } = 
            new Dictionary<string, ISchedule>();
    }
}
