using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOT.Negocio
{
    class Componente
    {
        private Double codigoComponente;
        private Double codigoModificador;
        private String nombreComponente;
        private String nombreModificador;

        public Componente()
        {

        }

        public Componente(Double codigoComponente, Double codigoModificador, String nombreComponente, String nombreModificador)
        {
            this.codigoComponente = codigoComponente;
            this.codigoModificador = codigoModificador;
            this.nombreComponente = nombreComponente;
            this.nombreModificador = nombreModificador;
        }

        public Double getCodigoComponente(){
            return this.codigoComponente;
        }

        public Double getCodigoModificador()
        {
            return this.codigoModificador;
        }

        public String getNombreComponente()
        {
            return this.nombreComponente;
        }

        public String getNombreModificador()
        {
            return this.nombreModificador;
        }

    }
}
