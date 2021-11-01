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
            try
            {
                DocenteCursoLogic dcLogic = new DocenteCursoLogic();
                switch (Modo)
                {
                    case ModoForm.Alta:
                        _DocenteCursoSeleccionado = new Business.Entities.DocenteCurso();
                        MapearADatos();
                        _DocenteCursoSeleccionado.State = BusinessEntity.States.New;
                        dcLogic.Save(_DocenteCursoSeleccionado);
                        break;
                    case ModoForm.Baja:
                        _DocenteCursoSeleccionado.State = BusinessEntity.States.Deleted;
                        dcLogic.Save(_DocenteCursoSeleccionado);
                        break;
                    case ModoForm.Modificacion:
                        MapearADatos();
                        _DocenteCursoSeleccionado.State = BusinessEntity.States.Modified;
                        dcLogic.Save(_DocenteCursoSeleccionado);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
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

            CbCurso.DataSource = new CursoLogic().GetAll().Select(c => new { ID = c.ID, Descripcion = $"{c.Materia} - {c.Comision} - {c.AnioCalendario}" }).ToList();
            CbCurso.DisplayMember = "Descripcion";
            CbCurso.ValueMember = "ID";

            switch (Modo)
            {
                case ModoForm.Alta:
                    BtnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    MapearDeDatos();
                    BtnAceptar.Text = "Eliminar";
                    CbCargo.Enabled = false;
                    CbDocente.Enabled = false;
                    CbCurso.Enabled = false;
                    break;
                case ModoForm.Modificacion:
                    MapearDeDatos();
                    BtnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void MapearDeDatos()
        {
            tbID.Text = _DocenteCursoSeleccionado.ID.ToString();
            CbCargo.SelectedItem = _DocenteCursoSeleccionado.Cargo;
            CbCurso.SelectedValue = _DocenteCursoSeleccionado.IDCurso;
            CbDocente.SelectedValue = _DocenteCursoSeleccionado.IDDocente;
        }

        public override void MapearADatos()
        {
            //_DocenteCursoSeleccionado.ID = int.Parse(tbID.Text);
            _DocenteCursoSeleccionado.Cargo = (Business.Entities.DocenteCurso.TiposCargo)CbCargo.SelectedIndex;
            _DocenteCursoSeleccionado.IDCurso = (int)CbCurso.SelectedValue;
            _DocenteCursoSeleccionado.IDDocente = (int)CbDocente.SelectedValue;
        }

    }
}
