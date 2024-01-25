using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AnnarComMICROSESV60.RJControls
{
    public partial class RJResultaButton : UserControl
    {
        public RJResultaButton()
        {
            InitializeComponent();
            CambiarTamañoImagenBoton(rjButton1, 50, 50); // Reemplaza 'nuevoAncho' y 'nuevoAlto' con los valores deseados
        }

        [Category("RJ Code Advance")]
        [Browsable(true)]
        [Description("Nuevo ancho de la imagen.")]
        public int NuevoAncho { get; set; } = 50;
        [Category("RJ Code Advance")]
        [Browsable(true)]
        [Description("Nuevo alto de la imagen.")]
        public int NuevoAlto { get; set; } = 50;

        

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
