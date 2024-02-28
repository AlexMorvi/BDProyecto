using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class TallerData
    {
        public static int insertar_taller(Taller taller_Quito, Conexion conexion)
        {
            int retorno = 0;
            using (conexion.obtener_Conexion()) 
            {
                string query = "Insert into taller_Quito (cod_taller, nombre_taller, localidad_taller)" +
                $"values ({taller_Quito.cod_taller}, {taller_Quito.nombre_taller}, {taller_Quito.localidad_taller})";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static List<Taller> mostrar_talleres_Quito(Conexion conexion) 
        {
            List<Taller> lista = new List<Taller> ();
            using (conexion.obtener_Conexion() ) 
            {
                conexion.abrir_Conexion();
                string query = "select cod_taller, nombre_taller, localidad_taller from taller_Quito";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    Taller taller_Quito = new Taller();
                    taller_Quito.cod_taller = reader.GetInt32 (0);
                    taller_Quito.nombre_taller = reader.GetString (1);
                    taller_Quito.localidad_taller = reader.GetString(2);
                    lista.Add(taller_Quito);
                }
                conexion.cerrar_Conexion();
                return lista;
            }
        }
        public static int actualizar_datos_taller_Quito(Taller taller_Quito, Conexion conexion) 
        {
            int retorno = 0;
            using (conexion.obtener_Conexion()) 
            {
                conexion.abrir_Conexion();
                string query = $"update taller_Quito set cod_taller={taller_Quito.cod_taller}, " +
                    $"nombre_taller={taller_Quito.nombre_taller}, localidad_taller={taller_Quito.localidad_taller} " +
                    $"from taller_Quito where cod_taller={taller_Quito.cod_taller}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
        public static int eliminar_taller_Quito(Taller taller_Quito, Conexion conexion) 
        {
            int retorno = 0;
            using (conexion.obtener_Conexion()) 
            {
                conexion.abrir_Conexion();
                string query = $"delete from taller_Quito where cod_taller={taller_Quito.cod_taller}";
                SqlCommand cmd = new SqlCommand(query, conexion.obtener_Conexion());
                retorno = cmd.ExecuteNonQuery();
            }
            conexion.cerrar_Conexion();
            return retorno;
        }
    }
}
