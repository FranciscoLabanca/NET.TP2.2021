using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Models.RegistroNotas
{
    class InscripcionResponse
    {
        public int AlumnoID { get; set; }
        public int InscripcionID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Legajo { get; set; }
        public string Condicion { get; set; }
        public int Nota { get; set; }
    }
}