using Business.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class RegistroNotas : ApplicationWeb
    {
        private CursoLogic _CursoLogic = new CursoLogic();
        protected new void Page_Load(object sender, EventArgs e)
        {
            DropDownListCursos.DataSource = _CursoLogic.GetAll().Select(c => new { ID = c.ID, Descripcion = $"{c.Materia} - {c.Comision} - {c.AnioCalendario}" }).ToList();
            DropDownListCursos.DataTextField = "Descripcion";
            DropDownListCursos.DataValueField = "ID";
            DropDownListCursos.DataBind();
        }
    }
}