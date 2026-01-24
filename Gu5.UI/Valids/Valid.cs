using System.Text.RegularExpressions;

using AntdUI;

namespace Gu5.Net.Winforms.UI.Valids
{
    public class Valid : IValid
    {
        /// <summary>
        /// 数字正则
        /// </summary>
        /// <returns></returns>
        public static readonly Regex RegNum = new(@"\d*");

        /// <summary>
        /// 密码正则
        /// </summary>
        /// <returns></returns>
        public static readonly Regex RegPwd = new("^[\u4e00-\u9fa5\b]$");

        /// <summary>
        /// 弱强度密码正则
        /// </summary>
        public static readonly Regex RegPwdLv1
            = new("^[a-zA-Z]+$|^\\d+$|^[^\\da-zA-Z\\s]+$");

        /// <summary>
        /// 中强度密码正则
        /// </summary>
        public static readonly Regex RegPwdLv2
            = new("^(?![a-zA-Z]+$)(?!\\d+$)(?![^\\da-zA-Z\\s]+$).+$");

        /// <summary>
        /// 高强度密码正则
        /// </summary>
        public static readonly Regex RegPwdLv3
            = new("^(?=.*[0-9])(?!.*(\\d)\\1\\1)(?!.*(?:012|123|234|345|456|567|678|789|987|876|765|654|543|432|321|210))(?=.*[a-zA-Z])(?=.*[^\\da-zA-Z]).+$");

        /// <inheritdoc/>
        public Dictionary<string, string> Msg { get; set; } = [];

        /// <summary>
        /// 检验结果
        /// </summary>
        /// <returns></returns>
        public bool Result => Msg.Count == 0;

        /// <inheritdoc/>
        public void ClearMsg() => Msg.Clear();

        public bool IsLong(Input ipt, int len = int.MinValue,
            bool cond = true, string? msg = null)
        {
            var isValid = cond && ipt.Text.Length >= len;
            ipt.Status = isValid ? TType.Success : TType.Error;
            if (!isValid && ipt.Tag is not null)
                Msg[$"{ipt.Tag}"] = msg ?? $"文本长度必须不少于 {len} 个字符";

            return isValid;
        }

        /// <inheritdoc/>
        public bool IsNumber(Input ipt, bool cond = true, string? msg = null)
        {
            var isValid = cond && RegNum.IsMatch(ipt.Text);
            ipt.Status = isValid ? TType.Success : TType.Error;
            if (!isValid && ipt.Tag is not null)
                Msg[$"{ipt.Tag}"] = msg ?? "内容含有非法字符";

            return isValid;
        }

        /// <inheritdoc/>
        public bool IsPassword(Input ipt, bool cond = true, string? msg = null)
        {
            var isValid = cond && RegPwd.IsMatch(ipt.Text);
            ipt.Status = isValid ? TType.Success : TType.Error;
            if (!isValid && ipt.Tag is not null)
                Msg[$"{ipt.Tag}"] = msg ?? "内容含有非法字符";

            return isValid;
        }

        /// <inheritdoc/>
        public bool IsRequired(Input ipt, bool cond = true, string? msg = null)
        {
            var isValid = cond && !string.IsNullOrEmpty(ipt.Text);
            ipt.Status = isValid ? TType.Success : TType.Error;
            if (!isValid && ipt.Tag is not null)
                Msg[$"{ipt.Tag}"] = msg ?? "内容不能为空";

            return isValid;
        }

        /// <inheritdoc/>
        public bool IsRequired(DatePickerRange dt, bool cond = true, string? msg = null)
        {
            var isValid = cond && dt.Value is not null;
            dt.Status = isValid ? TType.Success : TType.Error;
            if (!isValid && dt.Tag is not null)
                Msg[$"{dt.Tag}"] = msg ?? "开始或结束日期不能为空";

            return isValid;
        }

        public bool IsRequired(Select sel, bool cond = true, string? msg = null)
        {
            var isValid = cond && !string.IsNullOrEmpty(sel.Text);
            sel.Status = isValid ? TType.Success : TType.Error;
            if (!isValid && sel.Tag is not null)
                Msg[$"{sel.Tag}"] = msg ?? "内容不能为空";

            return isValid;
        }

        /// <inheritdoc/>
        public bool IsRequired(AntdUI.Button btn, bool cond = true, string? msg = null)
        {
            var isValid = cond && !string.IsNullOrEmpty(btn.Text);
            if (!isValid && btn.Tag is not null)
                Msg[$"{btn.Tag}"] = msg ?? "内容不能为空";

            return isValid;
        }

        /// <inheritdoc />/>
        public bool IsPassword(Input d, AntdUI.Label lb, int lv = 0) =>
            IsRequired(d) && IsLong(d, lv) && IsSafePwd(d, lb);

        /// <inheritdoc/>
        public bool IsSafePwd(Input ipt, AntdUI.Label lbl,
            int minLv = 0, bool cond = true, string? msg = null)
        {
            var lv = RegPwdLv3.IsMatch(ipt.Text) ? 3
                : RegPwdLv2.IsMatch(ipt.Text) ? 2
                : RegPwdLv1.IsMatch(ipt.Text) ? 1
                : 0;

            void SetUI()
            {
                lbl.Text = lv switch
                {
                    3 => "密码强度: 强",
                    2 => "密码强度: 中",
                    _ => "密码强度: 弱",
                };

                lbl.ForeColor = lv switch
                {
                    3 => Color.Green,
                    2 => Color.Orange,
                    _ => Color.Red,
                };

                lbl.Refresh();
            }

            if (lbl.InvokeRequired)
                lbl.Invoke(SetUI);
            else SetUI();

            var isValid = lv >= minLv;
            if (!isValid && ipt.Tag is not null)
                Msg[$"{ipt.Tag}"] = msg ?? "密码强度太低";
            return isValid;
        }

        /// <inheritdoc/>
        public bool IsValid(Input ipt, bool isValid, string? msg = null)
        {
            ipt.Status = isValid ? TType.Success : TType.Error;
            if (!isValid && ipt.Tag is not null)
                Msg[$"{ipt.Tag}"] = msg ?? "输入内容无效";

            return isValid;
        }

        /// <inheritdoc/>
        public bool IsValid(InputNumber ipt, bool isValid, string? msg = null) =>
            IsValid(ipt as Input, isValid, msg);

        /// <inheritdoc/>
        public void SetMsg(string name, string msg)
            => Msg.TryAdd(name, msg);

        /// <inheritdoc/>
        public void SetMsg(Control ctl, string msg)
            => SetMsg($"{ctl.Tag}", msg);

        /// <inheritdoc/>
        public void SetMsg(Control ctl, string msg, bool isValid)
            => SetMsg(ctl, isValid ? string.Empty : msg);

        /// <inheritdoc/>
        public string? MsgShow()
        {
            var msg = Msg
                .Where(x => !string.IsNullOrEmpty(x.Value))
                .Select(x => $"[{x.Key}] {x.Value}")
                .Reverse();

            if (!msg.Any()) return string.Empty;
            return string.Join(Environment.NewLine, msg);
        }

        /// <summary>
        /// 打印消息
        /// </summary>
        /// <returns>消息</returns>
        public override string? ToString() => MsgShow();
    }
}