using CustomControls.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnnarComMICROSESV60.RJControls
{
    public partial class RJResultadosBotton : UserControl
    {
        // Propiedades públicas para el nuevo ancho y alto
        [Browsable(true)]
        [Description("Nuevo ancho de la imagen.")]
        public int NuevoAncho { get; set; } = 50;

        [Browsable(true)]
        [Description("Nuevo alto de la imagen.")]
        public int NuevoAlto { get; set; } = 50;

        public RJResultadosBotton()
        {
            InitializeComponent();

            // Cambiar el tamaño de la imagen en el botón
            CambiarTamañoImagenBoton(rjButton1, NuevoAncho, NuevoAlto);
        }

        private void CambiarTamañoImagenBoton(Button boton, int nuevoAncho, int nuevoAlto)
        {
            // Verificar si hay una imagen asignada al botón
            if (boton.Image != null)
            {
                // Redimensionar la imagen y asignarla de nuevo al botón
                boton.Image = new Bitmap(boton.Image, nuevoAncho, nuevoAlto);
            }
        }
    }
}
