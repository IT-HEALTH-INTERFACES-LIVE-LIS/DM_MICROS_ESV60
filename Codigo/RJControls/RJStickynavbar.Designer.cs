namespace DM_MICROS_ESV60.RJControls
{
    partial class RJStickynavbar
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
            DM_MICROS_ESV60.RJControls.RJButton rjButton2;
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rjConnectionButton1 = new DM_MICROS_ESV60.RJControls.RJConnectionButton();
            rjButton2 = new DM_MICROS_ESV60.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rjButton2
            // 
            rjButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            rjButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            rjButton2.BorderRadius = 20;
            rjButton2.BorderSize = 0;
            rjButton2.Dock = System.Windows.Forms.DockStyle.Left;
            rjButton2.FlatAppearance.BorderSize = 0;
            rjButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(183)))), ((int)(((byte)(175)))));
            rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rjButton2.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold);
            rjButton2.FontSize = 18F;
            rjButton2.ForeColor = System.Drawing.Color.White;
            rjButton2.Location = new System.Drawing.Point(7, 7);
            rjButton2.Margin = new System.Windows.Forms.Padding(0);
            rjButton2.Name = "rjButton2";
            rjButton2.Padding = new System.Windows.Forms.Padding(7);
            rjButton2.Size = new System.Drawing.Size(520, 49);
            rjButton2.TabIndex = 1;
            rjButton2.TextColor = System.Drawing.Color.White;
            rjButton2.UseVisualStyleBackColor = false;
            rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Open Sans", 18.25F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(142, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(231, 34);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Cargar resultados";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.pictureBox1.BackgroundImage = global::DM_MICROS_ESV60.Properties.Resources.btn_carga2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(60, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 30);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // rjConnectionButton1
            // 
            this.rjConnectionButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rjConnectionButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.rjConnectionButton1.Location = new System.Drawing.Point(583, 7);
            this.rjConnectionButton1.Name = "rjConnectionButton1";
            this.rjConnectionButton1.Size = new System.Drawing.Size(159, 49);
            this.rjConnectionButton1.TabIndex = 5;
            // 
            // RJStickynavbar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.Controls.Add(this.rjConnectionButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(rjButton2);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RJStickynavbar";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(749, 63);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private RJConnectionButton rjConnectionButton1;
    }
}
