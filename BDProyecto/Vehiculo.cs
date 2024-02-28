using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class Vehiculo
    {
        public string placa { get; set; }
        public string nombre_cliente { get; set; }
        public string apellido_cliente { get; set; }
        public int cod_taller { get; set; }
        public string num_matricula { get; set; }
        public DateTime fecha_compra { get; set; }
        public Vehiculo() 
        {

        }
        public Vehiculo(string placa, string nombre_cliente, string apellido_cliente, int cod_taller, string num_matricula, DateTime fecha_compra)
        {
            this.placa = placa;
            this.nombre_cliente = nombre_cliente;
            this.apellido_cliente = apellido_cliente;
            this.cod_taller = cod_taller;
            this.num_matricula = num_matricula;
            this.fecha_compra = fecha_compra;
        }
    }
}
