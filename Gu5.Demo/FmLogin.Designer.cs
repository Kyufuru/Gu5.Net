namespace Gu5.Net.Winforms.Example
{
    partial class FmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmLogin));
            Login = new Gu5.Net.Winforms.UI.Controls.Login();
            SuspendLayout();
            // 
            // Login
            // 
            Login.AutoValidate = AutoValidate.EnableAllowFocusChange;
            Login.BackColor = Color.Transparent;
            Login.Dock = DockStyle.Fill;
            Login.Icon = (Image)resources.GetObject("Login.Icon");
            Login.IsRemember = false;
            Login.Loading = false;
            Login.Location = new Point(0, 0);
            Login.Name = "Login";
            Login.Password = "";
            Login.Size = new Size(700, 400);
            Login.SubTitle = "[副标题]";
            Login.TabIndex = 1;
            Login.Title = "[标题]";
            Login.Username = "";
            Login.Version = "[版本号]";
            Login.OnLogin += Login_OnLogin;
            // 
            // FmLogin
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(700, 400);
            Controls.Add(Login);
            Name = "FmLogin";
            Text = "FmLogin";
            ResumeLayout(false);
        }

        #endregion

        private Gu5.Net.Winforms.UI.Controls.Login Login;
    }
}