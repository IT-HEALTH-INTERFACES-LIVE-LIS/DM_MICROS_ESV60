using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_MICROS_ESV60.Models
{
    public class ResultadoAnalito
    {
        public string sampleNumber { get; set; }
        public string analyte { get; set; }
        public string medicalDevice { get; set; }
        public string reactive { get; set; }
        public string result { get; set; }
    }

}
