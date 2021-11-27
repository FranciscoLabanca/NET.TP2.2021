﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
    	private string _NombreUsuario;
        public string NombreUsuario 
        {
        	get
        	{
        		return _NombreUsuario;
        	} 
        	set
        	{
        		_NombreUsuario = value;
        	}
        }
        private string _Clave;
        public string Clave 
        {
        	get
        	{
        		return _Clave;
        	} 
        	set
        	{
        		_Clave = value;
        	}
        }
        private string _Nombre;
        public string Nombre 
        {
        	get
        	{
        		return _Nombre;
        	} 
        	set
        	{
        		_Nombre = value;
        	}
        }
        private string _Apellido;
        public string Apellido 
        {
        	get
        	{
        		return _Apellido;
        	} 
        	set
        	{
        		_Apellido = value;
        	}
        }
        private string _EMail;
        public string EMail 
        {
        	get
        	{
        		return _EMail;
        	} 
        	set
        	{
        		_EMail = value;
        	}
        }
        private bool _Habilitado;
        public bool Habilitado 
        {
        	get
        	{
        		return _Habilitado;
        	} 
        	set
        	{
        		_Habilitado = value;
        	}
        }

        private string _NombreApellido;

        public string NombreApellido
        {
            get
            {
                return _Nombre + " " + _Apellido;
            }
        }

        public int IDPersona { set; get; }
    }
}
