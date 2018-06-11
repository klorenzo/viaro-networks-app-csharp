using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using ViaroNetworksApp.Models;

namespace ViaroNetworksApp.Data
{
    public class AlumnoGradoRepository
    {

        public static AlumnoGrado GetByID(int id)
        {
            AlumnoGrado alumnoGrado = null;
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spAlumnoGradoGetByID", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        alumnoGrado = new AlumnoGrado
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            AlumnoID = Convert.ToInt32(reader["alumnoID"]),
                            GradoID = Convert.ToInt32(reader["gradoID"]),
                            Seccion = Convert.ToString(reader["seccion"])
                        };
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return alumnoGrado;
        }

        public static List<AlumnoGrado> GetAll()
        {
            List<AlumnoGrado> alumnosGrados = new List<AlumnoGrado>();
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spAlumnoGradoGetAll", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        AlumnoGrado alumnoGrado = new AlumnoGrado
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            AlumnoID = Convert.ToInt32(reader["alumnoID"]),
                            GradoID = Convert.ToInt32(reader["gradoID"]),
                            Seccion = Convert.ToString(reader["seccion"])
                        };
                        alumnosGrados.Add(alumnoGrado);
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return alumnosGrados;
        }

        public static bool Create(AlumnoGrado alumnoGrado)
        {
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spAlumnoGradoCreate", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@alumnoID", alumnoGrado.AlumnoID);
                    query.Parameters.AddWithValue("@gradoID", alumnoGrado.GradoID);
                    query.Parameters.AddWithValue("@seccion", alumnoGrado.Seccion);

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

        public static bool Update(AlumnoGrado alumnoGrado)
        {
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spAlumnoGradoUpdateByID", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@id", alumnoGrado.ID);
                    query.Parameters.AddWithValue("@alumnoID", alumnoGrado.AlumnoID);
                    query.Parameters.AddWithValue("@gradoID", alumnoGrado.GradoID);
                    query.Parameters.AddWithValue("@seccion", alumnoGrado.Seccion);

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
                    SqlCommand query = new SqlCommand("spAlumnoGradoDeleteByID", connection)
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