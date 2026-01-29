using System.ComponentModel;

namespace Gu5.UI.Enums
{
    /// <summary>
    /// 业务类型
    /// </summary>
    public enum IcType
    {
        /// <summary>
        /// 创建
        /// </summary>
        [Description("创建")]
        Add,

        /// <summary>
        /// 编辑
        /// </summary>
        [Description("编辑")]
        Set,

        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Del,

        /// <summary>
        /// 导入
        /// </summary>
        [Description("导入")]
        Imp,

        /// <summary>
        /// 导出
        /// </summary>
        [Description("导出")]
        Exp,

        /// <summary>
        /// 刷新
        /// </summary>
        [Description("刷新")]
        Get,

        /// <summary>
        /// 搜索
        /// </summary>
        [Description("搜索")]
        Qry,

        /// <summary>
        /// 筛选
        /// </summary>
        [Description("筛选")]
        Flt,

        /// <summary>
        /// 二维码
        /// </summary>
        [Description("二维码")]
        QR,

        /// <summary>
        /// 条码
        /// </summary>
        [Description("条码")]
        Bar,

        /// <summary>
        /// 打印
        /// </summary>
        [Description("打印")]
        Prt,

        /// <summary>
        /// 下载
        /// </summary>
        [Description("下载")]
        Down,

        /// <summary>
        /// 上传
        /// </summary>
        [Description("上传")]
        Up,

        /// <summary>
        /// 保存
        /// </summary>
        [Description("保存")]
        Save,
    }
}
