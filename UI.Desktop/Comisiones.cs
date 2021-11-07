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
    public partial class Comisiones : Form
    {
        public ComisionLogic ComisionesLogic { set; get; }
        public ModuloUsuario Permiso { set; get; }

        public static Business.Entities.Modulo.ListaModulos NombreModulo = Business.Entities.Modulo.ListaModulos.Comisiones;

        public Comisiones(ModuloUsuario permiso)
        {
            Permiso = permiso;
            InitializeComponent();
            dgvComisiones.AutoGenerateColumns = false;
            ComisionesLogic = new ComisionLogic();
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

        public void Listar()
        {
            if (Permiso.PermiteConsulta)            
                dgvComisiones.DataSource = ComisionesLogic.GetAll();
        }

        private void Comisiones_Load(object sender, EventArgs e)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop cd = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            cd.ShowDialog();
            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ComisionDesktop cd = new ComisionDesktop(((Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID,ApplicationForm.ModoForm.Modificacion);
            cd.ShowDialog();
            Listar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ComisionDesktop cd = new ComisionDesktop(((Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
            cd.ShowDialog();
            Listar();
        }
    }
}
