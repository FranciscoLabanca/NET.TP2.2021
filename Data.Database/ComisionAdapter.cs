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
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                OpenConnection();
                SqlCommand cmdComision = new SqlCommand("select * from comisiones c inner join planes p on c.id_plan = p.id_plan", sqlConn);
                SqlDataReader drComision = cmdComision.ExecuteReader();

                while (drComision.Read())
                {
                    Comision com = new Comision();

                    com.ID = (int)drComision["id_comision"];
                    com.Descripcion = (string)drComision["desc_comision"];
                    com.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    com.IDPlan = (int)drComision["id_plan"];
                    com.Plan = new Plan();
                    com.Plan.Descripcion = (string)drComision["desc_plan"];

                    comisiones.Add(com);
                }

                drComision.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return comisiones;
        }

        public List<Comision> GetByIdPlan(int id)
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                OpenConnection();
                SqlCommand cmdComision = new SqlCommand("select * from comisiones c inner join planes p on c.id_plan = p.id_plan where c.id_plan = @id", sqlConn);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drComision = cmdComision.ExecuteReader();

                while (drComision.Read())
                {
                    Comision com = new Comision();

                    com.ID = (int)drComision["id_comision"];
                    com.Descripcion = (string)drComision["desc_comision"];
                    com.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    com.IDPlan = (int)drComision["id_plan"];
                    com.Plan = new Plan();
                    com.Plan.Descripcion = (string)drComision["desc_plan"];

                    comisiones.Add(com);
                }

                drComision.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision com = new Comision();

            try
            {
                OpenConnection();
                SqlCommand cmdComision = new SqlCommand("select * from comisiones where id_comision = @id", sqlConn);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drComision = cmdComision.ExecuteReader();

                while (drComision.Read())
                {
                    com.ID = (int)drComision["id_comision"];
                    com.Descripcion = (string)drComision["desc_comision"];
                    com.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    com.IDPlan = (int)drComision["id_plan"];
                }

                drComision.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return com;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdComision = new SqlCommand("delete from comisiones where id_comision = @id", sqlConn);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdComision.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Comision com)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdComision = new SqlCommand("update comisiones set " + 
                                                        "desc_comision = @desc, id_plan = @id_plan, anio_especialidad = @anio_especialidad where id_comision = @id", 
                                                        sqlConn);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = com.ID;
                cmdComision.Parameters.Add("@id_plan", SqlDbType.Int).Value = com.IDPlan;
                cmdComision.Parameters.Add("@desc", SqlDbType.VarChar).Value = com.Descripcion;
                cmdComision.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdComision.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert (Comision com)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdComision = new SqlCommand("insert into comisiones " +
                                                        "(desc_comision, id_plan, anio_especialidad) " + 
                                                        "values (@desc, @id_plan, @anio_esp) select @@identity", sqlConn);

                cmdComision.Parameters.Add("@desc", SqlDbType.VarChar).Value = com.Descripcion;
                cmdComision.Parameters.Add("@id_plan", SqlDbType.Int).Value = com.IDPlan;
                cmdComision.Parameters.Add("@anio_esp", SqlDbType.Int).Value = com.AnioEspecialidad;
                com.ID = Decimal.ToInt32((decimal)cmdComision.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Comision com)
        {
            if (com.State == BusinessEntity.States.Deleted)
                this.Delete(com.ID);
            else if (com.State == BusinessEntity.States.New)
                this.Insert(com);
            else if (com.State == BusinessEntity.States.Modified)
                this.Update(com);
            com.State = BusinessEntity.States.Unmodified;
        }
    }
}
