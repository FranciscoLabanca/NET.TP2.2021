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
        public Menu()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

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

        private void comisionesNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones c = new Comisiones();
            c.ShowDialog();
        }

        private void planesNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes p = new Planes();
            p.ShowDialog();
        }

        private void permisosPorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModulosUsuarios mu = new ModulosUsuarios();
            mu.ShowDialog();

        }
    }
}
