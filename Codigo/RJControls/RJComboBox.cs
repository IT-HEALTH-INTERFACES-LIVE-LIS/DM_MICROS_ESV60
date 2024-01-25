using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DM_MICROS_ESV60.RJControls
{
    [DefaultEvent("_TextChanged")]
    public partial class RJComboBox : UserControl
    {
        private Color borderColor = Color.FromArgb(46, 189, 255);
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.FromArgb(172, 206, 247);
        private Color borderError = Color.Red;
        public bool isFocused = false;
        private int borderRadius = 0;

        public event EventHandler _TextChanged;

        public RJComboBox()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.TextChanged += (s, e) => textBox1_TextChanged(s, e);
            comboBox1.Enter += (s, e) => comboBox1_Enter(s, e);
            comboBox1.Leave += (s, e) => comboBox1_Leave(s, e);
            comboBox1.ForeColor = Color.FromArgb(62, 62, 62);
            comboBox1.SelectionChangeCommitted += (s, e) => comboBox1_SelectionChangeCommitted(s, e);


        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        [Category("RJ Code Advance")]
        public System.Windows.Forms.ComboBox ComboBoxControl
        {
            get { return comboBox1; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1)
            {
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(pathBorderSmooth);

                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;

                    if (string.IsNullOrEmpty(comboBox1.Text))
                    {
                        penBorder.Color = borderError;
                    }
                    else if (isFocused)
                    {
                        penBorder.Color = borderFocusColor;
                    }

                    if (underlinedStyle)
                    {
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graph.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (isFocused)
                    {
                        penBorder.Color = borderFocusColor;
                    }

                    if (underlinedStyle)
                    {
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                    }
                }
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            // Cambiar el color de fondo y el color del texto al entrar en el ComboBox
            isFocused = true; // Cambiar a true
            this.Invalidate();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            // Restaurar el color de fondo y el color del texto al salir del ComboBox
            isFocused = false;
            // Restaurar el color del texto
            this.Invalidate();// Cambiar a false
           
        }


        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Quita el foco al control invisible después de la selección


            isFocused = false;
            comboBox1.ForeColor = Color.FromArgb(62, 62, 62);
            this.Invalidate();
        }

        public override System.Drawing.Color BackColor { get; set; }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.ForeColor = Color.FromArgb(62, 62, 62);
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            comboBox1.BackColor = Color.White;
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            if (!comboBox1.DroppedDown) // Verifica si las opciones están desplegadas
            {
                comboBox1.BackColor = SystemColors.Window; // Restaura el color de fondo predeterminado
            }
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            if (!comboBox1.DroppedDown) // Verifica si las opciones están desplegadas
            {
                comboBox1.BackColor = Color.White; // Establece el color de fondo que desees
            }
        }
    }
}
