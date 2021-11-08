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
            try
            {
                Validar(docenteCurso);
                _DocenteCursoData.Save(docenteCurso);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        private void Validar(DocenteCurso docenteCurso)
        {
            List<DocenteCurso> docentesCursos = this.GetAll();
            if (docenteCurso.State == BusinessEntity.States.New)
            {
                
                List<DocenteCurso> docenteCursosRepetidos = docentesCursos.Where(dc => dc.IDCurso == docenteCurso.IDCurso && dc.IDDocente == docenteCurso.IDDocente && dc.Cargo == docenteCurso.Cargo).ToList();
                if (docenteCursosRepetidos.Count != 0)
                    throw new Exception("El docente ya se encuentra asignado al curso seleccionado");
            }

            if (docenteCurso.State == BusinessEntity.States.Modified)
            {
                List<DocenteCurso> docenteCargo = docentesCursos.Where(dc => dc.IDCurso == docenteCurso.IDCurso && dc.Cargo == docenteCurso.Cargo).ToList();
                if (docenteCargo.Count != 0)
                    throw new Exception("Ya hay un docente asignado en ese cargo");
            }
        }
    }
}
