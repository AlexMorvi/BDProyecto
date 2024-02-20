using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class Vehiculo_placaData
    {
        public static int insertar_vehiculo_placa(Vehiculo_placa vehiculo_Placa, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "insert into vehiculo_placa (placa) " +
                    $"values ({vehiculo_Placa.placa})";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();

            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static List<Vehiculo_placa> mostrar_vehiculos_placas(Conexion conexion)
        {
            List<Vehiculo_placa> lista = new List<Vehiculo_placa>();
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "select placa, rowguid from vehiculo_placa";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehiculo_placa vehiculo_Placa = new Vehiculo_placa();
                    vehiculo_Placa.placa = reader.GetString(0);
                    vehiculo_Placa.rowguid = reader.GetGuid(1);
                   
                    lista.Add(vehiculo_Placa);
                }
                conexion.cerrar_Conexion();
                return lista;
            }

        }
        public static int actualizar_vehiculos_placas(Vehiculo_placa vehiculo_Placa, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"update vehiculo_placa set placa={vehiculo_Placa.placa} where" +
                    $"vehiculo_placa={vehiculo_Placa.placa}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static int eliminar_vehiculo_placa(Vehiculo_placa vehiculo_Placa, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"delete from vehiculo_placa where vehiculo_placa={vehiculo_Placa.placa}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}

