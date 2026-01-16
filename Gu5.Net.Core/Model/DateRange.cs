namespace Gu5.Net.Core.Model
{
    /// <summary>
    /// 日期范围
    /// </summary>
    public class DateRange
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dts"></param>
        public DateRange(params DateTime?[] dts)
        {
            Start = dts[0];
            End = dts[1];
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dts"></param>
        public DateRange(params DateTime[] dts)
        {
            Start = dts[0]; End = dts[1];
        }

        /// <summary>
        /// 重载赋值运算符
        /// </summary>
        /// <param name="dts"></param>
        public static implicit operator DateRange(DateTime[]? dts)
            => dts is null ? new DateRange() : new DateRange(dts);

        /// <summary>
        /// 重载赋值运算符
        /// </summary>
        /// <param name="dts"></param>
        public static implicit operator DateRange(DateTime?[]? dts)
            => dts is null ? new DateRange() : new DateRange(dts);

        /// <summary>
        /// 转数组
        /// </summary>
        /// <returns></returns>
        public DateTime[]? ToNullArray()
        {
            if (Start is null || End is null) return null;

            var td = DateTime.Today;
            return [Start ?? td, End ?? td];
        }
        
    }

}