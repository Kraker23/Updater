namespace Updater
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.circularProgressBar = new Updater.CircularProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cCircularProgresBackground1 = new Updater.cCircularProgresBackground();
            this.SuspendLayout();
            // 
            // circularProgressBar
            // 
            this.circularProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.circularProgressBar.BarColor1 = System.Drawing.Color.Red;
            this.circularProgressBar.BarColor2 = System.Drawing.Color.Orange;
            this.circularProgressBar.BarWidth = 15F;
            this.circularProgressBar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.circularProgressBar.ForeColor = System.Drawing.Color.DimGray;
            this.circularProgressBar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.circularProgressBar.LineColor = System.Drawing.Color.DimGray;
            this.circularProgressBar.LineWidth = 1;
            this.circularProgressBar.Location = new System.Drawing.Point(51, 34);
            this.circularProgressBar.Maximum = ((long)(100));
            this.circularProgressBar.MinimumSize = new System.Drawing.Size(100, 100);
            this.circularProgressBar.Name = "circularProgressBar";
            this.circularProgressBar.ProgressShape = Updater.CircularProgressBar._ProgressShape.Round;
            this.circularProgressBar.Size = new System.Drawing.Size(287, 287);
            this.circularProgressBar.TabIndex = 0;
            this.circularProgressBar.Text = "57";
            this.circularProgressBar.TextMode = Updater.CircularProgressBar._TextMode.Percentage;
            this.circularProgressBar.Value = ((long)(57));
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(533, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cCircularProgresBackground1
            // 
            this.cCircularProgresBackground1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cCircularProgresBackground1.Location = new System.Drawing.Point(487, 259);
            this.cCircularProgresBackground1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cCircularProgresBackground1.MostrarTiempoCarga = false;
            this.cCircularProgresBackground1.Name = "cCircularProgresBackground1";
            this.cCircularProgresBackground1.Size = new System.Drawing.Size(131, 168);
            this.cCircularProgresBackground1.TabIndex = 4;
            this.cCircularProgresBackground1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cCircularProgresBackground1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.circularProgressBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CircularProgressBar circularProgressBar;
        private Button button1;
        private Button button2;
        private cCircularProgresBackground cCircularProgresBackground1;
    }
}