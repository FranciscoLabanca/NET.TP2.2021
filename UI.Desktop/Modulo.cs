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
    public partial class Modulo : Form
    {
        public ModuloLogic moduloLogic { set; get; }
        public Modulo()
        {
            InitializeComponent();
            dgvModulos.AutoGenerateColumns = false;
            moduloLogic = new ModuloLogic();
            dgvModulos.DataSource = moduloLogic.GetAll();
        }

        public void Listar()
        {
            ModuloLogic ml = new ModuloLogic();
            dgvModulos.DataSource = ml.GetAll();


        }

        private void Modulo_Load(object sender, EventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ModuloDesktop md = new ModuloDesktop(ApplicationForm.ModoForm.Alta);
            md.ShowDialog();
            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ModuloDesktop md = new ModuloDesktop(((Business.Entities.Modulo)dgvModulos.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Modificacion);
            md.ShowDialog();
            Listar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ModuloDesktop md = new ModuloDesktop(((Business.Entities.Modulo)dgvModulos.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
            md.ShowDialog();
            Listar();
        }
    }
}
