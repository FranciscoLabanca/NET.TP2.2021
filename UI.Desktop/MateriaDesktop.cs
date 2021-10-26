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
    public partial class MateriaDesktop : ApplicationForm
    {
        public Materia MateriaActual { get; set; }
        public MateriaDesktop()
        {
            InitializeComponent();
            List<Especialidad> especialidades = new EspecialidadLogic().GetAll();
            CbEspecialidad.DataSource = especialidades;
            CbEspecialidad.DisplayMember = "Descripcion";
            CbEspecialidad.ValueMember = "ID";
            CbEspecialidad.SelectedIndex = 0;
            //List<Plan> planes = new PlanLogic().GetAll();
            ActualizarPlanesCb();
            //cbPlanes.DisplayMember = "Descripcion";
            //cbPlanes.ValueMember = "ID";
        }

        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public MateriaDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaActual = new MateriaLogic().GetOne(id);
            MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            tbID.Text = MateriaActual.ID.ToString();
            tbDescripcion.Text = MateriaActual.Descripcion;
            tbHorasSemanales.Text = MateriaActual.HSSemanales.ToString();
            tbHorasTotales.Text = MateriaActual.HSTotales.ToString();
            cbPlanes.SelectedItem = new PlanLogic().GetOne(MateriaActual.IDPlan);

            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    btnAceptar.Text = "Guardar";
                    break;
            }
        }
        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    MateriaActual = new Materia();
                    MateriaActual.Descripcion = tbDescripcion.Text;
                    MateriaActual.HSSemanales = int.Parse(tbHorasSemanales.Text);
                    MateriaActual.HSTotales = int.Parse(tbHorasTotales.Text);
                    MateriaActual.IDPlan = ((Plan)cbPlanes.SelectedItem).ID;

                    MateriaActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Modificacion:
                    //MateriaActual = new Materia();
                    MateriaActual.Descripcion = tbDescripcion.Text;
                    MateriaActual.HSSemanales = int.Parse(tbHorasSemanales.Text);
                    MateriaActual.HSTotales = int.Parse(tbHorasTotales.Text);
                    MateriaActual.IDPlan = ((Plan)cbPlanes.SelectedItem).ID;

                    MateriaActual.State = BusinessEntity.States.Modified;
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    MateriaActual.State = BusinessEntity.States.Deleted;
                    btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    MateriaActual.State = BusinessEntity.States.Modified;
                    btnAceptar.Text = "Guardar";
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MapearADatos();
            new MateriaLogic().Save(MateriaActual);
            this.Close();
        }

        private void CbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPlanesCb();
        }

        private void ActualizarPlanesCb()
        {
            cbPlanes.DataSource = new PlanLogic().GetAll().Where(p => p.IDEspecialidad == ((Especialidad)CbEspecialidad.SelectedItem).ID).ToList();
            cbPlanes.DisplayMember = "Descripcion";
            cbPlanes.ValueMember = "ID";
        }
    }
}
