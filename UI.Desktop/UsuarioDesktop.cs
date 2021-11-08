using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Usuario UsuarioActual
        {
            set;
            get;
        }
        private UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            LoadCBPersona();
        }

        public UsuarioDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioActual = new UsuarioLogic().GetOne(id);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            tbID.Text = UsuarioActual.ID.ToString();
            LoadCBPersona();
            CargarCamposPersona();
            tbNombreUsuario.Text = UsuarioActual.NombreUsuario;
            tbClave.Text = UsuarioActual.Clave;
            cbHabilitado.Checked = UsuarioActual.Habilitado;

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
                    UsuarioActual = new Usuario();
                    UsuarioActual.Nombre = tbNombre.Text;
                    UsuarioActual.Apellido = tbApellido.Text;
                    UsuarioActual.NombreUsuario = tbNombreUsuario.Text;
                    UsuarioActual.Clave = tbClave.Text;
                    UsuarioActual.EMail = tbEmail.Text;
                    UsuarioActual.Habilitado = cbHabilitado.Checked;

                    UsuarioActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Modificacion:
                    UsuarioActual.Nombre = tbNombre.Text;
                    UsuarioActual.Apellido = tbApellido.Text;
                    UsuarioActual.NombreUsuario = tbNombreUsuario.Text;
                    UsuarioActual.Clave = tbClave.Text;
                    UsuarioActual.EMail = tbEmail.Text;
                    UsuarioActual.Habilitado = cbHabilitado.Checked;

                    UsuarioActual.State = BusinessEntity.States.Modified;
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override bool Validar()
        {            
            if (tbNombre.Text == "" || tbApellido.Text == "" || tbEmail.Text == "" || tbClave.Text == "" || tbNombreUsuario.Text == "")
                return false;
            else
                return true;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            new UsuarioLogic().Save(UsuarioActual);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
            else
                Notificar("Verifique que todos los campos esten completos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void LoadCBPersona()
        {
            cbPersona.DataSource = new PersonaLogic().GetAll();
            cbPersona.DisplayMember = "Apellido";
            cbPersona.ValueMember = "ID";
        }

        private void CargarCamposPersona()
        {
            tbApellido.Text = ((Persona)cbPersona.SelectedItem).Apellido;
            tbNombre.Text = ((Persona)cbPersona.SelectedItem).Nombre;
            tbEmail.Text = ((Persona)cbPersona.SelectedItem).Email;
        }

        private void cbPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCamposPersona();
        }
    }
}
