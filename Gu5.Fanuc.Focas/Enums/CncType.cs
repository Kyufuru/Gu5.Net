using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 机床类型
    /// </summary>
    public enum CncType
    {
        [Description("Series 15/15i")]
        S15i,

        [Description("Series 16/16i")]
        S16i,

        [Description("Series 18/18i")]
        S18i,

        [Description("Series 21/21i")]
        S21i,

        [Description("Series 30i")]
        S30i,

        [Description("Series 31i")]
        S31i,

        [Description("Series 32i")]
        S32i,

        [Description("Series 35i")]
        S35i,

        [Description("Series 0i")]
        S0i,

        [Description("Power Mate i-D")]
        PMiD,

        [Description("Power Mate i-H")]
        PMiH,

        [Description("Power Motion i")]
        PMi,

        [Description("其它")]
        Other,

    }
}
