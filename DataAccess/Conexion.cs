using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DataAccess
{
    public class Conexion
    {
        private string data_source;
        private string initial_catalog;
        private string user_id;
        private string password;

        public Conexion()
        {
            string cadena_Conexion = "";
            cadena_Conexion = $"Data Source={data_source};Initial Catalog={initial_catalog};User ID={user_id};Password={password}";
            SqlConnection conexion = new SqlConnection(cadena_Conexion);

        }
        public void abrir_Conexion(SqlConnection conexion)
        {
            try
            {
                conexion.Open();
            }
            catch (SqlException e){
                Console.WriteLine("No se pudo establecer una conexion");
            }
        }
    }
}
