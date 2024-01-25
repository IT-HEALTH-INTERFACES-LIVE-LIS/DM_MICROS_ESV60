using System;

namespace DM_MICROS_ESV60.Forms
{
    partial class Resultados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerIntervalos = new System.Windows.Forms.Timer(this.components);
            this.lblIntervalos = new System.Windows.Forms.Label();
            this.tmrCheckComPorts = new System.Windows.Forms.Timer(this.components);
            this.flpContenedorResul = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.flpCOM = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpResultados = new System.Windows.Forms.TableLayoutPanel();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.chkClearOnOpen = new System.Windows.Forms.CheckBox();
            this.chkRTS = new System.Windows.Forms.CheckBox();
            this.chkClearWithDTR = new System.Windows.Forms.CheckBox();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.chkDTR = new System.Windows.Forms.CheckBox();
            this.chkDSR = new System.Windows.Forms.CheckBox();
            this.chkCD = new System.Windows.Forms.CheckBox();
            this.chkCTS = new System.Windows.Forms.CheckBox();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.lblSend = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPortName = new DM_MICROS_ESV60.RJControls.RJInputComboBoxControl();
            this.cmbBaudRate = new DM_MICROS_ESV60.RJControls.RJInputComboBoxControl();
            this.cmbParity = new DM_MICROS_ESV60.RJControls.RJInputComboBoxControl();
            this.cmbDataBits = new DM_MICROS_ESV60.RJControls.RJInputComboBoxControl();
            this.cmbStopBits = new DM_MICROS_ESV60.RJControls.RJInputComboBoxControl();
            this.flpContenedorResul.SuspendLayout();
            this.flpCOM.SuspendLayout();
            this.tlpResultados.SuspendLayout();
            this.gbMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerIntervalos
            // 
            this.timerIntervalos.Tick += new System.EventHandler(this.timerIntervalos_Tick);
            // 
            // lblIntervalos
            // 
            this.lblIntervalos.BackColor = System.Drawing.Color.Transparent;
            this.lblIntervalos.Location = new System.Drawing.Point(699, 583);
            this.lblIntervalos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIntervalos.Name = "lblIntervalos";
            this.lblIntervalos.Size = new System.Drawing.Size(35, 15);
            this.lblIntervalos.TabIndex = 0;
            this.lblIntervalos.Text = "Timer";
            this.lblIntervalos.Visible = false;
            // 
            // tmrCheckComPorts
            // 
            this.tmrCheckComPorts.Interval = 580;
            this.tmrCheckComPorts.Tick += new System.EventHandler(this.tmrCheckComPorts_Tick);
            // 
            // flpContenedorResul
            // 
            this.flpContenedorResul.AutoScroll = true;
            this.flpContenedorResul.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpContenedorResul.BackColor = System.Drawing.Color.White;
            this.flpContenedorResul.Controls.Add(this.buttonDefault);
            this.flpContenedorResul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContenedorResul.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpContenedorResul.Font = new System.Drawing.Font("Century Gothic", 9.25F, System.Drawing.FontStyle.Bold);
            this.flpContenedorResul.Location = new System.Drawing.Point(3, 190);
            this.flpContenedorResul.Name = "flpContenedorResul";
            this.flpContenedorResul.Padding = new System.Windows.Forms.Padding(15);
            this.flpContenedorResul.Size = new System.Drawing.Size(755, 377);
            this.flpContenedorResul.TabIndex = 17;
            this.flpContenedorResul.WrapContents = false;
            this.flpContenedorResul.SizeChanged += new System.EventHandler(this.flpContenedorResul_SizeChanged);
            // 
            // buttonDefault
            // 
            this.buttonDefault.BackColor = System.Drawing.Color.Transparent;
            this.buttonDefault.Enabled = false;
            this.buttonDefault.FlatAppearance.BorderSize = 0;
            this.buttonDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDefault.Location = new System.Drawing.Point(18, 18);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(469, 0);
            this.buttonDefault.TabIndex = 0;
            this.buttonDefault.UseVisualStyleBackColor = false;
            this.buttonDefault.Resize += new System.EventHandler(this.button_Resize);
            // 
            // flpCOM
            // 
            this.flpCOM.AutoScroll = true;
            this.flpCOM.BackColor = System.Drawing.Color.White;
            this.flpCOM.Controls.Add(this.cmbPortName);
            this.flpCOM.Controls.Add(this.cmbBaudRate);
            this.flpCOM.Controls.Add(this.cmbParity);
            this.flpCOM.Controls.Add(this.cmbDataBits);
            this.flpCOM.Controls.Add(this.cmbStopBits);
            this.flpCOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCOM.Location = new System.Drawing.Point(3, 3);
            this.flpCOM.Name = "flpCOM";
            this.flpCOM.Size = new System.Drawing.Size(755, 181);
            this.flpCOM.TabIndex = 38;
            this.flpCOM.Visible = false;
            // 
            // tlpResultados
            // 
            this.tlpResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpResultados.ColumnCount = 1;
            this.tlpResultados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResultados.Controls.Add(this.flpCOM, 0, 0);
            this.tlpResultados.Controls.Add(this.flpContenedorResul, 0, 1);
            this.tlpResultados.Location = new System.Drawing.Point(18, 18);
            this.tlpResultados.Name = "tlpResultados";
            this.tlpResultados.RowCount = 2;
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpResultados.Size = new System.Drawing.Size(761, 570);
            this.tlpResultados.TabIndex = 39;
            // 
            // gbMode
            // 
            this.gbMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbMode.Controls.Add(this.chkClearOnOpen);
            this.gbMode.Controls.Add(this.chkRTS);
            this.gbMode.Controls.Add(this.chkClearWithDTR);
            this.gbMode.Controls.Add(this.rbText);
            this.gbMode.Controls.Add(this.chkDTR);
            this.gbMode.Controls.Add(this.chkDSR);
            this.gbMode.Controls.Add(this.chkCD);
            this.gbMode.Controls.Add(this.chkCTS);
            this.gbMode.Controls.Add(this.rbHex);
            this.gbMode.Controls.Add(this.lblSend);
            this.gbMode.Controls.Add(this.groupBox1);
            this.gbMode.Location = new System.Drawing.Point(627, 313);
            this.gbMode.Name = "gbMode";
            this.gbMode.Size = new System.Drawing.Size(149, 234);
            this.gbMode.TabIndex = 40;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "Data &Mode";
            this.gbMode.Visible = false;
            // 
            // chkClearOnOpen
            // 
            this.chkClearOnOpen.Location = new System.Drawing.Point(13, 176);
            this.chkClearOnOpen.Name = "chkClearOnOpen";
            this.chkClearOnOpen.Size = new System.Drawing.Size(94, 17);
            this.chkClearOnOpen.TabIndex = 10;
            this.chkClearOnOpen.Text = "Clear on Open";
            this.chkClearOnOpen.UseVisualStyleBackColor = true;
            this.chkClearOnOpen.Visible = false;
            // 
            // chkRTS
            // 
            this.chkRTS.Location = new System.Drawing.Point(13, 154);
            this.chkRTS.Name = "chkRTS";
            this.chkRTS.Size = new System.Drawing.Size(48, 17);
            this.chkRTS.TabIndex = 1;
            this.chkRTS.Text = "RTS";
            this.chkRTS.UseVisualStyleBackColor = true;
            // 
            // chkClearWithDTR
            // 
            this.chkClearWithDTR.Location = new System.Drawing.Point(13, 198);
            this.chkClearWithDTR.Name = "chkClearWithDTR";
            this.chkClearWithDTR.Size = new System.Drawing.Size(98, 17);
            this.chkClearWithDTR.TabIndex = 11;
            this.chkClearWithDTR.Text = "Clear with DTR";
            this.chkClearWithDTR.UseVisualStyleBackColor = true;
            this.chkClearWithDTR.Visible = false;
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Location = new System.Drawing.Point(12, 19);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(46, 19);
            this.rbText.TabIndex = 0;
            this.rbText.Text = "Text";
            // 
            // chkDTR
            // 
            this.chkDTR.Location = new System.Drawing.Point(12, 131);
            this.chkDTR.Name = "chkDTR";
            this.chkDTR.Size = new System.Drawing.Size(49, 17);
            this.chkDTR.TabIndex = 0;
            this.chkDTR.Text = "DTR";
            this.chkDTR.UseVisualStyleBackColor = true;
            // 
            // chkDSR
            // 
            this.chkDSR.Enabled = false;
            this.chkDSR.Location = new System.Drawing.Point(12, 108);
            this.chkDSR.Name = "chkDSR";
            this.chkDSR.Size = new System.Drawing.Size(49, 17);
            this.chkDSR.TabIndex = 3;
            this.chkDSR.Text = "DSR";
            this.chkDSR.UseVisualStyleBackColor = true;
            // 
            // chkCD
            // 
            this.chkCD.Enabled = false;
            this.chkCD.Location = new System.Drawing.Point(12, 62);
            this.chkCD.Name = "chkCD";
            this.chkCD.Size = new System.Drawing.Size(41, 17);
            this.chkCD.TabIndex = 4;
            this.chkCD.Text = "CD";
            this.chkCD.UseVisualStyleBackColor = true;
            // 
            // chkCTS
            // 
            this.chkCTS.Enabled = false;
            this.chkCTS.Location = new System.Drawing.Point(12, 85);
            this.chkCTS.Name = "chkCTS";
            this.chkCTS.Size = new System.Drawing.Size(47, 17);
            this.chkCTS.TabIndex = 2;
            this.chkCTS.Text = "CTS";
            this.chkCTS.UseVisualStyleBackColor = true;
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Location = new System.Drawing.Point(12, 39);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(46, 19);
            this.rbHex.TabIndex = 1;
            this.rbHex.Text = "Hex";
            // 
            // lblSend
            // 
            this.lblSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(-498, 174);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(37, 15);
            this.lblSend.TabIndex = 1;
            this.lblSend.Text = "Datos";
            this.lblSend.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Location = new System.Drawing.Point(-495, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 48);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Line Signals";
            this.groupBox1.Visible = false;
            // 
            // cmbPortName
            // 
            this.cmbPortName.BackgroundImage = global::DM_MICROS_ESV60.Properties.Resources.Icono_comport;
            this.cmbPortName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmbPortName.BorderRadius = 5;
            this.cmbPortName.ComboBoxSize = new System.Drawing.Size(180, 39);
            this.cmbPortName.Font = new System.Drawing.Font("Open Sans", 9.25F, System.Drawing.FontStyle.Bold);
            this.cmbPortName.LabelText = "COM PORT";
            this.cmbPortName.Location = new System.Drawing.Point(3, 3);
            this.cmbPortName.LocationImage = new System.Drawing.Point(3, 12);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(250, 79);
            this.cmbPortName.SizeImage = new System.Drawing.Size(59, 60);
            this.cmbPortName.TabIndex = 31;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.BackgroundImage = global::DM_MICROS_ESV60.Properties.Resources.Icono_baudrate;
            this.cmbBaudRate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmbBaudRate.BorderRadius = 5;
            this.cmbBaudRate.ComboBoxSize = new System.Drawing.Size(180, 39);
            this.cmbBaudRate.Font = new System.Drawing.Font("Open Sans", 9.25F, System.Drawing.FontStyle.Bold);
            this.cmbBaudRate.LabelText = "Baud Rate";
            this.cmbBaudRate.Location = new System.Drawing.Point(259, 3);
            this.cmbBaudRate.LocationImage = new System.Drawing.Point(3, 12);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(246, 76);
            this.cmbBaudRate.SizeImage = new System.Drawing.Size(59, 60);
            this.cmbBaudRate.TabIndex = 32;
            // 
            // cmbParity
            // 
            this.cmbParity.BackgroundImage = global::DM_MICROS_ESV60.Properties.Resources.Icono_parity;
            this.cmbParity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmbParity.BorderRadius = 5;
            this.cmbParity.ComboBoxSize = new System.Drawing.Size(180, 39);
            this.cmbParity.Font = new System.Drawing.Font("Open Sans", 9.25F, System.Drawing.FontStyle.Bold);
            this.cmbParity.LabelText = "Parity";
            this.cmbParity.Location = new System.Drawing.Point(3, 88);
            this.cmbParity.LocationImage = new System.Drawing.Point(3, 12);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(250, 76);
            this.cmbParity.SizeImage = new System.Drawing.Size(59, 60);
            this.cmbParity.TabIndex = 33;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.BackgroundImage = global::DM_MICROS_ESV60.Properties.Resources.Icono_databits;
            this.cmbDataBits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmbDataBits.BorderRadius = 5;
            this.cmbDataBits.ComboBoxSize = new System.Drawing.Size(180, 39);
            this.cmbDataBits.Font = new System.Drawing.Font("Open Sans", 9.25F, System.Drawing.FontStyle.Bold);
            this.cmbDataBits.LabelText = "Data Bits";
            this.cmbDataBits.Location = new System.Drawing.Point(259, 88);
            this.cmbDataBits.LocationImage = new System.Drawing.Point(3, 12);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(250, 79);
            this.cmbDataBits.SizeImage = new System.Drawing.Size(59, 60);
            this.cmbDataBits.TabIndex = 32;
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.BackgroundImage = global::DM_MICROS_ESV60.Properties.Resources.Icono_stopbits;
            this.cmbStopBits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmbStopBits.BorderRadius = 5;
            this.cmbStopBits.ComboBoxSize = new System.Drawing.Size(180, 39);
            this.cmbStopBits.Font = new System.Drawing.Font("Open Sans", 9.25F, System.Drawing.FontStyle.Bold);
            this.cmbStopBits.LabelText = "Stop Bits";
            this.cmbStopBits.Location = new System.Drawing.Point(3, 173);
            this.cmbStopBits.LocationImage = new System.Drawing.Point(10, 15);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(249, 79);
            this.cmbStopBits.SizeImage = new System.Drawing.Size(45, 45);
            this.cmbStopBits.TabIndex = 33;
            // 
            // Resultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(797, 606);
            this.Controls.Add(this.tlpResultados);
            this.Controls.Add(this.lblIntervalos);
            this.Controls.Add(this.gbMode);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Resultados";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Resultados_FormClosing);
            this.Load += new System.EventHandler(this.Terminal_Load);
            this.Shown += new System.EventHandler(this.Resultados_Shown);
            this.SizeChanged += new System.EventHandler(this.Resultados_SizeChanged);
            this.flpContenedorResul.ResumeLayout(false);
            this.flpCOM.ResumeLayout(false);
            this.tlpResultados.ResumeLayout(false);
            this.gbMode.ResumeLayout(false);
            this.gbMode.PerformLayout();
            this.ResumeLayout(false);

        }

        private void flpContenedorResul_SizeChanged(object sender, EventArgs e)
        {
            var widthClient = this.ClientSize.Width - 80;
            buttonDefault.Width = widthClient;
        }

        private void button_Resize(object sender, EventArgs e)
        {
            var widthClient = this.ClientSize.Width - 80;
            buttonDefault.Width = widthClient;
        }

        #endregion

        private System.Windows.Forms.Timer timerIntervalos;
        private System.Windows.Forms.Label lblIntervalos;
        private System.Windows.Forms.Timer tmrCheckComPorts;
        private System.Windows.Forms.FlowLayoutPanel flpContenedorResul;
        private System.Windows.Forms.FlowLayoutPanel flpCOM;
        private RJControls.RJInputComboBoxControl cmbPortName;
        private RJControls.RJInputComboBoxControl cmbBaudRate;
        private RJControls.RJInputComboBoxControl cmbParity;
        private RJControls.RJInputComboBoxControl cmbDataBits;
        private RJControls.RJInputComboBoxControl cmbStopBits;
        private System.Windows.Forms.TableLayoutPanel tlpResultados;
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.CheckBox chkClearOnOpen;
        private System.Windows.Forms.CheckBox chkRTS;
        private System.Windows.Forms.CheckBox chkClearWithDTR;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.CheckBox chkDTR;
        private System.Windows.Forms.CheckBox chkDSR;
        private System.Windows.Forms.CheckBox chkCD;
        private System.Windows.Forms.CheckBox chkCTS;
        private System.Windows.Forms.RadioButton rbHex;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDefault;
    }
}