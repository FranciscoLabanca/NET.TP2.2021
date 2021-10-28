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
        public DocenteCurso()
        {
            InitializeComponent();
        }
        private void DocenteCursos_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            LoadDataSource();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DocenteCursoDesktop dc = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            dc.ShowDialog();
            LoadDataSource();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Business.Entities.DocenteCurso docenteCursoSeleccionado = (Business.Entities.DocenteCurso)dgvDocenteCursos.SelectedRows[0].DataBoundItem;
            DocenteCursoDesktop dc = new DocenteCursoDesktop(docenteCursoSeleccionado, ApplicationForm.ModoForm.Modificacion);
            dc.ShowDialog();
            LoadDataSource();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Business.Entities.DocenteCurso docenteCursoSeleccionado = (Business.Entities.DocenteCurso)dgvDocenteCursos.SelectedRows[0].DataBoundItem;
            DocenteCursoDesktop dc = new DocenteCursoDesktop(docenteCursoSeleccionado, ApplicationForm.ModoForm.Baja);
            dc.ShowDialog();
            LoadDataSource();
        }
        private void LoadDataSource()
        {
            dgvDocenteCursos.DataSource = new DocenteCursoLogic().GetAll();
        }
    }
}
