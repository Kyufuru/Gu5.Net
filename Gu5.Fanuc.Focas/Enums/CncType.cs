using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 机床类型
    /// </summary>
    public enum CncType
    {
        /// <summary>
        /// Series 15/15i
        /// </summary>
        [Description("Series 15/15i")]
        S15i,

        /// <summary>
        /// Series 16/16i
        /// </summary>
        [Description("Series 16/16i")]
        S16i,

        /// <summary>
        /// Series 18/18i
        /// </summary>
        [Description("Series 18/18i")]
        S18i,

        /// <summary>
        /// Series 21/21i
        /// </summary>
        [Description("Series 21/21i")]
        S21i,

        /// <summary>
        /// Series 30i
        /// </summary>
        [Description("Series 30i")]
        S30i,

        /// <summary>
        /// Series 31i
        /// </summary>
        [Description("Series 31i")]
        S31i,

        /// <summary>
        /// Series 32i
        /// </summary>
        [Description("Series 32i")]
        S32i,

        /// <summary>
        /// Series 35i
        /// </summary>
        [Description("Series 35i")]
        S35i,

        /// <summary>
        /// Series 0i
        /// </summary>
        [Description("Series 0i")]
        S0i,

        /// <summary>
        /// Power Mate i-D
        /// </summary>
        [Description("Power Mate i-D")]
        PMiD,

        /// <summary>
        /// Power Mate i-H
        /// </summary>
        [Description("Power Mate i-H")]
        PMiH,

        /// <summary>
        /// Power Motion i
        /// </summary>
        [Description("Power Motion i")]
        PMi,

        /// <summary>
        /// 其它
        /// </summary>
        [Description("其它")]
        Other,

    }
}
