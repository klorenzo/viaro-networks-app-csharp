using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using ViaroNetworksApp.Models;

namespace ViaroNetworksApp.Data
{
    public class GradoRepository
    {

        public static Grado GetByID(int id)
        {
            Grado grado = null;
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spGradoGetByID", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        grado = new Grado
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            ProfesorID = Convert.ToInt32(reader["profesorID"])
                        };
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return grado;
        }

        public static List<Grado> GetAll()
        {
            List<Grado> grados = new List<Grado>();
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spGradoGetAll", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        Grado grado = new Grado
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            ProfesorID = Convert.ToInt32(reader["profesorID"])
                        };
                        grados.Add(grado);
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return grados;
        }

        public static bool Create(Grado grado)
        {
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spGradoCreate", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@nombre", grado.Nombre);
                    query.Parameters.AddWithValue("@profesorID", grado.ProfesorID);

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

        public static bool Update(Grado grado)
        {
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spGradoUpdateByID", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@id", grado.ID);
                    query.Parameters.AddWithValue("@nombre", grado.Nombre);
                    query.Parameters.AddWithValue("@profesorID", grado.ProfesorID);

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
                    SqlCommand query = new SqlCommand("spGradoDeleteByID", connection)
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