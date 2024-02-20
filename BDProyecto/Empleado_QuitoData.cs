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
    public class Empleado_QuitoData
    {
        public static int insertar_empleado_quito(Empleado_Quito empleado_quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "insert into empleado_Quito (cod_empleado, cod_taller, cedula_empleado, nombre_empleado, apellido_empleado, salario, fecha_inicio) " +
                    $"values ({empleado_Quito.cod_empleado},{empleado_Quito.cod_taller},{empleado_Quito.cedula_empleado},{empleado_Quito.nombre_empleado},{empleado_Quito.apellido_empleado},{empleado_Quito.salario},{empleado_Quito.fecha_inicio})";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();

            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static List<Empleado_Quito> mostrar_empleado_quito(Conexion conexion)
        {
            List<Empleado_Quito> lista = new List<Empleado_Quito>();
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "select cod_empleado, cod_taller, cedula_empleado, nombre_empleado, apellido_empleado, salario, fecha_inicio";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Empleado_Quito empleado_quito = new Empleado_Quito();
                    empleado_quito.cod_empleado = reader.GetString(0);
                    empleado_quito.cod_taller = reader.GetString(1);
                    empleado_quito.cedula_empleado = reader.GetInt32(2);
                    empleado_quito.nombre_empleado = reader.GetString(3);
                    empleado_quito.apellido_empleado = reader.GetString(4);
                    empleado_quito.salario = reader.GetString(5);
                    empleado_quito.fecha_inicio = reader.GetString(6);
                    lista.Add(cliente);
                }
                conexion.cerrar_Conexion();
                return lista;
            }

        }
        public static int actualizar_empleado_quito(Empleado_Quito empleado_quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"update empleado_Quito set cod_empleado={empleado_Quito.cod_empleado}, cod_taller = {empleado_Quito.cod_taller}, cedula_empleado = {empleado_Quito.cedula_empleado},nombre_empleado = {empleado_Quito.nombre_empleado},apellido_empleado={empleado_Quito.apellido_empleado},salario={empleado_Quito.salario},fecha_inicio={empleado_Quito.fecha_inicio} from empleado_Quito where" +
                    $"cod_empleado={empleado_Quito.cod_empleado}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static int eliminar_empleado_quito(Empleado_Quito empleado_quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"delete from empleado_Quito where cod_empleado={empleado_Quito.cod_empleado}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}
