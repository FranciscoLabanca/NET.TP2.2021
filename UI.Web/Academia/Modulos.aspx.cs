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

        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                EstablecerPermisos();
            }
        }

        private Modulo Entity { get; set; }

        override protected void LoadGrid() 
        {
            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();
            gridActionPanel.Visible = true;
            formActionPanel.Visible = false;
        }


        protected void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {
            DescripcionValidacion.Visible = false;
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
                EsconderValidaciones();
                gridActionPanel.Visible = false;
                formActionPanel.Visible = true;
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
                EsconderValidaciones();
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
            EsconderValidaciones();
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
            EsconderValidaciones();
            LoadGrid();
            formPanel.Visible = false;
        }

        protected override bool Validar()
        {
            bool flag = true;

            if(descripcionTextBox.Text == "")
            {
                DescripcionValidacion.Visible = true;
                flag = false;
            }

            return flag;
        }

        private void EsconderValidaciones()
        {
            DescripcionValidacion.Visible = false;
        }

        private void EstablecerPermisos()
        {
            List<ModuloUsuario> modulosUsuario = Session["Modulos"] as List<ModuloUsuario>;

            foreach (ModuloUsuario mu in modulosUsuario)
            {
                if (mu.DescripcionModulo == "Modulos")
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
    }
}