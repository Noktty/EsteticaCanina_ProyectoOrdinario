using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ordinario
{
    internal class Mascotas
    {
        public string nombreMascota {  get; set; }
        public string duenioMascota { get; set; }
        public int edadMascota { get; set; }
        public string razaMascota { get; set; }
        public string sexoMascota { get; set; }
        public string servicioRealizado { get; set; } 
        public string servicioLimpiezaRealizado { get; set; }
        public int precioTotal {  get; set; }
        public DateTime fechaServicio { get; set; }

        public Mascotas() {}
    }
}
