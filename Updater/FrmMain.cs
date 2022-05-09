using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Data;
using Updater.Configuration;
using Updater.Trees;

namespace Updater
{
    public partial class FrmMain : Form
    {
        Config configs;

        private List<DatoArchivo> archivosLocales;
        private List<DatoArchivo> archivosServidores;
        private List<DatoArchivo> archivos;
        private List<DatoArchivo> archivosTemp;
        //ListView listView1;
        // ImageList imgTree;

        public FrmMain(IOptions<Config> settings)
        {
            this.configs = settings.Value;

            InitializeComponent();
            archivos = new List<DatoArchivo>();
            archivosLocales = new List<DatoArchivo>();
            archivosServidores = new List<DatoArchivo>();
            archivosTemp = new List<DatoArchivo>();
            //


            //listView1 = new ListView();
            // imgTree = new ImageList();
            //listView1.SmallImageList = imgTree;
            /* listView.Location = new Point(37, 12);
             listView.Size = new Size(151, 262);
             listView.View = View.SmallIcon;
             this.ClientSize = new System.Drawing.Size(292, 266);
             this.Controls.Add(this.listView);*/
            //ExtractAssociatedIconEx(new DirectoryInfo(configs.rutaCarpetaCliente));
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            CargarListas();
            crearArbol();

        }


        private void CargarListas()
        {
            archivosLocales = buscarArchivos(configs.rutaCarpetaCliente);
            //archivosServidores = buscarArchivos(configs.rutaCarpetaServidor);
            // var r=System.IO.Directory.GetFiles(configs.rutaCarpetaCliente,"*", SearchOption.AllDirectories);

        }

        private List<DatoArchivo> buscarArchivos(string directorio, int Level = 0, string rutaBase = "")
        {
            // string directorio = System.IO.Directory.GetCurrentDirectory();
            if (Level == 0) archivos = new List<DatoArchivo>();
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
        private void crearArbol()
        {
            tree.ImageList = imgTree;

            DatoNodo NodoCopiaSeguridad = new DatoNodo();
            NodoCopiaSeguridad.Nombre = "Copia Seguridad";
            NodoCopiaSeguridad.Level = 0;
            NodoCopiaSeguridad.nombreLevel = "CopiaSeguridad";
            tree.Nodes.Add(new TreeNode { Text = NodoCopiaSeguridad.Nombre, Tag = NodoCopiaSeguridad });


            DatoNodo NodoArchivoLocal = new DatoNodo();
            NodoArchivoLocal.Nombre = "Archivos Local";
            NodoArchivoLocal.Level = 0;
            NodoArchivoLocal.nombreLevel = "Archivos Local";
            int i = tree.Nodes.Add(new TreeNode { Text = NodoArchivoLocal.Nombre, Tag = NodoArchivoLocal });
            //cTree.tree.Nodes[i].Nodes

            LoadFolder(tree.Nodes[i].Nodes, new DirectoryInfo(configs.rutaCarpetaCliente));
            
            DatoNodo NodoArchivoServidor = new DatoNodo();
            NodoArchivoServidor.Nombre = "Archivos Servidor";
            NodoArchivoServidor.Level = 0;
            NodoArchivoServidor.nombreLevel = "Archivos Local";
            int s = tree.Nodes.Add(new TreeNode { Text = NodoArchivoServidor.Nombre, Tag = NodoArchivoServidor });
            //cTree.tree.Nodes[i].Nodes

             LoadFolder(tree.Nodes[s].Nodes, new DirectoryInfo(configs.rutaCarpetaServidor));

        }

        private void LoadFolder(TreeNodeCollection nodes, DirectoryInfo folder)
        {
            ListViewItem item;
            TreeNode newNode = nodes.Add(folder.Name);
            if (!string.IsNullOrEmpty(folder.Extension))
            {
                newNode.ImageKey = folder.Extension;
            }
            else
            {
                newNode.ImageKey = "folder";
            }

            foreach (DirectoryInfo childFolder in folder.EnumerateDirectories())
            {
                LoadFolder(newNode.Nodes, childFolder);
            }
            foreach (FileInfo file in folder.EnumerateFiles())
            {
                Icon iconForFile = SystemIcons.WinLogo;

                item = new ListViewItem(file.Name, 1);

                if (!imgTree.Images.ContainsKey(file.Extension))
                {
                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(file.FullName);
                    imgTree.Images.Add(file.Extension, iconForFile);

                    item.ImageKey = file.Extension;
                    listView1.Items.Add(item);
                }

                TreeNode nodoArchivo = new TreeNode();
                nodoArchivo.Text = file.Name;
                nodoArchivo.ImageKey = file.Extension;
                newNode.Nodes.Add(nodoArchivo);
            }

            //return nodes;
        }

        public void ExtractAssociatedIconEx(DirectoryInfo dir)
        {
            listView1.SmallImageList = imgTree;
            listView1.View = View.SmallIcon;
            ListViewItem item;
            listView1.BeginUpdate();
            foreach (System.IO.FileInfo file in dir.GetFiles("*", SearchOption.AllDirectories))
            {
                // Set a default icon for the file.
                Icon iconForFile = SystemIcons.WinLogo;

                item = new ListViewItem(file.Name, 1);

                if (!imgTree.Images.ContainsKey(file.Extension))
                {
                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(file.FullName);
                    imgTree.Images.Add(file.Extension, iconForFile);

                    item.ImageKey = file.Extension;
                    listView1.Items.Add(item);
                }
            }
            listView1.EndUpdate();
        }

        private void expandirTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tree.ExpandAll();
        }

        private void contraerTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tree.CollapseAll();
        }
    }
}
