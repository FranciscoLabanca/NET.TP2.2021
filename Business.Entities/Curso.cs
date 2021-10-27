using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
    	private int _AnioCalendario;
        public int AnioCalendario 
        {
        	get
        	{
        		return _AnioCalendario;
        	} 
        	set
        	{
        		_AnioCalendario = value;
        	}
        }
        
        private int _Cupo;
        public int Cupo 
        {
        	get
        	{
        		return _Cupo;
        	} 
        	set
        	{
        		_Cupo = value;
        	}
        }

        private int _IDComision;
        public int IDComision 
        {
        	get
        	{
        		return _IDComision;
        	} 
        	set
        	{
        		_IDComision = value;
        	}
        }

        private int _IDMateria;
        public int IDMateria 
        {
        	get
        	{
        		return _IDMateria;
        	} 
        	set
        	{
        		_IDMateria = value;
        	}
        }

        private string _Comision;

        public string Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }

        private string _Materia;

        public string Materia
        {
            get { return _Materia; }
            set { _Materia = value; }
        }


    }
}
