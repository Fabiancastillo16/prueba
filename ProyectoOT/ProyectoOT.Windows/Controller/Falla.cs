using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOT.Negocio
{
    class Falla
    {
        private Double codigoSintoma;
        private String sintoma;
        private Double codigoCausa;
        private String causa;
        private String solucion;
        private Double numPiezaFallada;
        private Double numGrupoFalla;
        private Boolean fallaPrincipal;
        private String detallesFalla;
        private String detallesSolucion;

        public Falla()
        {

        }

        public Falla(Double codigoSintoma, String sintoma, Double codigoCausa, String causa,
            String solucion, Double numPiezaFallada, Double numGrupoFalla, Boolean fallaPrincipal,
            String detallesFalla, String detallesSolucion)
        {

            this.codigoSintoma = codigoSintoma;
            this.sintoma = sintoma;
            this.codigoCausa = codigoCausa;
            this.causa = causa;
            this.solucion = solucion;
            this.numPiezaFallada = numPiezaFallada;
            this.numGrupoFalla = numGrupoFalla;
            this.fallaPrincipal = fallaPrincipal;
            this.detallesFalla = detallesFalla;
            this.detallesSolucion = detallesSolucion;
        }

        public Double getCodigoSintoma()
        {
            return this.codigoSintoma;
        }
        public String getSintoma()
        {
            return this.sintoma;
        }
        public Double getCodigoCausa()
        {
            return this.codigoCausa;
        }
        public String getCausa()
        {
            return this.causa;
        }       
        public Double getNumPiezaFallada()
        {
            return this.numPiezaFallada;
        }
        public Double getNumGrupoFalla()
        {
            return this.numGrupoFalla;
        }
        public Boolean getFallaPrincipal()
        {
            return this.fallaPrincipal;
        }
        public String getDetallesFalla()
        {
            return this.detallesFalla;
        }
        public String getDetallesSolucion()
        {
            return this.detallesSolucion;
        }
    }
}
