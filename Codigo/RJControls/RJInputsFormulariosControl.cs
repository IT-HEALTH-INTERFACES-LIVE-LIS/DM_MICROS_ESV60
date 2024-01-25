using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DM_MICROS_ESV60.RJControls
{
    [DefaultEvent("_TextChanged")]
    public partial class RJInputsFormulariosControl : UserControl
    {
        bool cambio = false;
        int valor ;

        public RJInputsFormulariosControl()
        {
           
            InitializeComponent();
             RjTextBoxControl1_TextChanged();
            
            // Agrega el evento Resize
            // Agrega el evento TextChangedForeColor
            // Agrega el evento TextChanged
        }

        private void RjTextBoxControl1_TextChanged()
        {
           
                // Verifica si el texto del rjTextBoxControl1 está en nulo o es una cadena vacía
                if (string.IsNullOrEmpty(rjTextBoxControl1.Texts))
                {
                    label2.Visible = true;
                    label1.ForeColor = Color.Red;
                this.Invalidate();
                // Cambia el color del texto de label1 a rojo
            }
                else
                {
                label2.Visible = false;
                label1.ForeColor = Color.FromArgb(46, 189, 255);
                this.Invalidate();
                // Restablece el color del texto de label1
            }
            
        }

        [Category("RJ Code Advance")]
        public Color BorderFocusColor
        {
            get { return rjTextBoxControl1.BorderFocusColor; }
            set { rjTextBoxControl1.BorderFocusColor = value; }
        }

        // Propiedades expuestas para rjTextBoxControl1

        [Category("RJ Code Advance")]
        public bool Multiline
        {
            get { return rjTextBoxControl1.Multiline; }
            set { rjTextBoxControl1.Multiline = value; }
        }

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get { return rjTextBoxControl1.BorderRadius; }
            set { rjTextBoxControl1.BorderRadius = value; }
        }
        [Category("RJ Code Advance")]
        public string TextBoxText {

            get { return rjTextBoxControl1.Texts; }
            set { rjTextBoxControl1.Texts = value; }
        }

        public bool Focuse
        {
            get { return rjTextBoxControl1.isFocused; }
            set
            {
                rjTextBoxControl1.isFocused = value;
                this.Invalidate();
            }
        }


        [Category("RJ Code Advance")]
        public Size TextBoxSize
        {
            get { return rjTextBoxControl1.Size; }
            set { rjTextBoxControl1.Size = value; }
        }


        [Category("RJ Code Advance")]
        public Font FontTextBox
        {
            get { return rjTextBoxControl1.Font; }
            set { rjTextBoxControl1.Font = value; }
        }

        [Category("RJ Code Advance")]
        public Size SiseTextBox
        {
            get { return rjTextBoxControl1.Size; }
            set { rjTextBoxControl1.Size = value; }
        }

        [Category("RJ Code Advance")]
        public string LabelText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        [Category("RJ Code Advance")]
        public Padding Label2TextPadding
        {
            get { return label2.Padding; }
            set { label2.Padding = value; }
        }

        private void rjTextBoxControl1_Leave(object sender, EventArgs e)
        {
            
            rjTextBoxControl1.textBox1_Leave(sender, e);
            RjTextBoxControl1_TextChanged();
        }

        private void rjTextBoxControl1_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rjTextBoxControl1.Texts))
            {
                label2.Visible = true;
                label1.ForeColor = Color.Red;
                //this.Invalidate();
                // Cambia el color del texto de label1 a rojo
            }
            else
            {
                label2.Visible = false;
               
                label1.ForeColor = rjTextBoxControl1.BorderColor;
                this.Invalidate();
                //this.Invalidate();
                // Restablece el color del texto de label1
            }
        }

        private void RJInputsFormulariosControl_SizeChanged(object sender, EventArgs e)
        {
           

            if (rjTextBoxControl1.Size.Width >= 768)
            {

                label2.Padding = new Padding(0, 15, 0, 0);
                rjTextBoxControl1.Size = new Size(rjTextBoxControl1.Size.Width, 38);
                cambio = true;
                
            }
            else {
                if (cambio) {
                  
                    label2.Padding = new Padding(0, 0, 0, 0);
                    rjTextBoxControl1.Size = new Size(rjTextBoxControl1.Size.Width, 36);
                }
                cambio = false;
              
            }

            this.Invalidate();
        }
    }
}
