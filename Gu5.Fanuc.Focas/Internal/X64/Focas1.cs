using System;
using System.Net;
using System.Reflection;

using Gu5.Fanuc.Focas.Enums;
using Gu5.Fanuc.Focas.Models;

namespace Gu5.Fanuc.Focas.Internal.X64
{
    internal sealed class Focas1 : BaseFocas1
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="host">主机</param>
        /// <param name="port">端口</param>
        /// <param name="timeout">超时</param>
        public Focas1(IPAddress host, ushort port, int timeout) 
            : base(host, port, timeout) { }

        /// <inheritdoc />
        public override void Connect()
        {
            var rs = Native.cnc_allclibhndl3(
                $"{Host}", Port, Timeout, out var ptr);
            Valid(rs);

            Handle = new IntPtr(ptr);
        }

        /// <inheritdoc />
        public override void Disconnect()
        {
            var rs = Native.cnc_freelibhndl(Hdl);
            Valid(rs);
        }

        /// <inheritdoc />
        public override StatInfo GetStatInfo()
        {
            var d1 = new Native.ODBST();
            var rs1 = Native.cnc_statinfo(Hdl, d1);
            Valid(rs1);

            var d2 = new Native.ODBSYS();
            var rs2 = Native.cnc_sysinfo(Hdl, d2);
            Valid(rs2);

            var d3 = new Native.ODBPRO();
            var rs3 = Native.cnc_rdprgnum(Hdl, d3);
            Valid(rs3);

            return new StatInfo()
            {
                TMMode = (TMMode)d1.tmmode,
                AutoMode = (AutoMode)d1.aut,
                RunState = (RunStatus)d1.run,
                AxisMoveState = (AxisMoveState)d1.motion,
                MstbStatus = (MstbStatus)d1.mstb,
                EmergencyStatus = (EmergencyStatus)d1.emergency,
                AlarmStatus = (AlarmStatus)d1.alarm,
                ProgramEditStatus = (ProgramEditStatus)d1.edit,

                MaxAxis = d2.max_axis,
                Type = GetCncType($"{d2.cnc_type[0]}{d2.cnc_type[1]}"),
                Program = d3.mdata,
                SubProgram = d3.data,
            };
        }

        /// <summary>
        /// 获取机床类型
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static CncType GetCncType(string d)
        {
            switch (d)
            {
                case "15":
                    return CncType.S15i;
                case "16":
                    return CncType.S16i;
                case "18":
                    return CncType.S18i;
                case "21":
                    return CncType.S21i;
                case "30":
                    return CncType.S30i;
                case "31":
                    return CncType.S31i;
                case "32":
                    return CncType.S32i;
                case "35":
                    return CncType.S35i;
                case " 0":
                    return CncType.S0i;
                case "PD":
                    return CncType.PMiD;
                case "PH":
                    return CncType.PMiH;
                case "PM":
                    return CncType.PMi;
                default:
                    return CncType.Other;
            }
        }

        /// <summary>
        /// 获取轴数量
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static int GetAxisCount(Native.ODBPOS d) =>
            d.GetType().GetFields(
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly
            ).Length;

        /// <inheritdoc />
        public override ToolInfo GetToolInfo()
        {
            var d1 = new Native.ODBACT();
            var rs1 = Native.cnc_actf(Hdl, d1);
            Valid(rs1);

            var d2 = new Native.ODBPOS();
            var cnt = (short)GetAxisCount(d2);
            var rs2 = Native.cnc_rdposition(Hdl, (short)PosType.All, ref cnt, d2);
            Valid(rs2);

            return new ToolInfo()
            {
                FeedRate = d1.data,
                XAbs = FromSciNot(d2.p1.abs.data, d2.p1.abs.dec),
                YAbs = FromSciNot(d2.p2.abs.data, d2.p2.abs.dec),
                X = FromSciNot(d2.p1.rel.data, d2.p1.rel.dec),
                Y = FromSciNot(d2.p2.rel.data, d2.p2.rel.dec),
            };
        }

        /// <summary>
        /// 科学计数法
        /// </summary>
        /// <param name="d"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private static double FromSciNot(int d, int p) => d * Math.Pow(10, p);

        /// <inheritdoc />
        public override SpindleInfo GetSpindleInfo()
        {
            var rspd = new Native.ODBACT();
            var rs = Native.cnc_acts(Hdl, rspd);

            Valid(rs);

            short cnt = 3;
            var load = new Native.ODBSPLOAD();
            var rs2 = Native.cnc_rdspmeter(Hdl, (short)SpindleType.All, ref cnt, load);

            return new SpindleInfo()
            {
                RSpeed = rspd.data,
                Load = load.spload1.spload.data,
            };
        }


        private const int BATCH_COUNT = 6711;
        private const int TOTAL_COUNT = 6712;
        private const int TOTAL_POWER_TM = 6750;
        private const int TOTAL_WORK_TM_SEC = 6751;
        private const int TOTAL_WORK_TM = 6751;
        private const int TOTAL_PROC_TM = 6753;

        /// <inheritdoc />
        public override ProcInfo GetProcInfo()
        {
            return new ProcInfo()
            {
                BatchQty = ReadParam(BATCH_COUNT),
                TotalQty = ReadParam(TOTAL_COUNT),
                TotalPowerTime = ReadParam(TOTAL_POWER_TM),
                TotalWorkTime = 
                    ReadParam(TOTAL_WORK_TM_SEC) + 
                    ReadParam(TOTAL_WORK_TM),
                TotalProcTime = ReadParam(TOTAL_PROC_TM),
            };
        }

        /// <inheritdoc />
        public override int ReadParam(short num)
        {
            var d = new Native.IODBPSD_1();
            var rs = Native.cnc_rdparam(Hdl, num, 0, 8, d);

            Valid(rs);

            return d.ldata;
        }

    }
}
