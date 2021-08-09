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
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
        }

        public enum ModoForm { Alta, Baja, Modificacion, Consulta}
        public ModoForm Modo { set; get; }

        public virtual void MapearDeDatos() { }
        public virtual void MapearADatos() { }
        public virtual void GuardarCambios() { }
        public virtual bool Validar() { return false; }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon iconos)
        {
            MessageBox.Show(mensaje, titulo, botones, iconos);
        }

        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon iconos)
        {
            Notificar(Text, mensaje, botones, iconos);
        }
    }
}
