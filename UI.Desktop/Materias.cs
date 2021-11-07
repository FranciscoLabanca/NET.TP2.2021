using Business.Logic;
using Business.Entities;
using System;
using System.Collections.Generic;

namespace UI.Desktop
{
    public partial class Materias : ApplicationForm
    {
        public MateriaLogic MateriaLogic { get; set; }
        public ModuloUsuario Permiso { set; get; }

        public static Business.Entities.Modulo.ListaModulos NombreModulo = Business.Entities.Modulo.ListaModulos.Materias;
        public Materias()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
            dgvMaterias.DataSource = new MateriaLogic().GetAll();
        }
        public Materias(ModuloUsuario permiso)
        {
            Permiso = permiso;
            InitializeComponent();
            MateriaLogic = new MateriaLogic();
            dgvMaterias.AutoGenerateColumns = false;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            MateriaDesktop materiaDesktop = new MateriaDesktop(ModoForm.Alta);
            materiaDesktop.ShowDialog();
            Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            MateriaDesktop materiaDesktop = new MateriaDesktop(((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID, ModoForm.Modificacion);
            materiaDesktop.ShowDialog();
            Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            Materia materiaABorrar = (Materia)dgvMaterias.SelectedRows[0].DataBoundItem;
            MateriaDesktop materiaDesktop = new MateriaDesktop(materiaABorrar.ID,ModoForm.Baja);
            materiaDesktop.ShowDialog();
            Listar();
        }

        private void Listar()
        {
            if(Permiso.PermiteConsulta)
                dgvMaterias.DataSource = MateriaLogic.GetAll();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
