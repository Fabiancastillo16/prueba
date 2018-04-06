using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProyectoOT.Controller.InitializeTablesBd
{
    public class InitDbEquipo
    {
        [PrimaryKey]
        public string serial { get; set; }
        public string nombre { get; set; }
        public string modelo { get; set; }
    }
}
