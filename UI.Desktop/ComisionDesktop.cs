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
    public partial class ComisionDesktop : ApplicationForm
    {
        public Comision ComisionActual { set; get; }
        public ComisionDesktop()
        {
            InitializeComponent();
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> especialidades = el.GetAll();
            cbEspecialidad.DataSource = especialidades;
            cbEspecialidad.DisplayMember = "Descripcion";
            cbEspecialidad.ValueMember = "ID";
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ComisionLogic cl = new ComisionLogic();
            ComisionActual = cl.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            tbId.Text = ComisionActual.ID.ToString();
            tbDescripcion.Text = ComisionActual.Descripcion;
            tbAnio.Text = ComisionActual.AnioEspecialidad.ToString();
            Plan plan = BuscarPlan(ComisionActual.IDPlan);
            cbEspecialidad.SelectedValue = plan.IDEspecialidad;
            cbPlan.SelectedValue = plan.ID;
            switch (Modo)
            {
                case ModoForm.Alta:
                    btnGuardar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    btnGuardar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    btnGuardar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    btnGuardar.Text = "Aceptar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    ComisionActual = new Comision();
                    ComisionActual.Descripcion = tbDescripcion.Text;
                    ComisionActual.AnioEspecialidad = int.Parse(tbAnio.Text);
                    ComisionActual.IDPlan = ((Plan)cbPlan.SelectedItem).ID;
                    ComisionActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Modificacion:
                    ComisionActual.Descripcion = tbDescripcion.Text;
                    ComisionActual.AnioEspecialidad = int.Parse(tbAnio.Text);
                    ComisionActual.IDPlan = ((Plan)cbPlan.SelectedItem).ID;
                    ComisionActual.State = BusinessEntity.States.Modified;
                    break;

                case ModoForm.Baja:
                    ComisionActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    ComisionActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            cl.Save(ComisionActual);
        }

        public override bool Validar()
        {
            if(tbAnio.Text == "" || tbDescripcion.Text == "")
            {
                Notificar("Campos Obligatorios Vacios", "Existen uno o mas campos vacios, rellenelos antes de continuar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected Plan BuscarPlan(int ID)
        {
            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(ID);
            return plan;
        }

        private void cbEspecialidad_SelectedValueChanged(object sender, EventArgs e)
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetByIdEspecialidad(((Especialidad)cbEspecialidad.SelectedItem).ID);
            cbPlan.DataSource = planes;
            cbPlan.DisplayMember = "Descripcion";
            cbPlan.ValueMember = "ID";
        }
    }
}
