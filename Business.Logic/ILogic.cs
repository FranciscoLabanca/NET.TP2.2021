using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public interface ILogic<Entity>
    {
        List<Entity> GetAll();
        Entity GetOne(int id);
        void Delete(int id);
        void Save(Entity entity);
    }
}
