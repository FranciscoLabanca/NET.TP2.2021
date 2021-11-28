using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Modulo : BusinessEntity
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

        private ListaModulos _Ejecuta;
        public ListaModulos Ejecuta
        {
            get { return _Ejecuta; }
            set { _Ejecuta = value; }
        }

        public enum ListaModulos
        {
            Personas,
            Permisos,
            Usuarios,
            Comisiones,
            Cursos,
            Planes,
            Materias,
            Especialidades,
            RegistroNotas
        }
    }
}
