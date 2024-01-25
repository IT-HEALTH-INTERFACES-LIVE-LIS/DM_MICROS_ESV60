using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DM_MICROS_ESV60.RJControls
{
    [DefaultEvent("_TextChanged")]
    public partial class RJInputComboBoxControl : UserControl
    {
        public RJInputComboBoxControl()
        {
            InitializeComponent();
            RjComboBox1_TextChanged();
            //rjComboBox1.ComboBoxControl.Items.Add("Opción 1");
            //rjComboBox1.ComboBoxControl.Items.Add("Opción 2");
        }

        private void RjComboBox1_TextChanged()
        {
            if (rjComboBox1.ComboBoxControl.Items.Count == 0)
            {
                label2.Visible = true;
                label1.ForeColor = Color.Red;
                this.Invalidate();
            }
            else
            {
                label2.Visible = false;
                label1.ForeColor = Color.FromArgb(46, 189, 255);
                this.Invalidate();
            }
        }




        // Propiedades expuestas para rjComboBox1

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get { return rjComboBox1.BorderRadius; }
            set { rjComboBox1.BorderRadius = value; }
        }

        [Category("RJ Code Advance")]
        public Size ComboBoxSize
        {
            get { return rjComboBox1.Size; }
            set { rjComboBox1.Size = value; }
        }

        [Category("RJ Code Advance")]
        public string LabelText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        private void rjComboBox1__TextChanged(object sender, EventArgs e)
        {
            if (rjComboBox1.ComboBoxControl.Text == "" || rjComboBox1.ComboBoxControl.Text == string.Empty || rjComboBox1.ComboBoxControl.Text == "" || rjComboBox1.ComboBoxControl.Text == null)
            {
                label2.Visible = true;
                label1.ForeColor = Color.Red;
                this.Invalidate();
            }
            else
            {
                label2.Visible = false;
                label1.ForeColor = Color.FromArgb(46, 189, 255);
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public System.Windows.Forms.ComboBox ComboBoxControl
        {
            get { return rjComboBox1.ComboBoxControl; }
        }

        [Category("RJ Code Advance")]
        public Image BackgroundImage
        {
            get { return pictureBox1.BackgroundImage; }
            set { pictureBox1.BackgroundImage = value; }
        }

        [Category("RJ Code Advance")]
        public ImageLayout BackgroundImageLayout
        {
            get { return pictureBox1.BackgroundImageLayout; }
            set { pictureBox1.BackgroundImageLayout = value; }
        }
        [Category("RJ Code Advance")]
        public Size SizeImage
        {
            get { return pictureBox1.Size; }
            set { pictureBox1.Size = value; }
        }


        [Category("RJ Code Advance")]
        public Point LocationImage
        {
            get { return pictureBox1.Location; }
            set { pictureBox1.Location = value; }
        }

    }
}
