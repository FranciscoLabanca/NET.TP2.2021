using Business.Entities;
using Business.Logic;
using UI.Web.Models.RegistroNotas;
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
        private readonly CursoLogic _CursoLogic = new CursoLogic();
        private readonly PersonaLogic _PersonaLogic = new PersonaLogic();
        private readonly AlumnoInscripcionLogic _AlumnoInscripcionLogic = new AlumnoInscripcionLogic();

        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["InscripcionesAGuardar"] = new List<AlumnoInscripcion>();

                IEnumerable listaCursos = _CursoLogic.GetAll().Select(c => new CursosResponse { ID = c.ID, Descripcion = $"{c.Materia} - {c.Comision} - {c.AnioCalendario}" }).Prepend(new CursosResponse { ID = 0, Descripcion = "Seleccione un Curso" }).ToList();
                DropDownListCursos.DataSource = listaCursos;
                DropDownListCursos.DataTextField = "Descripcion";
                DropDownListCursos.DataValueField = "ID";
                DropDownListCursos.DataBind();
            }

        }

        protected void DropDownListCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGridView();
            GridViewAlumnos.SelectedIndex = -1;
        }

        private void CargarGridView()
        {
            List<Persona> alumnos = _PersonaLogic.GetAll().Where(a => a.TipoPersona == Business.Entities.Persona.TiposPersona.Alumno).ToList();
            List<AlumnoInscripcion> inscripciones = _AlumnoInscripcionLogic.GetAll().Where(i => i.IDCurso == int.Parse(DropDownListCursos.SelectedValue)).ToList();
            GridViewAlumnos.DataSource = (from alumno in alumnos
                                          join inscripcion in inscripciones
                                             on alumno.ID equals inscripcion.IDAlumno
                                          select new InscripcionResponse
                                          {
                                              AlumnoID = alumno.ID,
                                              InscripcionID = inscripcion.ID,
                                              Nombre = alumno.Nombre,
                                              Apellido = alumno.Apellido,
                                              Legajo = alumno.Legajo,
                                              Condicion = inscripcion.Condicion,
                                              Nota = inscripcion.Nota
                                          }).ToList();
            GridViewAlumnos.DataBind();
        }

        protected void GridViewAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)GridViewAlumnos.SelectedValue;
            MapearDeDatos();
        }

        private void MapearDeDatos()
        {
            TextBoxAlumnoSeleccionado.Text = $"{GridViewAlumnos.SelectedRow.Cells[1].Text} {GridViewAlumnos.SelectedRow.Cells[2].Text}";
            DropDownListCondicion.SelectedValue = GridViewAlumnos.SelectedRow.Cells[3].Text;
            TextBoxNota.Text = GridViewAlumnos.SelectedRow.Cells[4].Text;
        }

        private void ResetearFormulario()
        {
            TextBoxAlumnoSeleccionado.Text = "";
            DropDownListCondicion.SelectedValue = "Cursando";
            TextBoxNota.Text = "0";
        }

        private void MapearADatos(AlumnoInscripcion inscripcion)
        {
            inscripcion.Nota = int.Parse(TextBoxNota.Text);
            inscripcion.Condicion = DropDownListCondicion.SelectedValue;
            inscripcion.State = BusinessEntity.States.Modified;
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                AlumnoInscripcion inscripcion = _AlumnoInscripcionLogic.GetOne((int)GridViewAlumnos.SelectedValue);
                MapearADatos(inscripcion);
                ((List<AlumnoInscripcion>)ViewState["InscripcionesAGuardar"]).Add(inscripcion);
                GridViewAlumnos.SelectedRow.Cells[3].Text = DropDownListCondicion.SelectedValue;
                GridViewAlumnos.SelectedRow.Cells[4].Text = TextBoxNota.Text;
                GridViewAlumnos.SelectedIndex = -1;
                ResetearFormulario();

                HayCambiosSinGuardarError.Visible = true;
            }
        }

        protected void ButtonGuardarCambios_Click(object sender, EventArgs e)
        {
            foreach (var inscripcion in (List<AlumnoInscripcion>)ViewState["InscripcionesAGuardar"])
            {
                _AlumnoInscripcionLogic.Save(inscripcion);
            }
            HayCambiosSinGuardarError.Visible = false;
        }
    }



}