using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class Taller_Quito
    {
        public int cod_taller { get; set; }
        public string nombre_taller { get; set; }
        public string localidad_taller { get; set; }

        public Taller_Quito() 
        {

        }
        public Taller_Quito(int cod_taller, string nombre_taller, string localidad_taller)
        {
            this.cod_taller = cod_taller;
            this.nombre_taller = nombre_taller;
            this.localidad_taller = localidad_taller;
        }
    }
}
