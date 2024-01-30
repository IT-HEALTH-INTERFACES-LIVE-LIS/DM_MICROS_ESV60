using DM_MICROS_ESV60.Models;
using DM_MICROS_ESV60.Properties;
using DM_MICROS_ESV60.RJControls;
using DM_MICROS_ESV60.Services;
using DM_MICROS_ESV60.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DM_MICROS_ESV60.Forms
{
    #region Enumeraciones públicas
    public enum DataMode { Text, Hex }
    public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
    #endregion

    public partial class Resultados : Form
    {
        #region Variables locales
        // Control principal para comunicarse a través del puerto RS-232
        private SerialPort comport = new SerialPort();

        // Varios colores para la información de registro
        private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };

        // Temporizador para saber si se ha pulsado una tecla
        private bool KeyHandled = false;

        private Settings settings = Settings.Default;
        RegistroLog log = new RegistroLog();
        public string nombreLog = InterfaceConfig.nombreLog;
        readonly ServicioLiveLis servicioLiveLis = new ServicioLiveLis();
        #endregion

        public string[] ArrPaquete = new string[91];
        public string[] ArrPaqueteResultado = new string[3000];
        public string[] ArrPaqueteETX = new string[3000];
        public string[] ArrPaqueteETB = new string[3000];
        public string StrLineaEstudio = "";
        public string timeractivo = "N";
        public string strLineaResultado = "";
        public string iniciaRecepcion = "N";
        public string strLineaRestante = "";
        public string CharEnviado;
        public int inc;
        public int incr;

        public enum EnumEstados { Ok, Info, Process, Warning, Error, Empty }
        public RJButton nuevoButton;

        public const char EOT = (char)4;
        public const char US = (char)31;
        public const char RS = (char)30;
        public const char ACK = (char)6;
        public const char NAK = (char)21;
        public const char ENQ = (char)5;
        public const char STX = (char)2;
        public const char ETX = (char)3;
        public const char ETB = (char)23;
        public const char LF = '\n';
        public const char CR = '\r';
        public const char FS = (char)28;
        public const char SUB = (char)26;

        public class T
        {
            public const byte ENQ = 5;
            public const byte ACK = 6;
            public const byte NAK = 21;
            public const byte EOT = 4;
            public const byte ETX = 3;
            public const byte ETB = 23;
            public const byte STX = 2;
            public const byte NEWLINE = 10;
            public static byte[] ACK_BUFF = { ACK };
            public static byte[] ENQ_BUFF = { ENQ };
            public static byte[] NAK_BUFF = { NAK };
            public static byte[] EOT_BUFF = { EOT };
        }

        #region Constructor
        public Resultados()
        {
            // Construir el formulario
            InitializeComponent();

            // Cargar la configuración del usuario
            settings.Reload();

            // Restaurar la configuración de los usuarios
            LlenarComboBox();
            InitializeControlValues();

            // Activar/desactivar controles en función del estado actual
            EnableControls();

            // Cuando se reciben datos a través del puerto, llama a este método
            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            comport.PinChanged += new SerialPinChangedEventHandler(comport_PinChanged);
        }

        void comport_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            // Mostrar el estado de los pines
            UpdatePinState();
        }

        //Puerto Serial
        private void UpdatePinState()
        {
            this.Invoke(new ThreadStart(() =>
            {
                // Mostrar el estado de los pines
                chkCD.Checked = comport.CDHolding;
                chkCTS.Checked = comport.CtsHolding;
                chkDSR.Checked = comport.DsrHolding;

                chkCD.Checked = comport.CDHolding;
                chkCTS.Checked = comport.CtsHolding;
                chkDSR.Checked = comport.DsrHolding;
            }));
        }
        #endregion

        #region Métodos locales
        //Puerto Serial
        //Guardar la configuración del usuario
        public void SaveSettings()
        {
            settings.BaudRate = int.Parse(cmbBaudRate.ComboBoxControl.Text);
            settings.DataBits = int.Parse(cmbDataBits.ComboBoxControl.Text);
            settings.DataMode = CurrentDataMode;
            settings.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.ComboBoxControl.Text);
            settings.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.ComboBoxControl.Text);
            settings.PortName = cmbPortName.ComboBoxControl.Text;
            settings.ClearOnOpen = chkClearOnOpen.Checked;
            settings.ClearWithDTR = chkClearWithDTR.Checked;

            settings.Save();
        }

        //Puerto Serial
        //Rellenar los controles del formulario con la configuración por defecto
        private void InitializeControlValues() //Validar, comentado de momento
        {
            cmbParity.ComboBoxControl.Items.Clear(); cmbParity.ComboBoxControl.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cmbStopBits.ComboBoxControl.Items.Clear(); cmbStopBits.ComboBoxControl.Items.AddRange(Enum.GetNames(typeof(StopBits)));

            cmbParity.ComboBoxControl.Text = settings.Parity.ToString();
            cmbStopBits.ComboBoxControl.Text = settings.StopBits.ToString();
            cmbDataBits.ComboBoxControl.Text = settings.DataBits.ToString();
            cmbBaudRate.ComboBoxControl.Text = settings.BaudRate.ToString();
            CurrentDataMode = settings.DataMode;

            RefreshComPortList();

            chkClearOnOpen.Checked = settings.ClearOnOpen;
            chkClearWithDTR.Checked = settings.ClearWithDTR;

            // Si aún está disponible, seleccione el último puerto utilizado.
            if (cmbPortName.ComboBoxControl.Items.Contains(settings.PortName))
            {
                cmbPortName.ComboBoxControl.Text = settings.PortName;
            }
            else if (cmbPortName.ComboBoxControl.Items.Count > 0)
            {
                cmbPortName.ComboBoxControl.SelectedIndex = cmbPortName.ComboBoxControl.Items.Count - 1;
            }
            else
            {
                DialogResult result;
                using (var msFomr = new FormMessageBox("No se han detectado puertos COM en este ordenador.\nInstale un puerto COM y reinicie la aplicación.\nNo hay puertos COM instalados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error))
                {
                    result = msFomr.ShowDialog();
                }
                this.Close();
            }
        }

        //Puerto Serial
        //Activar/desactivar controles en función del estado actual de la aplicación
        public void EnableControls() //Validar, comentado de momento
        {
            // Activar/desactivar controles en función de si el puerto está abierto o no
            flpCOM.Enabled = !comport.IsOpen;
        }

        //Enviar los datos del usuario introducidos actualmente en la casilla "enviar".
        private void SendData(string strlinea)
        {
            if (CurrentDataMode == DataMode.Text)
            {
                // Enviar el texto del usuario directamente al puerto
                comport.Write(strlinea);

                // Mostrar en la ventana del terminal el texto del usuario
                Log(LogMsgType.Outgoing, strlinea + "\n");
            }
            else
            {
                try
                {
                    // Convertir la cadena de dígitos hexadecimales del usuario (por ejemplo: B4 CA E2) en una matriz de bytes.
                    byte[] data = HexStringToByteArray(strlinea);

                    // Envía los datos binarios por el puerto
                    comport.Write(data, 0, data.Length);

                    // Mostrar los dígitos hexadecimales en la ventana del terminal
                    Log(LogMsgType.Outgoing, ByteArrayToHexString(data) + "\n");
                }
                catch (FormatException)
                {
                    // Informar al usuario si la cadena hexadecimal no se ha formateado correctamente
                    Log(LogMsgType.Error, "Cadena hexadecimal mal formateada:");
                }
            }
        }

        /// <summary> Registrar datos en la ventana del terminal. </summary>
        /// <param name="msgtype"> El tipo de mensaje que se va a escribir. </param>
        /// <param name="msg"> La cadena que contiene el mensaje a mostrar. </param>
        private void Log(LogMsgType msgtype, string msg)
        {
            string tipomsg = "";
            string tokenObtenido = "";

            if (msgtype.ToString() == "Outgoing") { tipomsg = "Enviado"; }
            if (msgtype.ToString() == "Incoming") { tipomsg = "Recibido"; }

            if (CharEnviado == null)
            {
                CharEnviado = "";
            }

            if ((msgtype.ToString() == "Incoming") && (CharEnviado.Contains("ENQ")) && (msg.Contains(EOT)))
            {
                SendData(ACK.ToString());
            }

            if ((msgtype.ToString().Contains("Incoming")) && (CharEnviado.Contains("ENQ")) && (msg == ACK.ToString()) && (iniciaRecepcion.Contains("N")))
            {
                enviapaquete();
            }

            if ((msgtype.ToString().Contains("Incoming")) && (msg.Contains(ENQ.ToString())))
            {
                log.RegistraEnLog(" Inicio Recepcion de resultados --> ", InterfaceConfig.nombreLog);

                timeractivo = "N";
                incr = 0;
                iniciaRecepcion = "S";
                CharEnviado = "ACK";
                strLineaResultado = "";
                SendData(ACK.ToString());
            }

            if (msgtype.ToString() == "Incoming")
            {
                //Guardar paquete recibido
                strLineaResultado = strLineaResultado + msg.ToString();
                SendData(ACK.ToString());
            }

            if ((msgtype.ToString() == "Incoming") && (msg.Contains(EOT)))
            {
                MensajesEstadosTerminal("Recepción de resultados en proceso...", EnumEstados.Process);
                VariablesGlobal.Conectar = true;

                timeractivo = "S";
                CharEnviado = "";
                iniciaRecepcion = "N";
                incr = 0;

                strLineaResultado = strLineaRestante + strLineaResultado;
                ArrPaqueteETX = strLineaResultado.Split(ETX);
                strLineaRestante = ArrPaqueteETX[ArrPaqueteETX.Length - 1];

                try
                {
                    strLineaResultado = "";
                    for (var x = 0; x <= ArrPaqueteETX.Length - 2; x++)
                    {
                        strLineaResultado = strLineaResultado + ArrPaqueteETX[x].Split(CR)[1].Trim();
                    }
                }
                catch (FormatException)
                {
                    log.RegistraEnLog(" Error cargando paquete ArrPaqueteETX ", InterfaceConfig.nombreLog);
                }

                // timeractivo = "S";
                CharEnviado = "";
                // iniciaRecepcion = "N";
                incr = 0;

                try
                {
                    for (var x = 0; x <= ArrPaqueteResultado.Length - 1; x++)
                    {
                        ArrPaqueteResultado[x] = null;
                    }
                }
                catch (FormatException)
                {
                    log.RegistraEnLog(" Error limpiando Arreglo  ArrPaqueteResultado[x] ", InterfaceConfig.nombreLog);
                }

                // strLineaResultado = strLineaResultado.Replace(STX.ToString(), "");
                //strLineaResultado = strLineaResultado.Replace(ENQ.ToString(), "");
                strLineaResultado = strLineaResultado.Replace(ETB.ToString(), "");
                // strLineaResultado = strLineaResultado.Replace(EOT.ToString(), "");
                ArrPaqueteResultado = strLineaResultado.Split(STX);

                for (var x = 0; x <= ArrPaqueteResultado.Length - 1; x++)
                {
                    log.RegistraEnLog(" Paquete Recibido " + Convert.ToString(x) + " --> " + ArrPaqueteResultado[x], InterfaceConfig.nombreLog);
                }

                //Obtener Token
                tokenObtenido = servicioLiveLis.ObtenerToken();
                ProcesarResultados(ArrPaqueteResultado.ToList(), tokenObtenido);

                strLineaResultado = "";
                VariablesGlobal.Conectar = false;
                MensajesEstadosTerminal("", EnumEstados.Empty);

                for (var x = 0; x <= ArrPaqueteETX.Length - 1; x++)
                {
                    ArrPaqueteETX[x] = null;
                }
            }

            //Validar comentado de momento
            //flpContenedorResul.Invoke(new EventHandler(delegate
            //{
            //    log.RegistraEnLog(tipomsg + " --> " + msg, "Interfaz_Tramas_" + InterfaceConfig.nombreEquipo);
            //    flpContenedorResul.SelectedText = string.Empty;
            //    flpContenedorResul.Clear();
            //    flpContenedorResul.SelectionFont = new Font(flpContenedorResul.SelectionFont, FontStyle.Bold);
            //    flpContenedorResul.SelectionColor = LogMsgTypeColor[(int)msgtype];
            //    flpContenedorResul.AppendText(msg);
            //    flpContenedorResul.AppendText("Esperando Resultados...");
            //    flpContenedorResul.ScrollToCaret();
            //}));
        }

        /// <summary> Convertir una cadena de dígitos hexadecimales (por ejemplo: E4 CA B2) en una matriz de bytes. </summary>
        /// <param name="s"> La cadena que contiene los dígitos hexadecimales (con o sin espacios). </param>
        /// <returns> Devuelve una matriz de bytes. </returns>
        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary> Convierte una matriz de bytes en una cadena formateada de dígitos hexadecimales (por ejemplo: E4 CA B2).</summary>
        /// <param name="data"> El array de bytes a traducir en una cadena de dígitos hexadecimales. </param>
        /// <returns> Devuelve una cadena bien formateada de dígitos hexadecimales con espaciado. </returns>
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }
        #endregion

        #region Propiedades locales
        //Puerto Serial
        private DataMode CurrentDataMode
        {
            get
            {
                if (rbHex.Checked) return DataMode.Hex;
                else return DataMode.Text;
            }
            set
            {
                if (value == DataMode.Text) rbText.Checked = true;
                else rbHex.Checked = true;
            }
        }
        #endregion

        #region Manejadores de eventos
        //Puerto Serial
        private void rbText_CheckedChanged(object sender, EventArgs e)
        {
            if (rbText.Checked) CurrentDataMode = DataMode.Text;
        }

        //Puerto Serial
        private void rbHex_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHex.Checked) CurrentDataMode = DataMode.Hex;
        }

        //Puerto Serial
        private void chkDTR_CheckedChanged(object sender, EventArgs e)
        {
            comport.DtrEnable = chkDTR.Checked;
            if (chkDTR.Checked && chkClearWithDTR.Checked) LimpiarTerminal();
        }

        //Puerto Serial
        private void chkRTS_CheckedChanged(object sender, EventArgs e)
        {
            comport.RtsEnable = chkRTS.Checked;
        }

        //Puerto Serial
        private void cmbBaudRate_Validating(object sender, CancelEventArgs e)
        {
            int x; e.Cancel = !int.TryParse(cmbBaudRate.ComboBoxControl.Text, out x);
        }

        //Puerto Serial
        private void cmbDataBits_Validating(object sender, CancelEventArgs e)
        {
            int x; e.Cancel = !int.TryParse(cmbDataBits.ComboBoxControl.Text, out x);
        }

        //Puerto Serial
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Si el puerto com ha sido cerrado, no haga nada
            if (!comport.IsOpen) return;

            // Este método será llamado cuando haya datos esperando en el buffer del puerto

            // Determina en qué modo (cadena o binario) se encuentra el usuario
            if (CurrentDataMode == DataMode.Text)
            {
                // Leer todos los datos en espera en el búfer
                string data = comport.ReadExisting();

                // Mostrar el texto al usuario en el terminal
                Log(LogMsgType.Incoming, data);
            }
            else
            {
                // Obtener el número de bytes en espera en el búfer del puerto
                int bytes = comport.BytesToRead;

                // Crear una matriz de bytes para almacenar los datos entrantes
                byte[] buffer = new byte[bytes];


                // Leer los datos del puerto y almacenarlos en nuestro buffer
                comport.Read(buffer, 0, bytes);

                // Mostrar al usuario los datos entrantes en formato hexadecimal
                Log(LogMsgType.Incoming, ByteArrayToHexString(buffer));
            }
        }
        #endregion

        #region Metodos para puerto serial
        //Puerto Serial
        private void RefreshComPortList()
        {
            // Determain si la lista de nombres de puertos com ha cambiado desde la última vez que se comprobó.
            string selected = RefreshComPortList(cmbPortName.ComboBoxControl.Items.Cast<string>(), cmbPortName.ComboBoxControl.SelectedItem as string, comport.IsOpen);

            // Si hubo una actualización, entonces actualiza el control mostrando al usuario la lista de nombres de puertos
            if (!String.IsNullOrEmpty(selected))
            {
                cmbPortName.ComboBoxControl.Items.Clear();
                cmbPortName.ComboBoxControl.Items.AddRange(OrderedPortNames());
                cmbPortName.ComboBoxControl.SelectedItem = selected;
            }
        }

        //Puerto Serial
        private string[] OrderedPortNames()
        {
            // Sólo un marcador de posición para un análisis correcto de una cadena a un número entero
            int num;

            // Ordene los nombres de los puertos serie en orden numérico (si es posible)
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }

        //Puerto Serial
        private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Crear un nuevo informe de retorno para rellenar
            string selected = null;

            // Recupera la lista de puertos montados actualmente por el sistema operativo (ordenados por nombre)
            string[] ports = SerialPort.GetPortNames();

            // Primer determain si ha habido cambios (altas o bajas)
            bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

            // Si se ha producido algún cambio, seleccione un puerto por defecto adecuado
            if (updated)
            {
                // Utilizar el conjunto correctamente ordenado de nombres de puertos
                ports = OrderedPortNames();

                // Buscar el puerto más nuevo si se han añadido uno o más
                string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                if (PortOpen)
                {
                    if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else selected = ports.LastOrDefault();
                }
                else
                {
                    if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else selected = ports.LastOrDefault();
                }
            }

            // Si se ha producido un cambio en la lista de puertos, devuelve la selección recomendada por defecto
            return selected;
        }
        #endregion

        #region Eventos del formulario resultados
        private void Resultados_Shown(object sender, EventArgs e)
        {
            //Log(LogMsgType.Normal, String.Format("Interfaz Iniciada {0}\n", DateTime.Now));
        }

        private void Terminal_Load(object sender, EventArgs e)
        {
            tmrCheckComPorts.Interval = Convert.ToInt32(settings.VelocidadBuffer);

            MensajesEstadosTerminal($"Interfaz iniciada", EnumEstados.Ok);
            MensajesEstadosTerminal($"Esperando resultados...", EnumEstados.Process);
            //MensajesEstadosTerminal($"Warning", EnumEstados.Warning);
            //MensajesEstadosTerminal($"Error", EnumEstados.Error);
            //MensajesEstadosTerminal($"Info", EnumEstados.Info);

            VariablesGlobal.Resultados = true;
        }

        private void Resultados_SizeChanged(object sender, EventArgs e)
        {
            // Obtener el tamaño actual del formulario
            int nuevoAncho = this.Size.Width;
            int nuevoAlto = this.Size.Height;

            // Establecer el nuevo tamaño para el panel
            flpContenedorResul.Size = new Size(nuevoAncho, nuevoAlto);
            RedondearEsquinas(flpCOM, 10);
            RedondearEsquinas(flpContenedorResul, 10);
        }

        private void Resultados_FormClosing(object sender, FormClosingEventArgs e)
        {
            // El formulario se está cerrando, guarda las preferencias del usuario
            SaveSettings();
        }
        #endregion

        #region Metodos formulario resultados
        public string ProcesarResultados(List<string> PaqueteResultado, string tokenObtenido)
        {
            MensajesEstadosTerminal("Inicio de procesamiento de resultados",EnumEstados.Process);

            //return null;

            string numeroMuestra = null;

            log.RegistraEnLog("Paquete recibido: " + Convert.ToString(PaqueteResultado.Count), nombreLog);

            for (var x = 0; x <= PaqueteResultado.Count - 1; x++)
            {
                if (!string.IsNullOrEmpty(PaqueteResultado[x]))
                {
                    string strlinea = PaqueteResultado[x];

                    string encabezado = "";

                    try
                    {
                        encabezado = strlinea.Substring(1, 1);
                    }
                    catch (Exception)
                    {
                        encabezado = "";
                    }

                    string[] arrLinea = strlinea.Split('|');

                    if (encabezado == "H" || encabezado == "Q" || encabezado == "P" || encabezado == "C") continue;

                    if (encabezado == "O")
                    {
                        numeroMuestra = arrLinea[2].ToString();
                        log.RegistraEnLog("Nro Tubo: " + numeroMuestra, nombreLog);
                        continue;
                    }

                    if (encabezado == "R")
                    {
                        string nombreAnalito = "";
                        string resultadoAnalito = "";

                        try
                        {
                            //banderaquery = "N";
                            var arrgNombreAnalito = arrLinea[2].Split('^');
                            nombreAnalito = arrgNombreAnalito[3];
                            resultadoAnalito = arrLinea[3];

                            ResultadoAnalito resultadoAnalitoJson = new ResultadoAnalito();

                            log.RegistraEnLog($"Analito Procesado [{nombreAnalito}], resultado[{resultadoAnalito}]", nombreLog);
                            MensajesEstadosTerminal($"Analito Procesado [{nombreAnalito}], resultado[{resultadoAnalito}]",EnumEstados.Ok);

                            resultadoAnalitoJson.sampleNumber = numeroMuestra;
                            resultadoAnalitoJson.analyte = nombreAnalito;
                            resultadoAnalitoJson.medicalDevice = InterfaceConfig.medicalDevice;
                            resultadoAnalitoJson.reactive = InterfaceConfig.reactive;
                            resultadoAnalitoJson.result = resultadoAnalito;

                            servicioLiveLis.EnviarResultados(resultadoAnalitoJson, tokenObtenido);
                            continue;
                        }
                        catch (Exception ex)
                        {
                            log.RegistraEnLog("Error en trama Segmento R : " + ex.Message, nombreLog);
                            MensajesEstadosTerminal($"Error procesando analito:[{nombreAnalito}], resultado[{resultadoAnalito}]", EnumEstados.Error);
                        }
                    }

                    if (encabezado == "L")
                    {
                        log.RegistraEnLog("Fin de procesamiento de resultados", nombreLog);
                        SendData(ENQ.ToString());
                    }
                }
            }
            
            return null;
        }

        //Metodo para mostrar los mensajes en el FlowLayoutPanel        
        public void MensajesEstadosTerminal(string msg, EnumEstados estado)
        {
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            nuevoButton = new RJButton();

            nuevoButton.Dock = DockStyle.Fill;
            nuevoButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            nuevoButton.ImageAlign = ContentAlignment.MiddleLeft;
            nuevoButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            nuevoButton.Width = 700;
            nuevoButton.Height = 50;
            nuevoButton.FlatStyle = FlatStyle.Flat;
            nuevoButton.FlatAppearance.BorderColor = Color.White;
            nuevoButton.FlatAppearance.BorderSize = 0;
            nuevoButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            nuevoButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            nuevoButton.BorderRadius = 15;
            nuevoButton.BorderSize = 2;
            nuevoButton.BackColor = Color.Transparent;
            nuevoButton.TextColor = Color.FromArgb(62, 62, 62);
            nuevoButton.ForeColor = Color.FromArgb(62, 62, 62);
            nuevoButton.FontSize = 10;
            nuevoButton.Text = $" {fechaActual}: " + msg;
            nuevoButton.Padding = new Padding(10, 2, 10, 2);
            //nuevoButton.AutoSize = true;            
            nuevoButton.Resize += button_Resize;

            switch (estado)
            {
                case EnumEstados.Ok:
                    nuevoButton.Image = Resources.OkM;
                    nuevoButton.BorderColor = Color.FromArgb(25, 183, 175);
                    break;

                case EnumEstados.Info:
                    nuevoButton.Image = Resources.Null;
                    nuevoButton.BorderColor = Color.FromArgb(99, 121, 216);
                    break;

                case EnumEstados.Process:
                    nuevoButton.Image = Resources.InterpretandoM;
                    nuevoButton.BorderColor = Color.FromArgb(99, 121, 216);
                    break;

                case EnumEstados.Warning:
                    nuevoButton.Image = Resources.EsperandoM;
                    nuevoButton.BorderColor = Color.FromArgb(255, 183, 3);
                    break;

                case EnumEstados.Error:
                    nuevoButton.Image = Resources.ErrorM;
                    nuevoButton.BorderColor = Color.FromArgb(209, 62, 73);
                    break;

                case EnumEstados.Empty:
                    nuevoButton.Image = Resources.Null;
                    nuevoButton.BorderSize = 0;
                    nuevoButton.Text = "";
                    break;

                default:
                    break;
            }

            flpContenedorResul.Invoke(new EventHandler(delegate
            {
                flpContenedorResul.Controls.Add(nuevoButton);
                // Hacer un desplazamiento automático para mostrar el nuevo elemento
                flpContenedorResul.AutoScrollPosition = new Point(0, flpContenedorResul.VerticalScroll.Maximum);
            }));
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

        public bool flpCOMVisible
        {
            get { return flpCOM.Visible; }
            set
            {
                flpCOM.Visible = value;
            }
        }

        private void LlenarComboBox()
        {
            //cmbPortName
            cmbPortName.ComboBoxControl.Items.Add("COM1");
            cmbPortName.ComboBoxControl.Items.Add("COM2");
            cmbPortName.ComboBoxControl.Items.Add("COM3");
            cmbPortName.ComboBoxControl.Items.Add("COM4");
            cmbPortName.ComboBoxControl.Items.Add("COM5");
            cmbPortName.ComboBoxControl.Items.Add("COM6");

            //cmbBaudRate
            cmbBaudRate.ComboBoxControl.Items.Add("1200");
            cmbBaudRate.ComboBoxControl.Items.Add("2400");
            cmbBaudRate.ComboBoxControl.Items.Add("4800");
            cmbBaudRate.ComboBoxControl.Items.Add("9600");
            cmbBaudRate.ComboBoxControl.Items.Add("19200");
            cmbBaudRate.ComboBoxControl.Items.Add("38400");
            cmbBaudRate.ComboBoxControl.Items.Add("57600");
            cmbBaudRate.ComboBoxControl.Items.Add("115200");

            //cmbDataBits
            cmbDataBits.ComboBoxControl.Items.Add("7");
            cmbDataBits.ComboBoxControl.Items.Add("8");
            cmbDataBits.ComboBoxControl.Items.Add("9");
        }

        //Borrado FlowLayoutPanel
        public void LimpiarTerminal()
        {
            flpContenedorResul.Controls.Clear();
        }

        //Conectar puerto COM
        public void AbrirPuerto()
        {
            bool error = false;

            if (!VariablesGlobal.Config)
            {
                // If the port is open, close it.
                if (comport.IsOpen) comport.Close();
                else
                {
                    // Set the port's settings
                    comport.BaudRate = int.Parse(cmbBaudRate.ComboBoxControl.Text);
                    comport.DataBits = int.Parse(cmbDataBits.ComboBoxControl.Text);
                    comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.ComboBoxControl.Text);
                    comport.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.ComboBoxControl.Text);
                    comport.PortName = cmbPortName.ComboBoxControl.Text;

                    try
                    {
                        // Open the port
                        comport.Open();
                    }
                    catch (UnauthorizedAccessException) { error = true; }
                    catch (IOException) { error = true; }
                    catch (ArgumentException) { error = true; }

                    if (error)
                    {
                        MensajesEstadosTerminal("No se Puede Abrir el puerto, puerto COM no disponible", EnumEstados.Error);
                    }
                    else
                    {
                        // Show the initial pin states
                        UpdatePinState();
                        chkDTR.Checked = comport.DtrEnable;
                        chkRTS.Checked = comport.RtsEnable;
                    }
                }

                // Change the state of the form's controls
                EnableControls();

                // If the port is open, send focus to the send data box
                if (comport.IsOpen)
                {
                    if (chkClearOnOpen.Checked) LimpiarTerminal();
                    log.RegistraEnLog("Puerto Conectado", nombreLog);
                    MensajesEstadosTerminal("Puerto conectado",EnumEstados.Ok);
                    timerIntervalos.Interval = Convert.ToInt32(InterfaceConfig.intervalo) * 1000;
                }
                else
                {
                    log.RegistraEnLog("Puerto Desconectada", nombreLog);
                    MensajesEstadosTerminal("Puerto desconectado", EnumEstados.Warning);
                    timerIntervalos.Enabled = false;
                }
            }
            else
            {
                DialogResult result;
                using (var msFomr = new FormMessageBox("Cierre primero la ventana de configuración", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning))
                {
                    result = msFomr.ShowDialog();
                }

            }
        }
        #endregion

        #region Timers
        //Puerto Serial
        private void tmrCheckComPorts_Tick(object sender, EventArgs e)
        {
            // Comprueba si se han añadido o eliminado puertos COM,
            // ya que es bastante común ahora con los adaptadores de USB a serie.
            RefreshComPortList();
        }

        private void timerIntervalos_Tick(object sender, EventArgs e)
        {
            if ((timeractivo.Contains("S")) && (iniciaRecepcion.Contains("N")))
            {
                timeractivo = "N";

                if (ArrPaquete[inc] != null)
                {
                    CharEnviado = "ENQ";
                    SendData(ENQ.ToString());
                }
                else
                {
                    timeractivo = "S";
                }
            }
        }
        #endregion

        #region Envio Paquete
        //Envio de paquete - validar si es necesario
        private void enviapaquete()
        {
            if (ArrPaquete[inc] != null)
            {
                byte[] hexData = System.Text.Encoding.ASCII.GetBytes(STX + ArrPaquete[inc] + '\r' + ETX);

                // Después de llamar a la función GetCheckSum la variable
                // contendrá &H30 utilizando sus datos de prueba
                string checkSum = GetCheckSum(STX + ArrPaquete[inc] + '\r' + ETX);

                SendData(STX + ArrPaquete[inc] + '\r' + ETX + checkSum + "\r" + "\n");
                iniciaRecepcion = "N";

                inc = inc + 1;
            }
            else
            {
                CharEnviado = "EOT";
                SendData(EOT.ToString());

                iniciaRecepcion = "N";
                timeractivo = "S";
                inc = 0;

                for (var xx = 0; xx <= ArrPaquete.Length - 1; xx++)
                {
                    ArrPaquete[xx] = null;
                }
            }
        }

        //Envio de paquete - validar si es necesario
        public string GetCheckSum(string frame)
        {
            string checksum = "00";
            int byteVal = 0;
            int sumOfChars = 0;
            bool complete = false;

            for (int idx = 0; idx < frame.Length; idx++)
            {
                byteVal = frame[idx];

                switch (byteVal)
                {
                    case T.STX:
                        sumOfChars = 0;
                        break;
                    case T.ETX:
                    case T.ETB:
                        sumOfChars += byteVal;
                        complete = true;
                        break;
                    default:
                        sumOfChars += byteVal;
                        break;
                }

                if (complete)
                {
                    break;
                }
            }

            if (sumOfChars > 0)
            {
                checksum = Convert.ToString(sumOfChars % 256, 16).ToUpper();
            }
            return Convert.ToString((checksum.Length == 1) ? "0" + checksum : checksum);
        }

        #endregion
    }
}

