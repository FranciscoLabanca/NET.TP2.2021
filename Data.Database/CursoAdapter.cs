using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class CursoAdapter : Adapter, IEntityAdapter<Curso>
    {

        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("SELECT c.id_curso, c.id_materia, c.id_comision, c.anio_calendario, c.cupo, com.desc_comision, m.desc_materia FROM cursos AS c " +
                    "LEFT JOIN comisiones AS com " +
                    "ON c.id_comision = com.id_comision " +
                    "LEFT JOIN materias AS m " +
                    "ON c.id_materia=m.id_materia", sqlConn);
                SqlDataReader drCurso = cmdCurso.ExecuteReader();

                while (drCurso.Read())
                {
                    Curso curso = new Curso();

                    curso.ID = (int)drCurso["id_curso"];
                    curso.IDMateria = (int)drCurso["id_materia"];
                    curso.IDComision = (int)drCurso["id_comision"];
                    curso.AnioCalendario = (int)drCurso["anio_calendario"];
                    curso.Cupo = (int)drCurso["cupo"];
                    curso.Comision = (string)drCurso["desc_comision"];
                    curso.Materia = (string)drCurso["desc_materia"];

                    cursos.Add(curso);
                }
                return cursos;
            }
            catch(Exception e)
            {
                throw new Exception("Error al recuperar la lista de cursos", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public Curso GetOne(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("SELECT c.id_curso, c.id_materia, c.id_comision, c.anio_calendario, c.cupo, com.desc_comision, m.desc_materia FROM cursos AS c " +
                    "LEFT JOIN comisiones AS com " +
                    "ON c.id_comision = com.id_comision " +
                    "LEFT JOIN materias AS m " +
                    "ON c.id_materia=m.id_materia " +
                    "WHERE c.id_curso = @id", sqlConn);
                cmdCurso.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = ID;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();

                Curso curso = new Curso();

                if (drCurso.Read())
                {

                    curso.ID = (int)drCurso["id_curso"];
                    curso.IDMateria = (int)drCurso["id_materia"];
                    curso.IDComision = (int)drCurso["id_comision"];
                    curso.AnioCalendario = (int)drCurso["anio_calendario"];
                    curso.Cupo = (int)drCurso["cupo"];
                    curso.Comision = (string)drCurso["desc_comision"];
                    curso.Materia = (string)drCurso["desc_materia"];
                }
                return curso;
            }
            catch(Exception e)
            {
                throw new Exception("Error al recuperar el curso", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Insert(Curso curso)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("INSERT INTO cursos (id_materia, id_comision, anio_calendario, cupo) " +
                    "VALUES (@id_materia, @id_comision, @anio_calendario, @cupo) SELECT @@identity", sqlConn);
                cmdCurso.Parameters.Add(new SqlParameter("@id_materia", SqlDbType.Int)).Value = curso.IDMateria;
                cmdCurso.Parameters.Add(new SqlParameter("@id_comision", SqlDbType.Int)).Value = curso.IDComision;
                cmdCurso.Parameters.Add(new SqlParameter("@anio_calendario", SqlDbType.Int)).Value = curso.AnioCalendario;
                cmdCurso.Parameters.Add(new SqlParameter("@cupo", SqlDbType.Int)).Value = curso.Cupo;

                curso.ID = Decimal.ToInt32((decimal)cmdCurso.ExecuteScalar()); /*Ver si funciona bien esto*/
            }
            catch(Exception e)
            {
                throw new Exception("Error al agregar el curso", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(Curso curso)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("UPDATE cursos SET id_materia = @id_materia, id_comision = @id_comision, anio_calendario = @anio_calendario, cupo = @cupo " +
                    "WHERE id_curso = @id", sqlConn);
                cmdCurso.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = curso.ID;
                cmdCurso.Parameters.Add(new SqlParameter("@id_materia", SqlDbType.Int)).Value = curso.IDMateria;
                cmdCurso.Parameters.Add(new SqlParameter("@id_comision", SqlDbType.Int)).Value = curso.IDComision;
                cmdCurso.Parameters.Add(new SqlParameter("@anio_calendario", SqlDbType.Int)).Value = curso.AnioCalendario;
                cmdCurso.Parameters.Add(new SqlParameter("@cupo", SqlDbType.Int)).Value = curso.Cupo;

                cmdCurso.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al actualizar el curso", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("DELETE cursos WHERE id_curso = @id", sqlConn);
                cmdCurso.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = ID;

                cmdCurso.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw new Exception("Error al eliminar curso", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
                this.Delete(curso.ID);
            else if (curso.State == BusinessEntity.States.New)
                this.Insert(curso);
            else if (curso.State == BusinessEntity.States.Modified)
                this.Update(curso);
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
