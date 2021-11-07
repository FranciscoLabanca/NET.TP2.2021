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
    public partial class PersonaDesktop : ApplicationForm
    {
        public Persona PersonaActual { set; get; }
        public PersonaDesktop()
        {
            InitializeComponent();
            cbTipoPersona.DataSource = Enum.GetValues(typeof(Persona.TiposPersona));
            EspecialidadLogic el = new EspecialidadLogic();
            cbEspecialidad.DataSource = el.GetAll();
            cbEspecialidad.DisplayMember = "Descripcion";
            cbEspecialidad.ValueMember = "ID";
        }

        public PersonaDesktop (ModoForm modo) : this()
        {
            Modo = modo;
        }

        public PersonaDesktop (int id, ModoForm modo) :this()
        {
            Modo = modo;
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = pl.GetOne(id);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            tbID.Text = PersonaActual.ID.ToString();
            tbNombre.Text = PersonaActual.Nombre;
            tbApellido.Text = PersonaActual.Apellido;
            tbDireccion.Text = PersonaActual.Direccion;
            tbEmail.Text = PersonaActual.Email;
            tbTelefono.Text = PersonaActual.Telefono;
            dtFechaNac.Value = PersonaActual.FechaNacimiento;
            tbLegajo.Text = PersonaActual.Legajo.ToString();

            Plan plan = BuscarPlan(PersonaActual.IDPlan);

            cbEspecialidad.SelectedValue = plan.IDEspecialidad;
            cbPlan.SelectedValue = plan.ID;


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
                    PersonaActual = new Persona();
                    PersonaActual.Nombre = tbNombre.Text;
                    PersonaActual.Legajo = int.Parse(tbLegajo.Text);
                    PersonaActual.Apellido = tbApellido.Text;
                    PersonaActual.Direccion = tbDireccion.Text;
                    PersonaActual.Telefono = tbTelefono.Text;
                    PersonaActual.Email = tbDireccion.Text;
                    PersonaActual.IDPlan = ((Plan)cbPlan.SelectedItem).ID;
                    PersonaActual.FechaNacimiento = dtFechaNac.Value;


                    //Fuente: https://stackoverflow.com/questions/906899/binding-an-enum-to-a-winforms-combo-box-and-then-setting-it 
                    Persona.TiposPersona tiposPersona;
                    Enum.TryParse<Persona.TiposPersona>(cbTipoPersona.SelectedValue.ToString(), out tiposPersona);
                    PersonaActual.TipoPersona = tiposPersona;


                    PersonaActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Modificacion:
                    PersonaActual.Nombre = tbNombre.Text;
                    PersonaActual.Legajo = int.Parse(tbLegajo.Text);
                    PersonaActual.Apellido = tbApellido.Text;
                    PersonaActual.Direccion = tbDireccion.Text;
                    PersonaActual.Telefono = tbTelefono.Text;
                    PersonaActual.Email = tbDireccion.Text;
                    PersonaActual.IDPlan = ((Plan)cbPlan.SelectedItem).ID;
                    PersonaActual.FechaNacimiento = dtFechaNac.Value;
                    Persona.TiposPersona tipoPersona;
                    Enum.TryParse<Persona.TiposPersona>(cbTipoPersona.SelectedValue.ToString(), out tipoPersona);
                    PersonaActual.TipoPersona = tipoPersona;
                    PersonaActual.State = BusinessEntity.States.Modified;
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    PersonaActual.State = BusinessEntity.States.Modified;
                    btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PersonaLogic pl = new PersonaLogic();
            pl.Save(PersonaActual);
        }

        public override bool Validar()
        {
            if (tbNombre.Text == "")
            {
                Notificar("El campo Nombre esta vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tbApellido.Text == "")
            {
                Notificar("El campo Apellido esta vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tbLegajo.Text == "")
            {
                Notificar("El campo Legajo esta vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tbDireccion.Text == "")
            {
                Notificar("El campo Direccion esta vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tbTelefono.Text == "")
            {
                Notificar("El campo Telefono esta vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            PersonaLogic pl = new PersonaLogic();
            if (!pl.IsValidEmail(tbEmail.Text))
            {
                Notificar("El email es invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlanLogic pl = new PlanLogic();
            cbPlan.DataSource = pl.GetByIdEspecialidad(((Especialidad)cbEspecialidad.SelectedItem).ID);
            cbPlan.DisplayMember = "Descripcion";
            cbPlan.ValueMember = "ID";
        }

        protected Plan BuscarPlan(int ID)
        {
            PlanLogic pl = new PlanLogic();
            return pl.GetOne(ID);
        }
    }
}
