using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace DM_MICROS_ESV60.RJControls
{
    public class RJToggleButton : CheckBox
    {
        //Campos
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;

        //Propiedades
        [Category("RJ Code Advance")]
        public Color OnBackColor
        {
            get
            {
                return onBackColor;
            }

            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color OnToggleColor
        {
            get
            {
                return onToggleColor;
            }

            set
            {
                onToggleColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color OffBackColor
        {
            get
            {
                return offBackColor;
            }

            set
            {
                offBackColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color OffToggleColor
        {
            get
            {
                return offToggleColor;
            }

            set
            {
                offToggleColor = value;
                this.Invalidate();
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {

            }
        }

        [Category("RJ Code Advance")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get
            {
                return solidStyle;
            }

            set
            {
                solidStyle = value;
                this.Invalidate();
            }
        }

        //Constructor
        public RJToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
        }

        //Metodos
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            // Dibujar la superficie de control
            GraphicsPath figurePath = GetFigurePath();
            if (this.Checked)
            {
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), figurePath);
                else
                    pevent.Graphics.DrawPath(new Pen(onBackColor, 2), figurePath);

                // Dibujar la palanca y el símbolo "Visto"
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
                DrawCheckSymbol(pevent.Graphics, Brushes.White, new Rectangle(2, 2, toggleSize, toggleSize));
            }
            else
            {
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), figurePath);
                else
                    pevent.Graphics.DrawPath(new Pen(offBackColor, 2), figurePath);

                // Dibujar la palanca y el símbolo "X"
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
                DrawXSymbol(pevent.Graphics, Brushes.White, new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }

        private void DrawCheckSymbol(Graphics graphics, Brush brush, Rectangle bounds)
        {
            // Símbolo de marca de verificación (✓)
            Point[] points = new Point[5];
            points[0] = new Point(bounds.X + bounds.Width / 8, bounds.Y + bounds.Height / 2);
            points[1] = new Point(bounds.X + bounds.Width / 3, bounds.Y + 3 * bounds.Height / 4);
            points[2] = new Point(bounds.X + 7 * bounds.Width / 8, bounds.Y + bounds.Height / 4);
            points[3] = new Point(bounds.X + bounds.Width / 2, bounds.Y + 6 * bounds.Height / 8);
            points[4] = new Point(bounds.X + bounds.Width / 3, bounds.Y + 5 * bounds.Height / 8);

            graphics.FillPolygon(brush, points);
        }

        private void DrawXSymbol(Graphics graphics, Brush brush, Rectangle bounds)
        {
            // Símbolo de "X"
            graphics.DrawLine(new Pen(brush, 2), bounds.X + bounds.Width / 4, bounds.Y + bounds.Height / 4, bounds.X + 3 * bounds.Width / 4, bounds.Y + 3 * bounds.Height / 4);
            graphics.DrawLine(new Pen(brush, 2), bounds.X + bounds.Width / 4, bounds.Y + 3 * bounds.Height / 4, bounds.X + 3 * bounds.Width / 4, bounds.Y + bounds.Height / 4);
        }

    }
}
