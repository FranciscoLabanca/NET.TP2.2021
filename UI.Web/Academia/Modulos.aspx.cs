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
            try
            {
                gridView.DataSource = Logic.GetAll();
                gridView.DataBind();
                gridActionPanel.Visible = true;
                formActionPanel.Visible = false;
            }
            catch (Exception ex) { ManejarError(ex); }
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
            try
            {
                Entity = Logic.GetOne(id);
                descripcionTextBox.Text = Entity.Descripcion;
                ejecutaDDL.SelectedValue = Enum.GetNames(typeof(Modulo.ListaModulos)).ToString();
            }
            catch (Exception ex) { ManejarError(ex); }
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
                LoadEjecutaDDL();
                LoadForm(SelectedID);
            }
        }

        private void LoadEntity(Modulo modulo)
        {
            modulo.Descripcion = descripcionTextBox.Text;
            modulo.Ejecuta = (Modulo.ListaModulos)Enum.Parse(typeof(Modulo.ListaModulos), (string)ejecutaDDL.SelectedValue);
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
            try
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
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        protected override void EnableForm(bool enable)
        {
            descripcionTextBox.Enabled = enable;
            ejecutaDDL.Enabled = enable;
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
                LoadEjecutaDDL();
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
            LoadEjecutaDDL();
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
                if (mu.DescripcionModulo == "Permisos")
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

        private void LoadEjecutaDDL()
        {
            ejecutaDDL.DataSource = Enum.GetNames(typeof(Modulo.ListaModulos));
            ejecutaDDL.DataBind();
        }
    }
}