namespace DM_MICROS_ESV60.RJControls
{
    partial class RJInputsFormulariosControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rjTextBoxControl1 = new DM_MICROS_ESV60.RJControls.RJTextBoxControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Open Sans", 9.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(37, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Open Sans", 7.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(93)))), ((int)(((byte)(95)))));
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Campo vacío";
            // 
            // rjTextBoxControl1
            // 
            this.rjTextBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rjTextBoxControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.rjTextBoxControl1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(206)))), ((int)(((byte)(247)))));
            this.rjTextBoxControl1.BorderRadius = 5;
            this.rjTextBoxControl1.BorderSize = 2;
            this.rjTextBoxControl1.Focuse = false;
            this.rjTextBoxControl1.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjTextBoxControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.rjTextBoxControl1.Location = new System.Drawing.Point(11, 23);
            this.rjTextBoxControl1.Margin = new System.Windows.Forms.Padding(4);
            this.rjTextBoxControl1.Multiline = false;
            this.rjTextBoxControl1.Name = "rjTextBoxControl1";
            this.rjTextBoxControl1.Padding = new System.Windows.Forms.Padding(18, 8, 18, 8);
            this.rjTextBoxControl1.Size = new System.Drawing.Size(289, 36);
            this.rjTextBoxControl1.TabIndex = 0;
            this.rjTextBoxControl1.Texts = "";
            this.rjTextBoxControl1.UnderlinedStyle = false;
            this.rjTextBoxControl1.TextBoxTextChanged += new System.EventHandler(this.rjTextBoxControl1_TextBoxTextChanged);
            this.rjTextBoxControl1.Leave += new System.EventHandler(this.rjTextBoxControl1_Leave);
            // 
            // RJInputsFormulariosControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rjTextBoxControl1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Open Sans", 9.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RJInputsFormulariosControl";
            this.Padding = new System.Windows.Forms.Padding(7, 0, 15, 0);
            this.Size = new System.Drawing.Size(321, 91);
            this.SizeChanged += new System.EventHandler(this.RJInputsFormulariosControl_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RJTextBoxControl rjTextBoxControl1;
    }
}
