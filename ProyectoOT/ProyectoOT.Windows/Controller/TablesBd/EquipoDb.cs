using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProyectoOT.Controller.TablesBd
{
    [Table("Equipos")]
    public class EquipoDb
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Modelo { get; set; }
        public double Serial { get; set; }
        public double HorometroInicial { get; set; }
        public double HorometroFinal { get; set; }
        public int IdDetencion { get; set; }
        public bool FlagSend { get; set; }
    }
}
