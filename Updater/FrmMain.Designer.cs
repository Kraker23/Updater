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
            this.cCircularProgresBackground1 = new Updater.cCircularProgresBackground();
            this.SuspendLayout();
            // 
            // cCircularProgresBackground1
            // 
            this.cCircularProgresBackground1.Location = new System.Drawing.Point(591, 227);
            this.cCircularProgresBackground1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cCircularProgresBackground1.MostrarTiempoCarga = false;
            this.cCircularProgresBackground1.Name = "cCircularProgresBackground1";
            this.cCircularProgresBackground1.Size = new System.Drawing.Size(144, 161);
            this.cCircularProgresBackground1.TabIndex = 0;
            this.cCircularProgresBackground1.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cCircularProgresBackground1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private cCircularProgresBackground cCircularProgresBackground1;
    }
}