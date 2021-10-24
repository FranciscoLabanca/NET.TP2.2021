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

        protected override void LoadGrid()
        {
            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();
        }

        protected override void LoadForm(int id)
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
            EspecialidadLogic el = new EspecialidadLogic();
            especialidadDDL.DataSource = el.GetAll();
            especialidadDDL.DataTextField = "Descripcion";
            especialidadDDL.DataValueField = "ID";
            especialidadDDL.DataBind();
        }

        private void LoadPlanDDL()
        {
            PlanLogic pl = new PlanLogic();
            planDDL.DataSource = pl.GetByIdEspecialidad(int.Parse(especialidadDDL.SelectedValue));
            planDDL.DataTextField = "Descripcion";
            planDDL.DataValueField = "ID";
            planDDL.DataBind();
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
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

                formPanel.Visible = false;
            }
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
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
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
            LoadGrid();
            formPanel.Visible = false;
        }

        protected override bool Validar()
        {
            bool flag = true;

            if (descripcionTextBox.Text == "")
            {
                validacionDescripcion.Visible = true;
                flag = false;
            }

            if(anioEspecialidadTextBox.Text == "")
            {
                validacionAnioEspecialidad.Visible = true;
                flag = false;
            }

            return flag;
        }

        protected void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {
            validacionDescripcion.Visible = false;
        }

        protected void anioEspecialidadTextBox_TextChanged(object sender, EventArgs e)
        {
            validacionAnioEspecialidad.Visible = false;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
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

        protected void btnBuscarPlan_Click(object sender, EventArgs e)
        {
            LoadPlanDDL();
        }
    }
}