using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class Telefono
    {
        public int cod_empleado { get; set; }
        public string telefono_empleado { get; set; }
        public Telefono() 
        {

        }
        public Telefono(int cod_empleado, string telefono_empleado)
        {
            this.cod_empleado = cod_empleado;
            this.telefono_empleado = telefono_empleado;
        }
    }
}
