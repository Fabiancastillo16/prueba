using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOT.Negocio
{
    class Detencion
    {
        private String fechaInicio;
        private String horaInicio;
        private Double horometroInicial;
        private String fechaFinal;
        private String horaFinal;
        private Double horometroFinal;
        private String tipoTurno;
        private String horaTurno;
        private String tipoDetencion;

        public Detencion()
        {

        }

        public Detencion(String fechaInicio, String horaInicio, Double horometroInicial, String fechaFinal,
            String horaFinal, Double horometroFinal, String tipoTurno, String horaTurno, String tipoDetencion)
        {
            this.fechaInicio = fechaInicio;
            this.horaInicio = horaInicio;
            this.horometroInicial = horometroInicial;
            this.fechaFinal = fechaFinal;
            this.horaFinal = horaFinal;
            this.horometroFinal = horometroFinal;
            this.tipoTurno = tipoTurno;
            this.horaTurno = horaTurno;
            this.tipoDetencion = tipoDetencion;
        }

        public String getFechaInicio()
        {
            return this.fechaInicio;
        }
        public String getHoraInicio()
        {
            return this.horaInicio;
        }
        public Double getHorometroInicial()
        {
            return this.horometroInicial;
        }
        public String getFechaFinal()
        {
            return this.fechaFinal;
        }
        public String getHoraFinal()
        {
            return this.horaFinal;
        }
        public Double getHorometroFinal()
        {
            return this.horometroFinal;
        }
        public String getTipoTurno()
        {
            return this.tipoTurno;
        }
        public String getHoraTurno()
        {
            return this.horaTurno;
        }
        public String getTipoDetencion()
        {
            return this.tipoDetencion;
        }
    }
}
