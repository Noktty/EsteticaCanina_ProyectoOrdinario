using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ordinario
{
    internal interface IClientes
    {
        void NuevoClienteRegistrado(string NombreM, string DuenioM, string EdadM, string SexoM, string RazaM);
        string Servicios(bool corteUnias, bool vacuna, bool cortePeloCorto, bool cortePeloLargo, bool rasurado, bool estetica);
        string Limpieza(bool limpiezaDientes, bool limpiezaLagrimales, bool limpiezaOido);
        int CostoServicios(bool corteUnias, bool vacuna, bool cortePeloCorto, bool cortePeloLargo, bool rasurado,
                                  bool estetica, bool limpiezaDientes, bool limpiezaLagrimales, bool limpiezaOido, string tamanioMascota);
        DateTime fechaServicio();
    }
}
