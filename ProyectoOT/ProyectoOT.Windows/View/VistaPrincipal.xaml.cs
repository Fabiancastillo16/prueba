
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProyectoOT.Negocio;
using System.Threading.Tasks;
using Windows.Storage.Search;
using Windows.Storage;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Popups;
using SQLite;
using ProyectoOT.Controller.TablesBd;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProyectoOT.Vista
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VistaPrincipal : Page
    {
        public VistaPrincipal()
        {
            this.InitializeComponent();
            
           
        }

        // metodo que carga los equipos en el comboboxEquipo
        private void comboboxEquipo_Loaded(object sender, RoutedEventArgs e)
        {
            Negocio.Controlador controlador = new Negocio.Controlador();
            comboboxEquipo.Items.Insert(0,"Select");
            comboboxEquipo.SelectedIndex = 0;
            for (int i = 0; i < controlador.LoadEquipo().Count; i++)
            {
                
                comboboxEquipo.Items.Insert(i+1, controlador.LoadEquipo().ElementAt(i));
                
            }
                
            
        }

        // metodo que cambia los modelos del equipo 
        private void comboboxEquipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Negocio.Controlador controlador = new Negocio.Controlador();
            texboxModelo.Text = Convert.ToString(controlador.selectionChangeEquipo(comboboxEquipo.SelectedIndex));
            
        }

        // rellena el combobox de la hora de inicio de la detencion
        private void horaInicial_Loaded(object sender, RoutedEventArgs e)
        {
            horaInicial.Items.Insert(0, "00");
            horaInicial.SelectedIndex = 0;
            for (int i = 1; i < 24;i++ )
            {
                if(i<10){
                    horaInicial.Items.Insert(i, "0" + i);
                }
                else
                {
                    horaInicial.Items.Insert(i,i);
                }
                
            }
        }

        // rellena el combobox de los minutos de inicio de la detencion
        private void horaFinal_Loaded(object sender, RoutedEventArgs e)
        {
            horaFinal.Items.Insert(0, "00");
            horaFinal.SelectedIndex = 0;
            for (int i = 1; i < 24; i++)
            {
                if (i < 10)
                {
                    horaFinal.Items.Insert(i, "0" + i);
                }
                else
                {
                    horaFinal.Items.Insert(i, i);
                }

            }
        }

        // rellena el combobox de la hora final de la detencion
        private void minutoInicial_Loaded(object sender, RoutedEventArgs e)
        {
            minutoInicial.Items.Insert(0,"00");
            minutoInicial.SelectedIndex = 0;
            for (int i = 1; i < 60; i++ )
            {
                if (i < 10)
                {
                    minutoInicial.Items.Insert(i, "0" + i);
                }
                else
                {
                    minutoInicial.Items.Insert(i, i);
                }
            }
        }

        // rellena el combobox de los minutos finales de la detencion
        private void minutoFinal_Loaded(object sender, RoutedEventArgs e)
        {
            minutoFinal.Items.Insert(0, "00");
            minutoFinal.SelectedIndex = 0;
            for (int i = 1; i < 60; i++)
            {
                if (i < 10)
                {
                    minutoFinal.Items.Insert(i, "0" + i);
                }
                else
                {
                    minutoFinal.Items.Insert(i, i);
                }
            }
        }
        // ingresa el la tare y crea el archivo co los datos
        private async void ingresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombre = comboboxEquipo.SelectedItem.ToString();
                string modelo = texboxModelo.Text;
                double hoInit = Convert.ToDouble(TexboxHorometroInicial.Text);
                double hoFinal = Convert.ToDouble(TextboxHorometroFinal.Text);
                SQLiteAsyncConnection connection = new SQLiteAsyncConnection("Database.db");
                await connection.InsertAsync(new EquipoDb() { Nombre = nombre, Modelo = modelo, Serial = 123123, HorometroInicial = hoInit, HorometroFinal = hoFinal, IdDetencion=1, FlagSend=false });
                //Controlador controlador = new Controlador();
                //controlador.insertarData(comboboxEquipo.SelectedItem.ToString(), texboxModelo.Text, Convert.ToDouble(TexboxHorometroInicial.Text), Convert.ToDouble(TextboxHorometroFinal.Text),
                //Convert.ToString(fechaInicial.Date.ToString("dd/MM/yyyy")), Convert.ToString(FechaFinal.Date.ToString("dd/MM/yyyy")), string.Concat(horaInicial.SelectedItem.ToString(), ":", minutoInicial.SelectedItem.ToString()),
                //string.Concat(horaFinal.SelectedItem.ToString(), ":", minutoFinal.SelectedItem.ToString()), radioButtonSelected(), radioButtonSelectedTurno(), radioButtonSelectedHorario());
                //listo();

                /* +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
                string codigoComponente = codigoComp.SelectedItem.ToString();
                string codigoModificador = codigoMod.SelectedItem.ToString();
                string codigoTrabajo = codigotrab.SelectedItem.ToString();
                string codigoSintma = codigoSint.SelectedItem.ToString();
                string codigoCau = codigoCausa.SelectedItem.ToString();
                string solucion = textBlockSolución.Text;
                    
                /* +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
                Frame.Navigate(typeof(MainPage));
            }
            catch (Exception ex)
            {
                var message = new MessageDialog("Hay campos imcompletos");

                message.ShowAsync();
            }
            
        }
        // verifica que tipo de mantención fue seleccionada
        private string radioButtonSelected()
        {
            if ((bool)Accidente.IsChecked)
            {
                return Convert.ToString(Accidente.Content);
            }
            else
            {
                if ((bool)Programada.IsChecked)
                {
                    return Convert.ToString(Programada.Content);
                }
                else
                {
                    if ((bool)Imprevista.IsChecked)
                    {
                        return Convert.ToString(Imprevista.Content);
                    }
                    else
                    {
                        return "null";
                    }
                }
            }
        }
        // verifica el tipo de turno que fue seleccionado
        private string radioButtonSelectedTurno()
        {
            if ((bool)A.IsChecked)
            {
                return Convert.ToString(A.Content);
            }
            else
            {
                if ((bool)B.IsChecked)
                {
                    return Convert.ToString(B.Content);
                }
                else
                {
                    if ((bool)C.IsChecked)
                    {
                        return Convert.ToString(C.Content);
                    }
                    else
                    {
                        if ((bool)D.IsChecked)
                        {
                            return Convert.ToString(D.Content);
                        }
                        else
                        {
                            return "null";
                        }
                    }
                }
            }
        }
        // verifica si el turno es de día o noche
        private string radioButtonSelectedHorario()
        {
            if ((bool)dia.IsChecked)
            {
                return Convert.ToString(dia.Content);
            }
            else
            {
                if ((bool)noche.IsChecked)
                {
                    return Convert.ToString(noche.Content);
                }
                else
                {
                    return "null";
                    
                }
            }
        }
        // carga los codigos de los equipos
        private void comboboxCodigo_Loaded(object sender, RoutedEventArgs e)
        {
            Controlador controlador = new Controlador();
            comboboxCodigo.Items.Insert(0,"Select");
            comboboxCodigo.SelectedIndex = 0;
            for (int i = 0; i < controlador.loadCodigoTrabajador().Count; i++)
            {
                comboboxCodigo.Items.Insert(i + 1, controlador.loadCodigoTrabajador().ElementAt(i));
            }
               
        }
        // selecciona el modelo del equipo dependiendo de cual fue seleccionado
        private void comboboxCodigo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Controlador controlador = new Controlador();            
            int index = comboboxCodigo.SelectedIndex;
            if (index > 0 && index < controlador.loadCodigoTrabajador().Count)
            {
                Random na = new Random();
                comboboxNombre.SelectedIndex = index;
                comboboxStore.SelectedIndex = na.Next(1, 3);
            }

        }
        // 
        private void comboboxNombre_Loaded(object sender, RoutedEventArgs e)
        {
            Controlador controlador = new Controlador();
            comboboxNombre.Items.Insert(0, "Select");
            comboboxNombre.SelectedIndex = 0;
            for (int i = 0; i < controlador.loadNombreTrabajador().Count; i++)
            {
                comboboxNombre.Items.Insert(i + 1, controlador.loadNombreTrabajador().ElementAt(i));
            }
        }

        private void comboboxNombre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Controlador controlador = new Controlador();
            int index = comboboxNombre.SelectedIndex;
            if (index > 0 && index < controlador.loadCodigoTrabajador().Count)
            {
                Random na = new Random();
                comboboxCodigo.SelectedIndex = index;
                comboboxStore.SelectedIndex = na.Next(1, 3);
            }
        }

        private void comboboxStore_Loaded(object sender, RoutedEventArgs e)
        {
            Controlador controlador = new Controlador();
            comboboxStore.Items.Insert(0, "Select");
            comboboxStore.SelectedIndex = 0;
            for (int i = 0; i < controlador.loadStore().Count; i++)
            {
                comboboxStore.Items.Insert(i + 1, controlador.loadStore().ElementAt(i));
            }
        }

        List<Mecanico> listaMecanicos = new List<Mecanico>();
        List<HorasStandBy> listaHorasStandBy = new List<HorasStandBy>();
        private void botonTrabajador_Click(object sender, RoutedEventArgs e)
        {
            double horasStandBy = Int32.Parse(horasStandBy1.SelectedItem.ToString()) + Int32.Parse(horasStandBy2.SelectedItem.ToString()) + Int32.Parse(horasStandBy3.SelectedItem.ToString()) + Int32.Parse(horasStandBy4.SelectedItem.ToString());
            double minutosStandBy = Int32.Parse(minutosStandBy1.SelectedItem.ToString()) + Int32.Parse(minutosStandBy2.SelectedItem.ToString()) + Int32.Parse(minutosStandBy3.SelectedItem.ToString()) + Int32.Parse(minutosStandBy4.SelectedItem.ToString());
            if (codigoStandBy1.SelectedIndex > 0)
            {    
                listaHorasStandBy.Add(new HorasStandBy { codigoStandBy = codigoStandBy1.SelectedItem.ToString(), 
                    nombreCodigoStandBy = codigoStandBy1.SelectedItem.ToString(), 
                    horasStandBy = horasStandBy + (minutosStandBy / 60) });
            } 
            if (codigoStandBy2.SelectedIndex > 0)
            {

                listaHorasStandBy.Add(new HorasStandBy
                {
                    codigoStandBy = codigoStandBy2.SelectedItem.ToString(),
                    nombreCodigoStandBy = codigoStandBy2.SelectedItem.ToString(),
                    horasStandBy = horasStandBy + (minutosStandBy / 60)
                });
            }
            if (codigoStandBy3.SelectedIndex > 0)
            {

                listaHorasStandBy.Add(new HorasStandBy
                {
                    codigoStandBy = codigoStandBy3.SelectedItem.ToString(),
                    nombreCodigoStandBy = codigoStandBy3.SelectedItem.ToString(),
                    horasStandBy = horasStandBy + (minutosStandBy / 60)
                });
            }
            if (codigoStandBy4.SelectedIndex > 0)
            {

                listaHorasStandBy.Add(new HorasStandBy
                {
                    codigoStandBy = codigoStandBy4.SelectedItem.ToString(),
                    nombreCodigoStandBy = codigoStandBy4.SelectedItem.ToString(),
                    horasStandBy = horasStandBy + (minutosStandBy / 60)
                });
            }
            listaMecanicos.Add(new Mecanico { codigo = comboboxCodigo.SelectedItem.ToString(), store = Convert.ToInt16(comboboxStore.SelectedItem.ToString()), nombre = comboboxNombre.SelectedItem.ToString(), horasStandByList = listaHorasStandBy });
            workerList.ItemsSource = null;
            workerList.ItemsSource = listaMecanicos;
           


            comboboxCodigo.SelectedIndex = 0;
            horasTrabajadas.SelectedIndex = 0;
            minutosTrabajados.SelectedIndex = 0;
            comboboxNombre.SelectedIndex = 0;
            codigoStandBy1.SelectedIndex = 0;
            horasStandBy1.SelectedIndex = 0;
            minutosStandBy1.SelectedIndex = 0;
            codigoStandBy2.SelectedIndex = 0;
            horasStandBy2.SelectedIndex = 0;
            minutosStandBy2.SelectedIndex = 0;
            codigoStandBy3.SelectedIndex = 0;
            horasStandBy3.SelectedIndex = 0;
            minutosStandBy3.SelectedIndex = 0;
            codigoStandBy4.SelectedIndex = 0;
            horasStandBy4.SelectedIndex = 0;
            minutosStandBy4.SelectedIndex = 0;
            comboboxStore.SelectedIndex = 0;
            
        }


        private void evento(object sendr, RoutedEventArgs EventArgs, StackPanel panel1, StackPanel panel2, StackPanel panel3, StackPanel panel4, string codigo)
        {


            if (CampoCodTrab.Children.Count > 0)
            {


                CampoCodTrab.Children.Remove(panel1);
                CampoHrsTrab.Children.Remove(panel2);
                CampoHrsSBy.Children.Remove(panel3);
                CampoEliminacion.Children.Remove(panel4);
                
                //lista.eliminarPersona(nombre.Text);
               
            }

        }

        private void horasTrabajadas_Loaded(object sender, RoutedEventArgs e)
        {

            horasTrabajadas.Items.Insert(0, "00");
            horasTrabajadas.SelectedIndex = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (i < 10)
                {
                    horasTrabajadas.Items.Insert(i, "0" + i);
                }
                else
                {
                    horasTrabajadas.Items.Insert(i, i);
                }

            }
        }

        private void minutosTrabajados_Loaded(object sender, RoutedEventArgs e)
        {
            minutosTrabajados.Items.Insert(0, "00");
            minutosTrabajados.SelectedIndex = 0;
            for (int i = 1; i < 60; i++)
            {
                if (i < 10)
                {
                    minutosTrabajados.Items.Insert(i, "0" + i);
                }
                else
                {
                    minutosTrabajados.Items.Insert(i, i);
                }
            }
        }

        private void codigoStandBy1_Loaded(object sender, RoutedEventArgs e)
        {
            Controlador controlador = new Controlador();
            codigoStandBy1.Items.Insert(0, "Select");
            codigoStandBy1.SelectedIndex = 0;
            for (int i = 0; i < controlador.loadCodigoStandBy().Count; i++)
            {

                codigoStandBy1.Items.Insert(i + 1, controlador.loadCodigoStandBy().ElementAt(i));

            }
            
            
        }

        private void horasStandBy1_Loaded(object sender, RoutedEventArgs e)
        {
            horasStandBy1.Items.Insert(0, "00");
            horasStandBy1.SelectedIndex = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (i < 10)
                {
                    horasStandBy1.Items.Insert(i, "0" + i);
                }
                else
                {
                    horasStandBy1.Items.Insert(i, i);
                }

            }
        }

        private void minutosStandBy1_Loaded(object sender, RoutedEventArgs e)
        {
            minutosStandBy1.Items.Insert(0, "00");
            minutosStandBy1.SelectedIndex = 0;
            for (int i = 1; i < 60; i++)
            {
                if (i < 10)
                {
                    minutosStandBy1.Items.Insert(i, "0" + i);
                }
                else
                {
                    minutosStandBy1.Items.Insert(i, i);
                }
            }
        }

        private void codigoStandBy2_Loaded(object sender, RoutedEventArgs e)
        {
            Controlador controlador = new Controlador();
            codigoStandBy2.Items.Insert(0, "Select");
            codigoStandBy2.SelectedIndex = 0;
            for (int i = 0; i < controlador.loadCodigoStandBy().Count; i++)
            {

                codigoStandBy2.Items.Insert(i + 1, controlador.loadCodigoStandBy().ElementAt(i));

            }
        }

        private void horasStandBy2_Loaded(object sender, RoutedEventArgs e)
        {
            horasStandBy2.Items.Insert(0, "00");
            horasStandBy2.SelectedIndex = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (i < 10)
                {
                    horasStandBy2.Items.Insert(i, "0" + i);
                }
                else
                {
                    horasStandBy2.Items.Insert(i, i);
                }

            }
        }

        private void minutosStandBy2_Loaded(object sender, RoutedEventArgs e)
        {
            minutosStandBy2.Items.Insert(0, "00");
            minutosStandBy2.SelectedIndex = 0;
            for (int i = 1; i < 60; i++)
            {
                if (i < 10)
                {
                    minutosStandBy2.Items.Insert(i, "0" + i);
                }
                else
                {
                    minutosStandBy2.Items.Insert(i, i);
                }
            }
        }

        private void codigoStandBy3_Loaded(object sender, RoutedEventArgs e)
        {
            Controlador controlador = new Controlador();
            codigoStandBy3.Items.Insert(0, "Select");
            codigoStandBy3.SelectedIndex = 0;
            for (int i = 0; i < controlador.loadCodigoStandBy().Count; i++)
            {

                codigoStandBy3.Items.Insert(i + 1, controlador.loadCodigoStandBy().ElementAt(i));

            }
        }

        private void horasStandBy3_Loaded(object sender, RoutedEventArgs e)
        {
            horasStandBy3.Items.Insert(0, "00");
            horasStandBy3.SelectedIndex = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (i < 10)
                {
                    horasStandBy3.Items.Insert(i, "0" + i);
                }
                else
                {
                    horasStandBy3.Items.Insert(i, i);
                }

            }
        }

        private void minutosStandBy3_Loaded(object sender, RoutedEventArgs e)
        {
            minutosStandBy3.Items.Insert(0, "00");
            minutosStandBy3.SelectedIndex = 0;
            for (int i = 1; i < 60; i++)
            {
                if (i < 10)
                {
                    minutosStandBy3.Items.Insert(i, "0" + i);
                }
                else
                {
                    minutosStandBy3.Items.Insert(i, i);
                }
            }
        }

        private void codigoStandBy4_Loaded(object sender, RoutedEventArgs e)
        {
            Controlador controlador = new Controlador();
            codigoStandBy4.Items.Insert(0, "Select");
            codigoStandBy4.SelectedIndex = 0;
            for (int i = 0; i < controlador.loadCodigoStandBy().Count; i++)
            {

                codigoStandBy4.Items.Insert(i + 1, controlador.loadCodigoStandBy().ElementAt(i));

            }
        }

        private void horasStandBy4_Loaded(object sender, RoutedEventArgs e)
        {
            horasStandBy4.Items.Insert(0, "00");
            horasStandBy4.SelectedIndex = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (i < 10)
                {
                    horasStandBy4.Items.Insert(i, "0" + i);
                }
                else
                {
                    horasStandBy4.Items.Insert(i, i);
                }

            }
        }

        private void minutosStandBy4_Loaded(object sender, RoutedEventArgs e)
        {
            minutosStandBy4.Items.Insert(0, "00");
            minutosStandBy4.SelectedIndex = 0;
            for (int i = 1; i < 60; i++)
            {
                if (i < 10)
                {
                    minutosStandBy4.Items.Insert(i, "0" + i);
                }
                else
                {
                    minutosStandBy4.Items.Insert(i, i);
                }
            }
        }

        private void horasTrabajadas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int eleccion = Convert.ToInt32(horasTrabajadas.SelectedItem.ToString());
            if (eleccion == 12)
            {
                minutosTrabajados.SelectedIndex = 0;
                minutosTrabajados.IsEnabled = false;
            }
            else
            {
                minutosTrabajados.IsEnabled = true;
            }
        }

        private void horasStandBy1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int eleccion = Convert.ToInt32(horasStandBy1.SelectedItem.ToString());
            if (eleccion == 12)
            {
                minutosStandBy1.SelectedIndex = 0;
                minutosStandBy1.IsEnabled = false;
            }
            else
            {
                minutosStandBy1.IsEnabled = true;
            }
        }

        private void horasStandBy2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int eleccion = Convert.ToInt32(horasStandBy2.SelectedItem.ToString());
            if (eleccion == 12)
            {
                minutosStandBy2.SelectedIndex = 0;
                minutosStandBy2.IsEnabled = false;
            }
            else
            {
                minutosStandBy2.IsEnabled = true;
            }
        }

        private void horasStandBy3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int eleccion = Convert.ToInt32(horasStandBy3.SelectedItem.ToString());
            if (eleccion == 12)
            {
                minutosStandBy3.SelectedIndex = 0;
                minutosStandBy3.IsEnabled = false;
            }
            else
            {
                minutosStandBy3.IsEnabled = true;
            }
        }

        private void horasStandBy4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int eleccion = Convert.ToInt32(horasStandBy4.SelectedItem.ToString());
            if (eleccion == 12)
            {
                minutosStandBy4.SelectedIndex = 0;
                minutosStandBy4.IsEnabled = false;
            }
            else
            {
                minutosStandBy4.IsEnabled = true;
            }
        }

        public async Task<String> carpeta()
        {
            StorageFolder picturesFolder = KnownFolders.PicturesLibrary;

            StorageFolderQueryResult queryResult =
                picturesFolder.CreateFolderQuery(CommonFolderQuery.GroupByMonth);

            IReadOnlyList<StorageFolder> folderList =
                await queryResult.GetFoldersAsync();

            StringBuilder outputText = new StringBuilder();

            foreach (StorageFolder folder in folderList)
            {
                IReadOnlyList<StorageFile> fileList = await folder.GetFilesAsync();

                // Print the month and number of files in this group.
                outputText.AppendLine(folder.Name + " (" + fileList.Count + ")");

                foreach (StorageFile file in fileList)
                {
                    // Print the name of the file.
                    outputText.AppendLine("   " + file.Name);
                }
            }

            return Convert.ToString(outputText);
        }
        public async Task<StringBuilder> pictureFolder()
        {
            StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
            StringBuilder outputText = new StringBuilder();

            IReadOnlyList<IStorageItem> itemsList =
                await picturesFolder.GetItemsAsync();

            foreach (var item in itemsList)
            {
                if (item is StorageFolder)
                {
                    outputText.Append(item.Name + " folder\n");

                }
                else
                {
                    outputText.Append(item.Name + "\n");

                }
            }



            return outputText;


        }


        private async void listo()
        {
            var message = new MessageDialog("La tarea se ingresó correctamente");
           
            await message.ShowAsync();
        }

        private void tareaHoraIni_Loaded(object sender, RoutedEventArgs e)
        {
            tareaHoraIni.Items.Insert(0, "00");
            tareaHoraIni.SelectedIndex = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (i < 10)
                {
                    tareaHoraIni.Items.Insert(i, "0" + i);
                }
                else
                {
                    tareaHoraIni.Items.Insert(i, i);
                }

            }
        }

        private void tareaMinIni_Loaded(object sender, RoutedEventArgs e)
        {
            tareaMinIni.Items.Insert(0, "00");
            tareaMinIni.SelectedIndex = 0;
            for (int i = 1; i < 60; i++)
            {
                if (i < 10)
                {
                    tareaMinIni.Items.Insert(i, "0" + i);
                }
                else
                {
                    tareaMinIni.Items.Insert(i, i);
                }
            }
        }

        private void tareaHoraFin_Loaded(object sender, RoutedEventArgs e)
        {
            tareaHoraFin.Items.Insert(0, "00");
            tareaHoraFin.SelectedIndex = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (i < 10)
                {
                    tareaHoraFin.Items.Insert(i, "0" + i);
                }
                else
                {
                    tareaHoraFin.Items.Insert(i, i);
                }

            }
        }

        private void tareaMinFin_Loaded(object sender, RoutedEventArgs e)
        {
            tareaMinFin.Items.Insert(0, "00");
            tareaMinFin.SelectedIndex = 0;
            for (int i = 1; i < 60; i++)
            {
                if (i < 10)
                {
                    tareaMinFin.Items.Insert(i, "0" + i);
                }
                else
                {
                    tareaMinFin.Items.Insert(i, i);
                }
            }
        }

        private void codigoComp_Loaded(object sender, RoutedEventArgs e)
        {
            codigoComp.Items.Insert(0, "Select");
            codigoComp.SelectedIndex = 0;
            codigoComp.Items.Insert(1, "154");
            codigoComp.Items.Insert(2, "15954");
        }

        private void codigoMod_Loaded(object sender, RoutedEventArgs e)
        {
            codigoMod.Items.Insert(0, "Select");
            codigoMod.SelectedIndex = 0;
            codigoMod.Items.Insert(1, "01");
            codigoMod.Items.Insert(2, "02");
        }

        private void codigotrab_Loaded(object sender, RoutedEventArgs e)
        {
            codigotrab.Items.Insert(0, "Select");
            codigotrab.SelectedIndex = 0;
            codigotrab.Items.Insert(1, "23");
            codigotrab.Items.Insert(2, "24");
        }

        private void codigoSint_Loaded(object sender, RoutedEventArgs e)
        {
            codigoSint.Items.Insert(0, "Select");
            codigoSint.SelectedIndex = 0;
            codigoSint.Items.Insert(1, "96");
            codigoSint.Items.Insert(2, "97");
        }

        private void codigoCausa_Loaded(object sender, RoutedEventArgs e)
        {
            codigoCausa.Items.Insert(0, "Select");
            codigoCausa.SelectedIndex = 0;
            codigoCausa.Items.Insert(1, "101");
            codigoCausa.Items.Insert(2, "102");
        }
        
    }
}
