using LeviatanWeb.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace LeviatanWeb.DAO
{
    public class HomeDAO
    {
        private readonly string? _connectionString;
        
        public HomeDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BloggingDatabase");
        }

        public List<HomeModel> ObtenerParticipantes()
        {
            var participantes = new List<HomeModel>(); //VAR para participantes

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var consulta = new SqlCommand("select idParticipante,Nombre,apellido,correo,celular from lev.Participante", conn);
                var reader = consulta.ExecuteReader(); // Ejecutar Consulta

                while (reader.Read()) {

                    participantes.Add(new HomeModel
                    {
                        idParticipante = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        apellido = reader.GetString(2),
                        correo = reader.GetString(3),
                        celular = reader.GetString(4),
                    });


                }
            }

            return participantes;

        }

    }
}
