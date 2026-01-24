using System;

namespace Gu5.Core
{
    /// <summary>
    /// 操作失败, [消息]
    /// </summary>
    public class GException : Exception
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="pre">前缀</param>
        /// <param name="code">错误码</param>
        public GException(string msg = null, string pre = null, int code = 400) : 
            base(ToString(pre, msg)) { Code = code; }
        private static string ToString(string pre, string msg)
        {
            var p = $"{pre ?? "操作失败, "}";
            var m = $"{msg ?? "发生错误"}";
            if (m.Contains(p)) return m;
            else return $"{p}{m}";
        }
    }

    /// <summary>
    /// 数据已存在
    /// </summary>
    public class GExiException : GException
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="prop">参数</param>
        /// <param name="msg">消息</param>
        public GExiException(string prop = null, string msg = null) : 
            base($"{prop ?? "数据"}{msg ?? "已存在"}") { }
    }

    /// <summary>
    /// 未选择[数据项]
    /// </summary>
    public class GSelException : GException
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="msg">消息</param>
        public GSelException(string name = null, string msg = null) : 
            base($"{msg ?? "未选择"}{name ?? "数据项"}") { }
    }

    /// <summary>
    /// 缺少必填项
    /// </summary>
    public class GMustException : GException
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="msg">消息</param>
        public GMustException(string name = null, string msg = null) : 
            base($"{msg ?? "缺少必填项"}{(name == null ? "" : $"[{name}]")}") { }
    }

    /// <summary>
    /// 数据不存在
    /// </summary>
    public class GMissException : GException
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="prop">参数</param>
        /// <param name="idx">索引</param>
        public GMissException(string prop = null, int? idx = null) : 
            base($"{prop ?? "数据"}不存在{(idx == null ? "" : $"(行:{idx ?? 1})")}", code: 404) { }
    }

    /// <summary>
    /// 校验规则失败
    /// </summary>
    public class GRuleException : GException
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="idx">索引</param>
        public GRuleException(string msg = null, int? idx = null) :
            base($"{msg ?? "规则错误"}{(idx == null ? "" : $"(行:{idx ?? 1})")}") { }
    }

    /// <summary>
    /// 数据错误
    /// </summary>
    public class GWrongException : GException
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="prop">参数</param>
        public GWrongException(string prop = null) : base($"{prop ?? "数据"}错误") { }
    }

    /// <summary>
    /// 未实现
    /// </summary>
    public class GNopeException : GException 
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public GNopeException() : base("功能未实现", code: 501) { }
    }
}
