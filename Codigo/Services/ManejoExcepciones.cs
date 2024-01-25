using DM_MICROS_ESV60.Utilities;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace DM_MICROS_ESV60.Utils
{
    public class ManejoExcepciones
    {
        private static readonly RegistroLog log = new RegistroLog();
        private static readonly string nombreLog = InterfaceConfig.nombreLog + "_JSON";

        public static void ManejoErrores(RestResponse response)
        {
            // Puedes agregar más lógica aquí según tus necesidades
            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    log.RegistraEnLog("Recurso no encontrado. Verifica la URL de la solicitud.", nombreLog);
                    break;
                case HttpStatusCode.BadRequest:
                    log.RegistraEnLog("Solicitud incorrecta. Verifica los datos enviados en la solicitud.", nombreLog);
                    break;
                case HttpStatusCode.Unauthorized:
                    log.RegistraEnLog("No autorizado. Verifica las credenciales o permisos de acceso.", nombreLog);
                    break;
                case HttpStatusCode.UnsupportedMediaType:
                    log.RegistraEnLog("El tipo de media no es el adecuado. Verifica el Content-Type de los headers.", nombreLog);
                    break;
                case HttpStatusCode.Forbidden:
                    log.RegistraEnLog("Acceso prohibido. No tienes los permisos necesarios para realizar la solicitud.", nombreLog);
                    break;
                case HttpStatusCode.InternalServerError:
                    log.RegistraEnLog("Error interno del servidor. Inténtalo de nuevo más tarde.", nombreLog);
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    log.RegistraEnLog("Servicio no disponible. Inténtalo de nuevo más tarde.", nombreLog);
                    break;
                default:
                    log.RegistraEnLog($"Código de estado no manejado: {response.StatusCode}", nombreLog);
                    break;
            }


            if (response.ErrorException != null)
            {
                // Manejar excepciones generales de la solicitud
                log.RegistraEnLog($"Error en la solicitud: {response.ErrorException.Message}", nombreLog);
            }

            // Verificar si la respuesta contiene detalles adicionales
            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                try
                {
                    // Intentar analizar el contenido de la respuesta como JSON
                    var errorDetails = JsonConvert.DeserializeAnonymousType(response.Content, new { Message = "" });
                    if (!string.IsNullOrWhiteSpace(errorDetails?.Message))
                    {
                        log.RegistraEnLog($"Detalles del error: {errorDetails.Message}", nombreLog);
                    }
                }
                catch (JsonException)
                {
                    // No se pudo analizar el contenido como JSON
                }
            }

            log.RegistraEnLog($"-------------------------------------------------------------------------- \n", nombreLog);
        }
    }
}
