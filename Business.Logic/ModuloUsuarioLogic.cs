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
            if (ExisteModUsuario(moduloUsuario))
                throw new Exception("Ya existe un permiso cargado para ese usuario y modulo.");
            else
                ModuloUsuarioData.Save(moduloUsuario);
        }
        private bool ExisteModUsuario(ModuloUsuario moduloUsuario)
        {
            List<ModuloUsuario> modulosExistentes = this.GetAll();
            return modulosExistentes.Exists(mu => (mu.IdUsuario == moduloUsuario.IdUsuario && mu.IdModulo == moduloUsuario.IdModulo && moduloUsuario.State == BusinessEntity.States.New) || (moduloUsuario.State == BusinessEntity.States.Modified && mu.IdUsuario == moduloUsuario.IdUsuario && mu.IdModulo == moduloUsuario.IdModulo && mu.ID != moduloUsuario.ID) );
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
