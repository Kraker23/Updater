namespace Updater.Trees
{
    partial class cTree
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tree = new System.Windows.Forms.TreeView();
            this.mnuArbol = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandirTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contraerTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArbol.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.ContextMenuStrip = this.mnuArbol;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(150, 150);
            this.tree.TabIndex = 0;
            this.tree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeExpand);
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
            // cTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tree);
            this.Name = "cTree";
            this.mnuArbol.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ContextMenuStrip mnuArbol;
        private ToolStripMenuItem expandirTodoToolStripMenuItem;
        private ToolStripMenuItem contraerTodoToolStripMenuItem;
        public TreeView tree;
    }
}
