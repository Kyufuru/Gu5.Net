using FreeScheduler;

using Gu5.AspNet.Abstracts;

namespace Gu5.FreeSql.Abstracts
{
    /// <summary>
    /// 需要执行定时调度的任务, 需实现此接口
    /// </summary>
    public interface ISchedule : IInject
    {
        /// <summary>
        /// 使用调度器方法创建任务
        /// </summary>
        /// <param name="d">调度器</param>
        string AddTasks(Scheduler d);

        /// <summary>
        /// 任务触发事件
        /// </summary>
        /// <param name="d">任务信息</param>
        void OnExecuting(TaskInfo d);
    }
}
