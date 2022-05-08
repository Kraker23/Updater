namespace Updater
{
    partial class frmUpdate
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btUltimaFecha = new System.Windows.Forms.Button();
            this.btFicheros = new System.Windows.Forms.Button();
            this.txtBase = new System.Windows.Forms.RichTextBox();
            this.txtServidor = new System.Windows.Forms.RichTextBox();
            this.btUpdate = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btMover = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btActualizar = new System.Windows.Forms.Button();
            this.cProgress = new cProgressBackground();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(13, 103);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(343, 201);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.Text = "";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(10, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 13);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Comprobando si existe una Actualizacion";
            // 
            // btUltimaFecha
            // 
            this.btUltimaFecha.Location = new System.Drawing.Point(13, 38);
            this.btUltimaFecha.Name = "btUltimaFecha";
            this.btUltimaFecha.Size = new System.Drawing.Size(100, 23);
            this.btUltimaFecha.TabIndex = 4;
            this.btUltimaFecha.Text = "Ultima Fecha";
            this.btUltimaFecha.UseVisualStyleBackColor = true;
            this.btUltimaFecha.Visible = false;
            this.btUltimaFecha.Click += new System.EventHandler(this.btUltimaFecha_Click);
            // 
            // btFicheros
            // 
            this.btFicheros.Location = new System.Drawing.Point(119, 38);
            this.btFicheros.Name = "btFicheros";
            this.btFicheros.Size = new System.Drawing.Size(75, 23);
            this.btFicheros.TabIndex = 5;
            this.btFicheros.Text = "Ficheros";
            this.btFicheros.UseVisualStyleBackColor = true;
            this.btFicheros.Visible = false;
            this.btFicheros.Click += new System.EventHandler(this.btFicheros_Click);
            // 
            // txtBase
            // 
            this.txtBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBase.Location = new System.Drawing.Point(0, 0);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(71, 46);
            this.txtBase.TabIndex = 6;
            this.txtBase.Text = "";
            // 
            // txtServidor
            // 
            this.txtServidor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtServidor.Location = new System.Drawing.Point(0, 0);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(75, 46);
            this.txtServidor.TabIndex = 7;
            this.txtServidor.Text = "";
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(200, 38);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(75, 23);
            this.btUpdate.TabIndex = 8;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Visible = false;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtBase);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtServidor);
            this.splitContainer1.Size = new System.Drawing.Size(150, 46);
            this.splitContainer1.SplitterDistance = 71;
            this.splitContainer1.TabIndex = 9;
            // 
            // btMover
            // 
            this.btMover.Location = new System.Drawing.Point(281, 38);
            this.btMover.Name = "btMover";
            this.btMover.Size = new System.Drawing.Size(75, 23);
            this.btMover.TabIndex = 10;
            this.btMover.Text = "Mover";
            this.btMover.UseVisualStyleBackColor = true;
            this.btMover.Visible = false;
            this.btMover.Click += new System.EventHandler(this.btMover_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cProgress);
            this.splitContainer2.Panel1.Controls.Add(this.btActualizar);
            this.splitContainer2.Panel1.Controls.Add(this.txtDescripcion);
            this.splitContainer2.Panel1.Controls.Add(this.btMover);
            this.splitContainer2.Panel1.Controls.Add(this.btUpdate);
            this.splitContainer2.Panel1.Controls.Add(this.btFicheros);
            this.splitContainer2.Panel1.Controls.Add(this.lblTitulo);
            this.splitContainer2.Panel1.Controls.Add(this.btUltimaFecha);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(367, 312);
            this.splitContainer2.SplitterDistance = 83;
            this.splitContainer2.TabIndex = 11;
            // 
            // btActualizar
            // 
            this.btActualizar.Location = new System.Drawing.Point(305, 3);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(62, 23);
            this.btActualizar.TabIndex = 11;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Visible = false;
            this.btActualizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // cProgress
            // 
            this.cProgress.Location = new System.Drawing.Point(12, 67);
            this.cProgress.MostrarTiempoCarga = false;
            this.cProgress.Name = "cProgress";
            this.cProgress.Size = new System.Drawing.Size(343, 36);
            this.cProgress.TabIndex = 12;
            this.cProgress.Visible = false;
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 312);
            this.Controls.Add(this.splitContainer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizando Programa";
            this.Load += new System.EventHandler(this.frmUpdate_Load);
            this.Shown += new System.EventHandler(this.frmUpdate_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btUltimaFecha;
        private System.Windows.Forms.Button btFicheros;
        private System.Windows.Forms.RichTextBox txtBase;
        private System.Windows.Forms.RichTextBox txtServidor;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btMover;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btActualizar;
        private cProgressBackground cProgress;
    }
}

