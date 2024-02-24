using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace BDProyecto
{
    public class Conexion
    {
        public string data_source;
        private string initial_catalog;
        private string user_id;
        private string password;
        private SqlConnection conexion;

        public Conexion(string data_source, string initial_catalog, string user_id, string password)
        {
            this.data_source = data_source;
            this.initial_catalog = initial_catalog;
            this.user_id = user_id;
            this.password = password;
            string cadena_Conexion = $"Data Source={this.data_source};Initial Catalog={this.initial_catalog};User ID={this.user_id};Password={this.password}";
            this.conexion = new SqlConnection(cadena_Conexion);
            
        }

        public void abrir_Conexion()
        {

            try
            {
                if(this.conexion.State == ConnectionState.Open) {
                    return;
                }
                this.conexion.Open();
                Console.WriteLine("Conexión abierta exitosamente.");
            }
            catch (SqlException e)
            {
                Console.WriteLine("No se pudo establecer una conexión: " + e.Message);
                this.conexion.Close();
            }
        }

        public void cerrar_Conexion()
        {
            try
            {
                this.conexion.Close();
                Console.WriteLine("Conexión cerrada exitosamente.");
            }
            catch (SqlException e)
            {
                Console.WriteLine("No se pudo cerrar la conexión: " + e.Message);
            }
        }
        public SqlConnection obtener_Conexion()
        {
            return this.conexion;
        }
    }
}
