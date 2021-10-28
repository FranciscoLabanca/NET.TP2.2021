using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        private Business.Entities.DocenteCurso _DocenteCursoSeleccionado; 
        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }
        public DocenteCursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public DocenteCursoDesktop(Business.Entities.DocenteCurso docenteCurso, ModoForm modo) : this()
        {
            Modo = modo;
            _DocenteCursoSeleccionado = docenteCurso;
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CursosDesktop_Load(object sender, EventArgs e)
        {
            CbCargo.DataSource = Enum.GetValues(typeof(Business.Entities.DocenteCurso.TiposCargo));            

            CbDocente.DataSource = new PersonaLogic().GetAll().Where(d => d.TipoPersona == Persona.TiposPersona.Profesor).Select(p => new { ID = p.ID, NombreApellido = $"{p.Nombre} {p.Apellido}" }).ToList();
            CbDocente.DisplayMember = "NombreApellido";
            CbDocente.ValueMember = "ID";

            CbCurso.DataSource = new CursoLogic().GetAll().Select(c => new { ID = c.ID, Descripcion = $"{c.Materia} - {c.Comision} - {c.AnioCalendario}" });
            CbDocente.DisplayMember = "Descripcion";
            CbDocente.ValueMember = "ID";

            switch (Modo)
            {
                case ModoForm.Alta:
                    BtnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    BtnAceptar.Text = "Eliminar";
                    CbCargo.Enabled = false;
                    CbDocente.Enabled = false;
                    CbCurso.Enabled = false;
                    break;
                case ModoForm.Modificacion:
                    BtnAceptar.Text = "Guardar";
                    break;
            }
        }

    }
}
