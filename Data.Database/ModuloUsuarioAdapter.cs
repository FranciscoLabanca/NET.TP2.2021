using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> moduloUsuarios = new List<ModuloUsuario>();

            try
            {
                OpenConnection();

                SqlCommand sqlCommand = new SqlCommand("select * from modulos_usuarios mu " 
                                                    + "inner join modulos m on mu.id_modulo = m.id_modulo " 
                                                    + "inner join usuarios u on mu.id_usuario = u.id_usuario", sqlConn);

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    ModuloUsuario mu = new ModuloUsuario();

                    mu.ID = (int)dataReader["id_modulo_usuario"];
                    mu.IdModulo = (int)dataReader["id_modulo"];
                    mu.IdUsuario = (int)dataReader["id_usuario"];
                    mu.PermiteAlta = (bool)dataReader["alta"];
                    mu.PermiteBaja = (bool)dataReader["baja"];
                    mu.PermiteConsulta = (bool)dataReader["consulta"];
                    mu.PermiteModificacion = (bool)dataReader["modificacion"];
                    mu.User = new Usuario();
                    mu.User.NombreUsuario = (string)dataReader["nombre_usuario"];

                    mu.Modulo = new Modulo();
                    mu.Modulo.Descripcion = (string)dataReader["desc_modulo"];

                    moduloUsuarios.Add(mu);
                }
                dataReader.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los modulos de los usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return moduloUsuarios;
        }

        public ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario mu = new ModuloUsuario();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("select * from modulos_usuarios where id_modulo_usuario = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    mu.ID = (int)reader["id_modulo_usuario"];
                    mu.IdModulo = (int)reader["id_modulo"];
                    mu.IdUsuario = (int)reader["id_usuario"];
                    mu.PermiteAlta = (bool)reader["alta"];
                    mu.PermiteBaja = (bool)reader["baja"];
                    mu.PermiteConsulta = (bool)reader["consulta"];
                    mu.PermiteModificacion = (bool)reader["modificacion"];
                }
                reader.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el modulo del usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return mu;
        }

        protected void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("delete from modulos_usuarios where id_modulo_usuario = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el modulo del usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(ModuloUsuario moduloUsuario)
        {
            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand("update modulos_usuarios set id_modulo = @id_modulo, id_usuario = @id_usuario, alta = @alta, " + 
                                                "baja = @baja, modificacion = @modificacion, consulta = @consulta where id_modulo_usuario = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = moduloUsuario.ID;
                cmd.Parameters.Add("@id_modulo", SqlDbType.Int).Value = moduloUsuario.IdModulo;
                cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = moduloUsuario.IdUsuario;
                cmd.Parameters.Add("alta", SqlDbType.Bit).Value = moduloUsuario.PermiteAlta;
                cmd.Parameters.Add("@baja", SqlDbType.Bit).Value = moduloUsuario.PermiteBaja;
                cmd.Parameters.Add("@consulta", SqlDbType.Bit).Value = moduloUsuario.PermiteConsulta;
                cmd.Parameters.Add("@modificacion", SqlDbType.Bit).Value = moduloUsuario.PermiteModificacion;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar el modulo del usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert (ModuloUsuario moduloUsuario)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("insert into modulos_usuarios " + 
                                                "(id_usuario, id_modulo, alta, baja, consulta, modificacion) " + 
                                                "values (@id_usuario, @id_modulo, @alta, @baja, @consulta, @modificacion) select @@identity", sqlConn);
                cmd.Parameters.Add("@id_modulo", SqlDbType.Int).Value = moduloUsuario.IdModulo;
                cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = moduloUsuario.IdUsuario;
                cmd.Parameters.Add("alta", SqlDbType.Bit).Value = moduloUsuario.PermiteAlta;
                cmd.Parameters.Add("@baja", SqlDbType.Bit).Value = moduloUsuario.PermiteBaja;
                cmd.Parameters.Add("@consulta", SqlDbType.Bit).Value = moduloUsuario.PermiteConsulta;
                cmd.Parameters.Add("@modificacion", SqlDbType.Bit).Value = moduloUsuario.PermiteModificacion;
                moduloUsuario.ID = Decimal.ToInt32((decimal)cmd.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el modulo del usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(ModuloUsuario moduloUsuario)
        {
            if (moduloUsuario.State == BusinessEntity.States.Deleted)
                this.Delete(moduloUsuario.ID);
            else if (moduloUsuario.State == BusinessEntity.States.New)
                this.Insert(moduloUsuario);
            else if (moduloUsuario.State == BusinessEntity.States.Modified)
                this.Update(moduloUsuario);
            moduloUsuario.State = BusinessEntity.States.Unmodified;
        }
    }
}
