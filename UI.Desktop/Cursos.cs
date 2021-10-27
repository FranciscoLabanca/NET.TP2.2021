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
        public Cursos()
        {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
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
            dgvCursos.DataSource = new CursoLogic().GetAll();
        }
    }
}
