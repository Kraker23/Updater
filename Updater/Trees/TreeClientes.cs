using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackGroundWorked_ALG;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Columns;
using AdPlanningSharp.BL;
using System.Data.Entity;
using AdPlanningSharp.Controles;
using System.Reactive.Linq;

namespace Updater
{
    public partial class TreeClientes : UserControl
    {
        #region Parametros
        public delegate void NuevoCheck();
        public event NuevoCheck nuevoCheckEvento;
        //public event NuevoCheck checkAltaLCCEvento;
        public event EventHandler SeleccionNodoEvent;


        public delegate bool NuevoCheckAlta(string id);
        public event NuevoCheckAlta checkAltaLCCEvento;

        public delegate void RecargarDatos();
        public event RecargarDatos recargarDatosEvento;

        public delegate void DuplicarCampaña();
        public event DuplicarCampaña duplicarCampañaEvento;

        public delegate void CargarCache();
        public event CargarCache CargarCacheEvento;

        public enum eOpcion
        {
            ListadoPases,
            Calendario,
            Seguimiento,
            Configuración,
            AsignarInventario,
            Adjudicar,
            CargarpasePlanificados,
            SeleccionNodo,
            ActivarCampana
        }

        public class FiltroCadenaAlias
        {
            public int idCadenaAlias { get; set; }
            public string CodCadenaAlias { get; set; }
        }

        public class FiltroCadenaAliasAccion
        {
            public int idCadenaAlias { get; set; }
            public string CodCadenaAlias { get; set; }
            public string Accion { get; set; }
            public bool esLCC { get; set; }
            public bool PuedeEnviarse { get; set; }
            public bool TieneFranja { get; set; }
            public bool FaltaRelacion { get; set; }
            public string InfoRelacion { get; set; }
        }

        public class DatoNodo
        {
            public string id { get; set; }
            public string Nombre { get; set; }
            public string Accion { get; set; }
            public TreeLevel Level { get; set; }
            public int idPadre { get; set; }
            public bool esLCC { get; set; }
            public bool PuedeEnviarse { get; set; }
        }


        //public enum eTiposNodos
        //{

        //     Agencia =1 ,
        //     Oficjna = 2,
        //     ClienteId = 3
        //     DivisionId = 
        //     MarcaId { get; se
        //     ProductoId { get;
        //     CampanaMaestraId 

        //}

        public class DatoNodoEncontrado
        {
            public string Agencia { get; set; }
            public string Oficjna { get; set; }
            public int ClienteId { get; set; }
            public int DivisionId { get; set; }
            public int MarcaId { get; set; }
            public int ProductoId { get; set; }
            public int CampanaMaestraId { get; set; }
            public string CodCampanaMaestra { get; set; }
            public string idCampCompra { get; set; }
            public bool Cli_Inactivo { get; set; }
            public bool? UsoAdp { get; set; }
            public string ClienteCod { get; set; }
            public string ProductoCod { get; set; }
            public eOpcion Opcion { get; set; }
            public bool CampanaMBS { get; set; }
        }

        #endregion

        #region Variables


        public CachexUsuario CacheUsuario { get; set; }
        private List<DatoNodoEncontrado> LstNodoSeleccionados = new List<DatoNodoEncontrado>();
        //CachexUsuario CacheYUsuario = null;
        //CachexUsuario CacheZUsuario = null;

        public enum TreeLevel { Agencia = 1, Oficina = 2, Cliente = 3, Ejercicio = 4, Division = 5, Marca = 6, Producto = 7, CampanaMaestra = 8, DatosCampana = 9, CadenaAlias = 10, EstadoMbs = 11 }
        public enum FiltroClientes : int { Activos = 0, InActivos = 1, Todos = 2 }
        public enum FiltroAdp { MBS = 0, AdP = 1, Todos = 2 }


        public List<string> EstadosMBS = new List<string>();
        private List<DatoNodoEncontrado> LlstFiltro = new List<DatoNodoEncontrado>();

        public List<string> FiltroCampanaMBs { get; set; }
        public List<FiltroCadenaAlias> FiltroCadenasAlias { get; set; }
        public List<FiltroCadenaAliasAccion> FiltroCadenasAliasAccion { get; set; }

        private TreeLevel _Inicial;
        private TreeLevel _Final;

        //private DM.AdPlanningCliente ent;
        //private List<DM.CLClientes> clientesEF;
        //private List<DM.CLClientesDiv> divisionEF;
        //private List<DM.CLClientesDivMar> marcaEF;
        //private List<DM.CLClientesDivMarProducto> productoEF;
        //private List<DM.ClClientesAgencia> AgenciaEF;
        //private List<DM.ClClientesOficina> OficinaEF;


        private List<DatoNodo> Agencias = new List<DatoNodo>();
        private List<DatoNodo> Oficinas = new List<DatoNodo>();
        private List<DatoNodo> Clientes = new List<DatoNodo>();
        private List<DatoNodo> Divisiones = new List<DatoNodo>();
        private List<DatoNodo> Marcas = new List<DatoNodo>();
        private List<DatoNodo> Productos = new List<DatoNodo>();
        private List<DatoNodo> Campanas = new List<DatoNodo>();


        private List<DatoNodo> Agencias_A_Buscar = new List<DatoNodo>();
        private List<DatoNodo> Oficinas_A_Buscar = new List<DatoNodo>();
        private List<DatoNodo> Clientes_A_Buscar = new List<DatoNodo>();
        private List<DatoNodo> Divisiones_A_Buscar = new List<DatoNodo>();
        private List<DatoNodo> Marcas_A_Buscar = new List<DatoNodo>();
        private List<DatoNodo> Productos_A_Buscar = new List<DatoNodo>();
        private List<DatoNodo> Campanas_A_Buscar = new List<DatoNodo>();



        private bool showCheckbox = false;

        /// <summary> Muestra CheckBoxes en el arbol</summary>
        [System.ComponentModel.ToolboxItem(true)]
        public bool ShowCheckbox
        {
            get { return showCheckbox; }
            set
            {
                showCheckbox = value;
                treeData.OptionsView.ShowCheckBoxes = showCheckbox;
            }
        }

        [System.ComponentModel.ToolboxItem(true)]
        public TreeLevel PrimerNivel { get; set; }

        [System.ComponentModel.ToolboxItem(true)]
        public TreeLevel UltimoNivel { get; set; }

        public TreeLevel ActiveTreeLevel;
        public DM.SimpleTreeData ActiveData;

        #endregion


        #region Constructores

        public TreeClientes()
        {
            InitializeComponent();
        }

        #endregion


        #region Eventos


        #region propiedades


        public string CodCampanaMaestra
        {
            get
            {

                string result = string.Empty;
                DatoNodo nodo = (DatoNodo)treeData.Selection[0].Tag;

                if (nodo.Level == TreeLevel.CampanaMaestra)
                {
                    result = nodo.Nombre;
                }
                return result;
            }
        }


        public int CampanaMaestraId
        {
            get
            {

                int result = 0;
                DatoNodo nodo = (DatoNodo)treeData.Selection[0].Tag;

                if (nodo.Level == TreeLevel.CampanaMaestra)
                {
                    result = Convert.ToInt32(nodo.id);
                }
                return result;
            }
        }


        public int ClienteId
        {
            get
            {

                int result = 0;
                DatoNodo nodo = (DatoNodo)treeData.Selection[0].Tag;

                if (nodo.Level == TreeLevel.CampanaMaestra)
                {


                    DatoNodo Cliente = (DatoNodo)treeData.Selection[0].ParentNode.ParentNode.ParentNode.ParentNode.Tag;
                    result = Convert.ToInt32(Cliente.id);
                }
                return result;
            }
        }


        public string ClienteCod
        {
            get
            {

                string result = string.Empty;
                DatoNodo nodo = (DatoNodo)treeData.Selection[0].Tag;

                if (nodo.Level == TreeLevel.CampanaMaestra)
                {


                    DatoNodo Cliente = (DatoNodo)treeData.Selection[0].ParentNode.ParentNode.ParentNode.ParentNode.Tag;
                    result = Cliente.Nombre;
                }
                return result;
            }
        }

        public int DivisionId
        {
            get
            {

                int result = 0;
                DatoNodo nodo = (DatoNodo)treeData.Selection[0].Tag;

                if (nodo.Level == TreeLevel.CampanaMaestra)
                {


                    DatoNodo Division = (DatoNodo)treeData.Selection[0].ParentNode.ParentNode.ParentNode.Tag;
                    result = Convert.ToInt32(Division.id);
                }
                return result;
            }
        }

        public int MarcaId
        {
            get
            {

                int result = 0;
                DatoNodo nodo = (DatoNodo)treeData.Selection[0].Tag;

                if (nodo.Level == TreeLevel.CampanaMaestra)
                {


                    DatoNodo Marca = (DatoNodo)treeData.Selection[0].ParentNode.ParentNode.Tag;
                    result = Convert.ToInt32(Marca.id);
                }
                return result;
            }
        }


        public int ProductoId
        {
            get
            {

                int result = 0;
                DatoNodo nodo = (DatoNodo)treeData.Selection[0].Tag;

                if (nodo.Level == TreeLevel.CampanaMaestra)
                {


                    DatoNodo Producto = (DatoNodo)treeData.Selection[0].ParentNode.Tag;
                    result = Convert.ToInt32(Producto.id);
                }
                return result;
            }
        }

        public string ProductoCod
        {
            get
            {

                string result = string.Empty;
                DatoNodo nodo = (DatoNodo)treeData.Selection[0].Tag;

                if (nodo.Level == TreeLevel.CampanaMaestra)
                {


                    DatoNodo Producto = (DatoNodo)treeData.Selection[0].ParentNode.Tag;
                    result = Producto.Nombre;
                }
                return result;
            }
        }

        #endregion


        public void DesactivarMenusOpciones()
        {
            toolStripSeparator1.Visible = false;
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;
            activarCampañaToolStripMenuItem.Visible = false;
            listadoPasesToolStripMenuItem.Visible = false;
            calendarioToolStripMenuItem.Visible = false;
            seguimientoToolStripMenuItem.Visible = false;
            configuraciónToolStripMenuItem.Visible = false;
            asignarInventarioToolStripMenuItem.Visible = false;
            adjudicarToolStripMenuItem.Visible = false;
            cargarPasesComoPlanificadosToolStripMenuItem.Visible = false;

        }
        public void ActivarDesactivarMenu(bool estado)
        {
            toolStrip1.Visible = estado;
        }



        public void ActivarDesactivarCheckBox(bool estado)
        {

            treeData.OptionsView.ShowCheckBoxes = estado;


        }
        private void AplicarFiltros()
        {


        }
        private void cmPaletaCampañas()
        {

            DialogResult dialogResult = MessageBox.Show("¿Deseas activar la campaña para Adp?", "Activación Campaña", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                //do something

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }
        //private  AgenciaOficina_cache GetOficina()
        //{
        //        CacheUsuario.AgenciaOficina_cache.Where
        //}


        private void RecursivoTreeBuscar(string texto)
        {
            // int a = 0;

            try
            {
                //getBuscar(texto);

                if (texto.Length >= 1)
                {
                    Start(_Inicial, _Final);
                    treeData.BeginUpdate();
                    treeData.ExpandAll();
                    treeData.EndUpdate();
                }
                //ExpandirContraer(treeData.Nodes, true);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }



        private void Rx()
        {
            var textChangedObservable = Observable.FromEventPattern<EventArgs>(txtBuscar, "TextChanged").Select(evt => ((System.Windows.Forms.ToolStripTextBox)evt.Sender).Text).Throttle(TimeSpan.FromMilliseconds(500)).Select(timestampedText => txtBuscar.Text).Where(text => text != null).DistinctUntilChanged();


            textChangedObservable.ObserveOn(this).Subscribe(
                    words =>
                    {
                        RecursivoTreeBuscar(txtBuscar.Text);
                    });


            //var textChanged = Observable.FromEventPattern<EventHandler, EventArgs>
            //  (
            //   handler => handler.Invoke,
            //   h => textBox3.TextChanged += h,
            //   h => textBox3.TextChanged -= h
            //  );


            // textChanged
            // .ObserveOn(this) // scheduled on the Form's scheduler
            // .Subscribe(x => textBox2.Text =
            // textBox3.Text
            // .Split()
            // .DefaultIfEmpty()
            // .Where(s => s.Trim().Length > 0)
            // .Count()
            // .ToString());


        }

        /// <summary> Cargar la configuracion del control y cargar datos </summary>
        private void TreeClientes_Load(object sender, EventArgs e)
        {
            //if (!this.DesignMode)
            //{
            cboxCbAdP.SelectedItem = "MBS";
            cboxClientes.SelectedItem = "Cli. Activos";


            EstadosMBS.Add("Alta");
            EstadosMBS.Add("Bajas");
            EstadosMBS.Add("Modificacion");

            /* Activamos reactive extension */
            Rx();

            //textChangedObservable.ObserveOn(txtBuscar).Subscribe(Sub() BuscarTextoTree(txtBuscar.Text))


            //treeData.Appearance.SelectedRow.BackColor = Color.BlueViolet;
            //treeData.Appearance.FocusedCell.BackColor = Color.BlueViolet;

            //treeData.OptionsSelection.EnableAppearanceFocusedRow = true;


            //treeData.Appearance.OddRow.BackColor = Color.LightSteelBlue;

            //    configTree();
            //    loadData();
            //}
        }

        /// <summary> Cargar Partes del Arbol Dependiendo que nodo se haya abierto </summary>
        private void treeData_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            treeData.BeginUpdate();
            DatoNodo Valor = (DatoNodo)e.Node.Tag;
            if (Valor.Level.ToString() == "2")
            {
                treeData.Appearance.Row.ForeColor = Color.Yellow;
            }

            if (Valor.Level == TreeLevel.Agencia)
            {
                AgregarNodosOficinas(e, Valor);
            }
            else if (Valor.Level == TreeLevel.Oficina)
            {
                AgregarNodosClientes(e, Valor);
            }
            else if (Valor.Level == TreeLevel.Cliente)
            {
                AgregarNodosDivisiones(e);
            }
            else if (Valor.Level == TreeLevel.Division)
            {
                AgregarNodosMarcas(e);
            }
            else if (Valor.Level == TreeLevel.Marca)
            {
                AgregarNodosProducto(e);
            }
            else if (Valor.Level == TreeLevel.Producto)
            {
                AgregarNodosCampañas(e);
            }
            else if (Valor.Level == TreeLevel.CampanaMaestra)
            {
                AgregarNodosSoporte(e);
            }
            else if (Valor.Level == TreeLevel.CadenaAlias)
            {
                AgregarEstadosMBS(e);
            }

            treeData.EndUpdate();
        }

        /// <summary> Actualizar la configuracion y Volver a cargar los datos </summary>
        private void btRefrescarTreeClientes_Click(object sender, EventArgs e)
        {
            recargarDatosEvento();
            if (!this.DesignMode)
            {

                Start(_Inicial, _Final);
                //configTree();
                //loadData();
            }
        }

        private void Buscar()
        {

            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                if (treeData != null)
                {
                    getBuscar(txtBuscar.Text);
                }
            }
            else
            {
                MessageBox.Show("No hay texto a buscar");
            }
        }
        /// <summary> Buscar dentro del arbol, cargando todos los datos del arbol</summary>
        private void btBuscarTreeClientes_Click(object sender, EventArgs e)
        {
            //cboxClientes.SelectedItem.ToString();
            //cboxCbAdP.SelectedItem.ToString();
            Buscar();
        }

        /// <summary> Boton Derecho Expandir todo </summary>
        private void expandirTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeData.AllNodesCount != 0)
                treeData.Selection[0].ExpandAll();

            //treeData.Selection[0].Expanded = true;
        }

        /// <summary> Boton Derecho Contraer todo </summary>
        private void contraerTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeData.AllNodesCount != 0)
                treeData.Selection[0].Expanded = false;
            //treeData.CollapseAll();
            //treeData.Selection[0].CollapseAll();
            //treeData.Selection[0].Nodes[0].
        }

        /// <summary> Colores del Texto de Campañas </summary>
        private void treeData_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {



            if (e.Node.Tag != null)
            {
                DatoNodo item = (DatoNodo)e.Node.Tag;

                if (item.Level == TreeLevel.Cliente)
                {
                    var cliente = CacheUsuario.Clientes_cache.Where(x => x.IdCliente.ToString() == item.id).Single();


                    if (cliente.Inactivo == true)
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }

                }

                if (item.Level == TreeLevel.CampanaMaestra)
                {
                    var campana = CacheUsuario.PlCampanaMaestra_cache.Where(x => x.idCampanaMaestra.ToString() == item.id).Single();



                    if (campana.EstadoCampanaMaestra == false)
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                    else
                        if (campana.usoAdp == false)
                    {
                        e.Appearance.ForeColor = Color.Gray;

                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Italic);

                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }

                    // if (txtBuscar.Text != string.Empty)
                    // {
                    //     if (item.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()) || (campana.IdCampCompra ?? "").ToLower().Contains(txtBuscar.Text.ToLower()))
                    //     {
                    //         e.Appearance.ForeColor = Color.White;
                    //         e.Appearance.BackColor = Color.DarkBlue;

                    //     }
                    //}

                    //e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }

                if(item.Level==TreeLevel.EstadoMbs)
                {
                    if (item.esLCC && !item.PuedeEnviarse)
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
            //if (e.Node.Level.ToString() == "6")
            //{
            //    foreach (var item in CacheUsuario.PlCampanaMaestra_cache.Where(x => x.idCampanaMaestra.ToString() == ((DatoNodo)e.Node.Tag).id).OrderBy(y => y.CodCampanaMaestra))
            //    {
            //        //si la campaña esta activa, en MBS y en ADP
            //        if ((item.EstadoCampanaMaestra == true) && (item.CampanaMBS == true) && (item.usoAdp == true))
            //        {
            //            e.Appearance.ForeColor = Color.Blue;
            //            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            //        }
            //        //si la campaña esta activa, no en MBS y en ADP
            //        else if ((item.EstadoCampanaMaestra == true) && (item.CampanaMBS == false) && (item.usoAdp == true))
            //        {
            //            e.Appearance.ForeColor = Color.Blue;
            //            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            //        }
            //        //si la campaña esta desactiva, en MBS y en ADP
            //        else if ((item.EstadoCampanaMaestra == false) && (item.CampanaMBS == true) && (item.usoAdp == true))
            //        {
            //            e.Appearance.ForeColor = Color.Red;
            //            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            //            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Italic);
            //        }
            //        //si la campaña esta desactiva, en MBS y no en ADP
            //        else if ((item.EstadoCampanaMaestra == false) && (item.CampanaMBS == true) && (item.usoAdp == false))
            //        {
            //            e.Appearance.ForeColor = Color.Gray;
            //            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Italic);
            //        }
            //        //si la campaña esta activa, en MBS y no en ADP
            //        else if ((item.EstadoCampanaMaestra == true) && (item.CampanaMBS == true) && (item.usoAdp == false))
            //        {
            //            e.Appearance.ForeColor = Color.Gray;
            //            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            //        }
            //        //
            //        else
            //        {
            //            e.Appearance.BackColor = Color.Green;
            //        }
            //    }
            //}
            //if (!string.IsNullOrEmpty(txtTextoBuscarTreeClientes.Text))
            //{
            //    if (((DatoNodo)e.Node.Tag).Nombre.ToLower().Contains(txtTextoBuscarTreeClientes.Text.ToLower()))
            //    {
            //        e.Appearance.BackColor = Color.Green;
            //        //e.Appearance.ForeColor = Color.Yellow;
            //    }
            //}
        }




        private void ExpandirContraer(DevExpress.XtraTreeList.Nodes.TreeListNodes nodo, bool estado)
        {

            foreach (TreeListNode item in nodo)
            {
                item.Expanded = estado;
                if (item.Nodes != null && ((DatoNodo)item.Tag).Level != TreeLevel.Producto)
                    ExpandirContraer(item.Nodes, estado);

            }


        }
        private void ExpandirContraer(DevExpress.XtraTreeList.Nodes.TreeListNode nodo)
        {

            nodo.Expanded = false;
            nodo.Expanded = true;

            if (nodo.ParentNode != null)
                ExpandirContraer(nodo.ParentNode);


        }

        private void cboxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {







            //if (treeData.Nodes.Count > 0)
            Start(TreeLevel.Agencia, TreeLevel.CampanaMaestra);
            //ExpandirContraer(treeData.Selection[0]);

            switch (cboxClientes.Text)
            {
                //case "Activos": 
                //    FiltroActivas(true, false);
                //    break;
                //case "InActivos": 
                //    FiltroActivas(false, false);
                //    break;
                //case "Todos": 
                //    FiltroActivas(false, true);
                //    break;
                default:
                    break;
            }
        }

        /// <summary>Seleccion MBS-ADP-Todas 
        /// Buscar en el cacheusuario las campañas de MBS,ADP o todas, una vez encontradas, buscas el padre hasta llegar arriba, i luego vas abriendo uno a uno hasta llegar a campaña
        /// </summary>
        private void cboxCbAdP_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (treeData.Nodes.Count > 0)
                Start(TreeLevel.Agencia, TreeLevel.CampanaMaestra);
            //ExpandirContraer(treeData.Selection[0]);
            //treeData.RefreshNode(treeData.Nodes[0]);
            switch (cboxCbAdP.Text)
            {
                //case "MBS": 
                //    FiltroAdpMbs(true, false);
                //    break;
                //case "AdP": 
                //    FiltroAdpMbs(false, true);
                //    break;
                //case "Todos":
                //    FiltroAdpMbs(true, true);
                //    break;
                default:
                    break;
            }
        }

        #endregion


        #region Funciones

        /// <summary> Configuración del arbol </summary>
        private void configTree()
        {
            treeData.OptionsBehavior.AllowExpandOnDblClick = true;
            treeData.OptionsBehavior.Editable = false;

            treeData.OptionsView.ShowIndicator = false;
            treeData.OptionsView.ShowColumns = false;
            treeData.OptionsView.ShowHorzLines = false;
            treeData.OptionsView.ShowVertLines = false;
            treeData.TreeLineStyle = LineStyle.None;

            treeData.Columns.Clear();

            treeData.Columns.Add();
            treeData.Columns[0].Caption = "Customer";
            treeData.Columns[0].VisibleIndex = 0;
            treeData.Columns[0].OptionsColumn.AllowEdit = false;
            treeData.Columns[0].OptionsColumn.ReadOnly = true;
            treeData.BestFitColumns();
        }

        public void Start(TreeLevel Inicial, TreeLevel Final)
        {
            try
            {
                //cboxCbAdP.SelectedIndex = 2;
                //cboxClientes.SelectedIndex = 0;
                _Inicial = Inicial;
                _Final = Final;

                treeData.ClearNodes();




                treeData.Appearance.SelectedRow.BackColor = Color.CadetBlue;
                treeData.Appearance.FocusedCell.BackColor = Color.CadetBlue;

                //treeData.OptionsSelection.EnableAppearanceFocusedRow = true;

                LstNodoSeleccionados = new List<DatoNodoEncontrado>();
                //if (CacheUsuario==null)
                //{
                //    CargarCacheEvento();
                //}

                LstNodoSeleccionados = (from cam in CacheUsuario.PlCampanaMaestra_cache
                                        join pro in CacheUsuario.Producto_cache on cam.IdProducto equals pro.IdProducto
                                        join mar in CacheUsuario.Marca_cache on pro.IdMarca equals mar.IdMarca
                                        join div in CacheUsuario.Division_cache on mar.IdDivision equals div.IdDivision
                                        join cli in CacheUsuario.Clientes_cache on div.IdCliente equals cli.IdCliente
                                        join ofi in CacheUsuario.AgenciaOficina_cache on cli.IdCliente equals ofi.IdCliente
                                        select new DatoNodoEncontrado { Agencia = ofi.CompanyId, Oficjna = ofi.OfficeNameNative, CampanaMaestraId = cam.idCampanaMaestra, ClienteId = cli.IdCliente, DivisionId = div.IdDivision, MarcaId = mar.IdMarca, ProductoId = pro.IdProducto, CodCampanaMaestra = cam.CodCampanaMaestra, Cli_Inactivo = cli.Inactivo, idCampCompra = cam.IdCampCompra, CampanaMBS = cam.CampanaMBS, UsoAdp = cam.usoAdp }
                             ).ToList();



                if (FiltroCampanaMBs != null)
                {
                    LstNodoSeleccionados = LstNodoSeleccionados.Where(x => FiltroCampanaMBs.Contains(x.idCampCompra)).ToList();
                }

                var filtroCliente = new bool[] { true }; ;
                if (cboxClientes.SelectedIndex == Convert.ToInt32(FiltroClientes.Activos))
                    filtroCliente = new bool[] { false };
                //filtro = "1";
                else if (cboxClientes.SelectedIndex == Convert.ToInt32(FiltroClientes.InActivos))
                {
                    filtroCliente = new bool[] { true };
                }
                else
                    filtroCliente = new bool[] { false, true };



                var filtroAdp = new bool[] { true }; ;
                if (cboxCbAdP.Text == FiltroAdp.AdP.ToString())
                    filtroAdp = new bool[] { false };
                //filtro = "1";
                else if (cboxCbAdP.Text == FiltroAdp.MBS.ToString())
                {
                    filtroAdp = new bool[] { true };
                }
                else
                    filtroAdp = new bool[] { false, true };




                var filtroCampanasActivas = new bool[] { true }; ;
                if (btCampanasActivas.CheckState == CheckState.Checked)
                    filtroCampanasActivas = new bool[] { true };
                //filtro = "1";
                else if (btCampanasActivas.CheckState == CheckState.Unchecked)
                {
                    filtroCampanasActivas = new bool[] { false, true };
                }
                //else
                //    filtroCampanasActivas = new bool[] { false, true };



                string txt = this.txtBuscar.Text;

                LlstFiltro = new List<DatoNodoEncontrado>();

                LlstFiltro = LstNodoSeleccionados.Where(y => filtroCliente.Contains(y.Cli_Inactivo) && filtroAdp.Contains(y.CampanaMBS) && filtroCampanasActivas.Contains(y.UsoAdp ?? false)).ToList(); //&& y.CodCampanaMaestra.ToLower().Contains(txt.ToLower()) || (y.idCampCompra ?? "").Contains(txt.ToLower()))).ToList();


                if (txt != string.Empty)
                {
                    LlstFiltro = LlstFiltro.Where(y => y.CodCampanaMaestra.ToLower().Contains(txt.ToLower()) || (y.idCampCompra ?? "").Contains(txt.ToLower())).ToList();
                }

                configTree();


                treeData.BeginUpdate();

                if (TreeLevel.Agencia == Inicial)
                {
                    List<string> distinctAgencia = LlstFiltro.Select(y => y.Agencia.ToString()).Distinct().ToList();

                    foreach (var Agencia in CacheUsuario.AgenciaOficina_cache.Where(z => distinctAgencia.Contains(z.CompanyId)).OrderBy(x => x.OfficeNameNative).Select(y => new { Agencia = (string)y.CompanyId }).Distinct())
                    {
                        //DevExpress.XtraTreeList.Nodes.TreeListNode node = new TreeListNode();
                        DatoNodo Nodo = new DatoNodo();
                        Nodo.id = Agencia.Agencia;
                        Nodo.Nombre = Agencia.Agencia;
                        Nodo.Level = TreeLevel.Agencia;

                        DevExpress.XtraTreeList.Nodes.TreeListNode node = treeData.Nodes.Add(new object[] { Agencia.Agencia });

                        //node.SetValue(0, Agencia.Agencia);
                        node.ImageIndex = 0;
                        node.SelectImageIndex = 0;
                        node.Tag = Nodo;
                        node.Nodes.Add("");
                    }
                }



                treeData.EndUpdate();


            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }

        /// <summary> Cargar Datos en el TreeData </summary>
        //private void loadData()
        //{
        //    treeData.Nodes.Clear();

        //    Action bgFunc = new Action(() =>
        //    {
        //        ent = new DM.AdPlanningCliente();

        //        ent.Configuration.LazyLoadingEnabled = true;

        //        CargaArbol();
        //    });

        //    Action uiFunc = new Action(() => fillTree());

        //    MyProcessControl backWork = new MyProcessControl(this);
        //    backWork.BackColor = Color.White;
        //    backWork.Enabled = true;
        //    backWork.Visible = true;
        //    backWork.TicsNum = 5;
        //    backWork.Height = 75;
        //    backWork.Width = 200;
        //    backWork.CuadroColorRelleno = Color.CornflowerBlue;
        //    backWork.Efecto = MyProcessControl.eEfecto.Kid;

        //    backWork.Proceso(bgFunc, uiFunc);
        //}

        ///// <summary> Cargar el Arbol Inicial dependiendo cual es el PrimerNivel definido por Defecto </summary>
        //private void CargaArbol()
        //{
        //    if (PrimerNivel == TreeLevel.Cliente)
        //    {
        //        clientesEF = BL.Cliente.GetClientesUsuario(ent, 1);
        //    }
        //    else if (PrimerNivel == TreeLevel.Division)
        //    {
        //        divisionEF = BL.Cliente.GetDivisonUsuario(ent, 1);
        //    }
        //    else if (PrimerNivel == TreeLevel.Marca)
        //    {
        //        marcaEF = BL.Cliente.GetMarcaUsuario(ent, 1);
        //    }
        //    else if (PrimerNivel == TreeLevel.Producto)
        //    {
        //        productoEF = BL.Cliente.GetProductoUsuario(ent, 1);
        //    }
        //    else
        //    {
        //        clientesEF = BL.Cliente.GetClientesUsuario(ent, 1);
        //    }
        //}

        ///// <summary> Poner en el TreeData los nodos</summary>
        //private void fillTree()
        //{
        //    treeData.BeginUpdate();

        //    treeData.Nodes.Clear();

        //    CargarTree();

        //    treeData.EndUpdate();
        //}

        ///// <summary> Cargar Todo el Arbol Entero</summary>
        //private void CargarTree()
        //{
        //    if (clientesEF != null)
        //    {
        //        foreach (var cli in clientesEF.OrderBy(x => x.CodCliente))
        //        {
        //            var nodoCli = treeData.Nodes.Add(new object[] { cli.CodCliente });
        //            nodoCli.Tag = cli;
        //            nodoCli.Nodes.Add(new object[] { "-" }).Tag = null;
        //        }
        //    }
        //    if (divisionEF != null)
        //    {
        //        foreach (var div in divisionEF.OrderBy(x => x.CodDivision))
        //        {
        //            var nodoDiv = treeData.Nodes.Add(new object[] { div.CodDivision });
        //            nodoDiv.Tag = div;
        //            nodoDiv.Nodes.Add(new object[] { "-" }).Tag = null;
        //        }
        //    }
        //    if (marcaEF != null)
        //    {
        //        foreach (var marc in marcaEF.OrderBy(x => x.CodMarca))
        //        {
        //            var nodoMarc = treeData.Nodes.Add(new object[] { marc.CodMarca });
        //            nodoMarc.Tag = marc;
        //            nodoMarc.Nodes.Add(new object[] { "-" }).Tag = null;
        //        }
        //    }
        //    if (productoEF != null)
        //    {
        //        foreach (var pro in productoEF.OrderBy(x => x.CodProducto))
        //        {
        //            var nodoPro = treeData.Nodes.Add(new object[] { pro.CodProducto });
        //            nodoPro.Tag = pro;
        //            nodoPro.Nodes.Add(new object[] { "-" }).Tag = null;
        //        }
        //    }
        //}

        /// <summary> Buscar Dentro del Arbol si encuentra alguna coincidencia</summary>
        /// <param name="txtCompare"> Texto del txtBox para buscar en el arbol</param>
        private void getBuscar(string txt)
        {

            //treeData.CollapseAll();
            //ExpandirContraer(treeData.Nodes);
            treeData.BeginUpdate();
            //treeData.Nodes[0].Expanded = false;
            treeData.NodesIterator.DoLocalOperation(new CustomNodeOperation(), treeData.Nodes);


            DatoNodo N = new DatoNodo();
            foreach (var item in CacheUsuario.PlCampanaMaestra_cache.FindAll(x => x.CodCampanaMaestra.ToLower().Contains(txt.ToLower()) || (x.IdCampCompra ?? "").Contains(txt.ToLower())))
            {
                N = new DatoNodo();
                N.id = item.idCampanaMaestra.ToString();
                N.Level = TreeLevel.CampanaMaestra;
                N.Nombre = item.CodCampanaMaestra;
                N.idPadre = item.IdProducto;
                Campanas.Add(N);

            }



            //
            LstNodoSeleccionados = new List<DatoNodoEncontrado>();

            LstNodoSeleccionados = (from cam in Campanas
                                    join ca in CacheUsuario.PlCampanaMaestra_cache on cam.id equals ca.idCampanaMaestra.ToString()
                                    join pro in CacheUsuario.Producto_cache on ca.IdProducto equals pro.IdProducto
                                    join mar in CacheUsuario.Marca_cache on pro.IdMarca equals mar.IdMarca
                                    join div in CacheUsuario.Division_cache on mar.IdDivision equals div.IdDivision
                                    join cli in CacheUsuario.Clientes_cache on div.IdCliente equals cli.IdCliente
                                    join ofi in CacheUsuario.AgenciaOficina_cache on cli.IdCliente equals ofi.IdCliente
                                    select new DatoNodoEncontrado { Agencia = ofi.CompanyId, Oficjna = ofi.OfficeNameNative, CampanaMaestraId = ca.idCampanaMaestra, ClienteId = cli.IdCliente, DivisionId = div.IdDivision, MarcaId = mar.IdMarca, ProductoId = pro.IdProducto }
                         ).ToList();






            foreach (DatoNodoEncontrado item in LstNodoSeleccionados)
            {
                Recursiva(treeData.Nodes, item, TreeLevel.Agencia);
            }

            treeData.EndUpdate();
        }

        void Recursiva(TreeListNodes Nodos, DatoNodoEncontrado Id, TreeLevel Tipo)
        {
            foreach (TreeListNode item in Nodos)
            {
                DatoNodo datoN = (DatoNodo)item.Tag;
                string buscar = string.Empty;



                switch (Tipo)
                {
                    case TreeLevel.Agencia:
                        buscar = Id.Agencia;
                        break;
                    case TreeLevel.Oficina:
                        buscar = Id.Oficjna;
                        break;
                    case TreeLevel.Cliente:
                        buscar = Id.ClienteId.ToString();
                        break;
                    //case TreeLevel.Ejercicio:
                    //    buscar = Id.e;
                    //    break;
                    case TreeLevel.Division:
                        buscar = Id.DivisionId.ToString();
                        break;
                    case TreeLevel.Marca:
                        buscar = Id.MarcaId.ToString(); ;
                        break;
                    case TreeLevel.Producto:
                        buscar = Id.ProductoId.ToString();
                        break;
                    case TreeLevel.CampanaMaestra:
                        buscar = Id.CampanaMaestraId.ToString();
                        break;

                    default:
                        break;
                }

                if (buscar == datoN.id && Tipo == datoN.Level)

                {

                    Tipo = Tipo + 1;

                    if (Tipo == TreeLevel.Ejercicio)
                    {
                        Tipo = Tipo + 1;
                    }

                    if (!item.Expanded)
                    {
                        //treeData.BeginUpdate();
                        item.Expanded = true;
                        //treeData.EndUpdate();
                    }
                    Recursiva(item.Nodes, Id, Tipo);

                }

            }

        }
        #region AgregarNodos


        public List<string> BuscarCadenaAccion()
        {
            List<string> result = new List<string>();
            result = RecursivaCadenaAlias(treeData.Nodes, TreeLevel.EstadoMbs);
            return result;
        }

        public List<string> BuscarCadenaSeleccionadas()
        {
            List<string> result = new List<string>();
            result = RecursivaCadenaAlias(treeData.Nodes, TreeLevel.CadenaAlias);
            return result;
        }

        private List<string> RecursivaCadenaAlias(TreeListNodes Nodos, TreeLevel Level)
        {
            List<string> result = new List<string>();
            foreach (TreeListNode item in Nodos)
            {
                DatoNodo datoN = (DatoNodo)item.Tag;

                if (item.Checked == true && datoN.Level == Level && Level != TreeLevel.EstadoMbs)
                {
                    result.Add((datoN.id).ToString());
                }
                else
                    if (item.Checked == true && datoN.Level == Level && Level == TreeLevel.EstadoMbs)
                {

                    //string dato = string.Format("{0}{1}", datoN.id.ToString(), datoN.Nombre.ToString());
                    string dato = string.Format("{0}{1}", datoN.id.ToString(), datoN.Accion.ToString());
                    result.Add(dato);
                }

                result.AddRange(RecursivaCadenaAlias(item.Nodes, Level));

            }

            return result;
        }


        private void AgregarNodosOficinas(BeforeExpandEventArgs e, DatoNodo Valor)
        {

            treeData.BeginUpdate();

            e.Node.Nodes.Clear();



            List<string> distinctOficina = LlstFiltro.Select(y => y.Oficjna.ToString()).Distinct().ToList();

            foreach (var Oficina in CacheUsuario.AgenciaOficina_cache.Where(x => x.CompanyId == Valor.id && distinctOficina.Contains(x.OfficeNameNative)).Select(y => new { Oficina = (string)y.OfficeNameNative }).Distinct())
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = Oficina.Oficina;
                Nodo.Nombre = Oficina.Oficina;
                Nodo.Level = TreeLevel.Oficina;

                DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node.Nodes.Add(new object[] { Oficina.Oficina });
                node.ImageIndex = 1;
                node.SelectImageIndex = 1;
                node.Tag = Nodo;
                node.Nodes.Add("");
            }
            treeData.EndUpdate();
        }

        private void AgregarNodosClientes(BeforeExpandEventArgs e, DatoNodo Valor)
        {
            treeData.BeginUpdate();

            e.Node.Nodes.Clear();

            List<int> distinctCliente = LlstFiltro.Select(y => y.ClienteId).Distinct().ToList();

            //var Agencias = CacheUsuario.AgenciaOficina_cache.Where(x => x.CompanyId == ((DatoNodo)e.Node.ParentNode.Tag).id).ToList();

            /*var AgenciaOficina = (from agen in Agencias
                                  join ofi in CacheUsuario.AgenciaOficina_cache on agen.CompanyId equals ofi.CompanyId
                                  where ofi.OfficeNameNative == Valor.id
                                  select ofi
                     ).Select(y => new { Agencia = (string)y.CompanyId, Oficina = y.OfficeNameNative, idCliente = y.IdCliente }).Distinct().ToList();*/

            /*var idsCliente = (from agen in CacheUsuario.AgenciaOficina_cache
                              join ofi in CacheUsuario.AgenciaOficina_cache on agen.CompanyId equals ofi.CompanyId
                                  
                              where agen.CompanyId == ((DatoNodo)e.Node.ParentNode.Tag).id 
                                &&  ofi.OfficeNameNative == Valor.id
                                  select ofi.IdCliente).Distinct().ToList();


            var Clientes = (from cli in CacheUsuario.Clientes_cache
                            //join ageofi in AgenciaOficina on cli.IdCliente equals ageofi.idCliente
                            where idsCliente.Contains(cli.IdCliente)
                            select cli).ToList();*/
            //var filtro = new bool[] { true}; ;
            //if (cboxClientes.Text == FiltroClientes.Activos.ToString())
            //    filtro = new bool[] {false};
            //    //filtro = "1";
            //else if (cboxClientes.Text == FiltroClientes.InActivos.ToString())
            //{
            //    filtro = new bool[] {true};
            //}
            //else
            //    filtro = new bool[] {false,true};



            var Clientes = (from agen in CacheUsuario.AgenciaOficina_cache
                            join cli in CacheUsuario.Clientes_cache on agen.IdCliente equals cli.IdCliente
                            where agen.CompanyId == ((DatoNodo)e.Node.ParentNode.Tag).id
                              && agen.OfficeNameNative == Valor.id
                            select cli).Distinct().ToList();

            //var clientes = 
            //         (from agen in Agencias
            //          join ofi in CacheUsuario.AgenciaOficina_cache on agen.CompanyId equals ofi.CompanyId into AgeOfi
            //          from  c in AgeOfi
            //          where c.IdCliente = AgeOfi.IdCliente
            //         select cli
            //        ).ToList();


            foreach (var cli in Clientes.Where(y => distinctCliente.Contains(y.IdCliente)).OrderBy(x => x.Inactivo).ThenBy(y => y.CodCliente))
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = cli.IdCliente.ToString();
                Nodo.Nombre = cli.CodCliente;
                Nodo.Level = TreeLevel.Cliente;

                DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node.Nodes.Add(new object[] { cli.CodCliente });
                node.ImageIndex = 2;
                node.SelectImageIndex = 2;
                node.Tag = Nodo;
                node.Nodes.Add("");
            }

            treeData.EndUpdate();
        }

        private void AgregarNodosDivisiones(BeforeExpandEventArgs e)
        {


            treeData.BeginUpdate();
            e.Node.Nodes.Clear();
            //Division

            List<int> distinctdiv = LlstFiltro.Select(y => y.DivisionId).Distinct().ToList();

            foreach (var div in CacheUsuario.Division_cache.Where(x => x.IdCliente.ToString() == ((DatoNodo)e.Node.Tag).id && distinctdiv.Contains(x.IdDivision)).OrderBy(y => y.CodDivision))
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = div.IdDivision.ToString();
                Nodo.Nombre = div.CodDivision;
                Nodo.Level = TreeLevel.Division;

                DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node.Nodes.Add(new object[] { div.CodDivision });
                node.ImageIndex = 3;
                node.SelectImageIndex = 3;
                node.Tag = Nodo;
                node.Nodes.Add("");
            }
            treeData.EndUpdate();
        }

        private void AgregarNodosMarcas(BeforeExpandEventArgs e)
        {


            treeData.BeginUpdate();
            e.Node.Nodes.Clear();
            //Division
            List<int> distinctMar = LlstFiltro.Select(y => y.MarcaId).Distinct().ToList();

            foreach (var mar in CacheUsuario.Marca_cache.Where(x => x.IdDivision.ToString() == ((DatoNodo)e.Node.Tag).id && distinctMar.Contains(x.IdMarca)).OrderBy(y => y.CodMarca))
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = mar.IdMarca.ToString();
                Nodo.Nombre = mar.CodMarca;
                Nodo.Level = TreeLevel.Marca;

                DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node.Nodes.Add(new object[] { mar.CodMarca });
                node.ImageIndex = 4;
                node.SelectImageIndex = 4;
                node.Tag = Nodo;
                node.Nodes.Add("");
            }
            treeData.EndUpdate();
        }


        //public static IEnumerable<TSource> DistinctBy<TSource, TKey>
        //(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        //{
        //    HashSet<TKey> seenKeys = new HashSet<TKey>();
        //    foreach (TSource element in source)
        //    {
        //        if (seenKeys.Add(keySelector(element)))
        //        {
        //            yield return element;
        //        }
        //    }
        //}

        private void AgregarEstadosMBS(BeforeExpandEventArgs e)
        {

            treeData.BeginUpdate();
            e.Node.Nodes.Clear();
            //Division
            //List<int> distinctCam = LlstFiltro.Select(y => y.CampanaMaestraId).Distinct().ToList(); 

            //List<AdPlanningSharp.DM.PLCampanaMaestra> ListCampana = CacheUsuario.PlCampanaMaestra_cache.ToList();

            //var cadenaali = (from  cam in CacheUsuario.PlCampanaMaestra_cache
            //        join pl in CacheUsuario.PLCampanaMedio_cache on cam.idCampanaMaestra equals pl.IdCampanaMaestra
            //        join tv in CacheUsuario.PLTVCampana_cache on pl.IdCampanaMedio equals tv.IdCampanaMedio
            //         join cc in CacheUsuario.PLTVCadenaAlias_cache on tv.IdTVCampana equals cc.IdTvCampana
            //        join cade in CacheUsuario.PLTVCadenaAlias_cache on  PlTvCadenaAlias.  //tv.idTvCampana equals pl.
            //        where  ((DatoNodo)e.Node.Tag).id == cam.idCampanaMaestra.ToString() // distinctCam.Contains(cam.idCampanaMaestra)
            //             select cc
            //             ).ToList();


            //var a = from CacheUsuario.PlCampanaMaestra_cache.ToList() cam
            //              CacheUsuario.
            //        join distinctCam ca equals )
            //        select cam
            //var uids = FiltroCadenasAlias.Select(id => id.idCadenaAlias).ToList();
            List<FiltroCadenaAliasAccion> bb = (from cam in FiltroCadenasAliasAccion
                                                where cam.idCadenaAlias == Convert.ToInt32(((DatoNodo)e.Node.Tag).id)
                                                select cam).ToList();


            //Ver los distintos casos
            //var bbdistinct = bb.Select(x => new { x.idCadenaAlias, x.Accion,x.esLCC,x.TieneFranja }).Distinct().ToList();


            //var c = bb.Select(x => new { x.idCadenaAlias, x.Accion }).Distinct().ToList();


            var Query = from p in bb.GroupBy(p => new { p.idCadenaAlias, p.Accion, p.esLCC, p.PuedeEnviarse,p.InfoRelacion })
                        select new
                        {
                            count = p.Count(),
                            idCadenaAlias = p.Key.idCadenaAlias,
                            Accion = p.Key.Accion,
                            esLCC = p.Key.esLCC,
                            PuedeEnviarse = p.Key.PuedeEnviarse,
                            InfoRelacion = p.Key.InfoRelacion
                        };

            //Cristian J. 17/12/2019 -> para mostrar el contador de cuantos pases se hacen Alta, Modificacion, Baja

            foreach (var maes in Query)
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = maes.idCadenaAlias.ToString();

                string Estado = string.Empty;

                //Mantenemos los casos de uso normal, poniendo cuando no es de LCC
                if (!maes.esLCC)
                {
                    switch (maes.Accion)
                    {
                        case "A":
                            Estado = "Alta"; break;
                        case "B":
                            Estado = "Baja"; break;
                        case "M":
                            Estado = "Modificacion"; break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (maes.Accion)
                    {
                        case "A":
                            Estado = maes.PuedeEnviarse ? "Enviar Alta" : "Enviar " + maes.InfoRelacion; break;// "Enviar (SIN FRANJA)";break;
                            //Estado = "Alta"; break;
                        case "B":
                            Estado = maes.PuedeEnviarse ? "Enviar Baja" : "Enviar Baja " + maes.InfoRelacion; break; //"Enviar (SIN FRANJA)"; break;
                            //Estado = "Baja"; break;
                        case "M":
                            Estado = maes.PuedeEnviarse ? "Enviar Modificacion" : "Modificacion " + maes.InfoRelacion; break; //"Modificacion (SIN FRANJA)"; break;
                            //Estado = "Modificacion"; break;
                        default:
                            break;
                    }
                    Nodo.esLCC = maes.esLCC;
                    Nodo.PuedeEnviarse = maes.PuedeEnviarse;
                }

                Nodo.Nombre = Estado; //maes.Accion.ToString();
                Nodo.Accion = maes.Accion.ToString();
                Nodo.Level = TreeLevel.EstadoMbs;
                //asdf
                DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node.Nodes.Add(new object[] { string.Format("{0} ({1})", Estado, maes.count) });
                node.ImageIndex = 6;
                node.SelectImageIndex = 6;
                node.Tag = Nodo;
                
                //node.Nodes.Add("");
            }
            treeData.EndUpdate();
        }


        private void AgregarNodosSoporte(BeforeExpandEventArgs e)
        {

            treeData.BeginUpdate();
            e.Node.Nodes.Clear();
            //Division
            List<int> distinctCam = LlstFiltro.Select(y => y.CampanaMaestraId).Distinct().ToList();

            //var filtro = new bool[] { true }; ;
            //if (cboxCbAdP.Text == FiltroAdp.AdP.ToString())
            //    filtro = new bool[] { true };
            ////filtro = "1";
            //else if (cboxCbAdP.Text == FiltroAdp.MBS.ToString())
            //{
            //    filtro = new bool[] { false };
            //}
            //else
            //    filtro = new bool[] { false, true };

            List<AdPlanningSharp.DM.PLCampanaMaestra> ListCampana = CacheUsuario.PlCampanaMaestra_cache.ToList();

            var cadenaali = (from cam in CacheUsuario.PlCampanaMaestra_cache
                             join pl in CacheUsuario.PLCampanaMedio_cache on cam.idCampanaMaestra equals pl.IdCampanaMaestra
                             join tv in CacheUsuario.PLTVCampana_cache on pl.IdCampanaMedio equals tv.IdCampanaMedio
                             join cc in CacheUsuario.PLTVCadenaAlias_cache on tv.IdTVCampana equals cc.IdTvCampana
                             //join cade in CacheUsuario.PLTVCadenaAlias_cache on  PlTvCadenaAlias.  //tv.idTvCampana equals pl.
                             where ((DatoNodo)e.Node.Tag).id == cam.idCampanaMaestra.ToString() // distinctCam.Contains(cam.idCampanaMaestra)
                             select cc
                         ).ToList();


            //var a = from CacheUsuario.PlCampanaMaestra_cache.ToList() cam
            //              CacheUsuario.
            //        join distinctCam ca equals )
            //        select cam
            var uids = FiltroCadenasAlias.Select(id => id.idCadenaAlias).ToList();
            foreach (var maes in cadenaali.Where(y => uids.Contains(y.IdCadenaAlias)).OrderBy(x=>x.CodCadenaAlias))
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = maes.IdCadenaAlias.ToString();
                Nodo.Nombre = maes.CodCadenaAlias;
                Nodo.Level = TreeLevel.CadenaAlias;

                DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node.Nodes.Add(new object[] { maes.CodCadenaAlias });
                node.ImageIndex = 6;
                node.SelectImageIndex = 6;
                node.Tag = Nodo;
                node.Nodes.Add("");
            }
            treeData.EndUpdate();
        }


        private void AgregarNodosCampañas(BeforeExpandEventArgs e)
        {

            treeData.BeginUpdate();
            e.Node.Nodes.Clear();
            //Division
            List<int> distinctCam = LlstFiltro.Select(y => y.CampanaMaestraId).Distinct().ToList();

            //var filtro = new bool[] { true }; ;
            //if (cboxCbAdP.Text == FiltroAdp.AdP.ToString())
            //    filtro = new bool[] { true };
            ////filtro = "1";
            //else if (cboxCbAdP.Text == FiltroAdp.MBS.ToString())
            //{
            //    filtro = new bool[] { false };
            //}
            //else
            //    filtro = new bool[] { false, true };


            foreach (var maes in CacheUsuario.PlCampanaMaestra_cache.Where(x => x.IdProducto.ToString() == ((DatoNodo)e.Node.Tag).id && distinctCam.Contains(x.idCampanaMaestra)).OrderBy(y => y.CodCampanaMaestra))
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = maes.idCampanaMaestra.ToString();
                Nodo.Nombre = maes.CodCampanaMaestra;
                Nodo.Level = TreeLevel.CampanaMaestra;

                DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node.Nodes.Add(new object[] { maes.CodCampanaMaestra });
                node.ImageIndex = 6;
                node.SelectImageIndex = 6;
                node.Tag = Nodo;

                if (_Final >= TreeLevel.CadenaAlias)
                    node.Nodes.Add("");

            }
            treeData.EndUpdate();
        }

        private void AgregarNodosProducto(BeforeExpandEventArgs e)
        {

            treeData.BeginUpdate();
            e.Node.Nodes.Clear();

            //Division
            List<int> distinctPro = LlstFiltro.Select(y => y.ProductoId).Distinct().ToList();
            foreach (var pro in CacheUsuario.Producto_cache.Where(x => x.IdMarca.ToString() == ((DatoNodo)e.Node.Tag).id && distinctPro.Contains(x.IdProducto)).OrderBy(y => y.CodProducto))
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = pro.IdProducto.ToString();
                Nodo.Nombre = pro.CodProducto;
                Nodo.Level = TreeLevel.Producto;

                DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node.Nodes.Add(new object[] { pro.CodProducto });
                node.ImageIndex = 5;
                node.SelectImageIndex = 5;
                node.Tag = Nodo;
                node.Nodes.Add("");
            }
            treeData.EndUpdate();
        }

        #endregion

        #endregion


        #region Funciones de busqueda

        /// <summary> Encontrar el nodo</summary>
        private TreeListNode BuscarNodo(int level, int idDato)
        {
            var nodo = treeData.FindNode(x => x.Tag is DatoNodo && (int)((DatoNodo)x.Tag).Level == level && ((DatoNodo)x.Tag).id == idDato.ToString());

            if (nodo != null)
            {
                return nodo;
            }
            else
            {
                // sigue buscando
                return null;
            }
        }

        /// <summary> Buscar en las listas</summary>
        //private void getListas(DatoNodo N, List<DatoNodo> lista, bool exit)
        //{
        //    if (Campanas == null)
        //    {
        //        Campanas = lista;
        //    }
        //    if (exit == true)
        //    {
        //        CargarBusqueda();
        //    }
        //    else
        //    {
        //        #region Buscar por Listas
        //        List<DatoNodo> listaNodos = new List<DatoNodo>();
        //        DatoNodo x = new DatoNodo();

        //        switch (N.Level)
        //        {
        //            case TreeLevel.Agencia:
        //                exit = true;
        //                break;

        //            case TreeLevel.Oficina:
        //                foreach (var item in lista)
        //                {
        //                    foreach (var i in CacheUsuario.AgenciaOficina_cache.FindAll(y => y.IdCliente.ToString() == item.id))
        //                    {
        //                        x = new DatoNodo();
        //                        x.id = i.CompanyId;
        //                        x.Level = TreeLevel.Agencia;
        //                        x.Nombre = i.CompanyId;
        //                        listaNodos.Add(x);
        //                        Agencias.Add(x);
        //                    }
        //                }
        //                break;
        //            case TreeLevel.Cliente:
        //                foreach (var item in lista)
        //                {
        //                    foreach (var i in CacheUsuario.AgenciaOficina_cache.FindAll(y => y.IdCliente.ToString() == item.id))
        //                    {
        //                        x = new DatoNodo();
        //                        x.id = i.OfficeNameNative;
        //                        x.Level = TreeLevel.Oficina;
        //                        x.Nombre = i.OfficeNameNative;
        //                        listaNodos.Add(x);
        //                        Oficinas.Add(x);
        //                    }
        //                }
        //                break;
        //            case TreeLevel.Division:
        //                foreach (var item in lista)
        //                {
        //                    foreach (var i in CacheUsuario.Clientes_cache.FindAll(y => y.IdCliente == item.idPadre))
        //                    {
        //                        x = new DatoNodo();
        //                        x.id = i.IdCliente.ToString();
        //                        x.Level = TreeLevel.Cliente;
        //                        x.Nombre = i.CodCliente;
        //                        listaNodos.Add(x);
        //                        Clientes.Add(x);
        //                    }
        //                }
        //                break;
        //            case TreeLevel.Marca:
        //                foreach (var item in lista)
        //                {
        //                    foreach (var i in CacheUsuario.Division_cache.FindAll(y => y.IdDivision == item.idPadre))
        //                    {
        //                        x = new DatoNodo();
        //                        x.id = i.IdDivision.ToString();
        //                        x.Level = TreeLevel.Division;
        //                        x.Nombre = i.CodDivision;
        //                        x.idPadre = i.IdCliente;
        //                        listaNodos.Add(x);
        //                        Divisiones.Add(x);
        //                    }
        //                }
        //                break;
        //            case TreeLevel.Producto:
        //                foreach (var item in lista)
        //                {
        //                    foreach (var i in CacheUsuario.Marca_cache.FindAll(y => y.IdMarca == item.idPadre))
        //                    {
        //                        x = new DatoNodo();
        //                        x.id = i.IdMarca.ToString();
        //                        x.Level = TreeLevel.Marca;
        //                        x.Nombre = i.CodMarca;
        //                        x.idPadre = i.IdDivision;
        //                        listaNodos.Add(x);
        //                        Marcas.Add(x);
        //                    }
        //                }
        //                break;
        //            case TreeLevel.CampanaMaestra:
        //                foreach (var item in lista)
        //                {
        //                    foreach (var i in CacheUsuario.Producto_cache.FindAll(y => y.IdProducto == item.idPadre))
        //                    {
        //                        x = new DatoNodo();
        //                        x.id = i.IdProducto.ToString();
        //                        x.Level = TreeLevel.Producto;
        //                        x.Nombre = i.CodProducto;
        //                        x.idPadre = i.IdMarca;
        //                        listaNodos.Add(x);
        //                        Productos.Add(x);
        //                    }
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //        getListas(x, listaNodos, exit);
        //        #endregion
        //    }
        //}

        /// <summary> Cargar los nodoes encontrados</summary>
        private void CargarBusqueda()
        {
            treeData.ExpandAll();

            if (Agencias == null)
            {
                MessageBox.Show("Agencias Null");
            }
            foreach (var item in Agencias)
            {
                treeData.FindNode(x => ((DatoNodo)x.Tag).id == item.id && ((DatoNodo)x.Tag).Level == item.Level).Expanded = true;
            }
            foreach (var item in Oficinas)
            {
                if ((treeData.FindNode(x => x.GetDisplayText(0).Equals("")) == null))
                {
                    treeData.FindNode(x => x.Tag != null && ((DatoNodo)x.Tag).Nombre.Contains(item.Nombre)).Expanded = true;
                }
            }
            foreach (var item in Clientes)
            {
                if ((treeData.FindNode(x => x.GetDisplayText(0).Equals("")) == null))
                {
                    treeData.FindNode(x => ((DatoNodo)x.Tag).id == item.id && ((DatoNodo)x.Tag).Level == item.Level).Expanded = true;
                }
            }
            foreach (var item in Divisiones)
            {
                if ((treeData.FindNode(x => x.GetDisplayText(0).Equals("")) == null))
                {
                    treeData.FindNode(x => ((DatoNodo)x.Tag).id == item.id && ((DatoNodo)x.Tag).Level == item.Level).Expanded = true;
                }
            }
            foreach (var item in Marcas)
            {
                if ((treeData.FindNode(x => x.GetDisplayText(0).Equals("")) == null))
                {
                    treeData.FindNode(x => ((DatoNodo)x.Tag).id == item.id && ((DatoNodo)x.Tag).Level == item.Level).Expanded = true;
                }
            }
            foreach (var item in Productos)
            {
                if ((treeData.FindNode(x => x.GetDisplayText(0).Equals("")) == null))
                {
                    treeData.FindNode(x => ((DatoNodo)x.Tag).id == item.id && ((DatoNodo)x.Tag).Level == item.Level).Expanded = true;
                }
            }
            foreach (var item in Campanas)
            {
                if ((treeData.FindNode(x => x.GetDisplayText(0).Equals("")) == null))
                {
                    //treeData.FindNode(x => ((DatoNodo)x.Tag).id == item.id && ((DatoNodo)x.Tag).Level == item.Level).Expanded = true;
                }
            }
        }

        #endregion


        #region Funciones de Filtro MBS ADP

        //TODO -> se repiten las divisiones ,marca ,producto , y campaña
        //TODO -> Cuando selecionas las campañas activas o inactivas, se muestran todas las agencias, faltaria hacer que distinguieran entrre el usuario que puede verlas

        /// <summary> Filtro para la seleccion de MBS o Adp </summary>
        //private void FiltroAdpMbs(bool mbs, bool adp)
        //{
        //    CacheYUsuario = new CachexUsuario();

        //    if ((adp == true) && (mbs == true))
        //    {
        //        CacheUsuario = CacheZUsuario;
        //        Start(TreeLevel.Agencia, TreeLevel.CampanaMaestra);
        //    }
        //    else
        //    {
        //        CargarDatosCache(mbs, adp);
        //        RecrearNodos(TreeLevel.Agencia, TreeLevel.CampanaMaestra);
        //    }
        //}

        ///// <summary> Filtro para la seleccion de campañas Activas o inactivas</summary>
        //private void FiltroActivas(bool Activa, bool Todas)
        //{
        //    if (Todas == true)
        //    {
        //        CacheUsuario = CacheZUsuario;
        //        Start(TreeLevel.Agencia, TreeLevel.CampanaMaestra);
        //    }
        //    else
        //    {
        //        CacheYUsuario = new CachexUsuario();
        //        CargarDatosCache(Activa);
        //        RecrearNodos(TreeLevel.Agencia, TreeLevel.CampanaMaestra);
        //    }
        //}

        #region Cargar_Nodos


        /// <summary> Seleccion de Cargar Datos para las campañas de MBS o ADP </summary>
        //public void CargarDatosCache(bool mbs, bool adp)
        //{
        //    cargar_SeguridadClientes_cache();
        //    Cargar_PlCampanaMaestra(mbs, adp);
        //    Cargar_Producto();
        //    Cargar_Marca();
        //    Cargar_Division();
        //    Cargar_Clientes();
        //    Cargar_Oficinas();
        //    //Parallel.Invoke(new Action[] { Cargar_Oficinas,cargar_SeguridadClientes_cache, Cargar_Clientes, Cargar_Division, Cargar_Marca, Cargar_Producto, Cargar_PlCampanaMaestra });
        //}

        ///// <summary> Seleccion de Cargar Datos para las Campañas ACtivas o inactivas</summary>
        //public void CargarDatosCache(bool activa)
        //{
        //    cargar_SeguridadClientes_cache();
        //    Cargar_PlCampanaMaestraActivas(activa);
        //    Cargar_Producto();
        //    Cargar_Marca();
        //    Cargar_Division();
        //    Cargar_Clientes();
        //    Cargar_Oficinas();
        //    //Parallel.Invoke(new Action[] { Cargar_Oficinas,cargar_SeguridadClientes_cache, Cargar_Clientes, Cargar_Division, Cargar_Marca, Cargar_Producto, Cargar_PlCampanaMaestra });
        //}

        ///// <summary> Cargar la seguridad de las campañas</summary>
        //public void cargar_SeguridadClientes_cache()
        //{
        //    CacheYUsuario.SeguridadClientes_cache = Cache.Get_SeguridadClientes().Where(x => x.Propietario == CacheUsuario.UsuarioId).ToList();

        //    List<DM.Query_AgenciaOficina_Result> AgenciaOficina = Cache.Get_AgenciaOficina();

        //    CacheYUsuario.AgenciaOficina_cache = (from i in AgenciaOficina
        //                                          join y in CacheYUsuario.SeguridadClientes_cache on i.IdCliente equals y.IdCliente
        //                                          select i).ToList();
        //}

        ///// <summary> Cargar las Campañas</summary>
        //public void Cargar_PlCampanaMaestra(bool mbs, bool adp)
        //{
        //    if ((adp == true) && (mbs == false))
        //    {
        //        CacheYUsuario.PlCampanaMaestra_cache = Cache.Get_CampanaMaestra().Where(x => x.usoAdp == adp).ToList();
        //    }
        //    else if ((mbs == true) && (adp == false))
        //    {
        //        CacheYUsuario.PlCampanaMaestra_cache = Cache.Get_CampanaMaestra().Where(x => x.CampanaMBS == mbs).ToList();
        //    }
        //    else if ((adp == true) && (mbs == true))
        //    {
        //        CacheYUsuario.PlCampanaMaestra_cache = Cache.Get_CampanaMaestra().ToList();
        //    }
        //}

        ///// <summary> Cargar las campañas activas o inactivas</summary>
        //public void Cargar_PlCampanaMaestraActivas(bool activa)
        //{

        //    CacheYUsuario.PlCampanaMaestra_cache = Cache.Get_CampanaMaestra().Where(x => x.EstadoCampanaMaestra == activa).ToList();

        //}

        ///// <summary> Cargar los productos de las campañas </summary>
        //public void Cargar_Producto()
        //{
        //    CacheYUsuario.Producto_cache = new List<DM.CLClientesDivMarProducto>();
        //    foreach (var item in CacheYUsuario.PlCampanaMaestra_cache)
        //    {
        //        foreach (var item2 in Cache.Get_Producto().FindAll(x => x.IdProducto == item.IdProducto).ToList())
        //        {
        //            CacheYUsuario.Producto_cache.Add(item2);
        //        }
        //    }
        //}

        ///// <summary> Cargar marcas </summary>
        //public void Cargar_Marca()
        //{
        //    CacheYUsuario.Marca_cache = new List<DM.CLClientesDivMar>();
        //    foreach (var item in CacheYUsuario.Producto_cache)
        //    {
        //        foreach (var item2 in Cache.Get_Marca().Where(x => x.IdMarca == item.IdMarca).ToList())
        //        {
        //            CacheYUsuario.Marca_cache.Add(item2);
        //        }
        //    }
        //}

        ///// <summary> Cargar Division</summary>
        //public void Cargar_Division()
        //{
        //    CacheYUsuario.Division_cache = new List<DM.CLClientesDiv>();
        //    foreach (var item in CacheYUsuario.Marca_cache)
        //    {
        //        foreach (var item2 in Cache.Get_Divsion().Where(x => x.IdDivision == item.IdDivision).ToList())
        //        {
        //            CacheYUsuario.Division_cache.Add(item2);
        //        }
        //    }
        //}

        ///// <summary> Cargar Clientes</summary>
        //public void Cargar_Clientes()
        //{
        //    CacheYUsuario.Clientes_cache = new List<DM.CLClientes>();
        //    foreach (var item in CacheYUsuario.Division_cache)
        //    {
        //        foreach (var item2 in Cache.Get_Clientes().Where(x => x.IdCliente == item.IdCliente).ToList())
        //        {
        //            CacheYUsuario.Clientes_cache.Add(item2);
        //        }
        //    }
        //}

        ///// <summary> Carvar Oficinas</summary>
        //public void Cargar_Oficinas()
        //{


        //    CacheYUsuario.AgenciaOficina_cache = new List<DM.Query_AgenciaOficina_Result>();

        //    foreach (var item in CacheYUsuario.Clientes_cache)
        //    {
        //        foreach (var item2 in Cache.Get_AgenciaOficina().Where(x => x.IdCliente == item.IdCliente).ToList())
        //        {
        //            foreach (var seg in CacheYUsuario.SeguridadClientes_cache.Where(x => x.IdCliente == item2.IdCliente).ToList())
        //            {
        //                CacheYUsuario.AgenciaOficina_cache.Add(item2);
        //            }
        //        }
        //    }

        //}

        /// <summary> Recargar el treeData para la nueva muestra de datos</summary>
        //public void RecrearNodos(TreeLevel Inicial, TreeLevel Final)
        //{
        //    try
        //    {
        //        treeData.ClearNodes();

        //        configTree();

        //        if (TreeLevel.Agencia == Inicial)
        //        {
        //            foreach (var Agencia in CacheYUsuario.AgenciaOficina_cache.OrderBy(x => x.OfficeNameNative).Select(y => new { Agencia = (string)y.CompanyId }).Distinct())
        //            {
        //                DatoNodo Nodo = new DatoNodo();
        //                Nodo.id = Agencia.Agencia;
        //                Nodo.Nombre = Agencia.Agencia;
        //                Nodo.Level = TreeLevel.Agencia;

        //                DevExpress.XtraTreeList.Nodes.TreeListNode node = treeData.Nodes.Add(new object[] { Agencia.Agencia });

        //                node.ImageIndex = 0;
        //                node.SelectImageIndex = 0;
        //                node.Tag = Nodo;
        //                node.Nodes.Add("");

        //            }
        //        }
        //        if (CacheZUsuario == null)
        //        {
        //            CacheZUsuario = CacheUsuario;
        //        }

        //        CacheUsuario = CacheYUsuario;
        //    }
        //    catch (Exception ex)
        //    {
        //        var a = ex.Message;
        //    }
        //}

        #endregion

        //private void treeData_Click(object sender, EventArgs e)
        //{
        //    string a = "a";

        //    TreeList tl = (TreeList)sender;
        //    TreeListHitInfo hitInfo = tl.CalcHitInfo(e.Location);
        //    if (hitInfo.Node != null)
        //        tl.FocusedNode = hitInfo.Node;


        //}

        #endregion

        //private void treeData_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    TreeList tree = sender as TreeList;
        //    TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
        //    if (hi.Node != null)
        //    {
        //        //process hi.Node here
        //        SeleccionNodoEventArgs args = new SeleccionNodoEventArgs();
        //        args.Nodo = hi.Node.Tag;
        //        OnSeleccionNodoEvent(args);

        //    }
        //}

        protected virtual void OnSeleccionNodoEvent(EventArgs e)
        {
            EventHandler handler = SeleccionNodoEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //private void treeData_MouseDown(object sender, MouseEventArgs e)
        //{


        //    DevExpress.XtraTreeList.TreeListHitInfo hi = treeData.CalcHitInfo(e.Location);
        //    if (hi.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell)
        //    {

        //    //if (hi.Node != null)
        //    //{
        //        //process hi.Node here
        //        SeleccionNodoEventArgs args = new SeleccionNodoEventArgs();

        //        DatoNodoEncontrado item = new DatoNodoEncontrado();

        //        item.CampanaMaestraId = this.CampanaMaestraId;
        //        //item.Agencia = this.;
        //        item.ClienteId = ClienteId;
        //        item.DivisionId = DivisionId;
        //        item.MarcaId = MarcaId;
        //        //item.Oficjna = ;
        //        item.ProductoId = ProductoId;
        //        item.CodCampanaMaestra = CodCampanaMaestra;




        //        args.Nodo = item;
        //        OnSeleccionNodoEvent(args);

        //    }

        //}


        private DatoNodoEncontrado GetDatoNodoEncontrado(eOpcion opcion)
        {

            DatoNodoEncontrado item = new DatoNodoEncontrado();

            item.CampanaMaestraId = this.CampanaMaestraId;
            item.ClienteId = ClienteId;
            item.DivisionId = DivisionId;
            item.MarcaId = MarcaId;
            item.ProductoId = ProductoId;
            item.CodCampanaMaestra = CodCampanaMaestra;
            item.ClienteCod = ClienteCod;
            item.ProductoCod = ProductoCod;
            item.Opcion = opcion; //eOpcion.SeleccionNodo;

            return item;
        }

        private void treeData_AfterFocusNode(object sender, NodeEventArgs e)
        {


            SeleccionNodoEventArgs args = new SeleccionNodoEventArgs();

            DatoNodoEncontrado item = GetDatoNodoEncontrado(eOpcion.SeleccionNodo);

            //new DatoNodoEncontrado();

            //item.CampanaMaestraId = this.CampanaMaestraId;
            //item.ClienteId = ClienteId;
            //item.DivisionId = DivisionId;
            //item.MarcaId = MarcaId;
            //item.ProductoId = ProductoId;
            //item.CodCampanaMaestra = CodCampanaMaestra;
            //item.ClienteCod = ClienteCod;
            //item.ProductoCod = ProductoCod;
            //item.Opcion = eOpcion.SeleccionNodo;



            if (((DatoNodo)e.Node.Tag).Level == TreeLevel.CampanaMaestra)
            {
                //ribbonControl.SelectedPage = rbnCampañas;
                Activar((DatoNodo)e.Node.Tag);
            }
            else
            {
                Desactivar(((DatoNodo)e.Node.Tag));
            }



            args.Nodo = item;
            OnSeleccionNodoEvent(args);




        }

        private void txtTextoBuscarTreeClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Start(_Inicial, _Final);
                //Buscar();

            }
        }


        /* Opciones menu*/
        private void activarCampañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionNodoEventArgs args = new SeleccionNodoEventArgs();
            DatoNodoEncontrado item = GetDatoNodoEncontrado(eOpcion.ActivarCampana);
            args.Nodo = item;
            OnSeleccionNodoEvent(args);
        }

        private void listadoPasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionNodoEventArgs args = new SeleccionNodoEventArgs();
            DatoNodoEncontrado item = GetDatoNodoEncontrado(eOpcion.ListadoPases);
            args.Nodo = item;
            OnSeleccionNodoEvent(args);
        }

        private void calendarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionNodoEventArgs args = new SeleccionNodoEventArgs();
            DatoNodoEncontrado item = GetDatoNodoEncontrado(eOpcion.Calendario);
            args.Nodo = item;
            OnSeleccionNodoEvent(args);
        }

        private void seguimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionNodoEventArgs args = new SeleccionNodoEventArgs();
            DatoNodoEncontrado item = GetDatoNodoEncontrado(eOpcion.Seguimiento);
            args.Nodo = item;
            OnSeleccionNodoEvent(args);
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionNodoEventArgs args = new SeleccionNodoEventArgs();
            DatoNodoEncontrado item = GetDatoNodoEncontrado(eOpcion.Configuración);
            args.Nodo = item;
            OnSeleccionNodoEvent(args);
        }

        private void asignarInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionNodoEventArgs args = new SeleccionNodoEventArgs();
            DatoNodoEncontrado item = GetDatoNodoEncontrado(eOpcion.AsignarInventario);
            args.Nodo = item;
            OnSeleccionNodoEvent(args);
        }

        private void adjudicarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionNodoEventArgs args = new SeleccionNodoEventArgs();
            DatoNodoEncontrado item = GetDatoNodoEncontrado(eOpcion.Adjudicar);
            args.Nodo = item;
            OnSeleccionNodoEvent(args);
        }

        private void cargarPasesComoPlanificadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionNodoEventArgs args = new SeleccionNodoEventArgs();
            DatoNodoEncontrado item = GetDatoNodoEncontrado(eOpcion.CargarpasePlanificados);
            args.Nodo = item;
            OnSeleccionNodoEvent(args);

        }


        private void Activar(DatoNodo item)
        {

            var campana = CacheUsuario.PlCampanaMaestra_cache.Where(x => x.idCampanaMaestra.ToString() == item.id).Single();


            if (campana.usoAdp == false)
            {

                expandirTodoToolStripMenuItem.Visible = false;
                contraerTodoToolStripMenuItem.Visible = false;

                toolStripSeparator1.Visible = false;
                toolStripSeparator2.Visible = false;
                toolStripSeparator3.Visible = false;
                activarCampañaToolStripMenuItem.Visible = true;

                listadoPasesToolStripMenuItem.Visible = false;
                calendarioToolStripMenuItem.Visible = false;
                seguimientoToolStripMenuItem.Visible = false;
                configuraciónToolStripMenuItem.Visible = false;
                asignarInventarioToolStripMenuItem.Visible = false;
                adjudicarToolStripMenuItem.Visible = false;
                cargarPasesComoPlanificadosToolStripMenuItem.Visible = false;
                copiarDatosDeTVEnCampañaToolStripMenuItem.Visible = false;
            }
            else
            {

                expandirTodoToolStripMenuItem.Visible = false;
                contraerTodoToolStripMenuItem.Visible = false;
                toolStripSeparator1.Visible = false;

                toolStripSeparator1.Visible = false;
                toolStripSeparator2.Visible = false;
                toolStripSeparator3.Visible = false;
                activarCampañaToolStripMenuItem.Visible = false;


                listadoPasesToolStripMenuItem.Visible = true;
                calendarioToolStripMenuItem.Visible = true;
                seguimientoToolStripMenuItem.Visible = true;
                configuraciónToolStripMenuItem.Visible = true;
                asignarInventarioToolStripMenuItem.Visible = true;
                adjudicarToolStripMenuItem.Visible = true;
                cargarPasesComoPlanificadosToolStripMenuItem.Visible = true;

                copiarDatosDeTVEnCampañaToolStripMenuItem.Visible = true;

            }


        }


        private void Desactivar(DatoNodo item)
        {
            toolStripSeparator1.Visible = false;
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;
            activarCampañaToolStripMenuItem.Visible = false;
            listadoPasesToolStripMenuItem.Visible = false;
            calendarioToolStripMenuItem.Visible = false;
            seguimientoToolStripMenuItem.Visible = false;
            configuraciónToolStripMenuItem.Visible = false;
            asignarInventarioToolStripMenuItem.Visible = false;
            adjudicarToolStripMenuItem.Visible = false;
            copiarDatosDeTVEnCampañaToolStripMenuItem.Visible = false;
            cargarPasesComoPlanificadosToolStripMenuItem.Visible = false;
        }

        private void btCampanasActivas_Click(object sender, EventArgs e)
        {
            Start(_Inicial, _Final);
        }

        private void treeData_AfterCheckNode(object sender, NodeEventArgs e)
        {
            nuevoCheckEvento();
            e.Node.ExpandAll();
            if (!((DatoNodo)e.Node.Tag).esLCC)
            {
                CheckUnCheck(e.Node, e.Node.Checked);
            }
            else 
            {
                //CheckUnCheck(e.Node, false);
                CheckUnCheck(e.Node, ((DatoNodo)e.Node.Tag).PuedeEnviarse && e.Node.Checked);
                if (((DatoNodo)e.Node.Tag).Level == TreeLevel.EstadoMbs && e.Node.Checked)
                {
                    bool usuarioAutorizaEnvio = checkAltaLCCEvento(((DatoNodo)e.Node.Tag).id);
                    e.Node.Checked = ((DatoNodo)e.Node.Tag).PuedeEnviarse && e.Node.Checked && usuarioAutorizaEnvio;
                }
                else
                {
                    e.Node.Checked = ((DatoNodo)e.Node.Tag).PuedeEnviarse && e.Node.Checked;
                }
            }

        }
        private void CheckUnCheck(TreeListNode Nod, bool estado)
        {
            foreach (TreeListNode item in Nod.Nodes)
            {
                if (!((DatoNodo)item.Tag).esLCC && ((DatoNodo)item.Tag).Accion!="A")//Si es envio normal pero NO un Alta 
                {
                    item.Checked = estado;
                }
                else if (!((DatoNodo)item.Tag).esLCC && ((DatoNodo)item.Tag).Accion == "A")//Si es un Alta de envios normales
                {
                    if (estado == true)
                    {
                        bool usuarioAutorizaEnvio = checkAltaLCCEvento(((DatoNodo)item.Tag).id);
                        item.Checked = estado && usuarioAutorizaEnvio;
                    }
                    else
                    {
                        item.Checked = estado;
                    }
                }
                else/// Si es un envio de LCC
                {
                    if (estado == true)
                    {
                        bool usuarioAutorizaEnvio = checkAltaLCCEvento(((DatoNodo)item.Tag).id);
                        //if (result)
                        //{
                            item.Checked = ((DatoNodo)item.Tag).PuedeEnviarse && estado && usuarioAutorizaEnvio;
                        //}
                    }
                    else
                    {
                        item.Checked = false;
                    }
                }
                if (item.Nodes.Count > 0)
                    CheckUnCheck(item, item.Checked);
            }


        }

        private void copiarDatosDeTVEnCampañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            duplicarCampañaEvento();
        }

        private void treeData_ShowingEditor(object sender, CancelEventArgs e)
        {
           /* If treeList1.FocusedNode.Id Mod 2 = 0 Then
                Return
            End If
            e.Cancel = True
            */
        }
    }
}
