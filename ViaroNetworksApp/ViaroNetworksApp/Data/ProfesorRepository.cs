using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using ViaroNetworksApp.Models;

namespace ViaroNetworksApp.Data
{
    public class ProfesorRepository
    {

        public Profesor GetByID(int id)
        {
            Profesor profesor = null;
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spProfesorGetByID", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        profesor = new Profesor
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Apellidos = Convert.ToString(reader["apellidos"]),
                            Genero = Convert.ToString(reader["genero"])
                        };
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return profesor;
        }

        public List<Profesor> GetAll()
        {
            List<Profesor> profesores = new List<Profesor>();
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spProfesorGetAll", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        Profesor profesor = new Profesor
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Apellidos = Convert.ToString(reader["apellidos"]),
                            Genero = Convert.ToString(reader["genero"]),
                        };
                        profesores.Add(profesor);
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return profesores;
        }

        public bool Create(Profesor profesor)
        {
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spProfesorCreate", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@nombre", profesor.Nombre);
                    query.Parameters.AddWithValue("@apellidos", profesor.Apellidos);
                    query.Parameters.AddWithValue("@genero", profesor.Genero);

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

        public bool Update(Profesor profesor)
        {
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spProfesorUpdateByID", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    query.Parameters.AddWithValue("@id", profesor.ID);
                    query.Parameters.AddWithValue("@nombre", profesor.Nombre);
                    query.Parameters.AddWithValue("@apellidos", profesor.Apellidos);
                    query.Parameters.AddWithValue("@genero", profesor.Genero);

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

        public bool Delete(int id)
        {
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spProfesorDeleteByID", connection)
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