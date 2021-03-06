using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic, ILogic<Comision>
    {
        public ComisionAdapter ComisionData { set; get; }

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public ComisionLogic(ComisionAdapter comisionAdapter)
        {
            ComisionData = comisionAdapter;
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }

        public List<Comision> GetByIdPlan(int id)
        {
            return ComisionData.GetByIdPlan(id);
        }

        public Comision GetOne(int ID)
        {
            return ComisionData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            ComisionData.Delete(ID);
        }

        public void Save(Comision com)
        {
            ComisionData.Save(com);
        }
    }
}
