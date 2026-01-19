using System;

namespace Gu5.Framework.Core
{
    /// <summary>
    /// 操作失败, [消息]
    /// </summary>
    public class ZException: Exception
    {
        public ZException(string msg = null, string pre = null, int code = 400) : 
            base(ToString(pre, msg)) { Code = code; }
        public int Code { get; set; }
        private static string ToString(string pre, string msg)
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
    public class ZExiException : ZException
    {
        public ZExiException(string prop = null, string msg = null) : 
            base($"{prop ?? "数据"}{msg ?? "已存在"}") { }
    }

    /// <summary>
    /// 未选择[项]
    /// </summary>
    public class ZSelException : ZException
    {
        public ZSelException(string name = null, string msg = null) : 
            base($"{msg ?? "未选择"}{name ?? "项"}") { }
    }

    /// <summary>
    /// 缺少必填项
    /// </summary>
    public class ZMustException : ZException
    {
        public ZMustException(string name = null, string msg = null) : 
            base($"{msg ?? "缺少必填项"}[{name}]") { }
    }

    /// <summary>
    /// 数据不存在
    /// </summary>
    public class ZMissException : ZException
    {
        public ZMissException(string prop = null, int? idx = null) : 
            base($"{prop ?? "数据"}不存在(行:{idx ?? 1})", code: 404) { }
    }

    /// <summary>
    /// 缺少数据
    /// </summary>
    public class ZLackException : ZException
    {
        public ZLackException(string prop = null, int? idx = null) :
            base($"缺少{prop ?? "数据"}(行:{idx ?? 1})", code: 404) { }
    }

    /// <summary>
    /// 校验规则失败
    /// </summary>
    public class ZRuleException : ZException
    {
        public ZRuleException(string msg = null, int? idx = null) :
            base($"{msg ?? "规则错误"}(行:{idx ?? 1})") { }
    }

    /// <summary>
    /// 数据错误
    /// </summary>
    /// <param name="prop"></param>
    public class ZWrongException : ZException
    {
        public ZWrongException(string prop = null) : 
            base($"{prop ?? "数据"}错误") { }
    }

    /// <summary>
    /// 未实现
    /// </summary>
    public class ZNopeException : ZException 
    {
        public ZNopeException() : base("功能未实现", code: 501) { }
    }
}
