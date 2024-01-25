using DM_MICROS_ESV60.RJControls;
using DM_MICROS_ESV60.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml;

namespace DM_MICROS_ESV60.Forms
{
    public partial class Config : Form
    {
        //public string conexion = InterfaceConfig.StrCadenaConeccion;
        private string pathConfig;
        private string condicional;
        int heightInicial;
        Color IncialColorInputs = Color.FromArgb(46, 189, 255);
       


        public Config()
        {
            InitializeComponent();

            #region Cargar datos
            //Conexión
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.config");
            pathConfig = files[0];
            //var datosConexion = conexion.Split(';');


            // Definición del método que manejará el evento de clic del botón


            rjInputsCabecera.TextBoxText = InterfaceConfig.client;
            rjInputsCabecera.BorderFocusColor = IncialColorInputs;
            rjInputsUsuario.TextBoxText = InterfaceConfig.userName;
            rjInputsUsuario.BorderFocusColor = IncialColorInputs;
            rjInputsContraseña.TextBoxText = InterfaceConfig.password;
            rjInputsContraseña.BorderFocusColor = IncialColorInputs;
            rjInputsUrlResultados.TextBoxText = InterfaceConfig.endPointResultados;
            rjInputsUrlResultados.BorderFocusColor = IncialColorInputs;
            rjInputsUrlToken.TextBoxText = InterfaceConfig.endPointToken;
            rjInputsUrlToken.BorderFocusColor = IncialColorInputs;
            rjInputsBaseURL.TextBoxText = InterfaceConfig.endPointBase;
            rjInputsBaseURL.BorderFocusColor = IncialColorInputs;
            rjInputsDispositivoMedico.TextBoxText = InterfaceConfig.medicalDevice;
            rjInputsDispositivoMedico.BorderFocusColor = IncialColorInputs;
            rjInputsReactivo.TextBoxText = InterfaceConfig.reactive;
            rjInputsReactivo.BorderFocusColor = IncialColorInputs;
        
            rjInputsNombreInterfaz.TextBoxText = InterfaceConfig.nombreEquipo;
            rjInputsNombreInterfaz.BorderFocusColor = IncialColorInputs;
            rjInputsNombrelogs.TextBoxText = InterfaceConfig.nombreLog;
            rjInputsNombrelogs.BorderFocusColor = IncialColorInputs;
            rjInputsIntervalo.TextBoxText = InterfaceConfig.intervalo;
            rjInputsIntervalo.BorderFocusColor = IncialColorInputs;

            if (InterfaceConfig.logActivo == "S" || InterfaceConfig.logActivo.Equals("S"))
            {
                rjToggleLog.Checked = true;
            }
            else {
                rjToggleLog.Checked = false;
            }

          


            #endregion

            #region Proceso para cargar la primera ventana
            //Color
            btnConexion.ForeColor = Color.FromArgb(64, 81, 252);

            


            //panelConexion.BackColor = Color.FromArgb(64, 81, 252);

            btnParametrizacion.ForeColor = Color.Gray;
            //panelParametrizacion.BackColor = Color.Gray;

            btnRuta.ForeColor = Color.Gray;
            //panelRuta.BackColor = Color.Gray;

            //Comportamiento
            panelConexion2.Visible = true;
            panelConexion2.Dock = DockStyle.Fill;
            
            //panelParametrizacion2.Visible = false;
            panelRuta2.Visible = false;
            #endregion

             heightInicial = rjInputsFormulariosControl5.Size.Height;           

        }


        private void Config_Load(object sender, EventArgs e)
        {

            btnConexion.BackColor = Color.SteelBlue;
            btnConexion.ForeColor = Color.White;
            btnConexion.Capture = true;
            RedondearBordesSuperior(btnParametrizacion, 5);
            RedondearBordesSuperior(btnConexion, 5);
            RedondearBordesSuperior(btnRuta, 5);
            RedondearEsquinas(panelContenedor, 10);
        }
        private void RedondearBordesSuperior(Control control, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio * 2, radio * 2, 180, 90); // Esquina superior izquierda
            path.AddArc(control.Width - radio * 2, 0, radio * 2, radio * 2, 270, 90); // Esquina superior derecha
            path.AddArc(control.Width - radio * 2, control.Height - radio * 2, radio * 2, radio * 2, 0, 90); // Esquina inferior derecha
            path.AddArc(0, control.Height - radio * 2, radio * 2, radio * 2, 90, 90); // Esquina inferior izquierda
            control.Region = new Region(path);
        }
 

        private void btnParametrizacion_Click(object sender, EventArgs e)
        {
            //Color
            btnParametrizacion.BackColor = Color.SteelBlue;
            btnParametrizacion.ForeColor = Color.White;

            //panelParametrizacion.BackColor = Color.FromArgb(64, 81, 252);


            btnConexion.BackColor = Color.White;
            btnConexion.ForeColor = Color.Gray;
            //panelConexion.BackColor = Color.Gray;

            btnRuta.BackColor = Color.White;
            btnRuta.ForeColor = Color.Gray;
            //panelRuta.BackColor = Color.Gray;


            //Comportamiento
            panelParametrizacion2.Visible = true;
            panelParametrizacion2.Dock = DockStyle.Fill;

            panelConexion2.Visible = false;
            panelRuta2.Visible = false;
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            //Color
            btnRuta.ForeColor = Color.White;
            btnRuta.BackColor = Color.SteelBlue;
            //panelRuta.BackColor = Color.FromArgb(64, 81, 252);

            btnConexion.BackColor = Color.White;
            btnConexion.ForeColor = Color.Gray;
            //panelConexion.BackColor = Color.Gray;

            btnParametrizacion.BackColor = Color.White;
            btnParametrizacion.ForeColor = Color.Gray;
            //panelParametrizacion.BackColor = Color.Gray;

            //Comportamiento
            panelRuta2.Visible = true;
            panelRuta2.Dock = DockStyle.Fill;

            panelConexion2.Visible = false;
            panelParametrizacion2.Visible = false;
        }
        private void BtnConexion_Click(object sender, EventArgs e)
        {
            // Tu código aquí para manejar el evento de clic del botón
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
         
        }

       

    

        private void Config_Load_1(object sender, EventArgs e)
        {

        }

        private void lblIntervalo_Click(object sender, EventArgs e)
        {

        }

        private void panelIntervalo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void txtNombreEquipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConexion_Click(object sender, EventArgs e)
        {
            
            //Color
            btnConexion.BackColor = Color.SteelBlue;
            btnConexion.ForeColor = Color.White;

            //panelConexion.BackColor = Color.FromArgb(64, 81, 252);

            btnParametrizacion.BackColor = Color.White;
            btnParametrizacion.ForeColor = Color.Gray;

            //panelParametrizacion.BackColor = Color.Gray;

            btnRuta.BackColor = Color.White;
            btnRuta.ForeColor = Color.Gray;
            //panelRuta.BackColor = Color.Gray;

            //Comportamiento
            panelConexion2.Visible = true;
            panelConexion2.Dock = DockStyle.Fill;

            panelParametrizacion2.Visible = false;
            panelRuta2.Visible = false;
        }

        private void rjButton1_MouseHover(object sender, EventArgs e)
        {
            rjButton1.BackColor = Color.FromArgb(25, 183, 175);
        }

        //private void rjButton1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    rjButton1.BackColor = Color.FromArgb(25, 183, 175);
        //}

        private void rjButton1_MouseMove(object sender, MouseEventArgs e)
        {
            rjButton1.BackColor = Color.FromArgb(25, 183, 175);
        }

        private void rjButton1_MouseEnter(object sender, EventArgs e)
        {
            rjButton1.BackColor = Color.FromArgb(25, 183, 175);
        }

        private void rjButton1_MouseDown(object sender, MouseEventArgs e)
        {
            rjButton1.BackColor = Color.FromArgb(25, 183, 175);
        }


        private void Config_SizeChanged(object sender, EventArgs e)
        {

           
            // Obtener el tamaño actual del formulario
            int nuevoAncho = panelContenedor.Size.Width;
            int nuevoAlto = panelContenedor.Size.Height;

            // Establecer el nuevo tamaño para el panel
            panelContenedor.Size = new Size(nuevoAncho, nuevoAlto); ;
            RedondearEsquinas(panelContenedor, 10);
         
            int medio = this.Width / 2;
            int medioPanel = 700;

           
     
            panel3.Padding = new Padding(15, 15, 15, 15);
            panel7.Padding = new Padding(7, 7, 7, 7);
            panel8.Padding = new Padding(7, 7, 7, 7);
            panel14.Padding = new Padding(7, 7, 7, 7);
            panel10.Padding = new Padding(7, 40, 7, 7);


            if (medio >= 768)
            {




                panel3.Padding = new Padding(50, 150, 50, 150);
                panel7.Padding = new Padding(50, 150, 50, 150);
                panel8.Padding = new Padding(50, 150, 50, 150);
                panel14.Padding = new Padding(50, 150, 50, 150);
                panel10.Padding = new Padding(7, 150, 7, 50);

       

                rjInputsFormulariosControl8.Size = new Size(medioPanel, rjInputsFormulariosControl5.Size.Height + 10);
                rjInputsFormulariosControl7.Size = new Size(medio, rjInputsFormulariosControl7.Size.Height + 10);
                rjInputsFormulariosControl6.Size = new Size(medio, rjInputsFormulariosControl6.Size.Height + 10);
                rjInputsFormulariosControl5.Size = new Size(medio, rjInputsFormulariosControl5.Size.Height + 10);
               
                rjInputsNombreInterfaz.Size = new Size(medioPanel, rjInputsFormulariosControl5.Size.Height + 10);
                rjInputsNombrelogs.Size = new Size(medioPanel, rjInputsFormulariosControl5.Size.Height + 10);
                rjInputsIntervalo.Size = new Size(medioPanel, rjInputsFormulariosControl5.Size.Height + 10);
               



                // Pantalla grande: ajusta el diseño para una pantalla grande


                this.Invalidate();
            }
            else {

       


                rjInputsFormulariosControl8.Size = new Size(medio, heightInicial);
                rjInputsFormulariosControl7.Size = new Size(medio, heightInicial);
                rjInputsFormulariosControl6.Size = new Size(medio, heightInicial);
                rjInputsFormulariosControl5.Size = new Size(medio, heightInicial);

                rjInputsNombreInterfaz.Size = new Size(medio, heightInicial);
                rjInputsNombrelogs.Size = new Size(medio, heightInicial);
                rjInputsIntervalo.Size = new Size(medio, heightInicial);
            }
            if (medio <= 370)
            {
                pictureBox3.Visible = false;
                tableLayoutPanel3.ColumnCount = 1;
                this.Invalidate();
            }
            else {
                pictureBox3.Visible = true;
              
                tableLayoutPanel3.ColumnCount = 2;
                this.Invalidate();
            }

            if (medio <= 370)
            {
                pictureBox2.Visible = false;
                this.Invalidate();
            }
            else {
                pictureBox2.Visible = true;
                this.Invalidate();
            }




            if (medio >= 655 && medio <= 768)
            {
                // Ajustes específicos para este rango
               
                this.Invalidate();
            }

            if (medio >= 511 && medio <= 655)
            {
                // Ajustes específicos para este rango
                
                this.Invalidate();
            }

            if (medio >= 500 && medio <= 510)
            {
                // Ajustes específicos para este rango
               
                this.Invalidate();
            }

            if (medio <= 467)
            {
                
                // Ajustes específicos para este rango
               
                this.Invalidate();
            }

            // Aplicar configuraciones comunes


            //// Forzar la actualización del panelDashContenedor
            panelContenedor.Invalidate();

            //// Ajustar automáticamente el tamaño y la posición de los controles según el modo de escala automática
            ScaleControls();


        }
      

        private void RedondearEsquinas(Control control, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio * 2, radio * 2, 180, 90); // Esquina superior izquierda
            path.AddArc(control.Width - radio * 2, 0, radio * 2, radio * 2, 270, 90); // Esquina superior derecha
            path.AddArc(control.Width - radio * 2, control.Height - radio * 2, radio * 2, radio * 2, 0, 90); // Esquina inferior derecha
            path.AddArc(0, control.Height - radio * 2, radio * 2, radio * 2, 90, 90); // Esquina inferior izquierda

            // Cerrar el path para asegurar que el borde sea cerrado completamente
            path.CloseFigure();

            control.Region = new Region(path);
        }

        private void ScaleControls()
        {
            // Utilizar el modo de escala automática proporcionado por WinForms
            this.AutoScaleMode = AutoScaleMode.Dpi; // O AutoScaleMode.Font según tus preferencias

            // Forzar el rediseño y el repintado de los controles
            this.PerformLayout();
            this.Refresh();
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

      

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            #region Conexión
            if (!string.IsNullOrEmpty(rjInputsCabecera.TextBoxText) &&
                !string.IsNullOrEmpty(rjInputsUsuario.TextBoxText) &&
                !string.IsNullOrEmpty(rjInputsContraseña.TextBoxText) &&
                !string.IsNullOrEmpty(rjInputsUrlToken.TextBoxText) &&
                !string.IsNullOrEmpty(rjInputsUrlResultados.TextBoxText) &&
                !string.IsNullOrEmpty(rjInputsDispositivoMedico.TextBoxText) &&
                !string.IsNullOrEmpty(rjInputsReactivo.TextBoxText) &&
                !string.IsNullOrEmpty(rjInputsBaseURL.TextBoxText) 
                )
            {
                try
                {
                    UpdateConfigKey("client", rjInputsCabecera.TextBoxText, 1);
                    UpdateConfigKey("userName", rjInputsUsuario.TextBoxText, 1);
                    UpdateConfigKey("password", rjInputsContraseña.TextBoxText, 1);
                    UpdateConfigKey("endPointBase", rjInputsBaseURL.TextBoxText, 1);
                    UpdateConfigKey("endPointResultados", rjInputsUrlResultados.TextBoxText, 1);
                    UpdateConfigKey("endPointToken", rjInputsUrlToken.TextBoxText, 1);
                    UpdateConfigKey("medicalDevice", rjInputsDispositivoMedico.TextBoxText, 1);
                    UpdateConfigKey("reactive", rjInputsReactivo.TextBoxText, 1);


                    DialogResult result;
                    using (var msFomr = new FormMessageBox("Datos de conexión guardados correctamente. ", "OK", MessageBoxButtons.OK, MessageBoxIcon.None))
                        result = msFomr.ShowDialog();
                }
                catch (Exception ex)
                {
                    DialogResult result;
                    using (var msFomr = new FormMessageBox($"No se pudo guardar correctamente. {ex}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error))
                        result = msFomr.ShowDialog();
                }
            }
            else
            {
                DialogResult result;
                using (var msFomr = new FormMessageBox($"No puede enviar campos vacíos. ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information))
                    result = msFomr.ShowDialog();
            }
            #endregion
        }

        private void UpdateConfigKey(string strKey, string newValue, int seccion)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathConfig);

            if (!ConfigKeyExists(strKey, seccion))
            {
                throw new ArgumentNullException("Key", "<" + strKey + "> not found in the configuration.");
            }

            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");

            foreach (XmlNode childNode in appSettingsNode)
            {
                condicional = childNode.NodeType.ToString();

                if (condicional == "Comment")
                {
                    continue;
                }
                else if (childNode.Attributes["key"].Value == strKey)
                {
                    childNode.Attributes["value"].Value = newValue;
                }
            }

            xmlDoc.Save(pathConfig);
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            ConfigurationManager.RefreshSection("appSettings");
        }

        private bool ConfigKeyExists(string strKey, int seccion)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathConfig);

            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");

            foreach (XmlNode childNode in appSettingsNode)
            {
                condicional = childNode.NodeType.ToString();

                if (condicional == "Comment")
                {
                    continue;
                }
                else if (childNode.Attributes["key"].Value == strKey)
                {
                    return true;
                }
            }

            return false;
        }


        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnConexion_MouseHover(object sender, EventArgs e)
        {
            if (!btnConexion.Focused && !btnConexion.Capture )
            {
                btnConexion.BackColor = Color.FromArgb(46, 189, 255);
                btnConexion.ForeColor = Color.White;
                this.Invalidate();
            }
        }
        private void btnConexion_MouseLeave(object sender, EventArgs e)
        {
            if (!btnConexion.Focused)
            {
                btnConexion.BackColor = Color.White;
                btnConexion.ForeColor = Color.Gray;
            }
        }

        private void btnParametrizacion_MouseHover(object sender, EventArgs e)
        {
            if (!btnParametrizacion.Focused )
            {
                btnParametrizacion.BackColor = Color.FromArgb(46, 189, 255);
                btnParametrizacion.ForeColor = Color.White;
                this.Invalidate();
            }
        }

        private void btnParametrizacion_MouseLeave(object sender, EventArgs e)
        {
            if (!btnParametrizacion.Focused)
            {
                btnParametrizacion.BackColor = Color.White;
                btnParametrizacion.ForeColor = Color.Gray;
            }
        }

        private void btnParametrizacion_MouseMove(object sender, MouseEventArgs e)
        {
            btnParametrizacion_MouseHover(sender, e);
        }

        private void btnConexion_MouseMove(object sender, MouseEventArgs e)
        {
            btnConexion_MouseHover(sender, e);
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {

            if (
                !string.IsNullOrEmpty(rjInputsNombreInterfaz.TextBoxText) &&
                !string.IsNullOrEmpty(rjInputsNombrelogs.TextBoxText) &&
                !string.IsNullOrEmpty(rjInputsIntervalo.TextBoxText) 
                )
            {
                try
                {
                   
                    UpdateConfigKey("nombreEquipo", rjInputsNombreInterfaz.TextBoxText, 1);
                    UpdateConfigKey("nombreLog", rjInputsNombrelogs.TextBoxText, 1);
                    UpdateConfigKey("intervalo", rjInputsIntervalo.TextBoxText, 1);
                   

                    DialogResult result;
                    using (var msFomr = new FormMessageBox("Datos de parametrización guardados correctamente. ", "OK", MessageBoxButtons.OK, MessageBoxIcon.None))
                        result = msFomr.ShowDialog();
                }
                catch (Exception ex)
                {
                    DialogResult result;
                    using (var msFomr = new FormMessageBox($"No se pudo guardar correctamente. {ex}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error))
                        result = msFomr.ShowDialog();
                }
            }
            else
            {
                DialogResult result;
                using (var msFomr = new FormMessageBox($"No puede enviar campos vacíos. ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information))
                    result = msFomr.ShowDialog();
            }


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click_1(object sender, EventArgs e)
        {
            string log;
            if (rjToggleLog.Checked)
            {
                log = "S";
            }
            else {
                log = "N";
            }
            

            if (
                !string.IsNullOrEmpty(rjInputsNombreInterfaz.TextBoxText) &&
                !string.IsNullOrEmpty(rjInputsNombrelogs.TextBoxText) &&
                !string.IsNullOrEmpty(rjInputsIntervalo.TextBoxText)
                )
            {
                try
                {

                    UpdateConfigKey("nombreEquipo", rjInputsNombreInterfaz.TextBoxText, 1);
                    UpdateConfigKey("nombreLog", rjInputsNombrelogs.TextBoxText, 1);
                    UpdateConfigKey("intervalo", rjInputsIntervalo.TextBoxText, 1);
                    UpdateConfigKey("intervalo", rjInputsIntervalo.TextBoxText, 1);
                    UpdateConfigKey("logActivo", log, 1);


                    DialogResult result;
                    using (var msFomr = new FormMessageBox("Datos de parametrización guardados correctamente. ", "OK", MessageBoxButtons.OK, MessageBoxIcon.None))
                        result = msFomr.ShowDialog();
                }
                catch (Exception ex)
                {
                    DialogResult result;
                    using (var msFomr = new FormMessageBox($"No se pudo guardar correctamente. {ex}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error))
                        result = msFomr.ShowDialog();
                }
            }
            else
            {
                DialogResult result;
                using (var msFomr = new FormMessageBox($"No puede enviar campos vacíos. ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information))
                    result = msFomr.ShowDialog();
            }
        }
    }
}
