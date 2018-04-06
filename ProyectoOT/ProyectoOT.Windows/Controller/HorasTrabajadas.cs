using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOT.Negocio
{
    class HorasTrabajadas
    {
        private int horasTrabajadas;

        public HorasTrabajadas()
        {

        }
        public HorasTrabajadas(int horasTrabajadas)
        {
            this.horasTrabajadas = horasTrabajadas;
        }
        public int getHorasTrabajadas()
        {
            return this.horasTrabajadas;
        }
    }
}
