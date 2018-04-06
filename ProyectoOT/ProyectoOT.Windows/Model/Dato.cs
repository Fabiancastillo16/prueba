using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoOT.Negocio;
using Windows.Storage;

namespace ProyectoOT.Datos
{
    class Dato
    {
        public Dato()
        {

        }

        public List<string> importarEquipos()
        {
            List<string> listaEquipos = new List<string>();
            listaEquipos.Add("PA-01");
            listaEquipos.Add("PA-02");
            listaEquipos.Add("PA-03");
            return listaEquipos;
        }

        public List<string> importarModelo()
        {
            List<string> listaModelos = new List<string>();
            listaModelos.Add("HD643");
            listaModelos.Add("JD423");
            listaModelos.Add("GT954");
            return listaModelos;
        }

        public List<String> importarCodigoTrabajador()
        {
            List<string> listaCodigos = new List<string>();
            listaCodigos.Add("12549");
            listaCodigos.Add("16479");
            listaCodigos.Add("78461");
            listaCodigos.Add("56761");
            return listaCodigos;
        }

        public List<string> importarNombreTrabajador()
        {
            List<string> listaNombre = new List<string>();
            listaNombre.Add("Lopez A.");
            listaNombre.Add("Sarmiento S.");
            listaNombre.Add("Fierro L.");
            listaNombre.Add("Gonzales P.");
            return listaNombre;
        }

        public List<string> importarStore()
        {
            List<string> listaStore = new List<string>();
            listaStore.Add("15");
            listaStore.Add("23");
            return listaStore;
        }

        public List<string> importarCodigosStandBy()
        {
            List<string> listaCodigoStandBy = new List<string>();
            listaCodigoStandBy.Add("9665 - Charlas de seguridad ");
            listaCodigoStandBy.Add("9806 - Horas de Técnicos a causa de la asistencia a cualquier tipo de reuniones excluidas las relacionadas con seguridad ");
            listaCodigoStandBy.Add("9666 - Horas de técnicos a causa de reuniones con sindicatos dentro de las instalaciones de la operación. ");
            listaCodigoStandBy.Add("9062 - Horas utilizadas por el personal productivo en labores administrativas en el taller. ");
            listaCodigoStandBy.Add("9665 - Horas utilizadas en el desarrollo de cualquier actividad, derivada a la falta de trabajo. Algunos ejemplos son: Apoyo a otras a otras áreas, Auto Instrucción, Limpieza, Inconvenientes con el banco de prueba, Sin Bahías disponibles, Cortes de energía, Falta de lugar, no se puede trasladar componente.");

            return listaCodigoStandBy;

        }

        public async void crearArchivoOT(Equipo equipo, Detencion detencion)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFolder otsFolder = await storageFolder.CreateFolderAsync("OT's", CreationCollisionOption.OpenIfExists); 
            StorageFolder detentionFolder = await otsFolder.CreateFolderAsync(string.Concat("OT", dateTimeNow()), CreationCollisionOption.OpenIfExists);
            StorageFile archivo = await detentionFolder.CreateFileAsync(string.Concat("Equipo", equipo.getNombre(), ".txt"),CreationCollisionOption.GenerateUniqueName);
            await FileIO.WriteTextAsync(archivo, string.Concat(datosFace1(equipo,detencion)));
        }

        public string dateTimeNow()
        {
            string day = Convert.ToString(DateTime.Now.Day);
            string month = Convert.ToString(DateTime.Now.Month);
            string year = Convert.ToString(DateTime.Now.Year);
            string second = Convert.ToString(DateTime.Now.Second);
            string minute = Convert.ToString(DateTime.Now.Minute);
            string hour = Convert.ToString(DateTime.Now.Hour);
            return String.Concat(day, "-", month, "-", year, " ", hour, "-", minute, "-", second);
        }

        private String datosFace1(Equipo equipo, Detencion detencion)
        {
                return string.Concat(equipo.getNombre(),",",equipo.getModelo(),",",detencion.getFechaInicio(),",",detencion.getHoraInicio(),
                ",",detencion.getHorometroInicial(),",",detencion.getFechaFinal(),",",detencion.getHoraFinal(),",",detencion.getHorometroFinal(),
                ",",detencion.getTipoDetencion(),",",detencion.getTipoTurno(),",",detencion.getHoraTurno());
        }

        public string datosFace2(string codigoComponente, string codigoModificador, string codigoTrabajo, string codigoSintoma, string codigoCausa, string solucion)
        {


            return string.Concat(codigoComponente,",",codigoModificador,",",codigoTrabajo,",",codigoSintoma,",",codigoCausa,",",solucion);
        }

    }
}
