using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic, ILogic<Curso>
    {
        private readonly CursoAdapter _CursoData;
        public CursoLogic()
        {
            _CursoData = new CursoAdapter();
        }
        public List<Curso> GetAll()
        {
            List<Curso> cursos = _CursoData.GetAll();
            return cursos;
        }
        public Curso GetOne(int id)
        {
            Curso curso = _CursoData.GetOne(id);
            return curso;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public void Delete(Curso curso)
        {
            curso.State = BusinessEntity.States.Deleted;
            _CursoData.Save(curso);
        }
        public void Save(Curso curso)
        {
            _CursoData.Save(curso);
        }



    }
}
