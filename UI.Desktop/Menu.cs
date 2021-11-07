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
        private readonly int _IdUsuarioActual;
        private IEnumerable<ModuloUsuario> _ModulosConAcceso;
        public Menu()
        {
            InitializeComponent();
        }

        public Menu(int idUsuario) : this()
        {
            _IdUsuarioActual = idUsuario;
            SetearAccesoAModulos(_IdUsuarioActual);
        }

        private void accesoAModulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modulo mod = new Modulo(_ModulosConAcceso.First(m => m.Modulo.Ejecuta == Modulo.NombreModulo));
            mod.ShowDialog();
            SetearAccesoAModulos(_IdUsuarioActual);
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas per = new Personas(_ModulosConAcceso.First(m => m.Modulo.Ejecuta == Personas.NombreModulo));
            per.ShowDialog();
        }

        private void usuariosNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios us = new Usuarios(_ModulosConAcceso.First(m => m.Modulo.Ejecuta == Usuarios.NombreModulo));
            us.ShowDialog();
        }

        private void especialidadesNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades esp = new Especialidades(_ModulosConAcceso.First(m => m.Modulo.Ejecuta == Especialidades.NombreModulo));
            esp.ShowDialog();
        }

        private void materiasNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Materias(_ModulosConAcceso.First(m => m.Modulo.Ejecuta == Materias.NombreModulo)).ShowDialog();
        }

        private void comisionesNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones c = new Comisiones(_ModulosConAcceso.First(m => m.Modulo.Ejecuta == Comisiones.NombreModulo));
            c.ShowDialog();
        }

        private void permisosPorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModulosUsuarios mu = new ModulosUsuarios(_ModulosConAcceso.First(m => m.Modulo.Ejecuta == ModulosUsuarios.NombreModulo));
            mu.ShowDialog();
            SetearAccesoAModulos(_IdUsuarioActual);
        }

        private void planesNIToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Planes p = new Planes(_ModulosConAcceso.First(m => m.Modulo.Ejecuta == Planes.NombreModulo));
            p.ShowDialog();
        }

        private void asignarDocentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocenteCurso dc = new DocenteCurso(_ModulosConAcceso.First(m => m.Modulo.Ejecuta == DocenteCurso.NombreModulo));
            dc.ShowDialog();
        }

        private void administrarCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos c = new Cursos(_ModulosConAcceso.First(m => m.Modulo.Ejecuta == Cursos.NombreModulo));
            c.ShowDialog();
        }
        private void SetearAccesoAModulos(int idUsuario)
        {
            ModuloUsuarioLogic muLogic = new ModuloUsuarioLogic();
            ModuloLogic modLogic = new ModuloLogic();
            _ModulosConAcceso = (from modusuario in muLogic.GetByUserID(idUsuario)
                                 join modulo in modLogic.GetAll() on modusuario.IdModulo equals modulo.ID
                                 select new ModuloUsuario
                                 {
                                     ID = modusuario.ID,
                                     IdUsuario = modusuario.IdUsuario,
                                     PermiteAlta = modusuario.PermiteAlta,
                                     PermiteBaja = modusuario.PermiteBaja,
                                     PermiteConsulta = modusuario.PermiteConsulta,
                                     PermiteModificacion = modusuario.PermiteModificacion,
                                     Modulo = modulo
                                 });
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
