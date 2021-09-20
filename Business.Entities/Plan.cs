using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        private string _Descripcion;
        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                _Descripcion = value;
            }
        }
        private int _IDEspecialidad;
        public int IDEspecialidad
        {
            get
            {
                return _IDEspecialidad;
            }
            set
            {
                _IDEspecialidad = value;
            }
        }

        public Especialidad Esp { get; set; }

        public string DescripcionEspecialidad 
        { 
            get
            {
                if(Esp == null)
                {
                    return string.Empty;
                }
                else
                {
                    return Esp.Descripcion;
                }
            }
        }
    }
}
