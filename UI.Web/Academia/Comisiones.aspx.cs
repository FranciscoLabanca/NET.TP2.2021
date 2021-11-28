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
    public partial class Comisiones : ApplicationWeb
    {
        ComisionLogic _logic;

        private ComisionLogic Logic
        {
            get
            {
                if(_logic == null)
                {
                    _logic = new ComisionLogic();
                }
                return _logic;
            }
        }

        private Comision Entity { get; set; }

        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                EstablecerPermisos();
            }
        }

        protected override void LoadGrid()
        {
            try
            {
                gridView.DataSource = Logic.GetAll();
                gridView.DataBind();
                gridActionPanel.Visible = true;
                formActionPanel.Visible = false;
            }
            catch (Exception ex) { ManejarError(ex); }
        }

        protected override void LoadForm(int id)
        {
            try
            {
                Entity = Logic.GetOne(id);
                descripcionTextBox.Text = Entity.Descripcion;
                anioEspecialidadTextBox.Text = Entity.AnioEspecialidad.ToString();
                PlanLogic pl = new PlanLogic();
                Plan plan = pl.GetOne(Entity.IDPlan);
                especialidadDDL.SelectedValue = plan.IDEspecialidad.ToString();
                LoadPlanDDL();
                planDDL.SelectedValue = Entity.IDPlan.ToString();
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        private void LoadEntity(Comision com)
        {
            com.Descripcion = descripcionTextBox.Text;
            com.AnioEspecialidad = int.Parse(anioEspecialidadTextBox.Text);
            com.IDPlan = int.Parse(planDDL.SelectedValue);
        }

        private void SaveEntity(Comision com)
        {
            Logic.Save(com);
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
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
            catch (Exception ex) { ManejarError(ex); }
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
            catch (Exception ex) { ManejarError(ex); }
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
                            Entity = new Comision();
                            LoadEntity(Entity);
                            SaveEntity(Entity);
                            LoadGrid();
                            break;

                        case FormModes.Modificacion:
                            Entity = new Comision();
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
            catch (Exception ex) { ManejarError(ex); }
        }

        protected override void EnableForm(bool enable)
        {
            descripcionLabel.Enabled = enable;
            descripcionTextBox.Enabled = enable;
            anioEspecialidadLabel.Enabled = enable;
            anioEspecialidadTextBox.Enabled = enable;
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
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        protected override void ClearForm()
        {
            descripcionTextBox.Text = string.Empty;
            anioEspecialidadTextBox.Text = string.Empty;
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
            bool flag = true;

            if (descripcionTextBox.Text == "")
            {
                DescripcionValidacion.Visible = true;
                flag = false;
            }

            if(anioEspecialidadTextBox.Text == "")
            {
                AnioEspecialidadValidacion.Visible = true;
                flag = false;
            }

            return flag;
        }

        protected void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {
            DescripcionValidacion.Visible = false;
        }

        protected void anioEspecialidadTextBox_TextChanged(object sender, EventArgs e)
        {
            AnioEspecialidadValidacion.Visible = false;
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
                EsconderValidaciones();
                formPanel.Visible = true;
                LoadEspecialidadDDL();
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        protected void especialidadDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPlanDDL();
        }

        private void EsconderValidaciones()
        {
            DescripcionValidacion.Visible = false;
            AnioEspecialidadValidacion.Visible = false;
        }

        private void EstablecerPermisos()
        {
            List<ModuloUsuario> modulosUsuario = Session["Modulos"] as List<ModuloUsuario>;

            foreach (ModuloUsuario mu in modulosUsuario)
            {
                if (mu.DescripcionModulo == "Comisiones")
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
        private void ManejarError(Exception exc)
        {
            LabelError.Text = $"{exc.Message}.";

            LabelError.Visible = true;
        }
    }
}