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
    public class Reparacion_QuitoData
    {
        public static int insertar_cliente(Reparacion_Quito reparacion_Quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "insert into reparacion_Quito (placa, cod_reparacion, tipo_reparacion, precio, fecha_reparacion, observaciones)" +
                    $"values ({reparacion_Quito.placa},{reparacion_Quito.cod_reparacion},{reparacion_Quito.tipo_reparacion},{reparacion_Quito.precio},{reparacion_Quito.fecha_reparacion},{reparacion_Quito.observaciones})";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();

            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static List<Reparacion_Quito> mostrar_reparacion_Quito(Conexion conexion)
        {
            List<Reparacion_Quito> lista = new List<Reparacion_Quito>();
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = "select placa, cod_reparacion, tipo_reparacion, precio, fecha_reparacion, observaciones";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reparacion_Quito reparacion_Quito = new Reparacion_Quito();
                    reparacion_Quito.placa = reader.GetString(0);
                    reparacion_Quito.cod_reparacion = reader.GetString(1);
                    reparacion_Quito.tipo_reparacion = reader.GetInt32(2);
                    reparacion_Quito.precio = reader.GetString(3);
                    reparacion_Quito.fecha_reparacion = reader.GetString(4);
                    reparacion_Quito.observaciones = reader.GetString(5);
                    lista.Add(cliente);
                }
                conexion.cerrar_Conexion();
                return lista;
            }

        }
        public static int actualizar_datos_reparacion_Quito(Reparacion_Quito reparacion_Quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"update reparacion_Quito set placa = {reparacion_Quito.placa},cod_reparacion={reparacion_Quito.cod_reparacion},tipo_reparacion={reparacion_Quito.tipo_reparacion},precio={reparacion_Quito.precio},fecha_reparacion={reparacion_Quito.fecha_reparacion},observaciones={reparacion_Quito.observaciones} from reparacion_Quito where" +
                    $"placa = {reparacion_Quito.placa} and cod_reparacion={reparacion_Quito.cod_reparacion}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static int eliminar_reparacion_Quito(Reparacion_Quito reparacion_Quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion())
            {
                conexion.abrir_Conexion();
                string query = $"delete from reparacion_Quito where nplaca = {reparacion_Quito.placa} and cod_reparacion={reparacion_Quito.cod_reparacion}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}
