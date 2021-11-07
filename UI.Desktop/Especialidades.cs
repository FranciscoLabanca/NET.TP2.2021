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
    public partial class Especialidades : Form
    {
        public EspecialidadLogic EspecialidadLogic { set; get; }
        public ModuloUsuario Permiso { set; get; }
        public static Business.Entities.Modulo.ListaModulos NombreModulo = Business.Entities.Modulo.ListaModulos.Especialidades;

        public Especialidades(ModuloUsuario permiso)
        {
            Permiso = permiso;
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
            EspecialidadLogic = new EspecialidadLogic();
            EstablecerPermisos();
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
        public void Listar()
        {
            if (Permiso.PermiteConsulta)
                dgvEspecialidades.DataSource = EspecialidadLogic.GetAll();          
        }

        private void Especialidades_Load(object sender, EventArgs e)
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
            EspecialidadDesktop ed = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            ed.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop ed = new EspecialidadDesktop(((Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Modificacion);
            ed.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop ed = new EspecialidadDesktop(((Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
            ed.ShowDialog();
            Listar();
        }
    }
}
