﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("select * from planes", sqlConn);
                SqlDataReader drPlan = cmdPlan.ExecuteReader();

                while (drPlan.Read())
                {
                    Plan plan = new Plan();

                    plan.ID = (int)drPlan["id_plan"];
                    plan.IDEspecialidad = (int)drPlan["id_especialidad"];
                    plan.Descripcion = (string)drPlan["desc_plan"];

                    planes.Add(plan);
                }
                drPlan.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return planes;
        }

        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();

            try
            {
                OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("select * from planes where id_plan = @id", sqlConn);
                cmdPlan.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drPlan = cmdPlan.ExecuteReader();

                while (drPlan.Read())
                {
                    plan.ID = (int)drPlan["id_plan"];
                    plan.Descripcion = (string)drPlan["desc_plan"];
                    plan.IDEspecialidad = (int)drPlan["id_especialidad"];
                }
                drPlan.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return plan;
        }

        public void Delete (int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("delete from planes where id_plan = @id", sqlConn);
                cmdPlan.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdPlan.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Plan plan)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("update planes set desc_plan = @desc, id_especialidad = @id_esp where id_plan = @id", sqlConn);
                cmdPlan.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdPlan.Parameters.Add("@desc", SqlDbType.VarChar).Value = plan.Descripcion;
                cmdPlan.Parameters.Add("@id_esp", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdPlan.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("insert into planes (desc_plan, id_especialidad) values (@desc, @id_esp) select @@identity", sqlConn);
                cmdPlan.Parameters.Add("@id_esp", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdPlan.Parameters.Add("@desc", SqlDbType.VarChar).Value = plan.Descripcion;
                plan.ID = Decimal.ToInt32((decimal)cmdPlan.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
                this.Delete(plan.ID);
            else if (plan.State == BusinessEntity.States.New)
                this.Insert(plan);
            else if (plan.State == BusinessEntity.States.Modified)
                this.Update(plan);
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
