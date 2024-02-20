using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BDProyecto
{
    public class Vehiculo_placa
    {
        public string placa { get; set; }
        public Guid rowguid { get; set; }
        public Vehiculo_placa() 
        {

        }
        public Vehiculo_placa(string placa, Guid rowguid)
        {
            this.placa = placa;
            this.rowguid = rowguid;
        }
    }
}
