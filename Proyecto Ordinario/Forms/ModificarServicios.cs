using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Ordinario
{
    public partial class ModificarServicios : Form
    {
        public ModificarServicios()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ModificarServicios_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            List<Mascotas> listaMascota = new List<Mascotas>();
            BaseDeDatos baseDeDatos = new BaseDeDatos();
            baseDeDatos.loadData(listaMascota);

            var dataTable = new System.Data.DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Dueño", typeof(string));
            dataTable.Columns.Add("Edad", typeof(int));
            dataTable.Columns.Add("Raza", typeof(string));
            dataTable.Columns.Add("Sexo", typeof(string));
            dataTable.Columns.Add("Servicios", typeof(string));
            dataTable.Columns.Add("Limpieza", typeof(string));
            dataTable.Columns.Add("Total", typeof(int));
            dataTable.Columns.Add("Fecha de servicio", typeof(DateTime));

            foreach (Mascotas data in listaMascota)
            {
                dataTable.Rows.Add(0, 
                                    data.nombreMascota,
                                    data.duenioMascota, 
                                    data.edadMascota, 
                                    data.razaMascota, 
                                    data.sexoMascota, 
                                    data.servicioRealizado,
                                    data.servicioLimpiezaRealizado, 
                                    data.precioTotal, 
                                    data.fechaServicio
                                    );
            }

            modif.DataSource = dataTable;
        }

        private void save()
        {
            BaseDeDatos baseDeDatos = new BaseDeDatos();
            List<string> data = new List<string>();

            foreach (DataGridViewRow row in modif.Rows)
            {
                if (!row.IsNewRow)
                {
                    List<string> columns = new List<string>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        columns.Add(Convert.ToString(cell.Value));
                    }
                    data.Add(string.Join("&", columns)); // Cambia el delimitador según tu archivo
                }
            }

            baseDeDatos.prueba(string.Join("\n",data));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}
