using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater.Trees
{
    public partial class cTree : UserControl
    {
        public cTree()
        {
            InitializeComponent();
        }

        private void expandirTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tree.ExpandAll();
        }

        private void contraerTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tree.CollapseAll();
        }

        private void tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            tree.BeginUpdate();
            DatoNodo Valor = (DatoNodo)e.Node.Tag;

          

            tree.EndUpdate();
        }
       
    }
}
