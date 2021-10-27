using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class CursosDesktop : ApplicationForm
    {
        private Curso _CursoSeleccionado;
        public CursosDesktop()
        {
            InitializeComponent();
            CbMateria.DisplayMember = "Descripcion";
            CbMateria.ValueMember = "ID";
            CbComision.DisplayMember = "Descripcion";
            CbComision.ValueMember = "ID";
        }
        public CursosDesktop(Curso cursoSeleccionado, ModoForm modo) : this()
        {
            _CursoSeleccionado = cursoSeleccionado;
            Modo = modo;
        }
        public CursosDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        private void CursosDesktop_Load(object sender, EventArgs e)
        {
            CbMateria.DataSource = new MateriaLogic().GetAll();
            CbComision.DataSource = new ComisionLogic().GetAll();
            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    MapearDeDatos();
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    tbAnioCalendario.ReadOnly = true;
                    TbCupo.ReadOnly = true;
                    CbComision.Enabled = false;
                    CbMateria.Enabled = false;
                    MapearDeDatos();
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Guardar";
                    break;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    _CursoSeleccionado = new Curso();
                    MapearADatos();
                    _CursoSeleccionado.State = BusinessEntity.States.New;
                    new CursoLogic().Save(_CursoSeleccionado);
                    break;
                case ModoForm.Modificacion:
                    MapearADatos();
                    _CursoSeleccionado.State = BusinessEntity.States.Modified;
                    new CursoLogic().Save(_CursoSeleccionado);
                    break;
                case ModoForm.Baja:
                    _CursoSeleccionado.State = BusinessEntity.States.Deleted;
                    new CursoLogic().Save(_CursoSeleccionado);
                    break;
            }
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public override void MapearDeDatos()
        {
            tbID.Text = _CursoSeleccionado.ID.ToString();
            tbAnioCalendario.Text = _CursoSeleccionado.AnioCalendario.ToString();
            TbCupo.Text = _CursoSeleccionado.Cupo.ToString();
            CbMateria.SelectedValue = _CursoSeleccionado.IDMateria;
            CbComision.SelectedValue = _CursoSeleccionado.IDComision;
        }
        public override void MapearADatos()
        {
            _CursoSeleccionado.IDComision = (int)CbComision.SelectedValue;
            _CursoSeleccionado.IDMateria = (int)CbMateria.SelectedValue;
            _CursoSeleccionado.AnioCalendario = int.Parse(tbAnioCalendario.Text);
            _CursoSeleccionado.Cupo = int.Parse(TbCupo.Text);
        }
    }
}
