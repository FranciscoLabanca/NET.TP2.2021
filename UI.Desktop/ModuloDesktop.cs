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
    public partial class ModuloDesktop : ApplicationForm
    {
        public Business.Entities.Modulo ModuloActual { set; get; }
        public ModuloDesktop()
        {
            InitializeComponent();
            CbModulos.DataSource = Enum.GetNames(typeof(Business.Entities.Modulo.ListaModulos));
        }

        public ModuloDesktop(ModoForm modo) : this() 
        {
            Modo = modo;
        }

        public ModuloDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ModuloLogic ml = new ModuloLogic();
            ModuloActual = ml.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            tbId.Text = ModuloActual.ID.ToString();
            tbDesc.Text = ModuloActual.Descripcion;
            CbModulos.SelectedIndex = (int)ModuloActual.Ejecuta;
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
                    ModuloActual = new Business.Entities.Modulo();
                    ModuloActual.Descripcion = tbDesc.Text;
                    ModuloActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    ModuloActual.Descripcion = tbDesc.Text;
                    ModuloActual.Ejecuta = (Business.Entities.Modulo.ListaModulos)Enum.Parse(typeof(Business.Entities.Modulo.ListaModulos),(string)CbModulos.SelectedItem);
                    ModuloActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    ModuloActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    ModuloActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            try
            {
                ModuloLogic ml = new ModuloLogic();
                ml.Save(ModuloActual);
            }
            catch (Exception e)
            {
                Notificar("Error al guardar el modulo", $"{e.Message}\n\n{(e.InnerException == null ? "" : e.InnerException.Message)}",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            if (tbDesc.Text == null)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
