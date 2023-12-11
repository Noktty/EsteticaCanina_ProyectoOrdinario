using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Windows.Forms;

namespace Proyecto_Ordinario
{
    internal class BaseDeDatos
    {
        public void guardarDataBase(string valueNombreM, string valueDuenioM, string valueEdadM, string valueSexoM, string valueRazaM)
        {
            StreamWriter data = File.AppendText("DataClientes.txt");
            string dataTXT = valueNombreM + "&" + valueDuenioM + "&" + valueEdadM + "&" + valueSexoM + "&" + valueRazaM;
            data.WriteLine(dataTXT);

            data.Close();
        }

        public void loadData(List<Mascotas> mascotasList)
        {

            if ((File.Exists("DataClientes.txt")) && (File.Exists("serviciosData.txt")))
            {
                FileStream datosM = new FileStream("DataClientes.txt", FileMode.Open, FileAccess.Read);
                StreamReader readData = new StreamReader(datosM);

                FileStream datosServicio = new FileStream("serviciosData.txt", FileMode.Open, FileAccess.Read);
                StreamReader readServiciosRealizados = new StreamReader(datosServicio);

                string data, ServiciosRealizados;
                do
                {
                    data = readData.ReadLine();
                    ServiciosRealizados = readServiciosRealizados.ReadLine();

                    if (data != null)
                    {
                        //separa los datos
                        string[] dataMascotas = data.Split('&');
                        string[] serviciosMascota = ServiciosRealizados.Split('&');

                        //Asigna los datos a la lista de objeto
                        try
                        {
                            mascotasList.Add(new Mascotas()
                            {
                                nombreMascota = dataMascotas[0],
                                duenioMascota = dataMascotas[1],
                                edadMascota = int.Parse(dataMascotas[2]),
                                sexoMascota = dataMascotas[3],
                                razaMascota = dataMascotas[4],
                                servicioLimpiezaRealizado = serviciosMascota[1],
                                servicioRealizado = serviciosMascota[0],
                                precioTotal = int.Parse(serviciosMascota[2]),
                                fechaServicio = Convert.ToDateTime(serviciosMascota[3])
                            });
                        }
                        catch { }
                    }

                } while (data != null);

                readData.Close();
                readServiciosRealizados .Close();
            }
        }

        public void datosServicios(string Servicios, string servsLimpieza, int costoServicios, DateTime fechaServicio)
        {
            string dataServices = Servicios + "&" + servsLimpieza + "&" + costoServicios + "&" + fechaServicio;

            StreamWriter serviciosData = File.AppendText("serviciosData.txt");
            serviciosData.WriteLine(dataServices);
            serviciosData.Close();
        }

        public void prueba(string val)
        {
            StreamWriter serviciosData = new StreamWriter("pruebaData.txt");
            serviciosData.WriteLine(val);
            serviciosData.Close();
        }
    }
}
