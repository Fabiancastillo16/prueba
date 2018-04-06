using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProyectoOT.Datos;
using SQLite;
using ProyectoOT.Controller.TablesBd;
using System.Diagnostics;

namespace ProyectoOT.Negocio
{
    class Controlador
    {
        public Controlador()
        {

        }

        // método que carga los equipos en el comboboxEquipo.
        public List<String> LoadEquipo()
        {
            Datos.Dato datos = new Datos.Dato();
            List<String> listadoEquipos = new List<String>(datos.importarEquipos());
            return listadoEquipos;
        }

        // método que cambia el modelo del equipo.
        public String selectionChangeEquipo(int index)
        {
            Datos.Dato datos = new Datos.Dato();
            List<String> listadoModelo = new List<string>(datos.importarModelo());
            if (index == 0)
            {
                String modelo = "";
                return modelo;
            }
            else
            {
                String modelo = listadoModelo.ElementAt(index-1);
                return modelo;
            }
            
           
        }

        public void insertarData(String nombreEquipo, String modeloEquipo, double horometroInicial, double horometroFinal, string fechaInicial, string fechaFinal, 
            string horaInical, string horaFinal, string tipoDetencion, string turno, string horario)
        {
            Conexion connection = new Conexion();
            connection.insert(nombreEquipo,modeloEquipo,horometroInicial,horometroFinal);
            
            
            
            //Equipo equipo = new Equipo(nombreEquipo, modelo);
            //Detencion detencion = new Detencion(fechaInicial, horaInical, horometroInicial, fechaFinal, horaFinal, horometroFinal, turno, horario, tipoDetencion);
            //Datos.Dato datos = new Datos.Dato();
            //datos.crearArchivoOT(equipo, detencion);
            
        }

        public void insertarDataMecanicos(List<Mecanico> listaMecanicos, List<HorasStandBy> listaStandBy)
        {

        }

        public List<string> loadCodigoTrabajador()
        {
            Dato codigo = new Dato();
            List<string> listadoCodigosTrabajadores = new List<string>(codigo.importarCodigoTrabajador());
            return listadoCodigosTrabajadores;
        }

        public List<string> loadNombreTrabajador()
        {
            Dato dato = new Dato();
            List<string> listadoNombresTrabajadores = new List<string>(dato.importarNombreTrabajador());
            return listadoNombresTrabajadores;
        }

        public List<string> loadStore()
        {
            Dato dato = new Dato();
            List<string> listadoStore = new List<string>(dato.importarStore());
            return listadoStore;
        }

        public List<string> loadCodigoStandBy()
        {
            Dato dato = new Dato();
            List<string> listaStandBy = new List<string>(dato.importarCodigosStandBy());
            return listaStandBy;
        }
        
    }
}
