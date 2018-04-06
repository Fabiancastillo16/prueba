using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOT.Negocio
{
    class Fluido
    {
        private String sistema;
        private String tipo;
        private int cantidad;
        private String descripcion;

        public Fluido()
        {

        }
        public Fluido(String sistema, String tipo, int cantidad, String descripcion)
        {
            this.sistema = sistema;
            this.tipo = tipo;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
        }

        public String getSistema()
        {
            return this.sistema;
        }
        public String getTipo()
        {
            return this.tipo;
        }
        public int getCantidad()
        {
            return this.cantidad;
        }
        public String getDescripcion()
        {
            return this.descripcion;
        }
    }
}
