﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Materias : ApplicationWeb
    {
        MateriaLogic _logic;

        private MateriaLogic Logic
        {
            get
            {
                if(_logic == null)
                {
                    _logic = new MateriaLogic();
                }
                return _logic;
            }
        }

        private Materia Entity { get; set; }

        protected override void LoadGrid()
        {
            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();
            gridActionPanel.Visible = true;
            formActionPanel.Visible = false;
        }

        protected override void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            descripcionTextBox.Text = Entity.Descripcion;
            hsSemanalesTextBox.Text = Entity.HSSemanales.ToString();
            hsTotalesTextBox.Text = Entity.HSTotales.ToString();
            LoadEspecialidadDDL();
            if(Entity.Descripcion != null)
            {
                SetPlan();
            }
        }

        private void LoadEspecialidadDDL()
        {
            especialidadDDL.DataSource = new EspecialidadLogic().GetAll();
            especialidadDDL.DataTextField = "Descripcion";
            especialidadDDL.DataValueField = "ID";
            especialidadDDL.DataBind();
        }

        protected void especialidadDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPlanDDL();
        }

        private void LoadPlanDDL()
        {
            planDDL.DataSource = new PlanLogic().GetByIdEspecialidad(int.Parse(especialidadDDL.SelectedValue));
            planDDL.DataTextField = "Descripcion";
            planDDL.DataValueField = "ID";
            planDDL.DataBind();
        }

        private void SetPlan()
        {
            Plan plan = new PlanLogic().GetOne(Entity.IDPlan);
            especialidadDDL.SelectedValue = plan.IDEspecialidad.ToString();
            planDDL.SelectedValue = Entity.IDPlan.ToString();
        }

        private void LoadEntity(Materia materia)
        {
            materia.Descripcion = descripcionTextBox.Text;
            materia.HSSemanales = int.Parse(hsSemanalesTextBox.Text);
            materia.HSTotales = int.Parse(hsTotalesTextBox.Text);
            materia.IDPlan = int.Parse(planDDL.SelectedValue);
        }

        private void SaveEntity(Materia materia)
        {
            Logic.Save(materia);
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                switch (FormMode)
                {
                    case FormModes.Alta:
                        Entity = new Materia();
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;

                    case FormModes.Modificacion:
                        Entity = new Materia();
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

        protected override void EnableForm(bool enable)
        {
            descripcionLabel.Enabled = enable;
            descripcionTextBox.Enabled = enable;
            hsSemanalesLabel.Enabled = enable;
            hsSemanalesTextBox.Enabled = enable;
            hsTotalesLabel.Enabled = enable;
            hsTotalesTextBox.Enabled = enable;
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
                EsconderValidaciones();
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
            hsSemanalesTextBox.Text = string.Empty;
            hsTotalesTextBox.Text = string.Empty;
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
            if(descripcionTextBox.Text == "")
            {
                DescripcionValidacion.Visible = true;
                return false;
            }

            if(hsTotalesTextBox.Text == "")
            {
                HSTotalesValidacion.Visible = true;
                return false;
            }

            if(hsSemanalesTextBox.Text == "")
            {
                HSSemanalesValidacion.Visible = true;
                return false;
            }

            return true;
        }

        protected void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {
            DescripcionValidacion.Visible = true;
        }

        protected void hsSemanalesTextBox_TextChanged(object sender, EventArgs e)
        {
            HSSemanalesValidacion.Visible = true;
        }

        protected void hsTotalesTextBox_TextChanged(object sender, EventArgs e)
        {
            HSTotalesValidacion.Visible = true;
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

        private void EsconderValidaciones()
        {
            DescripcionValidacion.Visible = false;
            HSSemanalesValidacion.Visible = false;
            HSTotalesValidacion.Visible = false;
        }

    }
}