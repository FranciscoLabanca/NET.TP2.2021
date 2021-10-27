using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public interface IEntityAdapter<Entity>
    {
        List<Entity> GetAll();
        Entity GetOne(int ID);
        void Delete(int ID);
        void Update(Entity entity);
        void Insert(Entity entity);
        void Save(Entity entity);
    }
}
