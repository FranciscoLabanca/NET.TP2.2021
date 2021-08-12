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
    public class EspecialidadAdapter : Adapter
    {
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                OpenConnection();

                SqlCommand cmdEspecialidad = new SqlCommand("select * from especialidades", sqlConn);

                SqlDataReader drEspecialidad = cmdEspecialidad.ExecuteReader();

                while (drEspecialidad.Read())
                {
                    Especialidad esp = new Especialidad();

                    esp.ID = (int)drEspecialidad["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidad["desc_especialidad"];

                    especialidades.Add(esp);
                }
                drEspecialidad.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return especialidades;
        }

        public Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();

            try
            {
                OpenConnection();

                SqlCommand cmdEsp = new SqlCommand("select * from especialidades where id_especialidad = @id", sqlConn);
                cmdEsp.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drEsp = cmdEsp.ExecuteReader();
                while (drEsp.Read())
                {
                    esp.ID = (int)drEsp["id_especialidad"];
                    esp.Descripcion = (string)drEsp["desc_especialidad"];
                }
                drEsp.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return esp;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdEsp = new SqlCommand("delete from especialidades where id_especialidad = @id", sqlConn);
                cmdEsp.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdEsp.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Especialidad esp)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdEsp = new SqlCommand("update especialidades set desc_especialidad = @desc where id_especialidad = @id", sqlConn);
                cmdEsp.Parameters.Add("@id", SqlDbType.Int).Value = esp.ID;
                cmdEsp.Parameters.Add("@desc", SqlDbType.VarChar).Value = esp.Descripcion;
                cmdEsp.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Insert(Especialidad esp)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdEsp = new SqlCommand("insert into especialidades (desc_especialidad) values(@desc) select @@identity", sqlConn);
                cmdEsp.Parameters.Add("@desc", SqlDbType.VarChar).Value = esp.Descripcion;
                esp.ID = Decimal.ToInt32((decimal)cmdEsp.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Especialidad esp)
        {
            if (esp.State == BusinessEntity.States.Deleted)
                this.Delete(esp.ID);
            else if (esp.State == BusinessEntity.States.New)
                this.Insert(esp);
            else if (esp.State == BusinessEntity.States.Modified)
                this.Update(esp);
            esp.State = BusinessEntity.States.Unmodified;
        }
    }
}
