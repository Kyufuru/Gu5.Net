using System.ComponentModel;

using AntdUI;

using Gu5.Core;
using Gu5.UI.Enums;
using Gu5.UI.Extensions;

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
                    IcType.More => "MoreOutlined",
                    _ => IconSvg
                };

                Type = _iconType switch
                {
                    IcType.Del => TTypeMini.Error,
                    IcType.Get => TTypeMini.Primary,
                    _ => TTypeMini.Default,
                };

                Tag = Text = _iconType?.GetDescription();
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
                var w = CalcTextLen(Text) / 2;
                var ff = Font.FontFamily;

                if (_controlSize == CtrlSize.Small)
                {
                    w = 35 + 17 * w;
                    Font = new(ff, 9F);
                    Size = new(w, 35);
                    IconRatio = 0.7F;
                }

                if (_controlSize == CtrlSize.Medium)
                {
                    w = 40 + 20 * w; 
                    Font = new(ff, 10F);
                    Size = new(w, 40);
                    IconRatio = 0.75F;
                }

                if (_controlSize == CtrlSize.Large)
                {
                    w = 50 + 25 * w;
                    Font = new(ff, 12F);
                    Size = new(w, 47);
                    IconRatio = 0.75F;
                }
            }
        }

        public Button()
        {
            BorderWidth = 1;
            Size = new(80, 40);
            Font = new("Microsoft YaHei UI", 10);
        }

        private static int CalcTextLen(string? d)
        {
            if (string.IsNullOrEmpty(d)) return 0;
            return d.Select(x => x.IsChinese() ? 2 : 1).Sum();
        }
    }
}
