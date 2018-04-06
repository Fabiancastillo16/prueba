using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProyectoOT.Controller.TablesBd
{
    public class DetencionDb
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string fechaInicio { get; set; }
        public string horaInicial { get; set; }
        public string fechaTermino { get; set; }
        public string horaTermino { get; set; }
        public string tipo { get; set; }
        public string turno { get; set; }
        public string horario { get; set; }
        public bool flagSend { get; set; }
    }
}
