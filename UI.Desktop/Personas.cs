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
    public partial class Personas : Form
    {
        public PersonaLogic personaLogic { set; get; }
        public ModuloUsuario Permiso { set; get; }

        public static Business.Entities.Modulo.ListaModulos NombreModulo = Business.Entities.Modulo.ListaModulos.Personas;

        public Personas(ModuloUsuario permiso)
        {
            Permiso = permiso;
            InitializeComponent();
            dgvPersonas.AutoGenerateColumns = false;
            EstablecerPermisos();
        }

        public void Listar()
        {
            if (Permiso.PermiteConsulta)
            {
                PersonaLogic pl = new PersonaLogic();
                dgvPersonas.DataSource = pl.GetAll();
            }
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

        private void Personas_Load(object sender, EventArgs e)
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
            PersonaDesktop pd = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            pd.ShowDialog();
            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            PersonaDesktop pd = new PersonaDesktop(((Persona)dgvPersonas.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Modificacion);
            pd.ShowDialog();
            Listar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            PersonaDesktop pd = new PersonaDesktop(((Persona)dgvPersonas.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
            pd.ShowDialog();
            Listar();
        }
    }
}
