using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Ordinario
{
    public partial class ConsultaServicios : Form
    {
        public ConsultaServicios()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void LoadServicios()
        {
            List<Mascotas> listaMascota = new List<Mascotas>();

            BaseDeDatos baseDeDatos = new BaseDeDatos();
            baseDeDatos.loadData(listaMascota);

            dgvConsulta.DataSource = null;
            dgvConsulta.Columns.Clear();
            dgvConsulta.DataSource = listaMascota;

            dgvConsulta.Columns["nombreMascota"].HeaderText = "Nombre";
            dgvConsulta.Columns["duenioMascota"].HeaderText = "Dueño";
            dgvConsulta.Columns["edadMascota"].HeaderText = "Edad";
            dgvConsulta.Columns["razaMascota"].HeaderText = "Raza";
            dgvConsulta.Columns["sexoMascota"].HeaderText = "Sexo";
            dgvConsulta.Columns["servicioRealizado"].HeaderText = "Servicios";
            dgvConsulta.Columns["servicioLimpiezaRealizado"].HeaderText = "Limpieza";
            dgvConsulta.Columns["precioTotal"].HeaderText = "Total";
            dgvConsulta.Columns["fechaServicio"].HeaderText = "Fecha de servicio";

            dgvConsulta.DataSource = listaMascota;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModificarServicios modificarServicios = new ModificarServicios();
            modificarServicios.Show();  
        }

        private void ordenar_Click(object sender, EventArgs e)
        { 
           
        }

        private void ConsultaServicios_Load(object sender, EventArgs e)
        {
            LoadServicios();
        }
    }
}
