using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
    	private TiposCargo _Cargo;
        public TiposCargo Cargo 
        {
        	get
        	{
        		return _Cargo;
        	} 
        	set
        	{
        		_Cargo = value;
        	}
        }

        private int _IDCurso;
        public int IDCurso 
        {
        	get
        	{
        		return _IDCurso;
        	} 
        	set
        	{
        		_IDCurso = value;
        	}
        }

        public string Curso { get; set; }

        private int _IDDocente;
        public int IDDocente 
        {
        	get
        	{
        		return _IDDocente;
        	} 
        	set
        	{
        		_IDDocente = value;
        	}
        }

        public string NombreApellidoDocente { get; set; }

        public enum TiposCargo
        {
            Teoria,
            Practica,
            Auxiliar
        }
    }
}
