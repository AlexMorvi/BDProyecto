using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class Vehiculo_QuitoData
    {
        public static int insertar_vehiculo_Quito(Vehiculo_Quito vehiculo_Quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "insert into vehiculo_Quito (placa, nombre_cliente, apellido_cliente, cod_taller, num_matricula," +
                    $" fecha_compra) values ({vehiculo_Quito.placa},{vehiculo_Quito.nombre_cliente}," +
                    $"{vehiculo_Quito.apellido_cliente},{vehiculo_Quito.cod_taller},{vehiculo_Quito.num_matricula}," +
                    $"{vehiculo_Quito.fecha_compra})";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();

            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static List<Vehiculo_Quito> mostrar_vehiculos_Quito(Conexion conexion)
        {
            List<Vehiculo_Quito> lista = new List<Vehiculo_Quito>();
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "select placa, nombre_cliente, apellido_cliente, cod_taller, num_matricula, fecha_compra" +
                    " from vehiculo_Quito";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehiculo_Quito vehiculo_Quito = new Vehiculo_Quito();
                    vehiculo_Quito.placa = reader.GetString(0);
                    vehiculo_Quito.nombre_cliente = reader.GetString(1);
                    vehiculo_Quito.apellido_cliente = reader.GetString(2);
                    vehiculo_Quito.cod_taller = reader.GetInt32(3);
                    vehiculo_Quito.num_matricula = reader.GetString(4);
                    vehiculo_Quito.fecha_compra = reader.GetDateTime(5);
                    lista.Add(vehiculo_Quito);
                }
                conexion.cerrar_Conexion();
                return lista;
            }

        }
        public static int actualizar_vehiculos_Quito(Vehiculo_Quito vehiculo_Quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"update vehiculo_Quito set placa={vehiculo_Quito.placa}," +
                    $" nombre_cliente={vehiculo_Quito.nombre_cliente}, apellido_cliente={vehiculo_Quito.apellido_cliente}," +
                    $" cod_taller={vehiculo_Quito.cod_taller}, num_matricula={vehiculo_Quito.num_matricula}," +
                    $" fecha_compra={vehiculo_Quito.fecha_compra} from vehiculo_Quito where" +
                    $"nombre_cliente={vehiculo_Quito.nombre_cliente} and apellido_cliente={vehiculo_Quito.apellido_cliente}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static int eliminar_vehiculo_Quito(Vehiculo_Quito vehiculo_Quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"delete from vehiculo_Quito where placa ={vehiculo_Quito.placa} and " +
                    $"nombre_cliente={vehiculo_Quito.nombre_cliente} and apellido_cliente={vehiculo_Quito.apellido_cliente}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}
