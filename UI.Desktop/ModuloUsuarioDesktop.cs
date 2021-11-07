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
    public partial class ModuloUsuarioDesktop : ApplicationForm
    {
        public ModuloUsuario MUActual { get; set; }
        public ModuloUsuarioDesktop()
        {
            InitializeComponent();

            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> usuarios = ul.GetAll();
            cbUsuario.DataSource = usuarios;
            cbUsuario.DisplayMember = "NombreUsuario";
            cbUsuario.ValueMember = "ID";

            ModuloLogic ml = new ModuloLogic();
            List<Business.Entities.Modulo> modulos = ml.GetAll();
            cbModulo.DataSource = modulos;
            cbModulo.DisplayMember = "Descripcion";
            cbModulo.ValueMember = "ID";
        }

        public ModuloUsuarioDesktop(ModoForm modo) : this ()
        {
            Modo = modo;
        }

        public ModuloUsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            MUActual = mul.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            tbID.Text = MUActual.ID.ToString();
            cbUsuario.SelectedValue = MUActual.IdUsuario;
            cbModulo.SelectedValue = MUActual.IdModulo;
            checkAlta.Checked = MUActual.PermiteAlta;
            checkBaja.Checked = MUActual.PermiteBaja;
            checkConsulta.Checked = MUActual.PermiteConsulta;
            checkModificacion.Checked = MUActual.PermiteModificacion;
            switch(Modo)
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
                    MUActual = new ModuloUsuario();
                    MUActual.IdModulo = ((Business.Entities.Modulo)cbModulo.SelectedItem).ID;
                    MUActual.IdUsuario = ((Usuario)cbUsuario.SelectedItem).ID;
                    MUActual.PermiteAlta = checkAlta.Checked;
                    MUActual.PermiteBaja = checkBaja.Checked;
                    MUActual.PermiteConsulta = checkConsulta.Checked;
                    MUActual.PermiteModificacion = checkModificacion.Checked;
                    MUActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Modificacion:
                    MUActual.IdModulo = ((Business.Entities.Modulo)cbModulo.SelectedItem).ID;
                    MUActual.IdUsuario = ((Usuario)cbUsuario.SelectedItem).ID;
                    MUActual.PermiteAlta = checkAlta.Checked;
                    MUActual.PermiteBaja = checkBaja.Checked;
                    MUActual.PermiteConsulta = checkConsulta.Checked;
                    MUActual.PermiteModificacion = checkModificacion.Checked;
                    MUActual.State = BusinessEntity.States.Modified;
                    break;

                case ModoForm.Baja:
                    MUActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    MUActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            mul.Save(MUActual);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
