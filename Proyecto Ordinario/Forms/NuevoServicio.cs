using Proyecto_Ordinario.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto_Ordinario
{
    public partial class NuevoServicio : Form
    {
        public NuevoServicio()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            NuevoCliente datosCliente = new NuevoCliente();

            try
            {
                if (tbxNombreM.Text != string.Empty)
                {

                    if (cbxCorteUnias.Checked || cbxVacuna.Checked || rbtnPeloLargo.Checked || (rbtnPeloCorto.Checked && cbxTamanio.Text != string.Empty) ||
                        rbtnRasurado.Checked || rbtnEstetica.Checked || cbxLDientes.Checked || cbxLLagrimales.Checked || cbxLOidos.Checked)
                    {
                        datosCliente.NuevoClienteRegistrado(tbxNombreM.Text, tbxDuenioM.Text, cbxEdadM.Text, cbxSexo.Text, cbxRazaM.Text);

                        datosCliente.obtenerServicios(cbxCorteUnias.Checked, cbxVacuna.Checked, rbtnPeloCorto.Checked, rbtnPeloLargo.Checked,
                                                      rbtnRasurado.Checked, rbtnEstetica.Checked, cbxLDientes.Checked, cbxLLagrimales.Checked,
                                                      cbxLOidos.Checked, cbxTamanio.Text);

                        MessageBox.Show("Mascota agregada");
                        Close();
                    }
                    else
                        throw new Exception("Seleccione almenos un servicio");
                }
                else
                    throw new Exception("\"Agregue nombre de la mascota\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cbxEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRazaM.Text != string.Empty)
            {
                gbxServicios.Visible = true;
                gbxLimpieza.Visible = true;
                txtTotal.Visible = true;
                labelTotal.Visible = true;
            }
            else
            {
                gbxServicios.Visible = false;
                gbxLimpieza.Visible=false;
                txtTotal.Visible = false;
                labelTotal.Visible = false;
            }
        }
        private void cbxCortePelo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCortePelo.Checked)
            {
                rbtnPeloCorto.Checked = true;
                gbxTarifa.Visible = true;
                gbxCorte.Visible = true;
                cbxTamanio.Items.Add("5kg.");
                cbxTamanio.Items.Add("5kg. a 10kg.");
                cbxTamanio.Items.Add("10kg. a 20kg.");
                cbxTamanio.Items.Add("20kg. a 40kg.");
                cbxTamanio.Items.Add("40kg. a 60kg.");

                if (rbtnPeloLargo.Checked)
                    rbtnPeloLargo.Checked = false;
                else if (rbtnRasurado.Checked)
                    rbtnRasurado.Checked = false;
                else if (rbtnEstetica.Checked)
                    rbtnEstetica.Checked = false;
                else if (rbtnPeloCorto.Checked)
                    rbtnPeloCorto.Checked = true;
            }
            else
            {
                gbxTarifa.Visible = false;
                gbxCorte.Visible = false;
                cbxTamanio.Items.Clear();
                cbxTamanio.Text = "";
                txtPricePC.Text = "";
                txtPricePL.Text = "";
                txtPriceRB.Text = "";
                txtPriceEB.Text = "";
                rbtnPeloCorto.Checked = false;
                totalServicios();
            }
        }
        private void cbxTamanio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTamanio.Text == "5kg.")
            {
                txtPricePC.Text = "150";
                txtPricePL.Text = "180";
                txtPriceRB.Text = "190";
                txtPriceEB.Text = "250";
                totalServicios();
            }
            else if (cbxTamanio.Text == "5kg. a 10kg.")
            {
                txtPricePC.Text = "180";
                txtPricePL.Text = "210";
                txtPriceRB.Text = "210";
                txtPriceEB.Text = "280";
                totalServicios();
            }
            else if (cbxTamanio.Text == "10kg. a 20kg.")
            {
                txtPricePC.Text = "210";
                txtPricePL.Text = "240";
                txtPriceRB.Text = "240";
                txtPriceEB.Text = "310";
                totalServicios();
            }
            else if (cbxTamanio.Text == "20kg. a 40kg.")
            {
                txtPricePC.Text = "260";
                txtPricePL.Text = "290";
                txtPriceRB.Text = "310";
                totalServicios();
            }
            else if (cbxTamanio.Text == "40kg. a 60kg.")
            {
                txtPricePC.Text = "290";
                txtPricePL.Text = "340";
                txtPriceRB.Text = "370";
                txtPriceEB.Text = "490";
                totalServicios();
            }
        }

        private void rbtnPeloCorto_CheckedChanged(object sender, EventArgs e)
        {
            totalServicios();
        }

        private void rbtnPeloLargo_CheckedChanged(object sender, EventArgs e)
        {
            totalServicios();
        }
        private void rbtnRasurado_CheckedChanged(object sender, EventArgs e)
        {            
            totalServicios();
        }

        private void rbtnEstetica_CheckedChanged(object sender, EventArgs e)
        {
            totalServicios();
        }
        private void cbxCorteUnias_CheckedChanged(object sender, EventArgs e)
        {
            totalServicios();
        }

        private void cbxVacuna_CheckedChanged(object sender, EventArgs e)
        {
            totalServicios();
        }

        private void cbxLDientes_CheckedChanged(object sender, EventArgs e)
        {
            totalServicios();
        }

        private void cbxLLagrimales_CheckedChanged(object sender, EventArgs e)
        {
            totalServicios();
        }

        private void cbxLOidos_CheckedChanged(object sender, EventArgs e)
        {
            totalServicios();
        }

        private void totalServicios()
        {
            NuevoCliente mostratTotal = new NuevoCliente();
            
            txtTotal.Text = mostratTotal.CostoServicios(cbxCorteUnias.Checked, cbxVacuna.Checked, rbtnPeloCorto.Checked, rbtnPeloLargo.Checked,
                                                  rbtnRasurado.Checked, rbtnEstetica.Checked, cbxLDientes.Checked, cbxLLagrimales.Checked,
                                                  cbxLOidos.Checked, cbxTamanio.Text).ToString();
        }

    }
}
