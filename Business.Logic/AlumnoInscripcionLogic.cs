using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : ILogic<AlumnoInscripcion>
    {
        private readonly AlumnoInscripcionAdapter _AdapterAlumnoInscripcion = new AlumnoInscripcionAdapter();
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return _AdapterAlumnoInscripcion.GetAll();
        }

        public AlumnoInscripcion GetOne(int id)
        {
            return _AdapterAlumnoInscripcion.GetOne(id);
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            _AdapterAlumnoInscripcion.Save(inscripcion);
        }
    }
}
