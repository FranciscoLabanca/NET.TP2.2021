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
    public partial class Cursos : Form
    {
        public CursoLogic CursoLogic { set; get; }
        public ModuloUsuario Permiso { set; get; }
        public static Business.Entities.Modulo.ListaModulos NombreModulo = Business.Entities.Modulo.ListaModulos.Cursos;

        public Cursos(ModuloUsuario permiso)
        {
            Permiso = permiso;
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
            CursoLogic = new CursoLogic();
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

        private void Cursos_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            LoadDataSource();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new CursosDesktop(ApplicationForm.ModoForm.Alta).ShowDialog();
            LoadDataSource();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Curso cursoSeleccionado = (Curso)dgvCursos.SelectedRows[0].DataBoundItem;
            new CursosDesktop(cursoSeleccionado, ApplicationForm.ModoForm.Modificacion).ShowDialog();
            LoadDataSource();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Curso cursoSeleccionado = (Curso)dgvCursos.SelectedRows[0].DataBoundItem;
            new CursosDesktop(cursoSeleccionado, ApplicationForm.ModoForm.Baja).ShowDialog();
            LoadDataSource();
        }

        private void LoadDataSource()
        {
            if(Permiso.PermiteConsulta)
                dgvCursos.DataSource = CursoLogic.GetAll();
        }
    }
}
