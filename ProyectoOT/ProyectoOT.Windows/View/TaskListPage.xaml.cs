using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using ProyectoOT.Controller.InitializeTablesBd;
using System.Diagnostics;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using System.Security.Principal;
using ProyectoOT.Datos;
using System.Threading.Tasks;
using ProyectoOT.Controller;
using ProyectoOT.Controller.TablesBd;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProyectoOT.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TaskListPage : Page
    {
        public TaskListPage()
        {
            this.InitializeComponent();
            //getFolders();
            //inserEquipos();
            getEquipos();
           

            
        }

        public async void getFolders()
        {
            StorageFolder carpeta = ApplicationData.Current.LocalFolder;
            StorageFolder ots = await carpeta.GetFolderAsync("OT's");
            IReadOnlyList<StorageFolder> foldersList = await ots.GetFoldersAsync();
            Debug.WriteLine(carpeta.Path);
            List<Carpeta> listaCarpetas = new List<Carpeta>();
            foreach (StorageFolder folder in foldersList)
            {
                Debug.WriteLine(folder.Name);
                listaCarpetas.Add(new Carpeta { name = folder.DisplayName, dateCreated = Convert.ToString(folder.DateCreated) });
            }
            listaTareas.ItemsSource = null;
            listaTareas.ItemsSource = listaCarpetas;
        }

        public void getEquipos()
        {
            try
            {
                Conexion conexion = new Conexion();
                List<EquipoDb> query = conexion.consultarEquipo().Result;
                
                listaTareas.ItemsSource = null;
                listaTareas.ItemsSource = query;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
           
        }

        public void inserEquipos()
        {
            Conexion conexion = new Conexion();
            conexion.insertEquipo();
        }

        private async void listaTareas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Carpeta item = (Carpeta)listaTareas.SelectedItem;
            string nombre = item.name;
            Debug.WriteLine(nombre);
            StorageFolder carpeta = ApplicationData.Current.LocalFolder;
            StorageFolder ots = await carpeta.GetFolderAsync("OT's");
            IReadOnlyList<StorageFolder> foldersList = await ots.GetFoldersAsync();
            foreach (StorageFolder folder in foldersList)
            {
                Debug.WriteLine(folder.Name);
                if (folder.Name == nombre)
                {
                    StorageFolder laCarpeta = await ots.GetFolderAsync(nombre);
                    IReadOnlyList<StorageFile> fileList = await laCarpeta.GetFilesAsync();
                    foreach (StorageFile file in fileList)
                    {
                        Debug.WriteLine(file.Name);
                        string contenido = await FileIO.ReadTextAsync(file);
                        MessageDialog mensaje = new MessageDialog(contenido, file.Name);
                        await mensaje.ShowAsync();
                    }
                    
                }
            }

        }
    }
}
