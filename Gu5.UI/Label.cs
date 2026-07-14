using System.ComponentModel;

using AntdUI;

namespace Gu5.UI
{
    /// <summary>
    /// 文本
    /// </summary>
    public class Label : AntdUI.Label
    {
        private TTypeMini _type = TTypeMini.Default;
        [Category("Gu5_外观")]
        [Description("类型")]
        public TTypeMini Type 
        { 
            get => _type; 
            set
            {
                _type = value;
                ForeColor = _type switch
                {
                    TTypeMini.Default => "#333".ToColor(),
                    TTypeMini.Primary => Color.RoyalBlue,
                    TTypeMini.Error => Color.Firebrick,
                    TTypeMini.Success => Color.Green,
                    TTypeMini.Warn => "#de5f19".ToColor(),
                    TTypeMini.Info => Color.DimGray,
                    _ => ForeColor
                };
            }
        }
    }
}
