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
    public partial class ModulosUsuarios : Form
    {
        public ModuloUsuarioLogic MULogic { get; set; }

        public ModulosUsuarios()
        {
            InitializeComponent();
            dgvModulosUsuarios.AutoGenerateColumns = false;
            MULogic = new ModuloUsuarioLogic();
            dgvModulosUsuarios.DataSource = MULogic.GetAll();
        }

        public void Listar()
        {
            ModuloUsuarioLogic mu = new ModuloUsuarioLogic();
            dgvModulosUsuarios.DataSource = mu.GetAll();
        }

        private void ModulosUsuarios_Load(object sender, EventArgs e)
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
            ModuloUsuarioDesktop mud = new ModuloUsuarioDesktop(ApplicationForm.ModoForm.Alta);
            mud.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            ModuloUsuarioDesktop mud = new ModuloUsuarioDesktop(((ModuloUsuario)dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID,ApplicationForm.ModoForm.Modificacion);
            mud.ShowDialog();
            Listar();
        }

        private void tsbElminar_Click(object sender, EventArgs e)
        {
            ModuloUsuarioDesktop mud = new ModuloUsuarioDesktop(((ModuloUsuario)dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
            mud.ShowDialog();
            Listar();
        }
    }
}
