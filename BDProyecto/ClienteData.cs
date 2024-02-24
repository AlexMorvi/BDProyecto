using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Policy;
using BDProyecto;
using System.Collections;
namespace BDProyecto
{
    public class ClienteData
    {
        public static int insertar_cliente(Cliente cliente, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                int codigo_Taller = 0;
                if (conexion.data_source.Equals("BD-QUITO"))
                    codigo_Taller = 1;
                if (conexion.data_source.Equals("BD-GUAYAQUIL"))
                    codigo_Taller = 2;
                conexion.abrir_Conexion();
                string query = "insert into cliente_Quito (nombre_cliente, apellido_cliente, cod_taller, cedula_cliente, ciudad_residencia, telefono) " +
                    $"values ({cliente.nombre_cliente},{cliente.apellido_cliente},{codigo_Taller},{cliente.cedula_cliente},{cliente.ciudad_residencia},{cliente.telefono})";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();

            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static List<Cliente> mostrar_clientes(Conexion conexion)
        {
            List<Cliente> lista = new List<Cliente>();
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "select nombre_cliente, apellido_cliente, cod_taller, cedula_cliente, ciudad_residencia, telefono from cliente_Quito";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.nombre_cliente = reader.GetString(0);
                    cliente.apellido_cliente = reader.GetString(1);
                    cliente.cod_taller = reader.GetInt32(2);
                    cliente.cedula_cliente = reader.GetString(3);
                    cliente.ciudad_residencia = reader.GetString(4);
                    cliente.telefono = reader.GetString(5);
                    lista.Add(cliente);
                }
                conexion.cerrar_Conexion();
                return lista;
            }

        }
        public static int actualizar_datos_cliente(Cliente cliente, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"update cliente_Quito set nombre_cliente={cliente.nombre_cliente}, apellido_cliente={cliente.apellido_cliente}, cod_taller={cliente.cod_taller}, cedula_cliente={cliente.cedula_cliente}, ciudad_residencia={cliente.ciudad_residencia}, telefono={cliente.telefono} from cliente_Quito where" +
                    $"nombre_cliente={cliente.nombre_cliente} and apellido_cliente={cliente.apellido_cliente}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static int eliminar_cliente(Cliente cliente, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"delete from cliente_Quito where nombre_cliente={cliente.nombre_cliente} and apellido_cliente={cliente.apellido_cliente}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}
