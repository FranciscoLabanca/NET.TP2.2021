using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic, ILogic<Usuario>
    {
        public UsuarioAdapter UsuarioData { set; get; }

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public Usuario GetOne(int id)
        {
            return UsuarioData.GetOne(id);
        }

        public Usuario GetOne(string nombreUsuario)
        {
            return UsuarioData.GetOne(nombreUsuario);
        }

        public bool ValidarUsuario(string nombreUsuario, string clave)
        {
            return UsuarioData.ValidarUsuario(nombreUsuario, clave);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }
    }
}
