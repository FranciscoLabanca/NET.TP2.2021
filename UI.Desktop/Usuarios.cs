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
using Business.Logic;

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public UsuarioLogic UsuariosLogic { get; set; }
        public ModuloUsuario Permiso { set; get; }

        public static Business.Entities.Modulo.ListaModulos NombreModulo = Business.Entities.Modulo.ListaModulos.Usuarios;

        public Usuarios(ModuloUsuario permiso)
        {
            Permiso = permiso;
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
            UsuariosLogic = new UsuarioLogic();
            EstablecerPermisos();
        }

        private void EstablecerPermisos()
        {
            BtnActualizar.Enabled = false;
            BtnAgregar.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnEditar.Enabled = false;


            if (Permiso.PermiteConsulta)
            {
                BtnActualizar.Enabled = true;
            }
            if (Permiso.PermiteAlta)
                BtnAgregar.Enabled = true;
            if (Permiso.PermiteBaja)
                BtnEliminar.Enabled = true;
            if (Permiso.PermiteModificacion)
                BtnEditar.Enabled = true;
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
            Listar();
        }
        private void Listar()
        {
            if (Permiso.PermiteConsulta)            
                dgvUsuarios.DataSource = UsuariosLogic.GetAll();            
        }
        
    }
}
