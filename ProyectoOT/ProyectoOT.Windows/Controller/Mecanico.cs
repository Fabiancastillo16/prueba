using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOT.Negocio
{
    class Mecanico
    {
        public String codigo { get; set; }
        public int store { get; set; }
        public String nombre { get; set; }
        public List<HorasStandBy> horasStandByList { get; set; }

       
    }
}
