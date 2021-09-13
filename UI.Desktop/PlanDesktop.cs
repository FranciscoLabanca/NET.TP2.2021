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
    public partial class PlanDesktop : ApplicationForm
    {
        public Plan PlanActual { set; get; }
        public PlanDesktop()
        {
            InitializeComponent();
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> especialidades = el.GetAll();
            cbIdEspecialidad.DataSource = especialidades;
            cbIdEspecialidad.DisplayMember = "Descripcion";
            cbIdEspecialidad.ValueMember = "ID";
        }

        public PlanDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PlanLogic pl = new PlanLogic();
            PlanActual = pl.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            tbId.Text = PlanActual.ID.ToString();
            tbDesc.Text = PlanActual.Descripcion;
            cbIdEspecialidad.SelectedValue = BuscarEspecialidadPorID(PlanActual.IDEspecialidad).ID;
            switch (Modo)
            {
                case ModoForm.Alta:
                    btnGuardar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    btnGuardar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    btnGuardar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    btnGuardar.Text = "Aceptar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    PlanActual = new Plan();
                    PlanActual.Descripcion = tbDesc.Text;
                    PlanActual.IDEspecialidad = ((Especialidad)cbIdEspecialidad.SelectedItem).ID;
                    PlanActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Modificacion:
                    PlanActual.Descripcion = tbDesc.Text;
                    PlanActual.IDEspecialidad = ((Especialidad)cbIdEspecialidad.SelectedItem).ID;
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;

                case ModoForm.Baja:
                    PlanActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PlanLogic pl = new PlanLogic();
            pl.Save(PlanActual);
        }

        public override bool Validar()
        {
            if(tbDesc.Text == "")
            {
                Notificar("Campos Obligatorios Vacios", "Existen uno o mas campos vacios, rellenelos antes de continuar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Especialidad BuscarEspecialidadPorID(int id_esp)
        {
            EspecialidadLogic el = new EspecialidadLogic();
            Especialidad especialidad = el.GetOne(id_esp);
            return especialidad;
        }
    }
}
