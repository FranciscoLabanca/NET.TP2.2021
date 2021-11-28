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
    public partial class Planes : ApplicationWeb
    {
        PlanLogic _logic;

        private PlanLogic Logic
        {
            get
            {
                if(_logic == null)
                {
                    _logic = new PlanLogic();
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
        private Plan Entity { get; set; }

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
                descripcionTextBox.Text = Entity.Descripcion;
                especialidadDDL.SelectedValue = Entity.IDEspecialidad.ToString();
            }
            catch (Exception ex)
            {
                ManejarError(ex);                
            }
        }

        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = descripcionTextBox.Text;
            plan.IDEspecialidad = int.Parse(especialidadDDL.SelectedValue);
        }

        private void SaveEntity(Plan plan)
        {
            Logic.Save(plan);
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        private void LoadDropDownList()
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

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    switch (FormMode)
                    {
                        case FormModes.Alta:
                            Entity = new Plan();
                            LoadEntity(Entity);
                            SaveEntity(Entity);
                            LoadGrid();
                            break;

                        case FormModes.Modificacion:
                            Entity = new Plan();
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
            descripcionLabel.Enabled = enable;
            descripcionTextBox.Enabled = enable;
            especialidadLabel.Enabled = enable;
            especialidadDDL.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                EsconderValidaciones();
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
            LoadDropDownList();
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        protected override void ClearForm()
        {
            descripcionTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            EsconderValidaciones();
            LoadGrid();
            formPanel.Visible = false;
        }

        protected override bool Validar()
        {
            bool flag = true;

            if (descripcionTextBox.Text == "")
            {
                divValidacion.Visible = true;
                flag = false;
            }

            return flag;
        }

        protected void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {
            divValidacion.Visible = false;
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
                LoadDropDownList();
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        private void EsconderValidaciones ()
        {
            divValidacion.Visible = false;
        }

        private void ManejarError(Exception exc)
        {
            LabelError.Text = $"{exc.Message}.";

            LabelError.Visible = true;
        }
    }
}