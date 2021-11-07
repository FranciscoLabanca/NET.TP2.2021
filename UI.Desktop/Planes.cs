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
    public partial class Planes : Form
    {
        public PlanLogic planLogic { get; set; }
        public Planes()
        {
            InitializeComponent();
            dgvPlanes.AutoGenerateColumns = false;
            planLogic = new PlanLogic();
            dgvPlanes.DataSource = planLogic.GetAll();
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            dgvPlanes.DataSource = pl.GetAll();
        }

        private void Planes_Load(object sender, EventArgs e)
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop pd = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            pd.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            PlanDesktop pd = new PlanDesktop(((Plan)dgvPlanes.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Modificacion);
            pd.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            PlanDesktop pd = new PlanDesktop(((Plan)dgvPlanes.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
            pd.ShowDialog();
            Listar();
        }
    }
}
