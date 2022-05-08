using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Updater
{
    public partial class frmUpdate : Form
    {
        private string RutaServidor;
        private string RutaLocal;
        private string RutaTemporal;
        private List<DatoArchivo> archivosLocales;
        private List<DatoArchivo> archivosServidores;
        private List<DatoArchivo> archivos;
        private List<DatoArchivo> archivosTemp;
        public bool ExisteAcutalizacion = false;
        public bool CompletadaActualizacion = false;
        public bool todo = false;
        public string Error;
        public string nombreArchivoConfig;

        private string archivoLog = "LogActualizacacion.txt";

        public frmUpdate()
        {
            InitializeComponent();
            //RutaLocal = System.IO.Directory.GetCurrentDirectory();
            RutaLocal = @"F:\TEST UPDATE\Client";
            RutaServidor = @"F:\TEST UPDATE\Server";

            //RutaLocal = "C:\\Users\\Andres\\Desktop\\pruebas Borrado archivos\\Archivos ";
            //RutaServidor = "C:\\Users\\Andres\\Desktop\\pruebas Borrado archivos\\Archivo Cliente";

            RutaTemporal = System.IO.Path.Combine(RutaLocal, "tempUpdate");
            archivos = new List<DatoArchivo>();
            archivosLocales = new List<DatoArchivo>();
            archivosServidores = new List<DatoArchivo>();
            archivosTemp = new List<DatoArchivo>();

            btActualizar.Visible = true;
            btFicheros.Visible = true;
            btMover.Visible = true;
            btUltimaFecha.Visible = true;
            btUpdate.Visible = true;

        }

        public frmUpdate(string rutaLocal,string rutaServidor,string nombreArchivoConfig="")
        {
            InitializeComponent();
            //RutaLocal = System.IO.Directory.GetCurrentDirectory();
            RutaLocal = rutaLocal;// "\\\\172.18.2.159\\Software\\AutoUpdate\\AppBase";
            RutaServidor = rutaServidor;// "\\\\172.18.2.159\\Software\\AutoUpdate\\AppRepositorio";
            RutaTemporal = System.IO.Path.Combine(RutaLocal, "tempUpdate");
            archivos = new List<DatoArchivo>();
            archivosLocales = new List<DatoArchivo>();
            archivosServidores = new List<DatoArchivo>();
            archivosTemp = new List<DatoArchivo>();
            if (!string.IsNullOrEmpty(nombreArchivoConfig))
            {
                this.nombreArchivoConfig = nombreArchivoConfig;
                todo = GetTipoActualizacion();
            }
            this.TopMost = true;
        }

        private bool GetTipoActualizacion()
        {
            if (System.IO.File.Exists(Path.Combine(RutaServidor,nombreArchivoConfig)))
            {
                string rutaConfig = Path.Combine(RutaServidor, nombreArchivoConfig);
                
                var xDoc = new XmlDocument();
                xDoc.Load(rutaConfig);


                XmlNodeList xPersonas = xDoc.GetElementsByTagName("configuration");
                XmlNodeList xLista = ((XmlElement)xPersonas[0]).GetElementsByTagName("appSettings");
                XmlNodeList xLADD = ((XmlElement)xPersonas[0]).GetElementsByTagName("add");

                foreach (XmlElement nodo in xLADD)
                {
                    string xKey = nodo.GetAttribute("key");
                    string xValue = nodo.GetAttribute("value");
                    if (!string.IsNullOrEmpty(xKey) && xKey== "ActualizarTodo")
                    {
                        if (!string.IsNullOrEmpty(xValue))
                        {
                            if (xValue.ToLower() =="si")
                            {
                                return true;
                            }
                            else if (xValue.ToLower() == "no")
                            {
                                return false;
                            }
                        }
                    }
                    string xNombre = nodo.InnerText;

                }

            }
            return false;
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            //this.Show();
            //Thread.Sleep(1000);
            //ExisteNuevaVersion();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ((System.Windows.Forms.Timer)sender).Stop();
            ExisteNuevaVersion();
        }
        
        private void ExisteNuevaVersion()
        {
            EscribirLog("Comprobar Actualizacion");
            bool acceso=AccesoRutas();
            if (acceso)
            {
                DateTime fServidor = buscarUltimaFechaModificado(RutaServidor);
                DateTime fLocal = buscarUltimaFechaModificado(RutaLocal);
                bool Temp = System.IO.Directory.Exists(RutaTemporal) ?true : false;

                if ((fServidor > fLocal) || (Temp))
                {
                    ExisteAcutalizacion = true;
                    CheckForIllegalCrossThreadCalls = false;
                    cProgress.Start();
                    Accion("Existe una nueva version", true);
                    Task.Factory.StartNew(() =>
                    {
                        CargarListas();

                    }).ContinueWith((t) =>
                    {
                        //COPIANDO DEL SERVIDOR A TEMPORAL
                        Accion("\t\t ----> Copiar Archivos de Servidor a Temporal", true);
                        CopiarDeSevidorATemporal();
                    }).ContinueWith((t) =>
                    {
                        CargarListas(true);
                        Accion("\t\t ----> Finalizar Copiado " + archivosTemp.Count(), true);
                    }).ContinueWith((t) =>
                    {
                        //MOVIENDO DE TEMPORAL A LOCAL
                        Accion("\t\t ----> Modificando archivos de Solo Lectura", true);
                        CambiarEstadoReadOnly();

                        Accion("\t\t ----> Moviendo Archivos de Temporal a Local", true);
                        MoverTempALocal();
                        Accion("\t\t ----> Finalizar Moviendo ");
                    }).ContinueWith((t) =>
                    {

                        //ELIMINAR TEMPORAL
                        Accion("\t\t ----> Eliminar Temporal", true);
                        EliminarTemporal();
                        Accion("\t\t ----> Finalizar Eliminar ", true);
                    }).ContinueWith((t) =>
                    {
                        //CargarListas();
                        CheckForIllegalCrossThreadCalls = true;
                        cProgress.End();
                        CompletadaActualizacion = true;
                        MessageBoxTemporal.Show("Programa Actualzado", "Comprobar Actualizacion", 1);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }, TaskScheduler.FromCurrentSynchronizationContext());

                    //CheckForIllegalCrossThreadCalls = true;

                }

                else
                {

                    CompletadaActualizacion = true;
                    Accion("No existe una nueva version", true);
                    MessageBoxTemporal.Show("No existe una nueva version", "Comprobar Actualizacion", 1);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                Error = "No hay Acceso a la Rutas";
                Accion("No hay Acceso a la Rutas", true);
                MessageBoxTemporal.Show("No hay Acceso a la Rutas", "Comprobar Actualizacion", 2);
                this.DialogResult = DialogResult.Ignore;
                this.Close();
            }
        }

        private void CambiarEstadoReadOnly()
        {
            if (archivosLocales.Exists(x => x.SoloLectura == true))
            {
                foreach (DatoArchivo item in archivosLocales.Where(x => x.SoloLectura == true))
                {
                    FileAttributes fa = File.GetAttributes(item.Url);

                    fa &= ~FileAttributes.ReadOnly;
                    
                    File.SetAttributes(item.Url, fa);
                    
                }
            }
        }

        private bool AccesoRutas()
        {
            if (System.IO.Directory.Exists(RutaLocal) && System.IO.Directory.Exists(RutaServidor))
            {
                return true;
            }
            return false;
        }

        private void CargarListas(bool soloTemp =false)
        {
            txtBase.Clear();
            txtServidor.Clear();
            if (!soloTemp)
            {
                archivosLocales = buscarArchivos(RutaLocal);
                //foreach (DatoArchivo item in archivosLocales.OrderBy(x => x.Level).ThenBy(x => x.Archivo))
                //{
                //    string tabulaciones = DuplicarTexto("\t", item.Level);

                //    txtBase.Text += tabulaciones + " -> " + item.Nombre + " (" + item.Fecha.ToShortDateString() + " " + item.Fecha.ToShortTimeString() + ")" + Environment.NewLine;
                //}
                archivosServidores = buscarArchivos(RutaServidor);
                //foreach (DatoArchivo item in archivosServidores.OrderBy(x => x.Level).ThenBy(x => x.Archivo))
                //{
                //    string tabulaciones = DuplicarTexto("\t", item.Level);
                //    txtServidor.Text += tabulaciones + " -> " + item.Nombre + " (" + item.Fecha.ToShortDateString() + " " + item.Fecha.ToShortTimeString() + ")" + Environment.NewLine;
                //}
            }
            archivosTemp = buscarArchivos(RutaTemporal);
            
            
        }

        private DateTime buscarUltimaFechaModificado(string directorio)
        {
            //string directorio = System.IO.Directory.GetCurrentDirectory();
            string ultimaFecha = string.Empty;
            DateTime fecha = new DateTime(2010, 1, 1);

            //foreach (string pathArchivo in System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory()))
            foreach (string pathArchivo in System.IO.Directory.GetFiles(directorio))
            {
                if (System.IO.File.Exists(pathArchivo))
                {
                    if (!pathArchivo.Contains("LogActualizacacion"))
                    {
                        DateTime fechaArchivo = System.IO.File.GetLastWriteTime(pathArchivo);
                        if (fecha < fechaArchivo)
                        {
                            fecha = fechaArchivo;
                        }
                    }
                }
            }

            foreach (string pathArchivo in System.IO.Directory.GetDirectories(directorio))
            {
                if (System.IO.Directory.Exists(pathArchivo))
                {
                    DateTime fechaArchivo = System.IO.Directory.GetLastWriteTime(pathArchivo);
                    if (fecha < fechaArchivo)
                    {
                        fecha = fechaArchivo;
                    }
                    buscarUltimaFechaModificado(pathArchivo);

                }
            }



            ultimaFecha = fecha.ToShortDateString() + " " + fecha.ToShortTimeString();
            return fecha;
            //return string.IsNullOrEmpty(ultimaFecha) ? "" : ultimaFecha;
        }

        private List<DatoArchivo> buscarArchivos(string directorio,  int Level=0,string rutaBase="")
        {
            // string directorio = System.IO.Directory.GetCurrentDirectory();
            if (Level==0) archivos = new List<DatoArchivo>();
            if (string.IsNullOrEmpty(rutaBase)) rutaBase = directorio;
            string ultimaFecha = string.Empty;

            //foreach (string pathArchivo in System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory()))
            if (System.IO.Directory.Exists(directorio))
            {
                foreach (string pathArchivo in System.IO.Directory.GetFiles(directorio))
                {
                    if (System.IO.File.Exists(pathArchivo))
                    {
                        archivos.Add(new DatoArchivo
                        {
                            Nombre = System.IO.Path.GetFileName(pathArchivo),
                            Fecha = System.IO.File.GetLastWriteTime(pathArchivo),
                            Url = pathArchivo,
                            Archivo = true,
                            Level = Level,
                            SoloLectura = IsFileReadOnly(pathArchivo),
                            rutaBase = rutaBase,
                            rutaSinBase = pathArchivo.Substring(rutaBase.Length)

                        });
                        //if ()

                    }
                }

                foreach (string pathArchivo in System.IO.Directory.GetDirectories(directorio))
                {
                    if (System.IO.Directory.Exists(pathArchivo))
                    {
                        archivos.Add(new DatoArchivo
                        {
                            Nombre = System.IO.Path.GetFileName(pathArchivo),
                            Fecha = System.IO.File.GetLastWriteTime(pathArchivo),
                            Url = pathArchivo,
                            Level = Level,
                            rutaBase = rutaBase,
                            rutaSinBase = pathArchivo.Substring(rutaBase.Length)
                        });
                        buscarArchivos(pathArchivo, Level + 1, rutaBase);

                    }
                }
            }

            return archivos;
        }

        public static bool IsFileReadOnly(string FileName)
        {
            // Create a new FileInfo object.
            FileInfo fInfo = new FileInfo(FileName);

            // Return the IsReadOnly property value.
            return fInfo.IsReadOnly;

        }

        public class DatoArchivo
        {
            public string Nombre { get; set; }
            public DateTime Fecha { get; set; }
            public string Url { get; set; }
            public int Level { get; set; }
            public bool Archivo { get; set; }
            public string rutaBase { get; set; }
            public string rutaSinBase { get; set; }
            public bool SoloLectura { get; set; }

            public override string ToString()
            {
                string archivo = Archivo ? "1" : "0";
                string lectura = SoloLectura ? "1" : "0";
                return Nombre + "[" + Fecha.ToShortDateString() + "]" + "{" + archivo + "}" + "--->" + lectura;
                //return base.ToString(); 
            }
        }

        private void btUltimaFecha_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            txtDescripcion.Text = string.Format(" -> Ultima Fecha Modificacion Base {0},{1} -> Ultima Fecha Modificacion Servidor {2},{3} -> Numero archivos Local {4},{5} -> Numero archivos Servidores {6},{7} -> Numero archivos Temp {8}",
                                        buscarUltimaFechaModificado(RutaLocal),
                                        Environment.NewLine,
                                        buscarUltimaFechaModificado(RutaServidor),
                                        Environment.NewLine,
                                        archivosLocales.Count(),
                                        Environment.NewLine,
                                        archivosServidores.Count(),
                                        Environment.NewLine,
                                        archivosTemp.Count());
        }

        private void btFicheros_Click(object sender, EventArgs e)
        {
            CargarListas();
        }

        private string DuplicarTexto(string texto,int veces)
        {
            string resultado = string.Empty;
            if (veces > 1)
            {
                for (int i = 1; i <= veces; i++)
                {
                    resultado += texto;
                }
                return resultado;
            }
            else if (veces == 1)
            {
                return texto;
            }
            else
            {
                return string.Empty;
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {

            Accion("\t\t ----> Copiar Archivos de Servidor a Temporal");
            CopiarDeSevidorATemporal();
            CargarListas();
            Accion("\t\t ----> Finalizar Copiado " + archivosTemp.Count());
            //archivosTemp = buscarArchivos(RutaTemporal);
            CargarListas();

        }

        private void CopiarDeSevidorATemporal()
        {
            if (!System.IO.Directory.Exists(RutaTemporal))
            {
                System.IO.Directory.CreateDirectory(RutaTemporal);
            }
            foreach (DatoArchivo item in archivosServidores)
            {
                if (archivosLocales.Exists(x => x.Nombre == item.Nombre && x.Level == item.Level && x.rutaSinBase == item.rutaSinBase))
                {
                    DatoArchivo aLocal = archivosLocales.First(x => x.Nombre == item.Nombre && x.Level == item.Level && x.rutaSinBase == item.rutaSinBase);
                    if (item.Fecha > aLocal.Fecha)
                    {
                        string rutaActual = RutaTemporal + aLocal.Url.Substring(RutaLocal.Length);
                        if (item.Archivo)
                        {

                            System.IO.File.Copy(item.Url, rutaActual, true);
                            Accion(string.Format("Copiando -> {0}", item.Nombre));
                        }
                        else
                        {
                            if (!System.IO.Directory.Exists(rutaActual))
                            {
                                System.IO.Directory.CreateDirectory(rutaActual);
                                Accion(string.Format("Copiando -> {0}", item.Nombre));
                            }
                        }
                    }
                    else
                    {
                        if (todo)
                        {
                            string rutaActual = RutaTemporal + aLocal.Url.Substring(RutaLocal.Length);
                            if (item.Archivo)
                            {

                                System.IO.File.Copy(item.Url, rutaActual, true);
                                Accion(string.Format("Copiando -> {0}", item.Nombre));
                            }
                            else
                            {
                                if (!System.IO.Directory.Exists(rutaActual))
                                {
                                    System.IO.Directory.CreateDirectory(rutaActual);
                                    Accion(string.Format("Copiando -> {0}", item.Nombre));
                                }
                            }
                        }
                    }

                }
                else
                {
                    string rutaActual = RutaTemporal + item.Url.Substring(RutaServidor.Length);
                    if (item.Archivo)
                    {

                        System.IO.File.Copy(item.Url, rutaActual, true);
                        Accion(string.Format("Copiando -> {0}", item.Nombre));
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(rutaActual))
                        {
                            System.IO.Directory.CreateDirectory(rutaActual);
                            Accion(string.Format("Copiando -> {0}", item.Nombre));
                        }
                    }
                }
            }
        }

        private void btMover_Click(object sender, EventArgs e)
        {
            Accion("\t\t ----> Moviendo Archivos de Temporal a Local");
            MoverTempALocal();
            Accion("\t\t ----> Finalizar Moviendo ");


            Accion("\t\t ----> Eliminar Temporal");
            EliminarTemporal();
            Accion("\t\t ----> Finalizar Eliminar ");


            CargarListas();
        }

        private void EliminarTemporal()
        {
            if (System.IO.Directory.Exists(RutaTemporal))
            {
                //System.IO.Directory.Move(RutaTemporal, RutaLocal);
                System.IO.Directory.Delete(RutaTemporal, true);
            }
        }

        private void MoverTempALocal()
        {
            if (!System.IO.Directory.Exists(RutaLocal))
            {
                System.IO.Directory.CreateDirectory(RutaLocal);
            }
            foreach (DatoArchivo item in archivosServidores)
            {
                if (archivosLocales.Exists(x => x.Nombre == item.Nombre && x.Level == item.Level && x.rutaSinBase == item.rutaSinBase))
                {
                    DatoArchivo aLocal = archivosLocales.First(x => x.Nombre == item.Nombre && x.Level == item.Level && x.rutaSinBase == item.rutaSinBase);
                    if (item.Fecha > aLocal.Fecha)
                    {
                        string rutaActual = RutaLocal + aLocal.Url.Substring(RutaLocal.Length);
                        if (item.Archivo)
                        {
                            System.IO.File.Copy(item.Url, rutaActual, true);
                            Accion(string.Format("Moviendo -> {0} ", item.Nombre));
                        }
                        else
                        {
                            if (!System.IO.Directory.Exists(rutaActual))
                            {
                                System.IO.Directory.CreateDirectory(rutaActual);
                                Accion(string.Format("Moviendo -> {0} ", item.Nombre));
                            }
                        }
                    }
                    else
                    {
                        if (todo)
                        {
                            string rutaActual = RutaLocal + aLocal.Url.Substring(RutaLocal.Length);
                            if (item.Archivo)
                            {
                                System.IO.File.Copy(item.Url, rutaActual, true);
                                Accion(string.Format("Moviendo -> {0} ", item.Nombre));
                            }
                            else
                            {
                                if (!System.IO.Directory.Exists(rutaActual))
                                {
                                    System.IO.Directory.CreateDirectory(rutaActual);
                                    Accion(string.Format("Moviendo -> {0} ", item.Nombre));
                                }
                            }
                        }
                    }
                }
                else
                {
                    string rutaActual = RutaLocal + item.Url.Substring(RutaServidor.Length);
                    if (item.Archivo)
                    {
                        System.IO.File.Copy(item.Url, rutaActual, true);
                        Accion(string.Format("Moviendo -> {0} ", item.Nombre));
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(rutaActual))
                        {
                            System.IO.Directory.CreateDirectory(rutaActual);
                            Accion(string.Format("Moviendo -> {0} ", item.Nombre));
                        }
                    }
                }
            }
        }

        private void Accion(string mensaje,bool titulo=false)
        {
            List<string> lineas = txtDescripcion.Lines.ToList();

            lineas.Insert(0, mensaje + Environment.NewLine);

            txtDescripcion.Lines = lineas.ToArray();
            Thread.Sleep(25);
            
            if (titulo)
            {
                lblTitulo.Text = mensaje;
            }
            EscribirLog(mensaje);
        }

        private void EscribirLog(string mensaje)
        {
            string rutaLog = Path.Combine(RutaLocal, archivoLog);
            //No hace falta porque la linea del StreamWriter ya crea el archivo
            //if (!System.IO.File.Exists(rutaLog))
            //{
            //    System.IO.File.Create(rutaLog);
            //}
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(rutaLog, true))  //se crea el archivo
            {
                string fecha = DateTime.Now.ToString();
                file.WriteLine(fecha +"->"+ mensaje);
                file.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExisteNuevaVersion();
        }

        private void frmUpdate_Shown(object sender, EventArgs e)
        {
            //Thread.Sleep(1500);
            //ExisteNuevaVersion();
        }
        
    }
}
