using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Business.Entities;
using System.Data;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("select * from personas per inner join planes pl on per.id_plan = pl.id_plan", sqlConn);
                SqlDataReader drPersona = cmdPersona.ExecuteReader();

                while (drPersona.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersona["id_persona"];
                    per.Nombre = (string)drPersona["nombre"];
                    per.Apellido = (string)drPersona["apellido"];
                    per.Direccion = (string)drPersona["direccion"];
                    per.Email = (string)drPersona["email"];
                    per.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    per.IDPlan = (int)drPersona["id_plan"];
                    per.Legajo = (int)drPersona["legajo"];
                    per.Telefono = (string)drPersona["telefono"];
                    per.TipoPersona = (Persona.TiposPersona)drPersona["tipo_persona"];
                    per.Plan = new Plan();
                    per.Plan.Descripcion = (string)drPersona["desc_plan"];

                    personas.Add(per);
                }

                drPersona.Close();
                CloseConnection();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al buscar la lista de personas", Ex);
                throw ExcepcionManejada;
            }

            return personas;
        }

        public List<Persona> GetAlumnos()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("select * from personas per where per.tipo_persona = 'Alumno' inner join planes pl on per.id_plan = pl.id_plan", sqlConn);
                SqlDataReader drPersona = cmdPersona.ExecuteReader();

                while (drPersona.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersona["id_persona"];
                    per.Nombre = (string)drPersona["nombre"];
                    per.Apellido = (string)drPersona["apellido"];
                    per.Direccion = (string)drPersona["direccion"];
                    per.Email = (string)drPersona["email"];
                    per.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    per.IDPlan = (int)drPersona["id_plan"];
                    per.Legajo = (int)drPersona["legajo"];
                    per.Telefono = (string)drPersona["telefono"];
                    per.TipoPersona = (Persona.TiposPersona)drPersona["tipo_persona"];
                    per.Plan = new Plan();
                    per.Plan.Descripcion = (string)drPersona["desc_plan"];

                    personas.Add(per);
                }

                drPersona.Close();
                CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al buscar la lista de alumnos", Ex);
                throw ExcepcionManejada;
            }

            return personas;
        }

        public List<Persona> GetProfesores()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("select * from personas per where per.tipo_persona = 'Profesor' inner join planes pl on per.id_plan = pl.id_plan", sqlConn);
                SqlDataReader drPersona = cmdPersona.ExecuteReader();

                while (drPersona.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersona["id_persona"];
                    per.Nombre = (string)drPersona["nombre"];
                    per.Apellido = (string)drPersona["apellido"];
                    per.Direccion = (string)drPersona["direccion"];
                    per.Email = (string)drPersona["email"];
                    per.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    per.IDPlan = (int)drPersona["id_plan"];
                    per.Legajo = (int)drPersona["legajo"];
                    per.Telefono = (string)drPersona["telefono"];
                    per.TipoPersona = (Persona.TiposPersona)drPersona["tipo_persona"];
                    per.Plan = new Plan();
                    per.Plan.Descripcion = (string)drPersona["desc_plan"];

                    personas.Add(per);
                }

                drPersona.Close();
                CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al buscar la lista de alumnos", Ex);
                throw ExcepcionManejada;
            }

            return personas;
        }

        public Persona GetOne(int ID)
        {
            Persona per = new Persona();

            try
            {
                OpenConnection();

                SqlCommand cmdPersona = new SqlCommand("select * from personas where id_persona = @id", sqlConn);
                cmdPersona.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersona = cmdPersona.ExecuteReader();

                if (drPersona.Read())
                {
                    per.ID = (int)drPersona["id_persona"];
                    per.Nombre = (string)drPersona["nombre"];
                    per.Apellido = (string)drPersona["apellido"];
                    per.Direccion = (string)drPersona["direccion"];
                    per.Email = (string)drPersona["email"];
                    per.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    per.IDPlan = (int)drPersona["id_plan"];
                    per.Legajo = (int)drPersona["legajo"];
                    per.Telefono = (string)drPersona["telefono"];
                    per.TipoPersona = (Persona.TiposPersona)drPersona["tipo_persona"];
                }
                drPersona.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al buscar la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return per;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("delete personas where id_persona = @id", sqlConn);
                cmdPersona.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdPersona.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(Persona persona)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("update personas set " +
                    "nombre = @nombre, apellido=@apellido, direccion=@direccion, email = @email, telefono = @telefono, " + 
                    "fecha_nac = @fecha_nac, legajo = @legajo, tipo_persona = @tipo_persona, id_plan = @id_plan where id_persona = @id", 
                    sqlConn);
                cmdPersona.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdPersona.Parameters.Add("@nombre", SqlDbType.VarChar).Value = persona.Nombre;
                cmdPersona.Parameters.Add("@apellido", SqlDbType.VarChar).Value = persona.Apellido;
                cmdPersona.Parameters.Add("@direccion", SqlDbType.VarChar).Value = persona.Direccion;
                cmdPersona.Parameters.Add("@email", SqlDbType.VarChar).Value = persona.Email;
                cmdPersona.Parameters.Add("@telefono", SqlDbType.VarChar).Value = persona.Telefono;
                cmdPersona.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdPersona.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdPersona.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;
                cmdPersona.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdPersona.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar los datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Persona persona)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("insert into personas (nombre, apellido, direccion, email, telefono, " +
                    "fecha_nac, legajo, tipo_persona, id_plan) " + 
                    "values(@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) " + 
                    "select @@identity", sqlConn); 
                cmdPersona.Parameters.Add("@nombre", SqlDbType.VarChar).Value = persona.Nombre;
                cmdPersona.Parameters.Add("@apellido", SqlDbType.VarChar).Value = persona.Apellido;
                cmdPersona.Parameters.Add("@direccion", SqlDbType.VarChar).Value = persona.Direccion;
                cmdPersona.Parameters.Add("@email", SqlDbType.VarChar).Value = persona.Email;
                cmdPersona.Parameters.Add("@telefono", SqlDbType.VarChar).Value = persona.Telefono;
                cmdPersona.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdPersona.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdPersona.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;
                cmdPersona.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                persona.ID = Decimal.ToInt32((decimal)cmdPersona.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save (Persona persona)
        {
            if (persona.State == BusinessEntity.States.Deleted)
                this.Delete(persona.ID);
            else if (persona.State == BusinessEntity.States.New)
                this.Insert(persona);
            else if (persona.State == BusinessEntity.States.Modified)
                this.Update(persona);
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
