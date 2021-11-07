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
        public PlanLogic PlanLogic { get; set; }
        public ModuloUsuario Permiso { set; get; }

        public static Business.Entities.Modulo.ListaModulos NombreModulo = Business.Entities.Modulo.ListaModulos.Planes;

        public Planes(ModuloUsuario permiso)
        {
            Permiso = permiso;
            InitializeComponent();
            dgvPlanes.AutoGenerateColumns = false;
            PlanLogic = new PlanLogic();
            EstablecerPermisos();
        }

        public void Listar()
        {
            if(Permiso.PermiteConsulta)
                dgvPlanes.DataSource = PlanLogic.GetAll();
        }

        private void EstablecerPermisos()
        {
            btnActualizar.Enabled = false;
            BtnAgregar.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnEditar.Enabled = false;


            if (Permiso.PermiteConsulta)
            {
                btnActualizar.Enabled = true;
            }
            if (Permiso.PermiteAlta)
                BtnAgregar.Enabled = true;
            if (Permiso.PermiteBaja)
                BtnEliminar.Enabled = true;
            if (Permiso.PermiteModificacion)
                BtnEditar.Enabled = true;
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

        private void tsbGeneraPlanes_Click(object sender, EventArgs e)
        {
            ReportePlanes rp = new ReportePlanes();
            rp.ShowDialog();
            Listar();
        }
    }
}
