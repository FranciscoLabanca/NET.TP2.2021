using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
            Listar();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            UsuarioDesktop usDesktop = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            usDesktop.ShowDialog();
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            UsuarioDesktop usDesktop = new UsuarioDesktop(((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Modificacion);
            usDesktop.ShowDialog();
            Listar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            UsuarioDesktop usDesktop = new UsuarioDesktop(((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
            usDesktop.ShowDialog();
            Listar();
        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {

        }
        private void Listar() => dgvUsuarios.DataSource = new Business.Logic.UsuarioLogic().GetAll();
        
    }
}
