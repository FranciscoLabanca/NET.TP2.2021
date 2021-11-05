using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ModuloUsuarioLogic : BusinessLogic, ILogic<ModuloUsuario>
    {
        public ModuloUsuarioAdapter ModuloUsuarioData { get; set; }

        public ModuloUsuarioLogic()
        {
            ModuloUsuarioData = new ModuloUsuarioAdapter();
        }

        public ModuloUsuarioLogic(ModuloUsuarioAdapter moduloUsuarioAdapter)
        {
            ModuloUsuarioData = moduloUsuarioAdapter;
        }

        public List<ModuloUsuario> GetAll()
        {
            return ModuloUsuarioData.GetAll();
        }

        public ModuloUsuario GetOne(int ID)
        {
            return ModuloUsuarioData.GetOne(ID);
        }

        public List<ModuloUsuario> GetByUserID(int idUsuario)
        {
            return ModuloUsuarioData.GetByUserID(idUsuario);
        }

        public void Save(ModuloUsuario moduloUsuario)
        {
            ModuloUsuarioData.Save(moduloUsuario);
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
