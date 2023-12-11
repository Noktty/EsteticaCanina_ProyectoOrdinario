using System;
using System.CodeDom;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            NuevoServicio nuevoServicio = new NuevoServicio();
            nuevoServicio.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultaServicios consultaServicios = new ConsultaServicios();
            consultaServicios.Show();
        }
    }
}
