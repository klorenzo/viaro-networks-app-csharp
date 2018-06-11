using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using ViaroNetworksApp.Models;

namespace ViaroNetworksApp.Data
{
    public class AlumnoRepository
    {

        public static Alumno GetByID(int id)
        {
            Alumno alumno = null;
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spAlumnoGetByID", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        alumno = new Alumno
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Apellidos = Convert.ToString(reader["apellidos"]),
                            Genero = Convert.ToString(reader["genero"]),
                            FechaDeNacimiento = Convert.ToDateTime(reader["fechaDeNacimiento"])
                        };
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return alumno;
        }

        public static List<Alumno> GetAll()
        {
            List<Alumno> alumnos = new List<Alumno>();
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spAlumnoGetAll", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        Alumno alumno = new Alumno
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Apellidos = Convert.ToString(reader["apellidos"]),
                            Genero = Convert.ToString(reader["genero"]),
                            FechaDeNacimiento = Convert.ToDateTime(reader["fechaDeNacimiento"])
                        };
                        alumnos.Add(alumno);
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return alumnos;
        }

        public static bool Create(Alumno alumno)
        {
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spAlumnoCreate", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@nombre", alumno.Nombre);
                    query.Parameters.AddWithValue("@apellidos", alumno.Apellidos);
                    query.Parameters.AddWithValue("@genero", alumno.Genero);
                    query.Parameters.AddWithValue("@fechaDeNacimiento", alumno.FechaDeNacimiento);

                    int rowsAffected = query.ExecuteNonQuery();

                    if(rowsAffected == 1)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }

        public static bool Update(Alumno alumno)
        {
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spAlumnoUpdateByID", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@id", alumno.ID);
                    query.Parameters.AddWithValue("@nombre", alumno.Nombre);
                    query.Parameters.AddWithValue("@apellidos", alumno.Apellidos);
                    query.Parameters.AddWithValue("@genero", alumno.Genero);
                    query.Parameters.AddWithValue("@fechaDeNacimiento", alumno.FechaDeNacimiento);

                    int rowsAffected = query.ExecuteNonQuery();

                    if (rowsAffected == 1)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }

        public static bool Delete(int id)
        {
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spAlumnoDeleteByID", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@id", id);

                    int rowsAffected = query.ExecuteNonQuery();

                    if (rowsAffected == 1)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }
    }
}