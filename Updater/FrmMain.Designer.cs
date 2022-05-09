namespace Updater
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.cCircularProgresBackground1 = new Updater.cCircularProgresBackground();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btBuscar = new System.Windows.Forms.Button();
            this.tree = new System.Windows.Forms.TreeView();
            this.mnuArbol = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandirTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contraerTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imgTree = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mnuArbol.SuspendLayout();
            this.SuspendLayout();
            // 
            // cCircularProgresBackground1
            // 
            this.cCircularProgresBackground1.Location = new System.Drawing.Point(25, 12);
            this.cCircularProgresBackground1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cCircularProgresBackground1.MostrarTiempoCarga = false;
            this.cCircularProgresBackground1.Name = "cCircularProgresBackground1";
            this.cCircularProgresBackground1.Size = new System.Drawing.Size(189, 204);
            this.cCircularProgresBackground1.TabIndex = 0;
            this.cCircularProgresBackground1.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btBuscar);
            this.splitContainer1.Panel1.Controls.Add(this.cCircularProgresBackground1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tree);
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(73, 315);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 23);
            this.btBuscar.TabIndex = 1;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // tree
            // 
            this.tree.ContextMenuStrip = this.mnuArbol;
            this.tree.Dock = System.Windows.Forms.DockStyle.Left;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(346, 450);
            this.tree.TabIndex = 2;
            // 
            // mnuArbol
            // 
            this.mnuArbol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandirTodoToolStripMenuItem,
            this.contraerTodoToolStripMenuItem});
            this.mnuArbol.Name = "mnuArbol";
            this.mnuArbol.Size = new System.Drawing.Size(151, 48);
            // 
            // expandirTodoToolStripMenuItem
            // 
            this.expandirTodoToolStripMenuItem.Name = "expandirTodoToolStripMenuItem";
            this.expandirTodoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.expandirTodoToolStripMenuItem.Text = "Expandir Todo";
            this.expandirTodoToolStripMenuItem.Click += new System.EventHandler(this.expandirTodoToolStripMenuItem_Click);
            // 
            // contraerTodoToolStripMenuItem
            // 
            this.contraerTodoToolStripMenuItem.Name = "contraerTodoToolStripMenuItem";
            this.contraerTodoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.contraerTodoToolStripMenuItem.Text = "Contraer Todo";
            this.contraerTodoToolStripMenuItem.Click += new System.EventHandler(this.contraerTodoToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(352, 125);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(178, 213);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // imgTree
            // 
            this.imgTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTree.ImageStream")));
            this.imgTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTree.Images.SetKeyName(0, "folder");
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.mnuArbol.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private cCircularProgresBackground cCircularProgresBackground1;
        private SplitContainer splitContainer1;
        private Button btBuscar;
        private ListView listView1;
        private ImageList imgTree;
        private TreeView tree;
        private ContextMenuStrip mnuArbol;
        private ToolStripMenuItem expandirTodoToolStripMenuItem;
        private ToolStripMenuItem contraerTodoToolStripMenuItem;
    }
}