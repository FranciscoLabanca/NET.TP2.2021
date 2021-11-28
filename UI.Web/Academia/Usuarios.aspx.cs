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

        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                EstablecerPermisos();
            }
        }

        private void EstablecerPermisos()
        {
            List<ModuloUsuario> modulosUsuario = Session["Modulos"] as List<ModuloUsuario>;

            foreach (ModuloUsuario mu in modulosUsuario)
            {
                if (mu.DescripcionModulo == "Usuarios")
                {
                    if (!mu.PermiteAlta)
                    {
                        nuevoLinkButton.Visible = false;
                    }

                    if (!mu.PermiteBaja)
                    {
                        eliminarLinkButton.Visible = false;
                    }

                    if (!mu.PermiteModificacion)
                    {
                        editarLinkButton.Visible = false;
                    }

                    return;
                }

            }
            Response.Redirect("~/Academia/Default.aspx");
        }

        private Usuario Entity { get; set; }

        override protected void LoadGrid()
        {
            try
            {
                gridView.DataSource = Logic.GetAll();
                gridView.DataBind();
                gridActionPanel.Visible = true;
                formActionPanel.Visible = false;
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        override protected void LoadForm(int id)
        {
            try
            {
                Entity = Logic.GetOne(id);
                habilitadoCheckBox.Checked = Entity.Habilitado;
                nombreUsuarioTextBox.Text = Entity.NombreUsuario;
                personaDDL.SelectedValue = Entity.IDPersona.ToString();
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                gridActionPanel.Visible = false;
                formActionPanel.Visible = true;
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadPersonaDDL();
                LoadForm(SelectedID);
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            try
            {
                Persona per = new PersonaLogic().GetOne(int.Parse(personaDDL.SelectedValue));
                usuario.Nombre = per.Nombre;
                usuario.Apellido = per.Apellido;
                usuario.EMail = per.Email;
                usuario.NombreUsuario = nombreUsuarioTextBox.Text;
                usuario.Clave = claveTextBox.Text;
                usuario.Habilitado = habilitadoCheckBox.Checked;
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        private void SaveEntity(Usuario usuario)
        {
            Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            try
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
                    EsconderValidaciones();
                    formPanel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);
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
                gridActionPanel.Visible = false;
                formActionPanel.Visible = true;
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
            gridActionPanel.Visible = false;
            formActionPanel.Visible = true;
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
            claveTextBox.Text = string.Empty;
            repetirClaveTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            EsconderValidaciones();
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
                NombreUsuarioValidacion.Visible = true;
                flag = false;
            }

            if (claveTextBox.Text == "" && FormMode != FormModes.Baja)
            {
                ClaveValidacion.Visible = true;
                flag = false;
            }

            if(repetirClaveTextBox.Text == "" && FormMode != FormModes.Baja)
            {
                RepetirClaveValidacion.Visible = true;
                flag = false;
            }

            if(claveTextBox.Text != repetirClaveTextBox.Text && FormMode != FormModes.Baja)
            {
                ClavesIgualesValidacion.Visible = true;
                flag = false;
            }
            return flag;
        }

        /*protected void nombreTextBox_TextChanged(object sender, EventArgs e)
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
        }*/

        protected void nombreUsuarioTextBox_TextChanged(object sender, EventArgs e)
        {
            NombreUsuarioValidacion.Visible = false;
        }

        protected void claveTextBox_TextChanged(object sender, EventArgs e)
        {
            ClaveValidacion.Visible = false;
            ClavesIgualesValidacion.Visible = false;
        }

        protected void repetirClaveTextBox_TextChanged(object sender, EventArgs e)
        {
            RepetirClaveValidacion.Visible = false;
            ClavesIgualesValidacion.Visible = false;
        }

        private void LoadPersonaDDL()
        {
            try
            {
                personaDDL.DataSource = new PersonaLogic().GetAll();
                personaDDL.DataTextField = "Apellido";
                personaDDL.DataValueField = "ID";
                personaDDL.DataBind();
            }
            catch (Exception ex) { ManejarError(ex); }
        }

        protected void personaDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*nombreTextBox.Text = ((Persona)personaDDL.SelectedItem).Nombre;
            apellidoTextBox.Text = ((Persona)personaDDL.SelectedItem).Apellido;*/
        }

        private void EsconderValidaciones()
        {
            NombreUsuarioValidacion.Visible = false;
            ClaveValidacion.Visible = false;
            ClavesIgualesValidacion.Visible = false;
            RepetirClaveValidacion.Visible = false;
        }

        private void ManejarError(Exception exc)
        {
            LabelError.Text = $"{exc.Message}.";

            LabelError.Visible = true;
        }
    }
}