using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class DocenteCurso : Form
    {
        public DocenteCursoLogic DocenteCursoLogic { set; get; }
        public ModuloUsuario Permiso { set; get; }

        public static Business.Entities.Modulo.ListaModulos NombreModulo = Business.Entities.Modulo.ListaModulos.Cursos;

        public DocenteCurso(ModuloUsuario permiso)
        {
            Permiso = permiso;
            InitializeComponent();
            dgvDocenteCursos.AutoGenerateColumns = false;
            DocenteCursoLogic = new DocenteCursoLogic();
            EstablecerPermisos();
        }
        private void EstablecerPermisos()
        {
            btnActualizar.Enabled = false;
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;

            if (Permiso.PermiteConsulta)
            {
                btnActualizar.Enabled = true;
            }
            if (Permiso.PermiteAlta)
                btnAgregar.Enabled = true;
            if (Permiso.PermiteBaja)
                btnEliminar.Enabled = true;
            if (Permiso.PermiteModificacion)
                btnEditar.Enabled = true;
        }

        private void DocenteCursos_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DocenteCursoDesktop dc = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            dc.ShowDialog();
            Listar();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Business.Entities.DocenteCurso docenteCursoSeleccionado = (Business.Entities.DocenteCurso)dgvDocenteCursos.SelectedRows[0].DataBoundItem;
            DocenteCursoDesktop dc = new DocenteCursoDesktop(docenteCursoSeleccionado, ApplicationForm.ModoForm.Modificacion);
            dc.ShowDialog();
            Listar();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Business.Entities.DocenteCurso docenteCursoSeleccionado = (Business.Entities.DocenteCurso)dgvDocenteCursos.SelectedRows[0].DataBoundItem;
            DocenteCursoDesktop dc = new DocenteCursoDesktop(docenteCursoSeleccionado, ApplicationForm.ModoForm.Baja);
            dc.ShowDialog();
            Listar();
        }
        private void Listar()
        {
            if (Permiso.PermiteConsulta)
                dgvDocenteCursos.DataSource = DocenteCursoLogic.GetAll();
        }
    }
}
