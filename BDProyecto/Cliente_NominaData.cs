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
    public class Cliente_NominaData
    {
        public static int insertar_cliente_nomina(Cliente_Nomina cliente_nomina, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "insert into cliente_Quito (nombre_cliente, apellido_cliente) " +
                    $"values ({cliente_nomina.nombre_cliente},{cliente_nomina.apellido_cliente})";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();

            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static List<Cliente_Nomina> mostrar_clientes_nomina(Conexion conexion)
        {
            List<Cliente_Nomina> lista = new List<Cliente_Nomina>();
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "select nombre_cliente, apellido_cliente";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cliente_Nomina cliente_nomina = new Cliente_Nomina();
                    cliente_nomina.nombre_cliente = reader.GetString(0);
                    cliente_nomina.apellido_cliente = reader.GetString(1);
                    lista.Add(cliente);
                }
                conexion.cerrar_Conexion();
                return lista;
            }

        }
        public static int actualizar_datos_cliente_nomina(Cliente_Nomina cliente_nomina, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"update cliente_nomina set nombre_cliente={cliente_nomina.nombre_cliente}, apellido_cliente={cliente_nomina.apellido_cliente}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static int eliminar_cliente_nomina(Cliente_Nomina cliente_nomina, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"delete from cliente_nomina where nombre_cliente={cliente_nomina.nombre_cliente} and apellido_cliente={cliente_nomina.apellido_cliente}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}
