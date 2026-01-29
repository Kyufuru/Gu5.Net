using System.ComponentModel;

namespace Gu5.UI.Models
{
    /// <summary>
    /// 控件组映射
    /// </summary>
    internal class GroupMap
    {
        /// <summary>
        /// 控件
        /// </summary>
        public Control? Control { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public PropertyDescriptor? Prop { get; set; }
    }
}
