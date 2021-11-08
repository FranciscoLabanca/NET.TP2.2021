using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Usuarios : ApplicationWeb
    {
        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if(_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        private Usuario Entity { get; set; }

        override protected void LoadGrid()
        {
            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        override protected void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            nombreTextBox.Text = " ";
            apellidoTextBox.Text = " ";
            emailTextBox.Text = " ";
            habilitadoCheckBox.Checked = Entity.Habilitado;
            nombreUsuarioTextBox.Text = Entity.NombreUsuario;
            personaDDL.SelectedValue = Entity.IDPersona.ToString();
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadPersonaDDL();
                LoadForm(SelectedID);
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = nombreTextBox.Text;
            usuario.Apellido = apellidoTextBox.Text;
            usuario.EMail = emailTextBox.Text;
            usuario.NombreUsuario = nombreUsuarioTextBox.Text;
            usuario.Clave = claveTextBox.Text;
            usuario.Habilitado = habilitadoCheckBox.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                switch (FormMode)
                {
                    case FormModes.Baja:
                        DeleteEntity(SelectedID);
                        LoadGrid();
                        break;

                    case FormModes.Modificacion:
                        Entity = new Usuario();
                        Entity.ID = SelectedID;
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;

                    case FormModes.Alta:
                        Entity = new Usuario();
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;

                    default:
                        break;
                }

                formPanel.Visible = false;
            }            
        }

        override protected void EnableForm(bool enable)
        {
            /*nombreTextBox.Enabled = enable;
            apellidoTextBox.Enabled = enable;
            emailTextBox.Enabled = enable;*/
            nombreUsuarioTextBox.Enabled = enable;
            claveTextBox.Visible = enable;
            claveLabel.Visible = enable;
            repetirClaveLabel.Enabled = enable;
            repetirClaveTextBox.Visible = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
            LoadPersonaDDL();
        }

        override protected void ClearForm()
        {
            /*nombreTextBox.Text = string.Empty;
            apellidoTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;*/
            habilitadoCheckBox.Checked = false;
            nombreUsuarioTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            LoadGrid();
            formPanel.Visible = false;
        }

        override protected bool Validar()
        {
            bool flag = true;
            /*if(nombreTextBox.Text == "")
            {
                validacionNombre.Visible = true;
                flag = false;
            }

            if(apellidoTextBox.Text == "")
            {
                validacionApellido.Visible = true;
                flag = false;
            }

            if(emailTextBox.Text == "")
            {
                validacionMail.Visible = true;
                flag = false;
            }*/

            if(nombreUsuarioTextBox.Text == "")
            {
                validacionNombreUsuario.Visible = true;
                flag = false;
            }

            if (claveTextBox.Text == "" && FormMode != FormModes.Baja)
            {
                validacionClave.Visible = true;
                flag = false;
            }

            if(repetirClaveTextBox.Text == "" && FormMode != FormModes.Baja)
            {
                validacionRepetirClave.Visible = true;
                flag = false;
            }

            if(claveTextBox.Text != repetirClaveTextBox.Text && FormMode != FormModes.Baja)
            {
                validacionClavesIguales.Visible = true;
                flag = false;
            }
            return flag;
        }

        protected void nombreTextBox_TextChanged(object sender, EventArgs e)
        {
            //validacionNombre.Visible = false;
        }

        protected void apellidoTextBox_TextChanged(object sender, EventArgs e)
        {
            //validacionApellido.Visible = false;
        }

        protected void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            //validacionMail.Visible = false;
        }

        protected void nombreUsuarioTextBox_TextChanged(object sender, EventArgs e)
        {
            validacionNombreUsuario.Visible = false;
        }

        protected void claveTextBox_TextChanged(object sender, EventArgs e)
        {
            validacionClave.Visible = false;
            validacionClavesIguales.Visible = false;
        }

        protected void repetirClaveTextBox_TextChanged(object sender, EventArgs e)
        {
            validacionRepetirClave.Visible = false;
            validacionClavesIguales.Visible = false;
        }

        private void LoadPersonaDDL()
        {
            personaDDL.DataSource = new PersonaLogic().GetAll();
            personaDDL.DataTextField = "Apellido";
            personaDDL.DataValueField = "ID";
            personaDDL.DataBind();
        }

        protected void personaDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*nombreTextBox.Text = ((Persona)personaDDL.SelectedItem).Nombre;
            apellidoTextBox.Text = ((Persona)personaDDL.SelectedItem).Apellido;*/
        }
    }
}