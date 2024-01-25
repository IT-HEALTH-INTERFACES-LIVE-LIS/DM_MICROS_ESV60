using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DM_MICROS_ESV60.Utilities
{
    public class RegistroLog
    {
        private static bool logIniciado = false;
        public string logName = "Log_";

        public void InicializaLog(string p_equipo)
        {
            logName = InterfaceConfig.rutaLog + "/Log_" + p_equipo + "_v" + Application.ProductVersion + "_" + DateTime.Now.ToString("ddMMyyyy");
            using (StreamWriter w = File.AppendText(logName + ".txt"))
            {
                w.Write("\r\nLog " + p_equipo + "_v" + Application.ProductVersion + " : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("-------------------------------");
            }
            if (p_equipo != "Desconocido")
                logIniciado = true;
        }

        public void RegistraEnLog(string logMessage, string p_equipo)
        {
            if (InterfaceConfig.logActivo.Equals("S"))
            {

                logName = InterfaceConfig.rutaLog + "/Log_" + p_equipo + "_v" + Application.ProductVersion + "_" + DateTime.Now.ToString("ddMMyyyy");
                if (!logIniciado) InicializaLog(p_equipo);
                using (StreamWriter w = File.AppendText(logName + ".txt"))
                {
                    w.WriteLine(DateTime.Now + "  :  {0}", logMessage);
                }
            }
        }

    }
}
