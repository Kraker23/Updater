using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Updater
{
    public partial class cTree : UserControl
    {

        public delegate void NuevoCheck();
        public event NuevoCheck nuevoCheckEvento;

        public delegate void Confirmar();
        public event Confirmar ConfirmarEvento;

        public enum TreeLevel { Campaña = 1, TipoCompra = 2, GrupoSoporte = 3, Cadena = 4, CadenaAlias = 5}
        
        public class DatoNodo
        {
            public int id { get; set; }
            public int? idPadre { get; set; }
            public string Nombre { get; set; }
            public int idADP { get; set; }
            public TreeLevel Level { get; set; }
            public string nombreLevel { get; set; }
        }

        public List<DatoNodo> datos;
        public List<DatoNodo> datosVisualizados;
        public List<DatoNodo> datosChecked;
        public string textoBuscadoAnterior;
        private int idTVCampana;//= 16335; 
        private System.Timers.Timer timer;
        //public List<DatoNodo> datosFiltro;

        #region Constructor 

        public cTree()
        {
            InitializeComponent();

            configTree();
            datosChecked = new List<DatoNodo>();
            datos = new List<DatoNodo>();
            idTVCampana = 16335;
            cargarTimer();
            CargarArbol();

            //datos.Add(new DatoNodo { id = 1, idPadre = null, Nombre = "Campaña", idADP = 1000, Level = TreeLevel.Campaña, nombreLevel = "Campaña" });

            //datos.Add(new DatoNodo { id = 2, idPadre = 1, Nombre = "TipoCompra1", idADP = 2000, Level = TreeLevel.TipoCompra, nombreLevel = "TipoCompra" });
            //datos.Add(new DatoNodo { id = 3, idPadre = 1, Nombre = "TipoCompra2", idADP = 2001, Level = TreeLevel.TipoCompra, nombreLevel = "TipoCompra" });

            //datos.Add(new DatoNodo { id = 4, idPadre = 2, Nombre = "GrupoSoporte1", idADP = 3001, Level = TreeLevel.GrupoSoporte, nombreLevel = "GrupoSoporte" });
            //datos.Add(new DatoNodo { id = 5, idPadre = 2, Nombre = "GrupoSoporte2", idADP = 3002, Level = TreeLevel.GrupoSoporte, nombreLevel = "GrupoSoporte" });
            //datos.Add(new DatoNodo { id = 6, idPadre = 3, Nombre = "GrupoSoporte3", idADP = 3003, Level = TreeLevel.GrupoSoporte, nombreLevel = "GrupoSoporte" });
            //datos.Add(new DatoNodo { id = 7, idPadre = 3, Nombre = "GrupoSoporte4", idADP = 3004, Level = TreeLevel.GrupoSoporte, nombreLevel = "GrupoSoporte" });

            //datos.Add(new DatoNodo { id = 8, idPadre = 4, Nombre = "Cadena1", idADP = 4001, Level = TreeLevel.Cadena, nombreLevel = "Cadena" });
            //datos.Add(new DatoNodo { id = 9, idPadre = 4, Nombre = "Cadena2", idADP = 4002, Level = TreeLevel.Cadena, nombreLevel = "Cadena" });
            //datos.Add(new DatoNodo { id = 10, idPadre = 5, Nombre = "Cadena3", idADP = 4003, Level = TreeLevel.Cadena, nombreLevel = "Cadena" });
            //datos.Add(new DatoNodo { id = 11, idPadre = 6, Nombre = "Cadena4", idADP = 4004, Level = TreeLevel.Cadena, nombreLevel = "Cadena" });
            //datos.Add(new DatoNodo { id = 12, idPadre = 7, Nombre = "Cadena5", idADP = 4005, Level = TreeLevel.Cadena, nombreLevel = "Cadena" });
            //datos.Add(new DatoNodo { id = 13, idPadre = 7, Nombre = "Cadena6", idADP = 4006, Level = TreeLevel.Cadena, nombreLevel = "Cadena" });


            //datos.Add(new DatoNodo { id = 14, idPadre = 8, Nombre = "CadenaAlias1", idADP = 5001, Level = TreeLevel.CadenaAlias, nombreLevel = "CadenaAlias" });
            //datos.Add(new DatoNodo { id = 15, idPadre = 8, Nombre = "CadenaAlias2", idADP = 5002, Level = TreeLevel.CadenaAlias, nombreLevel = "CadenaAlias" });
            //datos.Add(new DatoNodo { id = 16, idPadre = 9, Nombre = "CadenaAlias3", idADP = 5002, Level = TreeLevel.CadenaAlias, nombreLevel = "CadenaAlias" });
            //datos.Add(new DatoNodo { id = 17, idPadre = 10, Nombre = "CadenaAlias4", idADP = 5004, Level = TreeLevel.CadenaAlias, nombreLevel = "CadenaAlias" });
            //datos.Add(new DatoNodo { id = 18, idPadre = 11, Nombre = "CadenaAlias5", idADP = 5005, Level = TreeLevel.CadenaAlias, nombreLevel = "CadenaAlias" });
            //datos.Add(new DatoNodo { id = 19, idPadre = 12, Nombre = "CadenaAlias6", idADP = 5006, Level = TreeLevel.CadenaAlias, nombreLevel = "CadenaAlias" });
            //datos.Add(new DatoNodo { id = 20, idPadre = 12, Nombre = "CadenaAlias7", idADP = 5007, Level = TreeLevel.CadenaAlias, nombreLevel = "CadenaAlias" });
            //datos.Add(new DatoNodo { id = 21, idPadre = 13, Nombre = "CadenaAlias8", idADP = 5008, Level = TreeLevel.CadenaAlias, nombreLevel = "CadenaAlias" });
            //datos.Add(new DatoNodo { id = 22, idPadre = 13, Nombre = "CadenaAlias9", idADP = 5009, Level = TreeLevel.CadenaAlias, nombreLevel = "CadenaAlias" });



        }

        public cTree(int idTVCampana)
        {
            InitializeComponent();

            configTree();
            datosChecked = new List<DatoNodo>();
            datos = new List<DatoNodo>();
            this.idTVCampana=idTVCampana;
            CargarArbol();

            cargarTimer();
        }

        private void cargarTimer()
        {
            timer = new Timer();
            timer.Interval = 1300;  // Whatever... Milliseconds (you may increase or decrease this value to suit your needs)
            timer.Tick += EndTimerTxt;
        }
        
        
        
        #endregion

        //public void DataSource(List<DatoNodo> datos)
        //{
        //    this.datos = datos;
        //}

        public void Start(List<DatoNodo> datos)
        {
            //DataSource(datos);
            Start();
        }

        public void Start(bool expandir=false)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtBuscar.Text))
                {
                    #region txt
                    // if (item.Nombre.ToLower() == txtBuscar.Text.ToLower() || item.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()) || item.idADP.ToString() == txtBuscar.Text || item.idADP.ToString().Contains(txtBuscar.Text))
                     //  cargar los datos de solo los que contengan uno de estos y sus padres
                    List<DatoNodo> datosAux = new List<DatoNodo>(); 
                    List <int> idsAnteriores = new List<int>();
                    foreach (DatoNodo item in datos.Where(x=>x.Level==TreeLevel.CadenaAlias && (Coincide(x) || idsAnteriores.Exists(y=>y==x.id))))
                    {
                        datosAux.Add(item);
                        idsAnteriores.Add(item.idPadre.Value);
                    }

                    foreach (DatoNodo item in datos.Where(x=>x.Level==TreeLevel.Cadena && (Coincide(x) || idsAnteriores.Exists(y=>y==x.id))))
                    {
                        datosAux.Add(item);
                        if (idsAnteriores.Exists(y => y == item.id))
                        {
                            idsAnteriores.RemoveAt(idsAnteriores.FindIndex(x => x == item.id));
                        }
                        idsAnteriores.Add(item.idPadre.Value);
                    }

                    foreach (DatoNodo item in datos.Where(x => x.Level == TreeLevel.GrupoSoporte && (Coincide(x) || idsAnteriores.Exists(y => y == x.id))))
                    {
                        datosAux.Add(item);
                        if (idsAnteriores.Exists(y => y == item.id))
                        {
                            idsAnteriores.RemoveAt(idsAnteriores.FindIndex(x => x == item.id));
                        }
                        idsAnteriores.Add(item.idPadre.Value);
                    }
                    foreach (DatoNodo item in datos.Where(x => x.Level == TreeLevel.TipoCompra && (Coincide(x) || idsAnteriores.Exists(y => y == x.id))))
                    {
                        datosAux.Add(item);
                        if (idsAnteriores.Exists(y => y == item.id))
                        {
                            idsAnteriores.RemoveAt(idsAnteriores.FindIndex(x => x == item.id));
                        }
                        idsAnteriores.Add(item.idPadre.Value);
                    }
                    foreach (DatoNodo item in datos.Where(x => x.Level == TreeLevel.Campaña && (Coincide(x) || idsAnteriores.Exists(y => y == x.id))))
                    {
                        datosAux.Add(item);
                        if (idsAnteriores.Exists(y => y == item.id))
                        {
                            idsAnteriores.RemoveAt(idsAnteriores.FindIndex(x => x == item.id));
                        }
                    }

                    expandir=true;
                    datosVisualizados = datosAux.OrderBy(x=>x.id).ToList();
                    #endregion
                }
                else
                {
                    datosVisualizados = datos;
                }

                tree.ClearNodes();

                tree.Appearance.SelectedRow.BackColor = Color.CadetBlue;
                tree.Appearance.FocusedCell.BackColor = Color.CadetBlue;
          
                configTree();

                tree.BeginUpdate();

                if (datosVisualizados.HasContent())
                {

                    foreach (DatoNodo item in datosVisualizados.Where(x => x.idPadre == null))
                    {
                        //DevExpress.XtraTreeList.Nodes.TreeListNode node = new TreeListNode();
                        DatoNodo Nodo = new DatoNodo();
                        Nodo.id = item.id;
                        Nodo.Nombre = item.Nombre;
                        Nodo.Level = TreeLevel.Campaña;
                        Nodo.nombreLevel = item.nombreLevel;
                        Nodo.idADP = item.idADP;

                        int num = BuscarHijos(item.id);
                       
                        //item.Nombre=item.Nombre+"("+num+")";

                        DevExpress.XtraTreeList.Nodes.TreeListNode node = tree.Nodes.Add(new object[] { item.Nombre + "(" + num + ")" });

                        //node.SetValue(0, Agencia.Agencia);
                        node.ImageIndex = 0;
                        node.SelectImageIndex = 0;
                        node.Tag = Nodo;
                        node.Nodes.Add("");
                    }
                }
                if (expandir )
                {
                    tree.ExpandAll();
                }

                tree.EndUpdate();


            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }


        /// <summary> Configuración del arbol </summary>
        private void configTree()
        {
            tree.OptionsBehavior.AllowExpandOnDblClick = true;
            tree.OptionsBehavior.Editable = false;

            tree.OptionsView.ShowIndicator = false;
            tree.OptionsView.ShowColumns = false;
            tree.OptionsView.ShowHorzLines = false;
            tree.OptionsView.ShowVertLines = false;
            tree.TreeLineStyle = LineStyle.None;

            //tree.Columns.Clear();

            //tree.Columns.Add();
            //tree.Columns[0].Caption = "Customer";
            //tree.Columns[0].VisibleIndex = 0;
            tree.Columns[0].OptionsColumn.AllowEdit = false;
            tree.Columns[0].OptionsColumn.ReadOnly = true;
            tree.BestFitColumns();
        }

        private void CargarArbol()
        {
            
            List<Query_ArbolFiltroAsociarKantar_Result> arbol = PasesKantar.getArbolfiltro(idTVCampana);
            foreach (Query_ArbolFiltroAsociarKantar_Result item in arbol)
            {
                DatoNodo nodoNew = new DatoNodo();
                nodoNew.id = item.Id;
                nodoNew.idADP = item.idADP;
                nodoNew.idPadre = item.idPadre;
                nodoNew.Nombre = item.Nombre;
                nodoNew.nombreLevel = item.nombreLevel;
                switch (item.nivel)
                {
                    case 1: nodoNew.Level = TreeLevel.Campaña; break;
                    case 2: nodoNew.Level = TreeLevel.TipoCompra; break;
                    case 3: nodoNew.Level = TreeLevel.GrupoSoporte; break;
                    case 4: nodoNew.Level = TreeLevel.Cadena; break;
                    case 5: nodoNew.Level = TreeLevel.CadenaAlias; break;
                    default:
                        break;
                }
                datos.Add(nodoNew);
            }
        }

        private void tree_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            tree.BeginUpdate();
            DatoNodo Valor = (DatoNodo)e.Node.Tag;

            if (Valor.Level == TreeLevel.Campaña)
            {
                AgregarNodosTipoCompra(e, Valor);
            }
            else if (Valor.Level == TreeLevel.TipoCompra)
            {
                AgregarNodosGrupoSoporte(e, Valor);
            }
            else if (Valor.Level == TreeLevel.GrupoSoporte)
            {
                AgregarNodosCadenas(e, Valor);
            }
            else if (Valor.Level == TreeLevel.Cadena)
            {
                AgregarNodosCadenasAlias(e, Valor);
            }
            

            tree.EndUpdate();
        }

        private void tree_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
           /* if (e.Node.Tag != null && !string.IsNullOrEmpty(txtBuscar.Text))
            {
                DatoNodo item = (DatoNodo)e.Node.Tag;
                //if (item.Nombre == txtBuscar.Text || item.Nombre.Contains(txtBuscar.Text) || item.idADP.ToString() == txtBuscar.Text || item.idADP.ToString().Contains(txtBuscar.Text))
                //if (item.Nombre.ToLower() == txtBuscar.Text || item.Nombre.ToLower().Contains(txtBuscar.Text) || item.idADP.ToString() == txtBuscar.Text || item.idADP.ToString().Contains(txtBuscar.Text))
                if (Coincide(item))
                {
                    e.Appearance.ForeColor = Color.Blue;

                }
            }*/
        }

        private int BuscarHijos(int id)
        {
            int n = 0;
            foreach (DatoNodo dato in datosVisualizados.Where(x=>x.idPadre==id))
            {
                if (datosVisualizados.Exists(x => x.idPadre == id))
                {
                    n =n+ BuscarHijos(dato.id);
                }
                n=n+1;

            }
            return n;
        }

    


        #region AgregarNodos

        private void AgregarNodosTipoCompra(BeforeExpandEventArgs e, DatoNodo Valor)
        {
            tree.BeginUpdate();

            e.Node.Nodes.Clear();


            foreach (DatoNodo TipoCompra in datosVisualizados.Where(x => x.idPadre == Valor.id))
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = TipoCompra.id;
                Nodo.Nombre = TipoCompra.Nombre;
                Nodo.nombreLevel = TipoCompra.nombreLevel;
                Nodo.idADP = TipoCompra.idADP;
                Nodo.Level = TreeLevel.TipoCompra;

                int num = BuscarHijos(TipoCompra.id);
                //TipoCompra.Nombre = TipoCompra.Nombre + "(" + num + ")";

                DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node.Nodes.Add(new object[] { TipoCompra.Nombre + "(" + num + ")" });
                node.ImageIndex = 1;
                node.SelectImageIndex = 1;
                node.Tag = Nodo;
                node.Checked = datosChecked.Exists(x => x.id == TipoCompra.id) ? true : false;
                node.Nodes.Add("");
            }
            tree.EndUpdate();
        }

        private void AgregarNodosGrupoSoporte(BeforeExpandEventArgs e, DatoNodo Valor)
        {
            tree.BeginUpdate();

            e.Node.Nodes.Clear();


            foreach (DatoNodo GrupoSoporte in datosVisualizados.Where(x => x.idPadre == Valor.id))
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = GrupoSoporte.id;
                Nodo.Nombre = GrupoSoporte.Nombre;
                Nodo.nombreLevel = GrupoSoporte.nombreLevel;
                Nodo.idADP = GrupoSoporte.idADP;
                Nodo.Level = TreeLevel.GrupoSoporte;

                int num = BuscarHijos(GrupoSoporte.id);
                //GrupoSoporte.Nombre = GrupoSoporte.Nombre + "(" + num + ")";

                DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node.Nodes.Add(new object[] { GrupoSoporte.Nombre + "(" + num + ")" });
                node.ImageIndex = 1;
                node.SelectImageIndex = 1;
                node.Tag = Nodo;
                node.Checked = datosChecked.Exists(x => x.id == GrupoSoporte.id) ? true : false;
                node.Nodes.Add("");
            }
            tree.EndUpdate();
        }

        private void AgregarNodosCadenas(BeforeExpandEventArgs e, DatoNodo Valor)
        {
            tree.BeginUpdate();

            e.Node.Nodes.Clear();


            foreach (DatoNodo Cadena in datosVisualizados.Where(x => x.idPadre == Valor.id))
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = Cadena.id;
                Nodo.Nombre = Cadena.Nombre;
                Nodo.nombreLevel = Cadena.nombreLevel;
                Nodo.idADP = Cadena.idADP;
                Nodo.Level = TreeLevel.Cadena;

                int num = BuscarHijos(Cadena.id);
                //Cadena.Nombre = Cadena.Nombre + "(" + num + ")";

                DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node.Nodes.Add(new object[] { Cadena.Nombre + "(" + num + ")" });
                node.ImageIndex = 1;
                node.SelectImageIndex = 1;
                node.Tag = Nodo;
                node.Checked = datosChecked.Exists(x => x.id == Cadena.id) ? true : false;
                node.Nodes.Add("");
            }
            tree.EndUpdate();
        }

        private void AgregarNodosCadenasAlias(BeforeExpandEventArgs e, DatoNodo Valor)
        {
            tree.BeginUpdate();

            e.Node.Nodes.Clear();


            foreach (DatoNodo CadenaAlias in datosVisualizados.Where(x => x.idPadre == Valor.id))
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = CadenaAlias.id;
                Nodo.Nombre = CadenaAlias.Nombre;
                Nodo.nombreLevel = CadenaAlias.nombreLevel;
                Nodo.idADP = CadenaAlias.idADP;
                Nodo.Level = TreeLevel.CadenaAlias;
                
                DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node.Nodes.Add(new object[] { CadenaAlias.Nombre });
                node.ImageIndex = 1;
                node.SelectImageIndex = 1;
                node.Checked = datosChecked.Exists(x => x.id == CadenaAlias.id) ? true : false;
                node.Tag = Nodo;
                //node.Nodes.Add("");
            }
            tree.EndUpdate();
        }

        #endregion


        private bool Coincide(DatoNodo item)
        {
            if (item != null)
                if (item.Nombre.ToLower() == txtBuscar.Text.ToLower() || item.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()) || item.idADP.ToString() == txtBuscar.Text || item.idADP.ToString().Contains(txtBuscar.Text))
                {
                    return true;
                }
            return false;
        }

        #region funciones ToolStrip

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
        }

        private void Buscar()
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                if (tree != null)
                {
                    textoBuscadoAnterior=txtBuscar.Text;
                    Start(true);
                }
            }
            else if (!string.IsNullOrEmpty(textoBuscadoAnterior))
            {
                Start();
            }
            else
            {
                textoBuscadoAnterior=string.Empty;
                MessageBox.Show("No hay texto a buscar");
            }
        }

        private void EndTimerTxt(object sender, EventArgs e)
        {
            Buscar();// Do here what you wanted to do in TextChanged;
            timer.Stop();  // This line must be here, at the end of the method
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Buscar();
            }
        }

        private void btRefrescar_Click(object sender, EventArgs e)
        {
            //recargarDatosEvento();
            if (!this.DesignMode)
            {
                Start();
            }
        }

        private void tree_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                desmarcarTodoToolStripMenuItem.Visible = datosChecked.HasContent() ? true : false;
            }
        }

        #endregion


        #region MenuStrip

        private void expandirTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tree.ExpandAll();
        }

        private void contraerTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tree.CollapseAll();
        }

        private void desmarcarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesmarcarTodo();
        }

        #endregion


        #region checks

        public List<DatoNodo> getChecked()
        {
            return datosChecked.Where(x => x.Level == TreeLevel.Cadena || x.Level == TreeLevel.CadenaAlias).ToList();
        }

        public void UncheckAll()
        {
            DesmarcarTodo();
        }

        private void tree_AfterCheckNode(object sender, NodeEventArgs e)
        {
            e.Node.ExpandAll();
            CheckUnCheck(e.Node, e.Node.Checked);
            if (e.Node.Checked)
            {
                datosChecked.Add(((DatoNodo)e.Node.Tag));
            }
            else
            {
                datosChecked.Remove(datosChecked.First(x => x.id == ((DatoNodo)e.Node.Tag).id));
            }
            nuevoCheckEvento();
        }

        private void CheckUnCheck(TreeListNode Nod, bool estado)
        {
            foreach (TreeListNode item in Nod.Nodes)
            {
                item.Checked = estado;
                if (item.Nodes.Count > 0)
                    CheckUnCheck(item, item.Checked);
                if (estado)
                {
                    datosChecked.Add(((DatoNodo)item.Tag));
                }
                else
                {
                    datosChecked.Remove(datosChecked.First(x => x.id == ((DatoNodo)item.Tag).id));
                }
            }


        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            ConfirmarEvento();
        }

        private void btDesmarcarTodo_Click(object sender, EventArgs e)
        {
            DesmarcarTodo();
        }

        private void DesmarcarTodo()
        {
            tree.UncheckAll();
            datosChecked = new List<DatoNodo>();
            nuevoCheckEvento();
        }

        #endregion

        

        

    }
}
