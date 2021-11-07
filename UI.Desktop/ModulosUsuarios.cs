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
        public ModuloUsuarioLogic ModulosUsuariosLogic { get; set; }
        public ModuloUsuario Permiso { set; get; }

        public static Business.Entities.Modulo.ListaModulos NombreModulo = Business.Entities.Modulo.ListaModulos.Permisos;

        public ModulosUsuarios(ModuloUsuario permiso)
        {
            Permiso = permiso;
            InitializeComponent();
            dgvModulosUsuarios.AutoGenerateColumns = false;
            ModulosUsuariosLogic = new ModuloUsuarioLogic();
            EstablecerPermisos();
        }

        public void Listar()
        {
            if (Permiso.PermiteConsulta)
                dgvModulosUsuarios.DataSource = ModulosUsuariosLogic.GetAll();
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
