using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        public List<Usuario> GetAll()
        {

            List<Usuario> usuarios = new List<Usuario>();
            SqlDataReader drUsuarios = null;

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios", sqlConn);

                drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];

                    usuarios.Add(usr);
                }

                drUsuarios.Close();

                this.CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally 
            {
                drUsuarios?.Dispose();
            }
            
            return usuarios;
        }

        public Usuario GetOne(string nombreUsuario)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE nombre_usuario = @nombreUsuario", sqlConn);
                cmdUsuarios.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = nombreUsuario;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                }
                else
                {
                    usr = null;
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public bool ValidarUsuario(string nombreUsuario, string clave)
        {
            string lookupPassword = null;

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("select clave from usuarios where nombre_usuario = @nombre_usuario", sqlConn);
                cmd.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = nombreUsuario;
                lookupPassword = (string)cmd.ExecuteScalar();
                cmd.Dispose();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            if(lookupPassword == null)
            {
                return false;
            }

            return (string.Compare(lookupPassword, clave, false) == 0);
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario=@id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();                

                if (drUsuarios.Read())
                {            
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                }
                drUsuarios.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;

        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave=@clave, habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email, id_persona=@id_persona WHERE id_usuario=@id", sqlConn);

                cmdSave.Parameters.Add("@id",SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value=usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave",SqlDbType.VarChar,50).Value=usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre",SqlDbType.VarChar,50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido",SqlDbType.VarChar,50).Value=usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar,50).Value = usuario.EMail;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
                cmdSave.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar los datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email,id_persona) values(@nombre_usuario, @clave, @habilitado,@nombre,@apellido,@email,@id_persona) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());            
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar los datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Usuario usuario)
        {

            if (usuario.State == BusinessEntity.States.Deleted)
                this.Delete(usuario.ID);
            else if (usuario.State == BusinessEntity.States.New)
                this.Insert(usuario);
            else if (usuario.State == BusinessEntity.States.Modified)
                this.Update(usuario);
            usuario.State = BusinessEntity.States.Unmodified;
        }
    }
}
