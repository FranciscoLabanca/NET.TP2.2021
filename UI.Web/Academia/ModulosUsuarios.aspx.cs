using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web.Academia
{
    public partial class ModulosUsuarios : ApplicationWeb
    {
        ModuloUsuarioLogic _logic;

        private ModuloUsuarioLogic Logic
        {
            get
            {
                if(_logic == null)
                {
                    _logic = new ModuloUsuarioLogic();
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

        private ModuloUsuario Entity { get; set; }

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
            LoadUsuariosDDL();
            LoadModuloDDL();
            usuarioDDL.SelectedValue = Entity.IdUsuario.ToString();
            moduloDDL.SelectedValue = Entity.IdModulo.ToString();
            altaCheckBox.Checked = Entity.PermiteAlta;
            bajaCheckBox.Checked = Entity.PermiteBaja;
            modificacionCheckBox.Checked = Entity.PermiteModificacion;
            consultaCheckBox.Checked = Entity.PermiteConsulta;
        }

        private void LoadEntity(ModuloUsuario moduloUsuario)
        {
            moduloUsuario.IdUsuario = int.Parse(usuarioDDL.SelectedValue);
            moduloUsuario.IdModulo = int.Parse(moduloDDL.SelectedValue);
            moduloUsuario.PermiteAlta = altaCheckBox.Checked;
            moduloUsuario.PermiteBaja = bajaCheckBox.Checked;
            moduloUsuario.PermiteModificacion = modificacionCheckBox.Checked;
            moduloUsuario.PermiteConsulta = consultaCheckBox.Checked;
        }

        private void SaveEntity(ModuloUsuario moduloUsuario)
        {
            Logic.Save(moduloUsuario);
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        private void LoadUsuariosDDL()
        {
            usuarioDDL.DataSource = new UsuarioLogic().GetAll();
            usuarioDDL.DataTextField = "NombreApellido";
            usuarioDDL.DataValueField = "ID";
            usuarioDDL.DataBind();
        }

        private void LoadModuloDDL()
        {
            moduloDDL.DataSource = new ModuloLogic().GetAll();
            moduloDDL.DataTextField = "Descripcion";
            moduloDDL.DataValueField = "ID";
            moduloDDL.DataBind();
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (FormMode)
            {
                case FormModes.Alta:
                    Entity = new ModuloUsuario();
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    LoadGrid();
                    break;

                case FormModes.Modificacion:
                    Entity = new ModuloUsuario();
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
            ReLoadSession((int)Session["ID"]);
            formPanel.Visible = false;
        }

        protected override void EnableForm(bool enable)
        {
            usuarioDDL.Enabled = enable;
            moduloDDL.Enabled = enable;
            altaCheckBox.Enabled = enable;
            bajaCheckBox.Enabled = enable;
            modificacionCheckBox.Enabled = enable;
            consultaCheckBox.Enabled = enable;
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
            LoadUsuariosDDL();
            LoadModuloDDL();
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        protected override void ClearForm()
        {
            usuarioDDL.DataSource = null;
            moduloDDL.DataSource = null;
            altaCheckBox.Checked = false;
            bajaCheckBox.Checked = false;
            modificacionCheckBox.Checked = false;
            consultaCheckBox.Checked = false;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            LoadGrid();
            formPanel.Visible = false;
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
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        private void ReLoadSession(int ID)
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            List<ModuloUsuario> modulosUsuarios = mul.GetByUserID(ID);
            Session["Modulos"] = modulosUsuarios;
        }
    }
}