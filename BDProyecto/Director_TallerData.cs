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
    public class Director_TallerData
    {
        public static int insertar_cliente(Director_Taller director_taller, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "insert into director_taller (cod_taller, cod_empleado) " +
                    $"values ({director_taller.cod_taller},{director_taller.cod_empleado})";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();

            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static List<Director_Taller> mostrar_director_taller(Conexion conexion)
        {
            List<Director_Taller> lista = new List<Director_Taller>();
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "cod_taller, cod_empleado from director_taller";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Director_Taller director_taller = new Director_Taller();
                    cliente.cod_taller = reader.GetInt32(0);
                    cliente.cod_empleado = reader.GetString(1);
                    lista.Add(director_taller);
                }
                conexion.cerrar_Conexion();
                return lista;
            }

        }
        public static int actualizar_datos_director_taller(Director_Taller director_taller, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"update director_taller set cod_taller={director_taller.cod_taller}, cod_empleado={director_taller.cod_empleado} from director_taller where" +
                    $"cod_taller={director_taller.cod_taller}, cod_empleado={director_taller.cod_empleado}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static int eliminar_director_taller(Director_Taller director_taller, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"delete from director_taller where cod_taller={director_taller.cod_taller}, cod_empleado={director_taller.cod_empleado}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}
