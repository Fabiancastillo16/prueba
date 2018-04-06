using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOT.Negocio
{
    class Repuesto
    {
        private Double codigo;
        private Double numeroParte;
        private String descripcion;
        private int cantidad;

        public Repuesto()
        {

        }
        public Repuesto(Double codigo, Double numeroParte, String descripcion, int cantidad)
        {
            this.codigo = codigo;
            this.numeroParte = numeroParte;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
        }
        public Double getCodigo()
        {
            return this.codigo;
        }
        public Double getNumeroParte()
        {
            return this.numeroParte;
        }
        public String getDescripcion()
        {
            return this.descripcion;
        }
        public int getCantidad()
        {
            return this.cantidad;
        }
    }
}
