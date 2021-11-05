using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Login : ApplicationForm
    {
        public Login()
        {
            InitializeComponent();
            BtnAceptar.CausesValidation = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                try
                {
                    UsuarioLogic ul = new UsuarioLogic();
                    var usuario = ul.GetOne(tbNombreUsuario.Text);
                    bool usuarioValido = (usuario != null) && (usuario.Clave == tbContraseña.Text) && usuario.Habilitado;
                    if (usuarioValido)
                    {
                        this.Hide();
                        new Menu(usuario.ID).ShowDialog();
                        this.Close();
                    }
                    else if ((usuario == null) || (usuario.Clave != tbContraseña.Text))
                    {
                        MessageBox.Show("Usuario o Constraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Usuario no habilitado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Se produjo un error\n\n{ex.Message}\n\n{ex.InnerException.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } 
            }
        }

        private void ChkBoxMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBoxMostrarContraseña.Checked)
                tbContraseña.UseSystemPasswordChar = false;
            if (!ChkBoxMostrarContraseña.Checked)
                tbContraseña.UseSystemPasswordChar = true;
        }

        private void tbNombreUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNombreUsuario.Text))
            {
                e.Cancel = true;
                tbNombreUsuario.Focus();
                errorProviderLogIn.SetError(tbNombreUsuario, "Por favor ingrese un usuario");
            }
            else
            {
                e.Cancel = false;
                errorProviderLogIn.SetError(tbNombreUsuario, "");
            }
        }

        private void tbContraseña_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbContraseña.Text))
            {
                e.Cancel = true;
                tbContraseña.Focus();
                errorProviderLogIn.SetError(tbContraseña, "Por favor ingrese una contraseña"); 
            }
            else
            {
                e.Cancel = false;
                errorProviderLogIn.SetError(tbContraseña, "");
            }
        }

        private void linkLblCrearInvitado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                UsuarioLogic uslogic = new UsuarioLogic();
                ModuloUsuarioLogic muLogic = new ModuloUsuarioLogic();
                ModuloLogic modLogic = new ModuloLogic();
                Usuario usuarioInvitado;
                Business.Entities.Modulo modulo;
                if (uslogic.GetOne("Invitado") == null)
                {
                    usuarioInvitado = new Usuario { NombreUsuario = "Invitado", Clave = "1234", Habilitado = true, Nombre = "Invitado", Apellido = "Invitado", EMail = "", State = BusinessEntity.States.New };
                    uslogic.Save(usuarioInvitado);
                    modulo = new Business.Entities.Modulo { Descripcion = "Permisos", Ejecuta = Business.Entities.Modulo.ListaModulos.Permisos, State = BusinessEntity.States.New };
                    modLogic.Save(modulo);
                    muLogic.Save(new ModuloUsuario { IdModulo = modulo.ID, IdUsuario = usuarioInvitado.ID, PermiteAlta = true, PermiteBaja = true, PermiteConsulta = true, PermiteModificacion = true });
                    MessageBox.Show("Se creo un usuario Invitado, acceda con las siguientes credenciales:\n\nUsuario: Invitado\nContraseña: 1234");
                }
                else
                {
                    MessageBox.Show("Usuario Invitado ya existe, acceda con las siguientes credenciales:\n\nUsuario: Invitado\nContraseña: 1234");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error\n\n{ex.Message}\n\n{ex.InnerException.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
