using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ordinario.DataBase
{
    internal class GuardarCambios
    {
        public void reload(string cambiosAplicados)
        {
            BaseDeDatos sobreescribirData = new BaseDeDatos();
            List<string> Clientes = new List<string>();
            List<string> Servicios = new List<string>();

            string listaDatos = cambiosAplicados;
            
            string[] arregloTemporalDatosClientes = listaDatos.Split('\n');
            string datosClientes; int count = 0;
            do
            {
                datosClientes = arregloTemporalDatosClientes[count];
                string[] dataMascotas = datosClientes.Split('&');

                string dataClientes = dataMascotas[0] + "&" + dataMascotas[1] + "&" + dataMascotas[2] + "&" + dataMascotas[3] + "&" + dataMascotas[4];
                string dataServicios = dataMascotas[5] + "&" + dataMascotas[6] + "&" + dataMascotas[7] + "&" + dataMascotas[8];

                Clientes.Add(dataClientes);
                Servicios.Add(dataServicios);
                count++;

            } while (count < arregloTemporalDatosClientes.Length);

            sobreescribirData.SobreescribirData((string.Join("\n", Clientes)), (string.Join("\n", Servicios)));
        }
    }
}
