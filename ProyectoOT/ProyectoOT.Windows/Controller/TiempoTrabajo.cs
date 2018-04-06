using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOT.Negocio
{
    class TiempoTrabajo
    {
        public TiempoTrabajo()
        {

        }
        public Double getHorasTotalTrabajadas( Double horasTrabajadas, Double horasStandBy)
        {
            return horasTrabajadas + horasStandBy;
        }
    }
}
