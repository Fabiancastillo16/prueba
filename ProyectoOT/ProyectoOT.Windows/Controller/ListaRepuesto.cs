using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOT.Negocio
{
    class ListaRepuesto
    {
        private List<Repuesto> listaRepuesto;
        private Dictionary<Double, Repuesto> listaRepuesto1;

        public ListaRepuesto()
        {
            listaRepuesto = new List<Repuesto>();
            listaRepuesto1 = new Dictionary<Double, Repuesto>();
        }

        public void agregarRepuesto(Repuesto repuesto)
        {
            listaRepuesto.Add(repuesto);            
        }
        public void buscarRepuesto(Double codigo)
        {
            int index =0;
            while(index<=listaRepuesto1.Count()){
                
            }
        }
    }
}
