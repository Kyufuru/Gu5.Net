namespace Gu5.Net.Winforms.Example
{
    partial class FmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            home1 = new Gu5.Net.Winforms.UI.Controls.Home();
            SuspendLayout();
            // 
            // home1
            // 
            home1.BackColor = Color.Transparent;
            home1.Dock = DockStyle.Fill;
            home1.Location = new Point(0, 0);
            home1.Name = "home1";
            home1.Size = new Size(1200, 700);
            home1.TabIndex = 0;
            // 
            // FmMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1200, 700);
            Controls.Add(home1);
            Margin = new Padding(2);
            Name = "FmMain";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private UI.Controls.Home home1;
    }
}
