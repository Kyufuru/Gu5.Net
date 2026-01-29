using System;
using System.Drawing.Text;

using AntdUI;

using Gu5.UI.Extensions;

namespace Gu5.UI
{
    /// <summary>
    /// 应用实体
    /// </summary>
    public class App
    {
        /// <summary>
        /// 登录窗体
        /// </summary>
        public Form Login { get; set; } = null!;

        /// <summary>
        /// 主窗体
        /// </summary>
        public Form Main { get; set; } = null!;

        public App()
        {
            Application.ThreadException += (s, e) => Main.ShowErrMsg(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => Main.ShowErrMsg($"{e}");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if NETCOREAPP || NET6_0_OR_GREATER
    Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
#endif
        }

        /// <summary>
        /// UI 配置
        /// </summary>
        /// <returns></returns>
        public App UseUI()
        {
            Style.SetPrimary(Color.RoyalBlue);
            Localization.DefaultLanguage = "zh-CN";
            AntdUI.Config.TextRenderingHighQuality = true;
            AntdUI.Config.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            AntdUI.Config.SetCorrectionTextRendering("Microsoft YaHei UI", "微软雅黑");
            AntdUI.Config.ShowInWindow = true;
            AntdUI.Config.Font = new("Microsoft YaHei UI", 10);

            return this;
        }

        /// <summary>
        /// 运行应用
        /// </summary>
        public void Run()
        {
            Login.StartPosition = FormStartPosition.CenterParent;

            if (Login.ShowDialog() != DialogResult.OK)
                Environment.Exit(0);

            Application.Run(Main);
        }
    }
}
