using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOT.Negocio
{
    class Equipo
    {
        private String nombre;
        private String modelo;

        public Equipo()
        {

        }

        public Equipo(String nombre, String modelo)
        {
            this.nombre = nombre;
            this.modelo = modelo;
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public String getModelo()
        {
            return this.modelo;
        }
    }
}
