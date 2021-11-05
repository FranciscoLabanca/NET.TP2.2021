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
    public partial class Menu : Form
    {
        private readonly IEnumerable<ModuloUsuario> _ModulosConAcceso;
        public Menu()
        {
            InitializeComponent();

        }

        public Menu(int idUsuario) : this()
        {
            ModuloUsuarioLogic muLogic = new ModuloUsuarioLogic();
            ModuloLogic modLogic = new ModuloLogic();
            _ModulosConAcceso = (from modusuario in muLogic.GetByUserID(idUsuario)
                                 join modulo in modLogic.GetAll() on modusuario.IdModulo equals modulo.ID
                                 select new ModuloUsuario { ID = modusuario.ID, 
                                                            IdUsuario = modusuario.IdUsuario,
                                                            PermiteAlta = modusuario.PermiteAlta,
                                                            PermiteBaja = modusuario.PermiteBaja,
                                                            PermiteConsulta = modusuario.PermiteConsulta,
                                                            PermiteModificacion = modusuario.PermiteModificacion,
                                                            Modulo = modulo});
            SetearAccesoAModulos();
        }

        private void accesoAModulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modulo mod = new Modulo();
            mod.ShowDialog();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas per = new Personas();
            per.ShowDialog();
        }

        private void usuariosNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios us = new Usuarios();
            us.ShowDialog();
        }

        private void especialidadesNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades esp = new Especialidades();
            esp.ShowDialog();
        }

        private void accesoAPlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes p = new Planes();
            p.ShowDialog();
        }

        private void materiasNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Materias().ShowDialog();
        }

        private void comisionesNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones c = new Comisiones();
            c.ShowDialog();
        }

        private void permisosPorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModulosUsuarios mu = new ModulosUsuarios();
            mu.ShowDialog();
        }

        private void planesNIToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Planes p = new Planes();
            p.ShowDialog();
        }

        private void asignarDocentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocenteCurso dc = new DocenteCurso();
            dc.ShowDialog();
        }

        private void administrarCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos c = new Cursos();
            c.ShowDialog();
        }

        private void SetearAccesoAModulos()
        {
            foreach (var modulo in _ModulosConAcceso)
            {              
                switch (modulo.Modulo.Ejecuta)
                {
                    case Business.Entities.Modulo.ListaModulos.Personas:
                        personasToolStripMenuItem.Enabled = true;
                        break;
                    case Business.Entities.Modulo.ListaModulos.Permisos:
                        permisosToolStripMenuItem.Enabled = true;
                        break;
                    case Business.Entities.Modulo.ListaModulos.Usuarios:
                        usuariosNIToolStripMenuItem.Enabled = true;
                        break;
                    case Business.Entities.Modulo.ListaModulos.Comisiones:
                        comisionesToolStripMenuItem.Enabled = true;
                        break;
                    case Business.Entities.Modulo.ListaModulos.Cursos:
                        CursostoolStripMenuItem.Enabled = true;
                        break;
                    case Business.Entities.Modulo.ListaModulos.Planes:
                        planesToolStripMenuItem.Enabled = true;
                        break;
                    case Business.Entities.Modulo.ListaModulos.Materias:
                        materiasToolStripMenuItem.Enabled = true;
                        break;
                    case Business.Entities.Modulo.ListaModulos.Especialidades:
                        especialidadesToolStripMenuItem.Enabled = true;
                        break;
                }
            }
        }

    }
}
