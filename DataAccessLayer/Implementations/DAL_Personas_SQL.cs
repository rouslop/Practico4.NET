using DataAccessLayer.Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class DAL_Personas_SQL : IDAL_Personas
    {
        private string sqlConnection = "Server=LAPTOP-KHTKCC25\\SQLEXPRESS;Database=Practico3;User Id=sa;Password=1234;";

        public Persona AddPersona(Persona x)
        {
            using (var connection = new SqlConnection(sqlConnection))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO PERSONAS VALUES(@nombre, @documento)", connection);
                {
                    cmd.Parameters.Add(new SqlParameter("nombre", x.Nombre));
                    cmd.Parameters.Add(new SqlParameter("documento", x.Documento));
                    connection.Open();

                    int result = cmd.ExecuteNonQuery();
                }   
            }

            return x;
        }

        public Persona Get(string documento)
        {
            Persona p = new Persona();
            using (var connection = new SqlConnection(sqlConnection))
            {
                
                SqlCommand cmd = new SqlCommand("SELECT * FROM PERSONAS WHERE Documento = @documento", connection);
                {
                    cmd.Parameters.Add(new SqlParameter("documento", documento));
                    connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    p.Id = dr.GetInt64(0);
                    p.Nombre = dr.GetString(1);
                    p.Documento = dr.GetString(2);

                }
            }

            return p;
        }

        public List<Persona> GetPersonas()
        {
            List<Persona> res = new List<Persona>();
            using (var connection = new SqlConnection(sqlConnection))
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM PERSONAS", connection);
                {
                    connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        Persona p = new Persona();
                        p.Id = dr.GetInt64(0);
                        p.Nombre = dr.GetString(1);
                        p.Documento = dr.GetString(2);
                        res.Add(p);
                    } 
                }
            }
            return res;
        }
    }
}
