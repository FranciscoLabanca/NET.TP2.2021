using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic, ILogic<Modulo>
    {
        public ModuloAdapter ModuloData { set; get; }

        public ModuloLogic()
        {
            ModuloData = new ModuloAdapter();
        }

        public ModuloLogic(ModuloAdapter moduloData)
        {
            ModuloData = moduloData;
        }

        public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();
        }

        public Modulo GetOne(int id)
        {
            return ModuloData.GetOne(id);
        }

        public void Delete(int id)
        {
            ModuloData.Delete(id);
        }

        public void Save(Modulo modulo)
        {            
            if (ModuloExiste(modulo))
                throw new Exception("Ya existe una entrada que ejecuta el modulo seleccionado.");
            else
                ModuloData.Save(modulo);
        }

        private bool ModuloExiste(Modulo modulo)
        {
            List<Modulo> modulosExistentes = this.GetAll();
            return modulosExistentes.Exists(m => m.Ejecuta == modulo.Ejecuta);
        }
    }
}
