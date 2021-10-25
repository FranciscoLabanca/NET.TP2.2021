using Business.Logic;
using Business.Entities;
using System;
using System.Collections.Generic;

namespace UI.Desktop
{
    public partial class Materias : ApplicationForm
    {
        public Materias()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
            dgvMaterias.DataSource = new MateriaLogic().GetAll();
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
            List<Materia> materias = new MateriaLogic().GetAll();
            dgvMaterias.DataSource = materias;
        }


    }
}
