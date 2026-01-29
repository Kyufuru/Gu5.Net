using AntdUI;

using Gu5.Core;
using Gu5.UI.Services;
using Gu5.UI.Valids;

using ContextMenuStrip = AntdUI.ContextMenuStrip;
using Message = AntdUI.Message;

namespace Gu5.UI.Extensions
{
    /// <summary>
    /// 弹窗
    /// </summary>
    public static class ModalExtensions
    {
        public const string FntFmy = "Microsoft YaHei UI";

        /// <summary>
        /// 内边距
        /// </summary>
        public static Size Pad => new(20, 15);

        /// <summary>
        /// 字体
        /// </summary>
        public static Font Fnt => new(FntFmy, 12);


        /// <summary>
        /// 右键菜单
        /// </summary>
        /// <param name="this">控件</param>
        /// <param name="menu">菜单</param>
        /// <returns></returns>
        public static ContextMenuStrip.Config Menu(this Control @this, MenuSrv menu) =>
            new(@this, x =>
            {
                if (menu.Events.TryGetValue($"{x.Text}", out var val)) val(x);
            }, [.. menu.Items]);

        /// <summary>
        /// 通知
        /// </summary>
        /// <param name="this">窗体</param>
        /// <param name="msg">内容</param>
        /// <returns></returns>
        public static Notification.Config Notice(this Control @this, string? msg = null, 
            TType icon = TType.Info, TAlignFrom align = TAlignFrom.BR) =>
            new(@this.GetForm(), "通知提醒", $"{msg}", icon, align);

        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="this">窗体</param>
        /// <param name="msg">内容</param>
        /// <returns></returns>
        public static Message.Config Message(this Control @this, string? msg = null) =>
            new(@this.GetForm(), $"{msg}", TType.None, new("微软雅黑", 11));

        /// <summary>
        /// 对话框
        /// </summary>
        /// <param name="this">内容</param>
        /// <param name="name">标题</param>
        /// <returns></returns>
        public static Modal.Config Modal(this Control @this, object body, string name = "") =>
            new(@this.GetForm(), name, body) { Padding = Pad, Font = Fnt, Keyboard = false };

        /// <summary>
        /// 气泡框
        /// </summary>
        /// <param name="this">控件</param>
        /// <param name="body">内容</param>
        /// <returns></returns>
        public static Popover.Config Pop(this Control @this, 
            object body, TAlign align = TAlign.Top) => 
            new(@this, body) 
            { 
                Radius = 0, 
                Padding = new(0, 0),
                
                ArrowAlign = align,
                Font = new(FntFmy, 10),
            };

        /// <summary>
        /// 确认框
        /// </summary>
        /// <param name="this">窗体</param>
        /// <param name="msg">内容</param>
        /// <param name="name">标题</param>
        /// <returns></returns>
        public static Modal.Config Confirm(this Control @this,
            string msg = "即将执行操作, 是否确认?", string name = "提示") =>
            new(@this.GetForm(), name, msg)
            {
                MaskClosable = false,
                Keyboard = false,
                Icon = TType.Warn,
                Padding = Pad,
                Font = Fnt,
            };

        /// <summary>
        /// 抽屉
        /// </summary>
        /// <param name="this"></param>
        /// <param name="body">内容</param>
        /// <returns></returns>
        public static Drawer.Config Drawer(this Control @this, Control body) =>
            new(@this.GetForm(), body);

        /// <summary>
        /// 图片预览
        /// </summary>
        /// <returns></returns>
        public static Preview.Config Preview(this Control @this,
            IList<Image> body, object? tag = null) => 
            new(@this.GetForm(), body) { Tag = tag };

        /// <summary>
        /// 显示气泡框
        /// </summary>
        /// <param name="this"></param>
        public static void Show(this Popover.Config @this) => @this.open();

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="this">对话框</param>
        public static DialogResult Show(this Modal.Config @this) => @this.open();

        /// <summary>
        /// 显示抽屉
        /// </summary>
        /// <param name="this"></param>
        public static void Show(this Drawer.Config @this) => @this.open();

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="this">消息</param>
        /// <returns>错误-False, 成功-True</returns>
        public static bool Show(this Message.Config @this)
        {
            @this.open();
            return @this.Icon == TType.Success;
        }

        /// <summary>
        /// 显示通知
        /// </summary>
        /// <param name="this">消息</param>
        /// <returns>错误-False, 成功-True</returns>
        public static bool Show(this Notification.Config @this)
        {
            @this.open();
            return @this.Icon == TType.Success;
        }

        /// <summary>
        /// 显示图片预览
        /// </summary>
        /// <param name="this"></param>
        public static void Show(this Preview.Config @this) => @this.open();

        /// <summary>
        /// 显示右键菜单
        /// </summary>
        /// <param name="this">消息</param>
        /// <returns>错误-False, 成功-True</returns>
        public static void Show(this ContextMenuStrip.Config @this) => @this.open();

        /// <summary>
        /// 成功消息
        /// </summary>
        /// <returns>True</returns>
        public static bool ShowOkMsg(this Control @this, string msg = "操作成功")
        {
            return @this.Message(msg).Also(x =>
            {
                x.Icon = TType.Success;
                x.AutoClose = 2;
            }).Show();
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <returns>False</returns>
        public static bool ShowErrMsg(this Control? @this, string? msg = "操作失败")
        {
            if (@this is null) return false;
            return @this
                .Message(msg)
                .Also(x =>
                {
                    x.Icon = TType.Error;
                    x.AutoClose = 8;
                }).Show();
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <returns>False</returns>
        public static bool ShowErrMsg(this Control? @this, Exception ex, string? pre = "发生错误")
        {
            if (@this is null) return false;
            if (!string.IsNullOrEmpty(pre)) pre += ": ";
            return @this
                .Message($"{pre}{ex.Message}")
                .Also(x =>
                {
                    x.Icon = TType.Error;
                    x.AutoClose = 8;
                }).Show();
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="this"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Modal.Config Valid(this Modal.Config @this, IValid d)
        {
            @this.OnOk = mod =>
            {
                d.ClearMsg();
                var isValid = @this.Content is ContainerControl c && c.ValidateChildren();
                return isValid || mod.Target.GetForm.ShowErrMsg($"{d}");
            };

            return @this;
        }

        /// <summary>
        /// 同步确定回调
        /// </summary>
        /// <param name="this">对话框</param>
        /// <param name="valid">验证服务</param>
        /// <param name="onOk">确定回调</param>
        /// <param name="msg">消息显示</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public static Modal.Config OnYes(this Modal.Config @this,
            IValid? valid, Action onOk, bool msg = true)
        {
            @this.OnOk = mod =>
            {
                var fm = mod.Target.GetForm;
                try
                {
                    if (valid is not null)
                    {
                        valid.ClearMsg();
                        if (@this.Content is ContainerControl c && !c.ValidateChildren())
                            throw new InvalidDataException($"{valid}");
                    }
                    onOk();
                    if (msg) fm?.ShowOkMsg();
                    return true;
                }
                catch (Exception err)
                {
                    fm?.ShowErrMsg(err.Message);
                    return false;
                }
            };

            return @this;
        }

        /// <summary>
        /// 同步确定回调
        /// </summary>
        /// <param name="this">对话框</param>
        /// <param name="onOk">回调</param>
        /// <returns></returns>
        public static Modal.Config OnYes(this Modal.Config @this,
            Action onOk, bool showOk = true) =>
            @this.OnYes(null, onOk, showOk);

        /// <summary>
        /// 异步确定回调
        /// </summary>
        /// <param name="this">对话框</param>
        /// <param name="valid">验证服务</param>
        /// <param name="onOk">确定回调</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public static Modal.Config OnYes(this Modal.Config @this,
            IValid? valid, Func<Modal.Config, Task>? onOk)
        {
            @this.OnOk = mod => Task.Run(async () =>
            {
                var fm = mod.Target.GetForm;
                try
                {
                    if (valid is not null)
                    {
                        valid.ClearMsg();

                        if (@this.Content is ContainerControl c && !c.ValidateChildren())
                            throw new InvalidDataException($"{valid}");
                    }
                    if (onOk is not null) await onOk(mod);
                    fm?.Invoke(() => fm?.ShowOkMsg());
                    return true;
                }
                catch (Exception ex)
                {
                    fm?.Invoke(() => fm?.ShowErrMsg(ex.Message));
                    return false;
                }
            }).Result;

            return @this;
        }

        /// <summary>
        /// 异步确定回调
        /// </summary>
        /// <param name="this">对话框</param>
        /// <param name="valid">验证服务</param>
        /// <param name="onOk">确定回调</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public static Modal.Config OnYes(this Modal.Config @this,
            IValid? valid, Func<Modal.Config, Task<bool?>> onOk)
        {
            @this.OnOk = mod => Task.Run(async () =>
            {
                var fm = mod.Target.GetForm;
                try
                {
                    if (valid is not null)
                    {
                        valid.ClearMsg();

                        if (@this.Content is ContainerControl c && !c.ValidateChildren())
                            throw new InvalidDataException($"{valid}");
                    }
                    if (await onOk(mod) == true) return true;
                    fm?.Invoke(() => fm?.ShowOkMsg());
                    return true;
                }
                catch (Exception ex)
                {
                    fm?.Invoke(() => fm?.ShowErrMsg(ex.Message));
                    return false;
                }
            }).Result;

            return @this;
        }

        /// <summary>
        /// 异步确定回调
        /// </summary>
        /// <param name="this">对话框</param>
        /// <param name="onOk">回调</param>
        /// <returns></returns>
        public static Modal.Config OnYes(this Modal.Config @this,
            Func<Modal.Config, Task> onOk) =>
                @this.OnYes(null, onOk);

        /// <summary>
        /// 异步确定回调
        /// </summary>
        /// <param name="this">对话框</param>
        /// <param name="onOk">回调</param>
        /// <returns></returns>
        public static Modal.Config OnYes(this Modal.Config @this,
            Func<Modal.Config, Task<bool?>> onOk) =>
                @this.OnYes(null, onOk);
    }
}
