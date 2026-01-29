using System.ComponentModel;

using AntdUI;

using Gu5.Core;
using Gu5.UI.Enums;

namespace Gu5.UI
{
    /// <summary>
    /// 基础按钮
    /// </summary>
    public class Button : AntdUI.Button
    {
        private CtrlSize? _controlSize;
        private TTypeMini? _type;
        private IcType? _iconType;

        [Category("外观")]
        [Description("按钮类型")]
        public new TTypeMini? Type
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

        [Category("外观")]
        [Description("图标类型")]
        public IcType? IconType
        {
            get => _iconType;
            set
            {
                _iconType = value;
                IconSvg = _iconType switch
                {
                    IcType.Add => "PlusOutlined",
                    IcType.Set => "FormOutlined",
                    IcType.Del => "DeleteOutlined",
                    IcType.Imp => "ImportOutlined",
                    IcType.Exp => "ExportOutlined",
                    IcType.Get => "RetweetOutlined",
                    IcType.Flt => "FilterOutlined",
                    IcType.Down => "DownloadOutlined",
                    IcType.Up => "UploadOutlined",
                    IcType.Prt => "PrinterOutlined",
                    IcType.QR => "QrcodeOutlined",
                    IcType.Bar => "BarcodeOutlined",
                    IcType.Qry => "SearchOutlined",
                    IcType.Save => "SaveOutlined",
                    _ => IconSvg
                };

                Type = _iconType switch
                {
                    IcType.Del => TTypeMini.Error,
                    IcType.Get => TTypeMini.Primary,
                    _ => Type,
                };

                Text = _iconType?.GetDescription();
                ControlSize = _controlSize ?? CtrlSize.Medium;

            }
        }

        [Category("外观")]
        [Description("尺寸")]
        public CtrlSize? ControlSize
        {
            get => _controlSize;
            set
            {
                _controlSize = value;
                var w = $"{Text}".Length;
                var ff = Font.FontFamily;

                if (_controlSize == CtrlSize.Small)
                {
                    if (w > 0) w = 40 + 15 * w;
                    Font = new(ff, 9F);
                    Size = new(w, 35);
                    IconRatio = 0.7F;
                }

                if (_controlSize == CtrlSize.Medium)
                {
                    if (w > 0) w = 40 + 20 * w; 
                    Font = new(ff, 10F);
                    Size = new(w, 40);
                    IconRatio = 0.8F;
                }

                if (_controlSize == CtrlSize.Large)
                {
                    if (w > 0) w = 60 + 25 * w;
                    Font = new(ff, 12.5F);
                    Size = new(w, 50);
                    IconRatio = 0.7F;
                }
            }
        }

        public Button()
        {
            BorderWidth = 1;
            Size = new(80, 40);
            Font = new("Microsoft YaHei UI", 10);
        }
    }
}
