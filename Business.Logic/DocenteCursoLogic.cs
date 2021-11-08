using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic, ILogic<DocenteCurso>
    {
        readonly DocenteCursoAdapter _DocenteCursoData;

        public DocenteCursoLogic()
        {
            _DocenteCursoData = new DocenteCursoAdapter();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(DocenteCurso docenteCurso)
        {
            docenteCurso.State = BusinessEntity.States.Deleted;
            _DocenteCursoData.Save(docenteCurso);
        }

        public List<DocenteCurso> GetAll()
        {
            return _DocenteCursoData.GetAll();
        }

        public DocenteCurso GetOne(int id)
        {
            return _DocenteCursoData.GetOne(id);
        }

        public void Save(DocenteCurso docenteCurso)
        {
            if (docenteCurso.State == BusinessEntity.States.New) 
            {
                Validar(docenteCurso);
            }
            else
            {
                _DocenteCursoData.Save(docenteCurso);
            }
            
        }

        private void Validar(DocenteCurso docenteCurso)
        {
            List<DocenteCurso> docentesCursos = this.GetAll();
            List<DocenteCurso> docenteCursosRepetidos = docentesCursos.Where(dc => dc.IDCurso == docenteCurso.IDCurso && dc.IDDocente == docenteCurso.IDDocente).ToList();
            if (docenteCursosRepetidos.Count != 0)
                throw new Exception("El docente ya se encuetra asignado al curso seleccionado");
        }
    }
}
