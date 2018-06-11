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
        public List<Alumno> GetAll()
        {
            List<Alumno> alumnos = new List<Alumno>();
            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                try
                {
                    SqlCommand query = new SqlCommand("spAlumnoGetAll", connection);
                    query.CommandType = CommandType.StoredProcedure;

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
    }
}