using DM_MICROS_ESV60.Forms;
using DM_MICROS_ESV60.Properties;
using DM_MICROS_ESV60.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;
using static DM_MICROS_ESV60.Forms.Resultados;

namespace DM_MICROS_ESV60
{
    public partial class Dashboard : Form
    {
        public string token = string.Empty;
        Resultados terminal = new Resultados();
        Config config = new Config();
        private Form activeForm = null;
        private string espacioTexto = "    ";
        private bool estadoBtnConectar = true;

        public Dashboard()
        {
            InitializeComponent();
            Text = InterfaceConfig.nombreEquipo + " - v" + Application.ProductVersion;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            rjbResultados.PerformClick();
            rjbResultados.Enabled = false;
        }

        private void Dashboard_SizeChanged(object sender, EventArgs e)
        {
            var widthClient = this.ClientSize.Width;
            if (widthClient <= 1000) rjbConectar.Text = "";
            else
            {
                if (estadoBtnConectar) rjbConectar.Text = "Conectar";
                else rjbConectar.Text = "Desconectar";
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.TopMost = true;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            using (var msFomr = new FormMessageBox("¿Desea cerrar la interfaz?", "Advertencia", MessageBoxButtons.YesNo))
            {
                result = msFomr.ShowDialog();
            }

            if (result.Equals(DialogResult.Yes))
            {
                Dispose();
                Environment.Exit(1);
            }
            else e.Cancel = true;
        }

        private void rjbConectar_Click(object sender, EventArgs e)
        {
            try
            {
                terminal = (Resultados)Application.OpenForms[1];

                if (!VariablesGlobal.Conectar)
                {
                    //Activación del puerto
                    terminal.AbrirPuerto();
                }
            }
            catch (Exception)
            {
                terminal.MensajesEstadosTerminal("Error en intento para establecer conexión con el puerto COM", EnumEstados.Error);
            }

            if (estadoBtnConectar)
            {
                rjbConectar.BackgroundColor = Color.FromArgb(163, 162, 162);
                rjbConectar.Text = "Desconectar";
                rjbConectar.Image = Resources.Desconectar;
                estadoBtnConectar = false;
                rjbConfiguracion.Enabled = false;
            }
            else
            {
                if (!VariablesGlobal.Conectar)
                {
                    rjbConectar.BackgroundColor = Color.FromArgb(21, 224, 213);
                    rjbConectar.Text = "Conectar";
                    rjbConectar.Image = Resources.Conectar;
                    estadoBtnConectar = true;
                    rjbConfiguracion.Enabled = true;
                }
            }
            Dashboard_SizeChanged(sender, e);
            rjbConectar_MouseHover(sender, e);
        }

        private void rjbResultados_Click(object sender, EventArgs e)
        {
            InterfaceConfig.InitializeConfig();

            //Activación de botones
            rjbResultados.Enabled = false;
            rjbConfiguracion.Enabled = true;
            rjbTitulo.Enabled = true;
            rjbConectar.Enabled = true;

            rjbConfiguracion.BackColor = Color.White;
            rjbConfiguracion.Image = Resources.btn_configuracion;
            rjbConfiguracion.ForeColor = Color.FromArgb(62, 62, 62);

            rjbTitulo.Text = espacioTexto + "Carga de Resultados";

            rjbResultados.BackColor = Color.FromArgb(99, 121, 217);
            rjbResultados.Image = Resources.btn_carga2;
            rjbResultados.ForeColor = Color.White;

            OpenChildForm(new Resultados());

            VariablesGlobal.Config = false;
        }

        private void rjbConfiguracion_Click(object sender, EventArgs e)
        {
            //Activación de botones
            rjbConfiguracion.Enabled = false;
            rjbResultados.Enabled = true;
            rjbTitulo.Enabled = false;
            rjbConectar.Enabled = false;

            rjbResultados.BackColor = Color.White;
            rjbResultados.Image = Resources.btn_carga1;
            rjbResultados.ForeColor = Color.FromArgb(62, 62, 62);

            rjbTitulo.Text = espacioTexto + "Configuración";

            rjbConfiguracion.BackColor = Color.FromArgb(21, 224, 213);
            rjbConfiguracion.Image = Resources.btn_configuracion_white;
            rjbConfiguracion.ForeColor = Color.White;

            OpenChildForm(new Config());

            VariablesGlobal.Config = true;
        }

        private void rjbTitulo_Click(object sender, EventArgs e)
        {
            try
            {
                terminal = (Resultados)Application.OpenForms[1];

                // Cambia la visibilidad de los FlowLayoutPanel en el formulario hijo
                if (terminal != null)
                {
                    //terminal.flpCOMVisible = !terminal.flpCOMVisible;
                    if (!terminal.flpCOMVisible)
                    {
                        terminal.flpCOMVisible = true;
                    }
                    else
                    {
                        terminal.flpCOMVisible = false;
                    }
                }
            }
            catch (Exception)
            {
                terminal.MensajesEstadosTerminal("Error en visibilidad de configuración COM",EnumEstados.Error);
            }
        }

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        terminal = (Resultados)Application.OpenForms[1];

        //        terminal.LimpiarTerminal();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
