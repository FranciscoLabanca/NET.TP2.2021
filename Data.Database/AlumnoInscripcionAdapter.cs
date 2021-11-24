using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter, IEntityAdapter<AlumnoInscripcion>
    {
        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripcions = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();

                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM alumnos_inscripciones", sqlConn);
                SqlDataReader rdAlumnoInscripciones = cmdGetAll.ExecuteReader();
                while (rdAlumnoInscripciones.Read())
                {
                    AlumnoInscripcion inscripcion = new AlumnoInscripcion();
                    inscripcion.ID = (int)rdAlumnoInscripciones["id_inscripcion"];
                    inscripcion.IDAlumno = (int)rdAlumnoInscripciones["id_alumno"];
                    inscripcion.IDCurso = (int)rdAlumnoInscripciones["id_curso"];
                    inscripcion.Condicion = (string)rdAlumnoInscripciones["condicion"];
                    inscripcion.Nota = rdAlumnoInscripciones["nota"].GetType() != typeof(DBNull) ? (int)rdAlumnoInscripciones["nota"] : 0 ;
                    inscripcions.Add(inscripcion);
                }

                return inscripcions;
            }
            catch (Exception e)
            {
                throw new Exception("Error al recuperar el listado de inscripciones", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdGetAll = new SqlCommand(  "SELECT * FROM alumnos_inscripciones " +
                                                        "WHERE alumnos_inscripciones.id_inscripcion = @id_inscripcion", sqlConn);
                cmdGetAll.Parameters.Add("@id_inscripcion", System.Data.SqlDbType.Int).Value = ID;
                SqlDataReader rdAlumnoInscripciones = cmdGetAll.ExecuteReader();
                AlumnoInscripcion inscripcion = new AlumnoInscripcion();
                if (rdAlumnoInscripciones.Read())
                {
                    inscripcion.ID = (int)rdAlumnoInscripciones["id_inscripcion"];
                    inscripcion.IDAlumno = (int)rdAlumnoInscripciones["id_alumno"];
                    inscripcion.IDCurso = (int)rdAlumnoInscripciones["id_curso"];
                    inscripcion.Condicion = (string)rdAlumnoInscripciones["condicion"];
                    inscripcion.Nota = rdAlumnoInscripciones["nota"].GetType() != typeof(DBNull) ? (int)rdAlumnoInscripciones["nota"] : 0;                    
                }

                return inscripcion;
            }
            catch (Exception e)
            {
                throw new Exception("Error al recuperar la inscripcion", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Insert(AlumnoInscripcion entity)
        {
            throw new NotImplementedException();
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            switch (inscripcion.State)
            {
                case BusinessEntity.States.Deleted:
                    this.Delete(inscripcion.ID);
                    break;
                case BusinessEntity.States.New:
                    this.Insert(inscripcion);
                    break;
                case BusinessEntity.States.Modified:
                    this.Update(inscripcion);
                    break;
                default:
                    break;
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }

        public void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdUpdate = new SqlCommand(  "UPDATE alumnos_inscripciones " +
                                                        "SET id_alumno = @id_alumno, id_curso = @id_curso, condicion = @condicion, nota = @nota " +
                                                        "WHERE id_inscripcion = @id"
                                                        , sqlConn);

                cmdUpdate.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = inscripcion.ID;
                cmdUpdate.Parameters.Add("@id_alumno", System.Data.SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdUpdate.Parameters.Add("@id_curso", System.Data.SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdUpdate.Parameters.Add("@condicion", System.Data.SqlDbType.VarChar).Value = inscripcion.Condicion;
                cmdUpdate.Parameters.Add("@nota", System.Data.SqlDbType.Int).Value = inscripcion.Nota;

                cmdUpdate.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("Error al modificar la inscripcion", e);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
