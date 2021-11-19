using Business.Entities;
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
        private PersonaLogic _PersonaLogic = new PersonaLogic();
        private AlumnoInscripcionLogic _AlumnoInscripcionLogic = new AlumnoInscripcionLogic();
        protected new void Page_Load(object sender, EventArgs e)
        {
            DropDownListCursos.DataSource = _CursoLogic.GetAll().Select(c => new { ID = c.ID, Descripcion = $"{c.Materia} - {c.Comision} - {c.AnioCalendario}" }).ToList();
            DropDownListCursos.DataTextField = "Descripcion";
            DropDownListCursos.DataValueField = "ID";
            DropDownListCursos.DataBind();
        }

        protected void DropDownListCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Persona> alumnos = _PersonaLogic.GetAll().Where(a => a.TipoPersona == Business.Entities.Persona.TiposPersona.Alumno).ToList();
            List<AlumnoInscripcion> inscripciones = _AlumnoInscripcionLogic.GetAll();
            GridViewAlumnos.DataSource = 
        }
    }
}