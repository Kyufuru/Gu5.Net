namespace Gu5.Framework.Core
{
    /// <summary>
    /// 操作失败, [消息]
    /// </summary>
    /// <param name="msg">消息</param>
    /// <param name="pre">前缀</param>
    /// <param name="code">代码</param>
    public class ZException(string? msg = null, string? pre = null, int code = 400) 
        : Exception(ToString(pre, msg))
    {
        public int Code { get; set; } = code;

        private static string ToString(string? pre, string? msg)
        {
            var p = $"{pre ?? "操作失败, "}";
            var m = $"{ msg ?? "发生错误" }";
            if (m.Contains(p)) return m;
            else return $"{p}{m}";
        }
    }

    /// <summary>
    /// 数据已存在
    /// </summary>
    public class ZExiException(string? prop = null, string? msg = null) 
        : ZException($"{prop ?? "数据"}{msg ?? "已存在"}") { }

    /// <summary>
    /// 未选择[项]
    /// </summary>
    /// <param name="name"></param>
    /// <param name="msg"></param>
    public class ZSelException(string? name = null, string? msg = null) 
        : ZException($"{msg ?? "未选择"}{name ?? "项"}") { }

    /// <summary>
    /// 缺少必填项
    /// </summary>
    /// <param name="name">字段名称</param>
    /// <param name="msg">信息</param>
    public class ZMustException(string? name = null, string? msg = null) 
        : ZException($"{msg ?? "缺少必填项"}[{name}]") { }

    /// <summary>
    /// 数据不存在
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="idx">行号</param>
    public class ZMissException(string? prop = null, int? idx = null) 
        : ZException($"{prop ?? "数据"}不存在(行:{idx ?? 1})", code: 404) { }

    /// <summary>
    /// 缺少数据
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="idx">行号</param>
    public class ZLackException(string? prop = null, int? idx = null) 
        : ZException($"缺少{prop ?? "数据"}(行:{idx ?? 1})", code: 404) { }

    /// <summary>
    /// 校验规则失败
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="idx"></param>
    public class ZRuleException(string? msg = null, int? idx = null) 
        : ZException($"{msg ?? "规则错误"}(行:{idx ?? 1})") { }

    /// <summary>
    /// 数据错误
    /// </summary>
    /// <param name="prop"></param>
    public class ZWrongException(string? prop = null)
        : ZException($"{prop ?? "数据"}错误") { }

    /// <summary>
    /// 未实现
    /// </summary>
    public class ZNopeException() 
        : ZException("功能未实现", code: 501) { }
}
