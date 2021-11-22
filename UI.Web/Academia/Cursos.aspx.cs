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
    public partial class Cursos : ApplicationWeb
    {
        CursoLogic _logic;

        private CursoLogic Logic
        {
            get
            {
                if(_logic == null)
                {
                    _logic = new CursoLogic();
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

        private Curso Entity { get; set; }

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
            AnioCalendarioTextBox.Text = Entity.AnioCalendario.ToString();
            CupoTextBox.Text = Entity.Cupo.ToString();
            LoadEspecialidadDDL();
        }

        private void LoadEspecialidadDDL()
        {
            EspecialidadDDL.DataSource = new EspecialidadLogic().GetAll();
            EspecialidadDDL.DataTextField = "Descripcion";
            EspecialidadDDL.DataValueField = "ID";
            EspecialidadDDL.DataBind();
        }

        private void LoadPlanDDL(int id)
        {
            PlanDDL.DataSource = new PlanLogic().GetByIdEspecialidad(id);
            PlanDDL.DataTextField = "Descripcion";
            PlanDDL.DataValueField = "ID";
            PlanDDL.DataBind();
        }

        protected void EspecialidadDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPlanDDL(int.Parse(EspecialidadDDL.SelectedValue));
        }

        private void LoadComisionDDL(int id)
        {
            ComisionDDL.DataSource = new ComisionLogic().GetByIdPlan(id);
            ComisionDDL.DataTextField = "Descripcion";
            ComisionDDL.DataValueField = "ID";
            ComisionDDL.DataBind();
        }

        private void LoadMateriaDDL(int id)
        {
            MateriaDDL.DataSource = new MateriaLogic().GetByIdPlan(id);
            MateriaDDL.DataTextField = "Descripcion";
            MateriaDDL.DataValueField = "ID";
            MateriaDDL.DataBind();
        }

        protected void PlanDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComisionDDL(int.Parse(PlanDDL.SelectedValue));
            LoadMateriaDDL(int.Parse(PlanDDL.SelectedValue));
        }

        private void LoadEntity(Curso curso)
        {
            curso.IDComision = int.Parse(ComisionDDL.SelectedValue);
            curso.IDMateria = int.Parse(MateriaDDL.SelectedValue);
            curso.AnioCalendario = int.Parse(AnioCalendarioTextBox.Text);
            curso.Cupo = int.Parse(CupoTextBox.Text);
        }

        private void SaveEntity(Curso curso)
        {
            Logic.Save(curso);
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
                        Entity = new Curso();
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;

                    case FormModes.Modificacion:
                        Entity = new Curso();
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
            AnioCalendarioLabel.Enabled = enable;
            AnioCalendarioTextBox.Enabled = enable;
            CupoLabel.Enabled = enable;
            CupoTextBox.Enabled = enable;
            EspecialidadLabel.Enabled = enable;
            EspecialidadDDL.Enabled = enable;
            PlanLabel.Enabled = enable;
            PlanDDL.Enabled = enable;
            MateriaLabel.Enabled = enable;
            MateriaDDL.Enabled = enable;
            ComisionLabel.Enabled = enable;
            ComisionDDL.Enabled = enable;
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
            CupoTextBox.Text = string.Empty;
            AnioCalendarioTextBox.Text = string.Empty;
            EspecialidadDDL.DataSource = null;
            PlanDDL.DataSource = null;
            MateriaDDL.DataSource = null;
            ComisionDDL.DataSource = null;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            gridActionPanel.Visible = false;
            formActionPanel.Visible = true;
            EsconderValidaciones();
            LoadGrid();
            formPanel.Visible = false;
        }

        protected override bool Validar()
        {
            if(AnioCalendarioTextBox.Text == "")
            {
                AnioCalendarioValidacion.Visible = true;
                return false;
            }

            if(CupoTextBox.Text == "")
            {
                CupoValidacion.Visible = true;
                return false;
            }

            return true;
        }

        protected void AnioCalendarioTextBox_TextChanged(object sender, EventArgs e)
        {
            AnioCalendarioValidacion.Visible = false;
        }

        protected void CupoTextBox_TextChanged(object sender, EventArgs e)
        {
            CupoValidacion.Visible = false;
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
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        private void EsconderValidaciones()
        {
            AnioCalendarioValidacion.Visible = false;
            CupoValidacion.Visible = false;
        }

        private void EstablecerPermisos()
        {
            List<ModuloUsuario> modulosUsuario = Session["Modulos"] as List<ModuloUsuario>;

            foreach (ModuloUsuario mu in modulosUsuario)
            {
                if (mu.DescripcionModulo == "Cursos")
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