using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class Cliente
    {
        public string nombre_cliente { get; set; }
        public string apellido_cliente { get; set; }
        public int cod_taller { get; set; }
        public string cedula_cliente { get; set; }
        public string ciudad_residencia { get; set; }
        public string telefono { get; set; }
        public Cliente()
        {

        }
        public Cliente(string nombre_cliente, string apellido_cliente, int cod_taller, string cedula_cliente, string ciudad_residencia, string telefono)
        {
            this.nombre_cliente = nombre_cliente;
            this.apellido_cliente = apellido_cliente;
            this.cod_taller = cod_taller;
            this.cedula_cliente = cedula_cliente;
            this.ciudad_residencia  = ciudad_residencia;
            this.telefono = telefono;

        }

    }
}
