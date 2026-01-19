namespace Gu5.Framework.Core.Model
{
    /// <summary>
    /// 基础筛选实体
    /// </summary>
    public class BaseFlt
    {
        /// <summary>
        /// 搜索
        /// </summary>
        public string Query { get; set; } = string.Empty;

        /// <summary>
        /// 分页
        /// </summary>
        public PageReq Req { get; set; } = new PageReq();
    }
}
