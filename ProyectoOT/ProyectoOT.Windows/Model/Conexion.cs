using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Search;
using Windows.Foundation.Collections;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Text;
using SQLite;
using ProyectoOT.Controller.InitializeTablesBd;
using ProyectoOT.Controller.TablesBd;
using System.Diagnostics;
using System.IO;









namespace ProyectoOT .Datos
{
    public class Conexion
    {
        public Conexion()
        {

        }
        public SQLiteAsyncConnection ConexionInitialDb()
        {
            return new SQLiteAsyncConnection("InitialDb.db");
        }

        public async Task<bool> DbExist()
        {
            bool dbExist = true;
            try
            {
                StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync("Database.db");
            }
            catch
            {
                dbExist = false;
            }

            return dbExist;
        }

        public async void CreateDatabase()
        {

            if (DbExist().Result)
            {
                Debug.WriteLine("existe la bd");

            }else
            {
                Debug.WriteLine("no existe la bd");
                Debug.WriteLine("jajajaj");
                SQLiteAsyncConnection connection = new SQLiteAsyncConnection("Database.db");
                await connection.CreateTableAsync<EquipoDb>();
            }
            
            
        }       

        /*
         * Carga los datos de los equipos almacenados en la carpeta local en formato .txt
         **/
       public async void insertEquipo()
        {
            try
            {
                SQLiteAsyncConnection connection = ConexionInitialDb();
                //createTable();
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                //**********************************************************
                Debug.WriteLine(storageFolder.Path);
                //**********************************************************
                StorageFolder carpetaCodigos = await storageFolder.CreateFolderAsync("Codigos", CreationCollisionOption.OpenIfExists);
                //**********************************************************
                Debug.WriteLine(carpetaCodigos.Path);
                //**********************************************************
                IReadOnlyList<StorageFile> fileList = await carpetaCodigos.GetFilesAsync();
                foreach (StorageFile file in fileList)
                {
                    //**********************************************************
                    Debug.WriteLine(file.Name);
                    Debug.WriteLine(file.Path);
                    //**********************************************************
                    if (file.Name == "codigos.txt")
                    {
                        string cadena = await FileIO.ReadTextAsync(file);
                        //**********************************************************
                        Debug.WriteLine(cadena);
                        //**********************************************************
                        string[] separadorSaltoLinea = new string []{ Environment.NewLine };
                        string[] tupla = cadena.Split(separadorSaltoLinea,StringSplitOptions.None);
                        foreach (var subTupla in tupla)
                        {
                            string[] palabra = subTupla.Split(',');
                            string serial1 = (string)palabra.GetValue(0);
                            //*****************************************************
                            Debug.WriteLine(serial1);
                            //*****************************************************
                            string nombre1 = (string)palabra.GetValue(1);
                            //*****************************************************
                            Debug.WriteLine(nombre1);
                            //*****************************************************
                            string modelo1 = (string)palabra.GetValue(2);
                            //*****************************************************
                            Debug.WriteLine(modelo1);
                            //*****************************************************
                            InitDbEquipo equipo = new InitDbEquipo { serial = serial1, nombre= nombre1, modelo=modelo1};
                            await connection.InsertAsync(equipo);
                            
                        }
                    }
                }
            }catch(Exception ex){
                Debug.WriteLine(ex);
            }
            
        }

        /*
         * Consulta en la base de datos inicial los detalles de los equipos (Solo para prueba, Eliminar)
         */
       List<EquipoDb> listaEquipos = new List<EquipoDb>();
       public async Task<List<EquipoDb>> consultarEquipo()
        {
            try
            {
                SQLiteAsyncConnection connection = new SQLiteAsyncConnection("Database.db");
                var query = await connection.QueryAsync<EquipoDb>("Select * FROM Equipos");
                //var result = await connection.QueryAsync<EquipoDb>("Select * FROM Equipos");
                //var query = await conexion.QueryAsync<EquipoDb>("Select * FROM EquipoDb");
                foreach (var data in query)
                {
                    listaEquipos.Add(new EquipoDb { Id = data.Id, Nombre = data.Nombre, Modelo = data.Modelo, Serial = data.Serial, HorometroInicial = data.HorometroInicial, HorometroFinal = data.HorometroFinal, IdDetencion = data.IdDetencion, FlagSend = data.FlagSend });
                }
                return listaEquipos;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
            
        }

       public async void insert(string nombreEquipo,string modeloEquipo,double horometroInicial,double horometroFinal)
       {
           string storageFolder = ApplicationData.Current.LocalFolder.Path;
           Debug.WriteLine(storageFolder);
           string path = Path.Combine(storageFolder,"Database.db");           
           SQLiteAsyncConnection connection = new SQLiteAsyncConnection("Database.db");
           await connection.InsertAsync(new EquipoDb() { Nombre=nombreEquipo, Modelo=modeloEquipo, Serial=52342, HorometroInicial=horometroInicial, HorometroFinal=horometroFinal, IdDetencion=1, FlagSend=false});
       }
    }
}
