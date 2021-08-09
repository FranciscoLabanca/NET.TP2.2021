﻿using System;
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
    public partial class PersonaDesktop : ApplicationForm
    {
        public Persona PersonaActual { set; get; }
        public PersonaDesktop()
        {
            InitializeComponent();
        }

        public PersonaDesktop (ModoForm modo) : this()
        {
            Modo = modo;
        }

        public PersonaDesktop (int id, ModoForm modo) :this()
        {
            Modo = modo;
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = pl.GetOne(id);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            tbID.Text = PersonaActual.ID.ToString();
            tbNombre.Text = PersonaActual.Nombre;
            tbApellido.Text = PersonaActual.Apellido;
            tbDireccion.Text = PersonaActual.Direccion;
            tbEmail.Text = PersonaActual.Email;
            tbTelefono.Text = PersonaActual.Telefono;
            dtFechaNac.Value = PersonaActual.FechaNacimiento;
            tbLegajo.Text = PersonaActual.Legajo.ToString();
            //cbTipoPersona. no se como aplicar esto
            tbIdPlan.Text = PersonaActual.IDPlan.ToString();

            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    PersonaActual = new Persona();
                    PersonaActual.Nombre = tbNombre.Text;
                    PersonaActual.Legajo = int.Parse(tbLegajo.Text);
                    PersonaActual.Apellido = tbApellido.Text;
                    PersonaActual.Direccion = tbDireccion.Text;
                    PersonaActual.Telefono = tbTelefono.Text;
                    PersonaActual.Email = tbDireccion.Text;
                    PersonaActual.IDPlan = int.Parse(tbIdPlan.Text);
                    PersonaActual.FechaNacimiento = dtFechaNac.Value;
                    //Falta tipo de persona
                    PersonaActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Modificacion:
                    PersonaActual.Nombre = tbNombre.Text;
                    PersonaActual.Legajo = int.Parse(tbLegajo.Text);
                    PersonaActual.Apellido = tbApellido.Text;
                    PersonaActual.Direccion = tbDireccion.Text;
                    PersonaActual.Telefono = tbTelefono.Text;
                    PersonaActual.Email = tbDireccion.Text;
                    PersonaActual.IDPlan = int.Parse(tbIdPlan.Text);
                    PersonaActual.FechaNacimiento = dtFechaNac.Value;
                    //falta tipo persona
                    PersonaActual.State = BusinessEntity.States.Modified;
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    PersonaActual.State = BusinessEntity.States.Modified;
                    btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PersonaLogic pl = new PersonaLogic();
            pl.Save(PersonaActual);
        }

        public override bool Validar()
        {
            if (tbNombre.Text == "" || tbApellido.Text == "" || tbLegajo.Text == "" || tbDireccion.Text == "" || tbTelefono.Text == "" || tbEmail.Text == "")
                return false;
            else
                return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
            else
                Notificar("Verifique que todos los campos esten completos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}