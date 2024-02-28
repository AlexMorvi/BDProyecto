using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class TelefonoData
    {
        public static int insertar_telefono_Quito(Telefono telefono_Quito, Conexion conexion) 
        {
            int retorno = 0;
            using (conexion.obtener_Conexion()) 
            {
                conexion.abrir_Conexion();
                string query = "insert into telefono_Quito (cod_empleado, telefono_empleado) " +
                    $"values ({telefono_Quito.cod_empleado}, {telefono_Quito.telefono_empleado})";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static List<Telefono> mostrar_telefonos_Quito(Conexion conexion) 
        {
            List<Telefono> lista = new List<Telefono> ();
            using (conexion.obtener_Conexion()) 
            {
                conexion.abrir_Conexion ();
                string query = "select cod_empleado, telefono_empleado from telefono_Quito";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Telefono telefono_Quito = new Telefono ();
                    telefono_Quito.cod_empleado = reader.GetInt32 (0);
                    telefono_Quito.telefono_empleado  =reader.GetString (1);
                    lista.Add (telefono_Quito);
                }
                conexion.cerrar_Conexion();
                return lista;
            }
        }
        public static int actualizar_telefonos_Quito(Telefono telefono_Quito, Conexion conexion) 
        {
            int retorno = 0;
            using (conexion.obtener_Conexion()) 
            {
                conexion.abrir_Conexion();
                string query = $"update telefono_Quito set cod_empleado={telefono_Quito.cod_empleado}," +
                    $" telefono_empleado={telefono_Quito.telefono_empleado} from telefono_Quito " +
                    $"where cod_empleado={telefono_Quito.cod_empleado}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion() ;
            return retorno;
        }
        public static int eliminar_telefono_Quito(Telefono telefono_Quito, Conexion conexion) 
        {
            int retorno = 0;
            using (conexion.obtener_Conexion()) 
            {
                conexion.abrir_Conexion();
                string query = $"delete from telefono_Quito where cod_empleado={telefono_Quito.cod_empleado}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}
