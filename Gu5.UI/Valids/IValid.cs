using AntdUI;

namespace Gu5.UI.Valids
{
    public interface IValid
    {
        /// <summary>
        /// 验证消息
        /// </summary>
        Dictionary<string, string> Msg { get; set; }

        /// <summary>
        /// 清空验证消息
        /// </summary>
        public void ClearMsg();

        /// <summary>
        /// 长度验证
        /// </summary>
        /// <param name="ipt">输入框</param>
        /// <param name="cond">附加条件</param>
        /// <param name="msg">验证消息</param>
        /// <returns></returns>
        public bool IsLong(Input ipt, int len = int.MinValue,
            bool cond = true, string? msg = null);

        /// <summary>
        /// 数字验证
        /// </summary>
        /// <param name="ipt">输入框</param>
        /// <param name="cond">附加条件</param>
        /// <param name="msg">验证消息</param>
        /// <returns>验证结果</returns>
        public bool IsNumber(Input ipt, bool cond = true, string? msg = null);

        /// <summary>
        /// 密码验证
        /// </summary>
        /// <param name="ipt">输入框</param>
        /// <param name="cond">附加条件</param>
        /// <param name="msg">验证消息</param>
        /// <returns>验证结果</returns>
        public bool IsPassword(Input ipt, bool cond = true, string? msg = null);

        /// <summary>
        /// 必填验证
        /// </summary>
        /// <param name="ipt">输入框</param>
        /// <param name="cond">附加条件</param>
        /// <param name="msg">验证消息</param>
        /// <returns>验证结果</returns>
        public bool IsRequired(Input ipt, bool cond = true, string? msg = null);

        /// <summary>
        /// 必填验证
        /// </summary>
        /// <param name="sel">选择框</param>
        /// <param name="cond">附加条件</param>
        /// <param name="msg">验证消息</param>
        /// <returns>验证结果</returns>
        public bool IsRequired(Select sel, bool cond = true, string? msg = null);

        /// <summary>
        /// 必填验证
        /// </summary>
        /// <param name="dt">输入框</param>
        /// <param name="cond">附加条件</param>
        /// <param name="msg">验证消息</param>
        /// <returns>验证结果</returns>
        public bool IsRequired(DatePickerRange dt, bool cond = true, string? msg = null);

        /// <summary>
        /// 密码强度
        /// </summary>
        /// <param name="ipt">输入框</param>
        /// <param name="lbl">强度文本</param>
        /// <param name="minLv">最小强度</param>
        /// <param name="cond">附加条件</param>
        /// <param name="msg">验证消息</param>
        /// <returns>强度</returns>
        public bool IsSafePwd(Input ipt, AntdUI.Label lbl,
            int minLv = 0, bool cond = true, string? msg = null);

        /// <summary>
        /// 自定义数字验证
        /// </summary>
        /// <param name="ipt">数字输入框</param>
        /// <param name="isValid">条件</param>
        /// <returns>验证结果</returns>
        public bool IsValid(InputNumber ipt, bool isValid, string? msg = null);

        /// <summary>
        /// 自定义验证
        /// </summary>
        /// <param name="ipt">输入框控件</param>
        /// <param name="isValid">附加条件</param>
        /// <returns>验证结果</returns>
        public bool IsValid(Input ipt, bool isValid, string? msg = null);

        /// <summary>
        /// 添加验证消息
        /// </summary>
        /// <param name="name">验证名称</param>
        /// <param name="msg">验证消息</param>
        public void SetMsg(string name, string msg);

        /// <summary>
        /// 添加验证消息
        /// </summary>
        /// <param name="ctl">验证控件</param>
        /// <param name="msg">验证消息</param>
        public void SetMsg(Control ctl, string msg);

        /// <summary>
        /// 添加验证消息
        /// </summary>
        /// <param name="ctl">验证控件</param>
        /// <param name="isValid">验证状态</param>
        /// <param name="msg">验证消息</param>
        public void SetMsg(Control ctl, string msg, bool isValid);

        /// <summary>
        /// 显示验证消息
        /// </summary>
        /// <returns>验证消息</returns>
        public string? MsgShow();

        /// <summary>
        /// 密码校验
        /// </summary>
        /// <param name="d">控件</param>
        /// <param name="lb">等级标签</param>
        /// <param name="len">最小长度</param>
        /// <returns></returns>
        bool IsPassword(Input d, AntdUI.Label lb, int len = 0);
    }
}