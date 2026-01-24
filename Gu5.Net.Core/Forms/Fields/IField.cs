using Gu5.Net.Core.Enums;
using Gu5.Net.Core.Models;

namespace Gu5.Net.Core.Forms.Fields
{
    /// <summary>
    /// 表单项
    /// </summary>
    public interface IField<T>
    {
        /// <summary>
        /// 标识符
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 类型
        /// </summary>
        FieldType Type { get; }

        /// <summary>
        /// 启用
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// 构建筛选项
        /// </summary>
        /// <returns></returns>
        GroupFilter Build();
    }
}
