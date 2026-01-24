using System;

using Gu5.Fanuc.Focas.Models;

namespace Gu5.Fanuc.Focas
{
    /// <summary>
    /// 公共接口
    /// </summary>
    public interface IFocas1: IDisposable
    {
        /// <summary>
        /// 连接
        /// </summary>
        void Connect();

        /// <summary>
        /// 断开
        /// </summary>
        void Disconnect();

        /// <summary>
        /// 获取机床信息
        /// </summary>
        /// <returns>机床信息</returns>
        StatInfo GetStatInfo();

        /// <summary>
        /// 获取刀具状态
        /// </summary>
        /// <returns>刀具状态</returns>
        ToolInfo GetToolInfo();

        /// <summary>
        /// 获取主轴状态
        /// </summary>
        /// <returns>主轴状态</returns>
        SpindleInfo GetSpindleInfo();

        /// <summary>
        /// 获取加工信息
        /// </summary>
        /// <returns>加工信息</returns>
        ProcInfo GetProcInfo();

        /// <summary>
        /// 读取参数
        /// </summary>
        /// <param name="num">参数号</param>
        /// <returns></returns>
        int ReadParam(short num);
    }
}
