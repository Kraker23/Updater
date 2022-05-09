namespace Updater
{
    partial class cCircularProgresBackground
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
            this.lbl = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.circularProgressBar = new Updater.CircularProgressBar();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(48, 10);
            this.lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(104, 15);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Cargando Datos ...";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(14, 15);
            this.lblTiempo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(0, 15);
            this.lblTiempo.TabIndex = 2;
            this.lblTiempo.Visible = false;
            // 
            // circularProgressBar
            // 
            this.circularProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.circularProgressBar.BarColor1 = System.Drawing.Color.Orange;
            this.circularProgressBar.BarColor2 = System.Drawing.Color.Orange;
            this.circularProgressBar.BarWidth = 14F;
            this.circularProgressBar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.circularProgressBar.ForeColor = System.Drawing.Color.DimGray;
            this.circularProgressBar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.circularProgressBar.LineColor = System.Drawing.Color.DimGray;
            this.circularProgressBar.LineWidth = 1;
            this.circularProgressBar.Location = new System.Drawing.Point(14, 33);
            this.circularProgressBar.Maximum = ((long)(100));
            this.circularProgressBar.MinimumSize = new System.Drawing.Size(100, 100);
            this.circularProgressBar.Name = "circularProgressBar";
            this.circularProgressBar.ProgressShape = Updater.CircularProgressBar._ProgressShape.Flat;
            this.circularProgressBar.Size = new System.Drawing.Size(164, 164);
            this.circularProgressBar.TabIndex = 3;
            this.circularProgressBar.Text = "57";
            this.circularProgressBar.TextMode = Updater.CircularProgressBar._TextMode.Percentage;
            this.circularProgressBar.Value = ((long)(57));
            // 
            // cCircularProgresBackground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.circularProgressBar);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lbl);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "cCircularProgresBackground";
            this.Size = new System.Drawing.Size(200, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label lblTiempo;
        private CircularProgressBar circularProgressBar;
    }
}
