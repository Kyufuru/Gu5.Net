using System;

namespace Gu5.Core.Animations
{
    /// <summary>
    /// 动画扩展
    /// </summary>
    public static class AnimationExtensions
    {
        /// <summary>
        /// 淡出曲线, y=1-(1-x)^3
        /// </summary>
        /// <param name="this">x值</param>
        /// <returns></returns>
        public static double EaseOut(this double @this) => 1 - Math.Pow(1 - @this, 3);
    }
}
