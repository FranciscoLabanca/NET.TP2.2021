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
    public partial class Modulos : ApplicationWeb
    {
        ModuloLogic _logic;

        private ModuloLogic Logic
        {
            get
            {
                if(_logic == null)
                {
                    _logic = new ModuloLogic();
                }
                return _logic;

            }
        }

        private Modulo Entity { get; set; }

        override protected void LoadGrid() 
        {
            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();
        }


        protected void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {
            validacionDescripcion.Visible = false;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        protected override void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            descripcionTextBox.Text = Entity.Descripcion;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        private void LoadEntity(Modulo modulo)
        {
            modulo.Descripcion = descripcionTextBox.Text;
        }

        private void SaveEntity(Modulo modulo)
        {
            Logic.Save(modulo);
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
                        Entity = new Modulo();
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;

                    case FormModes.Modificacion:
                        Entity = new Modulo();
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
            descripcionTextBox.Enabled = enable;
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
            LoadGrid();
            formPanel.Visible = false;
        }

        protected override bool Validar()
        {
            bool flag = true;

            if(descripcionTextBox.Text == "")
            {
                validacionDescripcion.Visible = true;
                flag = false;
            }

            return flag;
        }
    }
}