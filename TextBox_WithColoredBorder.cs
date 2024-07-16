using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextBox_WithBorder
{
    public partial class TextBox_WithColoredBorder : UserControl
    {
        public const int TEXT_PADDING = 3;
        public TextBox_WithColoredBorder()
        {
            InitializeComponent();
            AddAndSetControls();
        }
        private Label BackgroundLabel;
        private Label PaddingLabel;
        private TextBox MainTextBox;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MainTextBox.Margin = new Padding(50);
        }
        protected void AddAndSetControls()
        {
            AddBackground();
            AddPadding();
            AddTextBox();
            PaddingLabel.SendToBack();
            BackgroundLabel.SendToBack();
            AdjustTextBoxRectangle();
            Resize += TextBox_WithColoredBorder_Resize;
        }
        protected void AddBackground()
        {
            BackgroundLabel = new Label
            {
                Name = "BackgroundLabel",
                AutoSize = false,
                Text = "",
                BackColor = f_BorderColor,
                TabIndex = 1,
            };
            Controls.Add(BackgroundLabel);
        }
        protected void AddPadding()
        {
            PaddingLabel = new Label
            {
                Name = "PaddingLabel",
                AutoSize = false,
                Text = "",
                BackColor = f_BackColor,
                TabIndex = 2,
            };
            Controls.Add(PaddingLabel);
        }
        protected void AddTextBox()
        {
            MainTextBox = new TextBox
            {
                Name= "MainTextBox",
                AutoSize = false,
                BorderStyle = BorderStyle.None,
                TextAlign = HorizontalAlignment.Left,
                ForeColor = ForeColor,
                Font = Font,
                Margin = new Padding(0),
                Text = "",
                TabIndex = 3
            };
            Controls.Add(MainTextBox);
        }
        private void SetControlBounds(Control TheControl, int Delta = 0)
        {
            var Rect = ClientRectangle;
            TheControl.SetBounds(Rect.X + Delta, Rect.Y + Delta, Rect.Width - 2 * Delta, Rect.Height - 2 * Delta);
        }
        protected void AdjustTextBoxRectangle()
        {
            SetControlBounds(BackgroundLabel);
            SetControlBounds(PaddingLabel, f_BorderThickness);
            SetControlBounds(MainTextBox, f_BorderThickness + TEXT_PADDING);
         }
        protected void TextBox_WithColoredBorder_Resize(object sender, EventArgs e)
        {
            AdjustTextBoxRectangle();
        }
        protected void RefreshParent()
        {
            if (Parent != null)
                Parent.Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            AdjustTextBoxRectangle();
            base.OnPaint(e);
        }
        protected override void OnBackColorChanged(EventArgs e)
        {
            if (MainTextBox.BackColor != f_BackColor)
            {
                MainTextBox.BackColor = f_BackColor;
                AdjustTextBoxRectangle();
            }
        }
        protected override void OnFontChanged(EventArgs e)
        {
            if (MainTextBox.Font != Font)
            {
                MainTextBox.Font = Font;
                AdjustTextBoxRectangle();
            }
        }
        protected override void OnForeColorChanged(EventArgs e)
        {
            if (MainTextBox.ForeColor != ForeColor)
            {
                MainTextBox.ForeColor = ForeColor;
                base.OnForeColorChanged(e);
            }
        }
        private Color f_BorderColor = Color.Red;
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get
            {
                return f_BorderColor;
            }
            set
            {
                if (f_BorderColor != value)
                {
                    f_BorderColor = value;
                    if (BackgroundLabel.BackColor != f_BorderColor)
                        BackgroundLabel.BackColor = f_BorderColor;
                    AdjustTextBoxRectangle();
                    RefreshParent();
                }
            }
        }
        private Color f_BackColor = Color.White;
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color BackColor
        {
            get
            {
                return f_BackColor;
            }
            set
            {
                if (f_BackColor != value)
                {
                    f_BackColor = value;
                    MainTextBox.BackColor = f_BackColor;
                    PaddingLabel.BackColor = f_BackColor;
                    base.BackColor = f_BackColor;
                }
            }
        }
        private int f_BorderThickness = 1;
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderThickness
        {
            get
            {
                return f_BorderThickness;
            }
            set
            {
                if (f_BorderThickness != value)
                {
                    f_BorderThickness = value;
                    RefreshParent();
                }
            }
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return MainTextBox.Text;
            }

            set
            {
                if (MainTextBox.Text != value)
                {
                    MainTextBox.Text = value;
                    RefreshParent();
                }
            }
        }
        private bool f_Multiline = false;
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Multiline
        {
            get
            {
                return f_Multiline;
            }
            set
            {
                if (f_Multiline != value)
                {
                    f_Multiline = value;
                    AdjustTextBoxRectangle();
                    MainTextBox.Multiline = f_Multiline;
                    RefreshParent();
                }
            }
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return MainTextBox.TextAlign;
            }
            set
            {
                MainTextBox.TextAlign = value;
            }
        }
    }
}
