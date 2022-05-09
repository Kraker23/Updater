namespace Updater
{
    partial class TreeClientes
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeClientes));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btRefrescarTreeClientes = new System.Windows.Forms.ToolStripButton();
            this.btBuscarTreeClientes = new System.Windows.Forms.ToolStripButton();
            this.btCampanasActivas = new System.Windows.Forms.ToolStripButton();
            this.txtBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.cboxClientes = new System.Windows.Forms.ToolStripComboBox();
            this.cboxCbAdP = new System.Windows.Forms.ToolStripComboBox();
            this.treeData = new DevExpress.XtraTreeList.TreeList();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandirTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contraerTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.copiarDatosDeTVEnCampañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.activarCampañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.listadoPasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seguimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjudicarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarPasesComoPlanificadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("Agencia", "devav/people/customerlocation_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("devav/people/customerlocation_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "Agencia");
            this.imageCollection1.InsertGalleryImage("Oficina", "images/navigation/home_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/navigation/home_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "Oficina");
            this.imageCollection1.InsertGalleryImage("Cliente", "devav/actions/mapit_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("devav/actions/mapit_16x16.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "Cliente");
            this.imageCollection1.Images.SetKeyName(3, "Division");
            this.imageCollection1.Images.SetKeyName(4, "Marca");
            this.imageCollection1.Images.SetKeyName(5, "Producto");
            this.imageCollection1.Images.SetKeyName(6, "Campana");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btRefrescarTreeClientes,
            this.btBuscarTreeClientes,
            this.btCampanasActivas,
            this.txtBuscar,
            this.cboxClientes,
            this.cboxCbAdP});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(556, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btRefrescarTreeClientes
            // 
            this.btRefrescarTreeClientes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btRefrescarTreeClientes.Image = ((System.Drawing.Image)(resources.GetObject("btRefrescarTreeClientes.Image")));
            this.btRefrescarTreeClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btRefrescarTreeClientes.Name = "btRefrescarTreeClientes";
            this.btRefrescarTreeClientes.Size = new System.Drawing.Size(23, 22);
            this.btRefrescarTreeClientes.Text = "Refrescar";
            this.btRefrescarTreeClientes.ToolTipText = "Refrescar";
            this.btRefrescarTreeClientes.Click += new System.EventHandler(this.btRefrescarTreeClientes_Click);
            // 
            // btBuscarTreeClientes
            // 
            this.btBuscarTreeClientes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btBuscarTreeClientes.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarTreeClientes.Image")));
            this.btBuscarTreeClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btBuscarTreeClientes.Name = "btBuscarTreeClientes";
            this.btBuscarTreeClientes.Size = new System.Drawing.Size(23, 22);
            this.btBuscarTreeClientes.Text = "Buscar";
            this.btBuscarTreeClientes.Click += new System.EventHandler(this.btBuscarTreeClientes_Click);
            // 
            // btCampanasActivas
            // 
            this.btCampanasActivas.CheckOnClick = true;
            this.btCampanasActivas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCampanasActivas.Image = ((System.Drawing.Image)(resources.GetObject("btCampanasActivas.Image")));
            this.btCampanasActivas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCampanasActivas.Name = "btCampanasActivas";
            this.btCampanasActivas.Size = new System.Drawing.Size(23, 22);
            this.btCampanasActivas.Text = "Campañas Activas";
            this.btCampanasActivas.Click += new System.EventHandler(this.btCampanasActivas_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(100, 25);
            // 
            // cboxClientes
            // 
            this.cboxClientes.BackColor = System.Drawing.Color.White;
            this.cboxClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxClientes.Items.AddRange(new object[] {
            "Cli. Activos",
            "Cli. InActivos",
            "Cli. Todos"});
            this.cboxClientes.Name = "cboxClientes";
            this.cboxClientes.Size = new System.Drawing.Size(121, 25);
            this.cboxClientes.Tag = "";
            this.cboxClientes.ToolTipText = "Clientes";
            this.cboxClientes.SelectedIndexChanged += new System.EventHandler(this.cboxClientes_SelectedIndexChanged);
            // 
            // cboxCbAdP
            // 
            this.cboxCbAdP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCbAdP.Items.AddRange(new object[] {
            "MBS",
            "AdP",
            "Todos"});
            this.cboxCbAdP.Name = "cboxCbAdP";
            this.cboxCbAdP.Size = new System.Drawing.Size(121, 25);
            this.cboxCbAdP.ToolTipText = "cbAdP";
            this.cboxCbAdP.SelectedIndexChanged += new System.EventHandler(this.cboxCbAdP_SelectedIndexChanged);
            // 
            // treeData
            // 
            this.treeData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeData.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.treeData.Appearance.Row.Options.UseBackColor = true;
            this.treeData.Appearance.Row.Options.UseBorderColor = true;
            this.treeData.Appearance.TreeLine.BackColor = System.Drawing.Color.White;
            this.treeData.Appearance.TreeLine.Options.UseBackColor = true;
            this.treeData.ContextMenuStrip = this.contextMenuStrip1;
            this.treeData.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeData.Location = new System.Drawing.Point(0, 25);
            this.treeData.Name = "treeData";
            this.treeData.SelectImageList = this.imageCollection1;
            this.treeData.Size = new System.Drawing.Size(556, 615);
            this.treeData.TabIndex = 3;
            this.treeData.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeData_NodeCellStyle);
            this.treeData.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.treeData_BeforeExpand);
            this.treeData.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeData_AfterFocusNode);
            this.treeData.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeData_AfterCheckNode);
            this.treeData.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.treeData_ShowingEditor);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandirTodoToolStripMenuItem,
            this.contraerTodoToolStripMenuItem,
            this.toolStripSeparator3,
            this.copiarDatosDeTVEnCampañaToolStripMenuItem,
            this.toolStripSeparator1,
            this.activarCampañaToolStripMenuItem,
            this.toolStripSeparator2,
            this.listadoPasesToolStripMenuItem,
            this.calendarioToolStripMenuItem,
            this.seguimientoToolStripMenuItem,
            this.configuraciónToolStripMenuItem,
            this.asignarInventarioToolStripMenuItem,
            this.adjudicarToolStripMenuItem,
            this.cargarPasesComoPlanificadosToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(245, 264);
            // 
            // expandirTodoToolStripMenuItem
            // 
            this.expandirTodoToolStripMenuItem.Name = "expandirTodoToolStripMenuItem";
            this.expandirTodoToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.expandirTodoToolStripMenuItem.Text = "Expandir Todo";
            this.expandirTodoToolStripMenuItem.Click += new System.EventHandler(this.expandirTodoToolStripMenuItem_Click);
            // 
            // contraerTodoToolStripMenuItem
            // 
            this.contraerTodoToolStripMenuItem.Name = "contraerTodoToolStripMenuItem";
            this.contraerTodoToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.contraerTodoToolStripMenuItem.Text = "Contraer Todo";
            this.contraerTodoToolStripMenuItem.Click += new System.EventHandler(this.contraerTodoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(241, 6);
            // 
            // copiarDatosDeTVEnCampañaToolStripMenuItem
            // 
            this.copiarDatosDeTVEnCampañaToolStripMenuItem.Name = "copiarDatosDeTVEnCampañaToolStripMenuItem";
            this.copiarDatosDeTVEnCampañaToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.copiarDatosDeTVEnCampañaToolStripMenuItem.Text = "Copiar Datos de TV en Campaña";
            this.copiarDatosDeTVEnCampañaToolStripMenuItem.Click += new System.EventHandler(this.copiarDatosDeTVEnCampañaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(241, 6);
            // 
            // activarCampañaToolStripMenuItem
            // 
            this.activarCampañaToolStripMenuItem.Name = "activarCampañaToolStripMenuItem";
            this.activarCampañaToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.activarCampañaToolStripMenuItem.Text = "Activar Campaña";
            this.activarCampañaToolStripMenuItem.Click += new System.EventHandler(this.activarCampañaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(241, 6);
            // 
            // listadoPasesToolStripMenuItem
            // 
            this.listadoPasesToolStripMenuItem.Name = "listadoPasesToolStripMenuItem";
            this.listadoPasesToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.listadoPasesToolStripMenuItem.Text = "Listado Pases ";
            this.listadoPasesToolStripMenuItem.Click += new System.EventHandler(this.listadoPasesToolStripMenuItem_Click);
            // 
            // calendarioToolStripMenuItem
            // 
            this.calendarioToolStripMenuItem.Name = "calendarioToolStripMenuItem";
            this.calendarioToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.calendarioToolStripMenuItem.Text = "Calendario";
            this.calendarioToolStripMenuItem.Click += new System.EventHandler(this.calendarioToolStripMenuItem_Click);
            // 
            // seguimientoToolStripMenuItem
            // 
            this.seguimientoToolStripMenuItem.Name = "seguimientoToolStripMenuItem";
            this.seguimientoToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.seguimientoToolStripMenuItem.Text = "Seguimiento";
            this.seguimientoToolStripMenuItem.Click += new System.EventHandler(this.seguimientoToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // asignarInventarioToolStripMenuItem
            // 
            this.asignarInventarioToolStripMenuItem.Name = "asignarInventarioToolStripMenuItem";
            this.asignarInventarioToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.asignarInventarioToolStripMenuItem.Text = "Asignar % Inventario ";
            this.asignarInventarioToolStripMenuItem.Click += new System.EventHandler(this.asignarInventarioToolStripMenuItem_Click);
            // 
            // adjudicarToolStripMenuItem
            // 
            this.adjudicarToolStripMenuItem.Name = "adjudicarToolStripMenuItem";
            this.adjudicarToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.adjudicarToolStripMenuItem.Text = "Adjudicar";
            this.adjudicarToolStripMenuItem.Click += new System.EventHandler(this.adjudicarToolStripMenuItem_Click);
            // 
            // cargarPasesComoPlanificadosToolStripMenuItem
            // 
            this.cargarPasesComoPlanificadosToolStripMenuItem.Name = "cargarPasesComoPlanificadosToolStripMenuItem";
            this.cargarPasesComoPlanificadosToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.cargarPasesComoPlanificadosToolStripMenuItem.Text = "Cargar pases como planificados";
            this.cargarPasesComoPlanificadosToolStripMenuItem.Click += new System.EventHandler(this.cargarPasesComoPlanificadosToolStripMenuItem_Click);
            // 
            // TreeClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeData);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TreeClientes";
            this.Size = new System.Drawing.Size(556, 640);
            this.Load += new System.EventHandler(this.TreeClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btRefrescarTreeClientes;
        private System.Windows.Forms.ToolStripButton btBuscarTreeClientes;
        private System.Windows.Forms.ToolStripComboBox cboxClientes;
        private System.Windows.Forms.ToolStripComboBox cboxCbAdP;
        //private Infragistics.Win.AppStyling.Runtime.AppStylistRuntime appStylistRuntime1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraTreeList.TreeList treeData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem expandirTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contraerTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem activarCampañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem listadoPasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calendarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seguimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarInventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjudicarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarPasesComoPlanificadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btCampanasActivas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem copiarDatosDeTVEnCampañaToolStripMenuItem;
    }
}
