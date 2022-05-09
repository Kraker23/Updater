namespace Updater
{
    partial class cTree
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
            this.mnuArbol = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandirTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contraerTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desmarcarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tree = new System.Windows.Forms.TreeView();
            this.mnuArbol.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuArbol
            // 
            this.mnuArbol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandirTodoToolStripMenuItem,
            this.contraerTodoToolStripMenuItem,
            this.desmarcarTodoToolStripMenuItem});
            this.mnuArbol.Name = "mnuArbol";
            this.mnuArbol.Size = new System.Drawing.Size(161, 70);
            // 
            // expandirTodoToolStripMenuItem
            // 
            this.expandirTodoToolStripMenuItem.Name = "expandirTodoToolStripMenuItem";
            this.expandirTodoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.expandirTodoToolStripMenuItem.Text = "Expandir Todo";
            this.expandirTodoToolStripMenuItem.Click += new System.EventHandler(this.expandirTodoToolStripMenuItem_Click);
            // 
            // contraerTodoToolStripMenuItem
            // 
            this.contraerTodoToolStripMenuItem.Name = "contraerTodoToolStripMenuItem";
            this.contraerTodoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.contraerTodoToolStripMenuItem.Text = "Contraer Todo";
            this.contraerTodoToolStripMenuItem.Click += new System.EventHandler(this.contraerTodoToolStripMenuItem_Click);
            // 
            // desmarcarTodoToolStripMenuItem
            // 
            this.desmarcarTodoToolStripMenuItem.Name = "desmarcarTodoToolStripMenuItem";
            this.desmarcarTodoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.desmarcarTodoToolStripMenuItem.Text = "Desmarcar Todo";
            this.desmarcarTodoToolStripMenuItem.Click += new System.EventHandler(this.desmarcarTodoToolStripMenuItem_Click);
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(362, 443);
            this.tree.TabIndex = 11;
            // 
            // cTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tree);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(362, 443);
            this.Name = "cTree";
            this.Size = new System.Drawing.Size(362, 443);
            this.mnuArbol.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip mnuArbol;
        private System.Windows.Forms.ToolStripMenuItem expandirTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contraerTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desmarcarTodoToolStripMenuItem;
        private TreeView tree;
    }
}
