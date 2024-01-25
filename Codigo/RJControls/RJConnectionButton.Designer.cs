namespace DM_MICROS_ESV60.RJControls
{
    partial class RJConnectionButton
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
            this.rjpictureBox1 = new System.Windows.Forms.PictureBox();
            this.rjButton2 = new DM_MICROS_ESV60.RJControls.RJButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rjpictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rjpictureBox1
            // 
            this.rjpictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(224)))), ((int)(((byte)(213)))));
            this.rjpictureBox1.BackgroundImage = global::DM_MICROS_ESV60.Properties.Resources.Conectar;
            this.rjpictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjpictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.rjpictureBox1.Location = new System.Drawing.Point(0, 0);
            this.rjpictureBox1.Name = "rjpictureBox1";
            this.rjpictureBox1.Size = new System.Drawing.Size(49, 49);
            this.rjpictureBox1.TabIndex = 1;
            this.rjpictureBox1.TabStop = false;
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(224)))), ((int)(((byte)(213)))));
            this.rjButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(224)))), ((int)(((byte)(213)))));
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 20;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(183)))), ((int)(((byte)(175)))));
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Open Sans", 15F);
            this.rjButton2.FontSize = 15F;
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(0, 0);
            this.rjButton2.Margin = new System.Windows.Forms.Padding(0);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.rjButton2.Size = new System.Drawing.Size(159, 49);
            this.rjButton2.TabIndex = 0;
            this.rjButton2.Text = "Conectar";
            this.rjButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(224)))), ((int)(((byte)(213)))));
            this.pictureBox1.BackgroundImage = global::DM_MICROS_ESV60.Properties.Resources.Conectar;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(13, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(30, 40);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // RJConnectionButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rjButton2);
            this.Name = "RJConnectionButton";
            this.Size = new System.Drawing.Size(159, 49);
            ((System.ComponentModel.ISupportInitialize)(this.rjpictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DM_MICROS_ESV60.RJControls.RJButton rjButton1;
        private System.Windows.Forms.PictureBox rjpictureBox1;
        private DM_MICROS_ESV60.RJControls.RJButton rjButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
