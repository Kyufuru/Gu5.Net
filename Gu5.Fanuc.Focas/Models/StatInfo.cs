using Gu5.Fanuc.Focas.Enums;

namespace Gu5.Fanuc.Focas.Models
{
    /// <summary>
    /// 机床信息
    /// </summary>
    public class StatInfo
    {
        /// <summary>
        /// T/M 模式
        /// </summary>
        public TMMode TMMode { get; set; } = TMMode.T;

        /// <summary>
        /// 自动模式
        /// </summary>
        public AutoMode AutoMode { get; set; } = AutoMode.MDI;

        /// <summary>
        /// 运行状态
        /// </summary>
        public RunStatus RunState { get; set; } = RunStatus.Reset;

        /// <summary>
        /// 轴运动状态
        /// </summary>
        public AxisMoveState AxisMoveState { get; set; } = AxisMoveState.None;

        /// <summary>
        /// M/S/T/B 功能状态
        /// </summary>
        public MstbStatus MstbStatus { get; set; } = MstbStatus.None;

        /// <summary>
        /// 急停状态
        /// </summary>
        public EmergencyStatus EmergencyStatus { get; set; } = EmergencyStatus.Off;

        /// <summary>
        /// 报警状态
        /// </summary>
        public AlarmStatus AlarmStatus { get; set; } = AlarmStatus.Off;

        /// <summary>
        /// 程序编辑状态
        /// </summary>
        public ProgramEditStatus ProgramEditStatus { get; set; } = ProgramEditStatus.None;

        /// <summary>
        /// 最大轴数
        /// </summary>
        public int MaxAxis { get; set; } = 0;

        /// <summary>
        /// 机床型号
        /// </summary>
        public CncType Type { get; set; } = CncType.Other;

        /// <summary>
        /// 主程序号
        /// </summary>
        public int Program { get; set; } = 0;

        /// <summary>
        /// 子程序号(运行程序号)
        /// </summary>
        public int SubProgram { get; set; } = 0;
    }
}
