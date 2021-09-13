using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
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

        public Comision GetOne(int ID)
        {
            return ComisionData.GetOne(ID);
        }

        public void Save(Comision com)
        {
            ComisionData.Save(com);
        }
    }
}
