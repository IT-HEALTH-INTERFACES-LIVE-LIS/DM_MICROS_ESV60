using System;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DM_MICROS_ESV60.Utilities
{
    static internal class InterfaceConfig
    {
        //Configuración Interfaz
        static internal string nombreEquipo;
        static internal string intervalo;
        //Configuración Log
        static internal string logActivo;
        static internal string rutaLog;
        static internal string nombreLog;
        static internal string imprimirQueriesDBLog;
        //Configuración Servicios
        static internal string client;
        static internal string reactive;
        static internal string medicalDevice;
        static internal string userName;
        static internal string password;
        static internal string endPointToken;
        static internal string endPointResultados;
        static internal string endPointBase;

        static internal void InitializeConfig()
        {
            //Configuración Interfaz
            nombreEquipo = ConfigurationManager.AppSettings["nombreEquipo"];
            intervalo = ConfigurationManager.AppSettings["intervalo"].ToString();
            //Configuración Log
            logActivo = ConfigurationManager.AppSettings["logActivo"];
            rutaLog = ConfigurationManager.AppSettings["rutaLog"];
            nombreLog = ConfigurationManager.AppSettings["nombreLog"];
            imprimirQueriesDBLog = ConfigurationManager.AppSettings["imprimirQueriesDBLog"];
            //Configuración Servicios
            client = ConfigurationManager.AppSettings["client"].ToString();
            reactive = ConfigurationManager.AppSettings["reactive"].ToString();
            medicalDevice = ConfigurationManager.AppSettings["medicalDevice"].ToString();
            userName = ConfigurationManager.AppSettings["userName"].ToString();
            password = ConfigurationManager.AppSettings["password"].ToString();
            endPointToken = ConfigurationManager.AppSettings["endPointToken"].ToString();
            endPointResultados = ConfigurationManager.AppSettings["endPointResultados"].ToString();
            endPointBase = ConfigurationManager.AppSettings["endPointBase"].ToString();
        }
    }
}
