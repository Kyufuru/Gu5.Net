using AntdUI;

namespace Gu5.UI.Services
{
    /// <summary>
    /// 右键菜单
    /// </summary>
    public class MenuSrv
    {
        /// <summary>
        /// 菜单项
        /// </summary>
        public List<ContextMenuStripItem> Items { get; set; } = [];

        /// <summary>
        /// 订阅事件
        /// </summary>
        public Dictionary<string, Action<ContextMenuStripItem>> Events { get; set; } = [];

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="it">菜单项, 会替换重复名称</param>
        /// <param name="e">点击事件</param>
        /// <returns></returns>
        public MenuSrv Add(ContextMenuStripItem it,
            Action<ContextMenuStripItem> e)
        {
            Items.RemoveAll(x => x.Text == it.Text);
            Items.Add(it);
            Events[$"{it.Text}"] = e;

            return this;
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="name">菜单项名称</param>
        /// <param name="e">点击事件</param>
        /// <returns></returns>
        public MenuSrv Add(string name, Action<ContextMenuStripItem> e) =>
            Add(new ContextMenuStripItem(name), e);
    }
}
