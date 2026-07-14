using System.ComponentModel;
using System.Windows.Forms.Design;

namespace Gu5.UI.Designers
{
    /// <summary>
    /// 表单项设计器
    /// </summary>
    public class FormItemDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            var c = (FormItem)component;

            EnableDesignMode(c.Panel, "Panel");
        }
    }
}