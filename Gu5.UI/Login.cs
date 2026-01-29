using System.ComponentModel;

using Gu5.UI.Extensions;
using Gu5.UI.Valids;

namespace Gu5.UI
{
    /// <summary>
    /// 登录
    /// </summary>
    [DefaultEvent("OnLogin")]
    public partial class Login : UserControl
    {
        [Category("外观")]
        [Description("图标")]
        public Image Icon
        {
            get => Ic.Image;
            set => Ic.Image = value;
        }

        [Category("外观")]
        [Description("加载")]
        public bool Loading
        {
            get => BtOk.Loading;
            set => BtOk.Loading = value;
        }

        [Category("数据")]
        [Description("标题")]
        public string? Title
        {
            get => LbTit.Text;
            set => LbTit.Text = value;
        }

        [Category("数据")]
        [Description("简介")]
        public string? SubTitle
        {
            get => LbDes.Text;
            set => LbDes.Text = value;
        }

        [Category("数据")]
        [Description("版本号")]
        public string? Version
        {
            get => LbVer.Text;
            set => LbVer.Text = value;
        }

        [Category("数据")]
        [Description("用户名")]
        public string Username
        {
            get => IpAcc.Text;
            set => IpAcc.Text = value;
        }

        [Category("数据")]
        [Description("密码")]
        public string Password
        {
            get => IpPwd.Text;
            set => IpPwd.Text = value;
        }

        [Category("数据")]
        [Description("记住用户名")]
        public bool IsRemember
        {
            get => Ck.Checked;
            set => Ck.Checked = value;
        }

        [Category("行为")]
        [Description("登录")]
        public event EventHandler? OnLogin;

        private Valid Valid { get; set; } = new();

        private void HdLogin()
        {
            if (!ValidateChildren()) this.ShowErrMsg(Valid.MsgShow());
            else OnLogin?.Invoke(this, EventArgs.Empty);
        }

        private void HdAccValid(CancelEventArgs e)
        {
            e.Cancel = !Valid.IsRequired(IpAcc);
        }

        private void HdPwdValid(CancelEventArgs e)
        {
            e.Cancel = !Valid.IsRequired(IpPwd);
        }

        private void HdPress(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) HdLogin();
        }

        public Login() { InitializeComponent(); }
        private void BtOk_Click(object sender, EventArgs e) => HdLogin();
        private void IpAcc_Validating(object sender, CancelEventArgs e) => HdAccValid(e);
        private void IpPwd_Validating(object sender, CancelEventArgs e) => HdPwdValid(e);
        private void ULogin_KeyUp(object sender, KeyEventArgs e) => HdPress(e);
    }
}
