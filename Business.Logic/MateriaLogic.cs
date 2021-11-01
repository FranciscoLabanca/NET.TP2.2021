using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic, ILogic<Materia>
    {
        public MateriaAdapter MateriaData { set; get; }

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public List<Materia> GetByIdPlan(int id)
        {
            return MateriaData.GetByIdPlan(id);
        }

        public Materia GetOne(int id)
        {
            return MateriaData.GetOne(id);
        }

        public void Delete(int id)
        {
            MateriaData.Delete(id);
        }

        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }
    }
}
