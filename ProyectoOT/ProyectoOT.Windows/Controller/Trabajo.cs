using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOT.Negocio
{
    class Trabajo
    {
        private Double codigo;
        private String nombreTrabajo;
        private Double tiempoInicio;
        private Double tiempoTermino;
        private String descripcion;

        public Trabajo()
        {

        }
        public Trabajo(Double codigo, String nombreTrabajo, Double tiempoInicio, Double tiempoTermino, String descripcion)
        {
            this.codigo = codigo;
            this.nombreTrabajo = nombreTrabajo;
            this.tiempoInicio = tiempoInicio;
            this.tiempoTermino = tiempoTermino;
            this.descripcion = descripcion;

        }
        public Double getCodigo()
        {
            return this.codigo;
        }
        public String getNombreTrabajo()
        {
            return this.nombreTrabajo;
        }
        public Double getTiempoInicio()
        {
            return this.tiempoInicio;
        }
        public Double getTiempoTermino()
        {
            return this.tiempoTermino;
        }
        public String getDescripcion()
        {
            return this.descripcion;
        }
    }
}
