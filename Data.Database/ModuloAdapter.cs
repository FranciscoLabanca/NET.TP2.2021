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
    public class ModuloAdapter : Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                OpenConnection();

                SqlCommand cmdModulos = new SqlCommand("select * from modulos", sqlConn);
                SqlDataReader drModulos = cmdModulos.ExecuteReader();

                while (drModulos.Read())
                {
                    Modulo mod = new Modulo();

                    mod.ID = (int)drModulos["id_modulo"];
                    mod.Descripcion = (string)drModulos["desc_modulo"];

                    modulos.Add(mod);
                }
                drModulos.Close();
                CloseConnection();
                

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de modulos", Ex);
                throw ExcepcionManejada;
            }
            return modulos;
        }

        public Modulo GetOne(int ID)
        {
            Modulo mod = new Modulo();

            try
            {
                OpenConnection();
                SqlCommand cmdModulos = new SqlCommand("select * from modulos where id_modulo = @id", sqlConn);
                cmdModulos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulos = cmdModulos.ExecuteReader();

                if (drModulos.Read())
                {
                    mod.ID = (int)drModulos["id_modulo"];
                    mod.Descripcion = (string)drModulos["desc_modulo"];
                }
                drModulos.Close();
                
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return mod;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete modulos where id_modulo = @id", sqlConn);
                cmdDelete.Parameters.Add("id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Modulo modulo)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdSave = new SqlCommand("update modulos set desc_modulo = @desc_modulo where id_modulo = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = modulo.ID;
                cmdSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al acutalizar modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            
        }

        protected void Insert(Modulo modulo)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into modulos(desc_modulo) values(@desc_modulo) select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = modulo.ID;
                cmdSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar).Value = modulo.Descripcion;
                modulo.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al acutalizar modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Modulo modulo)
        {
            if (modulo.State == BusinessEntity.States.Deleted)
                this.Delete(modulo.ID);
            else if (modulo.State == BusinessEntity.States.New)
                this.Insert(modulo);
            else if (modulo.State == BusinessEntity.States.Modified)
                this.Update(modulo);
            modulo.State = BusinessEntity.States.Unmodified;
        }
    }
}
