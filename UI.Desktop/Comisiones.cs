using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Comisiones : Form
    {
        public ComisionLogic ComLogic { set; get; }
        public Comisiones()
        {
            InitializeComponent();
            dgvComisiones.AutoGenerateColumns = false;
            ComLogic = new ComisionLogic();
            dgvComisiones.DataSource = ComLogic.GetAll();
        }

        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            dgvComisiones.DataSource = cl.GetAll();
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop cd = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            cd.ShowDialog();
            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ComisionDesktop cd = new ComisionDesktop(((Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID,ApplicationForm.ModoForm.Modificacion);
            cd.ShowDialog();
            Listar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ComisionDesktop cd = new ComisionDesktop(((Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
            cd.ShowDialog();
            Listar();
        }
    }
}
