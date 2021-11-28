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
    public partial class Personas : ApplicationWeb
    {
        PersonaLogic _logic;

        private PersonaLogic Logic
        {
            get
            {
                if(_logic == null)
                {
                    _logic = new PersonaLogic();
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
                if (mu.DescripcionModulo == "Personas")
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

        private Persona Entity { get; set; }

        protected override void LoadGrid()
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

        protected override void LoadForm(int id)
        {
            try
            {
                Entity = Logic.GetOne(id);
                nombreTextBox.Text = Entity.Nombre;
                apellidoTextBox.Text = Entity.Apellido;
                direccionTextBox.Text = Entity.Direccion;
                emailTextBox.Text = Entity.Email;
                telefonoTextBox.Text = Entity.Telefono;
                fechaNacimientoTextBox.Text = Entity.FechaNacimiento.ToString();
                legajoTextBox.Text = Entity.Legajo.ToString();
                LoadTipoPersonaDDL();
                LoadPlanDDL();
            }
            catch (Exception ex) { ManejarError(ex); }
        }

        private void LoadTipoPersonaDDL()
        {
            tipoPersonaDDL.DataSource = Enum.GetValues(typeof(Persona.TiposPersona));
            tipoPersonaDDL.DataBind();
        }

        private void LoadEspecialidadDDL()
        {
            try
            {
                EspecialidadLogic el = new EspecialidadLogic();
                especialidadDDL.DataSource = el.GetAll();
                especialidadDDL.DataTextField = "Descripcion";
                especialidadDDL.DataValueField = "ID";
                especialidadDDL.DataBind();
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        private void LoadPlanDDL()
        {
            try
            {
                PlanLogic pl = new PlanLogic();
                planDDL.DataSource = pl.GetByIdEspecialidad(int.Parse(especialidadDDL.SelectedValue));
                planDDL.DataTextField = "Descripcion";
                planDDL.DataValueField = "ID";
                planDDL.DataBind();
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        private void LoadEntity(Persona persona)
        {
            persona.Nombre = nombreTextBox.Text;
            persona.Apellido = apellidoTextBox.Text;
            persona.Direccion = direccionTextBox.Text;
            persona.Email = emailTextBox.Text;
            persona.Telefono = telefonoTextBox.Text;
            persona.FechaNacimiento = DateTime.Parse(fechaNacimientoTextBox.Text);
            persona.Legajo = int.Parse(legajoTextBox.Text);
            Enum.TryParse(tipoPersonaDDL.SelectedValue.ToString(), out Persona.TiposPersona tiposPersona);
            persona.TipoPersona = tiposPersona;
            persona.IDPlan = int.Parse(planDDL.SelectedValue);
        }

        private void SaveEntity(Persona persona)
        {
            Logic.Save(persona);
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    switch (FormMode)
                    {
                        case FormModes.Alta:
                            Entity = new Persona();
                            LoadEntity(Entity);
                            SaveEntity(Entity);
                            LoadGrid();
                            break;

                        case FormModes.Modificacion:
                            Entity = new Persona();
                            Entity.ID = SelectedID;
                            Entity.State = BusinessEntity.States.Modified;
                            LoadEntity(Entity);
                            SaveEntity(Entity);
                            LoadGrid();
                            break;

                        case FormModes.Baja:
                            DeleteEntity(SelectedID);
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

        protected override void EnableForm(bool enable)
        {
            nombreLabel.Enabled = enable;
            nombreTextBox.Enabled = enable;
            apellidoLabel.Enabled = enable;
            apellidoTextBox.Enabled = enable;
            direccionLabel.Enabled = enable;
            direccionTextBox.Enabled = enable;
            emailLabel.Enabled = enable;
            emailTextBox.Enabled = enable;
            telefonoLabel.Enabled = enable;
            telefonoTextBox.Enabled = enable;
            fechaNacimientoTextBox.Enabled = enable;
            fechaNacimientoLabel.Enabled = enable;
            legajoLabel.Enabled = enable;
            legajoTextBox.Enabled = enable;
            tipoPersonaLabel.Enabled = enable;
            tipoPersonaDDL.Enabled = enable;
            especialidadLabel.Enabled = enable;
            especialidadDDL.Enabled = enable;
            planLabel.Enabled = enable;
            planDDL.Enabled = enable;
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

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            gridActionPanel.Visible = false;
            formActionPanel.Visible = true;
            formPanel.Visible = true;
            LoadEspecialidadDDL();
            LoadTipoPersonaDDL();
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        protected override void ClearForm()
        {
            nombreTextBox.Text = string.Empty;
            apellidoTextBox.Text = string.Empty;
            direccionTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            telefonoTextBox.Text = string.Empty;
            fechaNacimientoTextBox.Text = string.Empty;
            legajoTextBox.Text = string.Empty;
            especialidadDDL.DataSource = null;
            planDDL.DataSource = null;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            EsconderValidaciones();
            LoadGrid();
            formPanel.Visible = false;
        }

        protected override bool Validar()
        {
            if(nombreTextBox.Text == "")
            {
                NombreValidacion.Visible = true;
                return false;
            }

            if(apellidoTextBox.Text == "")
            {
                ApellidoValidacion.Visible = true;
                return false;
            }

            if(direccionTextBox.Text == "")
            {
                DireccionValidacion.Visible = true;
                return false;
            }

            if(!new PersonaLogic().IsValidEmail(emailTextBox.Text))
            {
                MailValidacion.Visible = true;
                return false;
            }

            if(telefonoTextBox.Text == "")
            {
                TelefonoValidacion.Visible = true;
                return false;
            }

            if(legajoTextBox.Text == "")
            {
                LegajoValidacion.Visible = true;
                return false;
            }

            if(fechaNacimientoTextBox.Text == "")
            {
                FechaNacimientoValidacion.Visible = true;
                return false;
            }
            return true;
        }

        protected void nombreTextBox_TextChanged(object sender, EventArgs e)
        {
            NombreValidacion.Visible = false;
        }

        protected void apellidoTextBox_TextChanged(object sender, EventArgs e)
        {
            ApellidoValidacion.Visible = false;
        }

        protected void direccionTextBox_TextChanged(object sender, EventArgs e)
        {
            DireccionValidacion.Visible = false;
        }

        protected void telefonoTextBox_TextChanged(object sender, EventArgs e)
        {
            TelefonoValidacion.Visible = false;
        }

        protected void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            MailValidacion.Visible = false;
        }

        protected void legajoTextBox_TextChanged(object sender, EventArgs e)
        {
            LegajoValidacion.Visible = false;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                gridActionPanel.Visible = false;
                formActionPanel.Visible = true;
                formPanel.Visible = true;
                LoadEspecialidadDDL();
                LoadTipoPersonaDDL();
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        protected void especialidadDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPlanDDL();
        }

        protected void fechaNacimientoTextBox_TextChanged(object sender, EventArgs e)
        {
            FechaNacimientoValidacion.Visible = false;
        }

        private void EsconderValidaciones()
        {
            NombreValidacion.Visible = false;
            ApellidoValidacion.Visible = false;
            DireccionValidacion.Visible = false;
            MailValidacion.Visible = false;
            LegajoValidacion.Visible = false;
            TelefonoValidacion.Visible = false;
        }
        private void ManejarError(Exception exc)
        {
            LabelError.Text = $"{exc.Message}.";

            LabelError.Visible = true;
        }
    }
}