using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_Ordinario.Forms
{
    internal class NuevoCliente : IClientes
    {
        public NuevoCliente() { }

        public void NuevoClienteRegistrado (string tbxNombreM, string tbxDuenioM, string cbxEdadM, string cbxSexo, string cbxRazaM)
        {
            BaseDeDatos GuardarDatosCliente = new BaseDeDatos();

            if (cbxEdadM == string.Empty)
            {

                GuardarDatosCliente.guardarDataBase(tbxNombreM, tbxDuenioM, "0", cbxSexo, cbxRazaM);
            }
            else
            {
                GuardarDatosCliente.guardarDataBase(tbxNombreM, tbxDuenioM, cbxEdadM, cbxSexo, cbxRazaM);
            }
        }

        public void obtenerServicios(bool corteUnias, bool vacuna, bool cortePeloCorto, bool cortePeloLargo, bool rasurado,
                                  bool estetica, bool limpiezaDientes, bool limpiezaLagrimales, bool limpiezaOido, string tamanioAnimal)
        {
            BaseDeDatos serviciosRealizados = new BaseDeDatos();

            string servicios = Servicios(corteUnias, vacuna, cortePeloCorto, cortePeloLargo, rasurado, estetica);
            string limpieza = Limpieza(limpiezaDientes, limpiezaLagrimales, limpiezaOido);
            int costoServicios = CostoServicios(corteUnias, vacuna, cortePeloCorto, cortePeloLargo, rasurado,
                                  estetica, limpiezaDientes, limpiezaLagrimales,limpiezaOido, tamanioAnimal);

            serviciosRealizados.datosServicios(servicios, limpieza, costoServicios, fechaServicio());
        }

        public string Servicios(bool corteUnias, bool vacuna, bool cortePeloCorto, bool cortePeloLargo, bool rasurado, bool estetica)
        {
            string serviciosRealizado = "";

            if (corteUnias == true)
                serviciosRealizado += "Corte uñas - ";
            if (vacuna == true)
                serviciosRealizado += "Vacuna - ";

            if (cortePeloCorto == true)
                serviciosRealizado += "Corte pelo corto";
            else if (cortePeloLargo == true)
                serviciosRealizado += "Corte pelo largo";
            else if (rasurado == true)
                serviciosRealizado += "Rasurado con baño";
            else if (estetica == true)
                serviciosRealizado += "Estética con baño";

            return serviciosRealizado;
        }

        public string Limpieza(bool limpiezaDientes, bool limpiezaLagrimales, bool limpiezaOido)
        {
            string limpiezaRealizada = "";

            if (limpiezaDientes == true)
                limpiezaRealizada += "Limpieza de dientes -";
            if (limpiezaLagrimales == true)
                limpiezaRealizada += "Limpieza de lagrimales";
            if (limpiezaOido == true)
                limpiezaRealizada += "Limpieza de oidos";

            return limpiezaRealizada;
        }
        public int CostoServicios(bool corteUnias, bool vacuna, bool cortePeloCorto, bool cortePeloLargo, bool rasurado,
                                  bool estetica, bool limpiezaDientes, bool limpiezaLagrimales, bool limpiezaOido, string tamanioMascota)
        {
            int costoServices = 0;

            if (corteUnias == true)
                costoServices += 50;
            if (vacuna == true)
                costoServices += 130;

            if (limpiezaDientes == true)
                costoServices += 75;
            if (limpiezaLagrimales == true)
                costoServices += 65;
            if (limpiezaOido == true)
                costoServices += 85;

            if (cortePeloCorto == true)
            {
                if (tamanioMascota == "5kg.")
                    costoServices += 150;
                else if (tamanioMascota == "5kg. a 10kg.")
                    costoServices += 180;
                else if (tamanioMascota == "10kg. a 20kg.")
                    costoServices += 210;
                else if (tamanioMascota == "20kg. a 40kg.")
                    costoServices += 260;
                else if (tamanioMascota == "40kg. a 60kg.")
                    costoServices += 290;
                else
                    costoServices += 0;
            }
            else if (cortePeloLargo == true)
            {
                if (tamanioMascota == "5kg.")
                    costoServices += 180;
                else if (tamanioMascota == "5kg. a 10kg.")
                    costoServices += 210;
                else if (tamanioMascota == "10kg. a 20kg.")
                    costoServices += 240;
                else if (tamanioMascota == "20kg. a 40kg.")
                    costoServices += 290;
                else if (tamanioMascota == "40kg. a 60kg.")
                    costoServices += 340;
                else
                    costoServices += 0;
            }
            else if (rasurado == true)
            {
                if (tamanioMascota == "5kg.")
                    costoServices += 190;
                else if (tamanioMascota == "5kg. a 10kg.")
                    costoServices += 210;
                else if (tamanioMascota == "10kg. a 20kg.")
                    costoServices += 240;
                else if (tamanioMascota == "20kg. a 40kg.")
                    costoServices += 310;
                else if (tamanioMascota == "40kg. a 60kg.")
                    costoServices += 370;
                else
                    costoServices += 0;
            }
            else if (estetica == true)
            {
                if (tamanioMascota == "5kg.")
                    costoServices += 250;
                else if (tamanioMascota == "5kg. a 10kg.")
                    costoServices += 280;
                else if (tamanioMascota == "10kg. a 20kg.")
                    costoServices += 310;
                else if (tamanioMascota == "20kg. a 40kg.")
                    costoServices += 390;
                else if (tamanioMascota == "40kg. a 60kg.")
                    costoServices += 490;
                else
                    costoServices += 0;
            }

            return costoServices;
        }

        public DateTime fechaServicio() 
        { 
            return DateTime.Now; 
        }

    }
}
