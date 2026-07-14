namespace Gu5.Core.Http
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
        public PageReq Page { get; set; } = new PageReq();
    }
}
