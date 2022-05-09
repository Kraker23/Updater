using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Updater
{
    public partial class cCircularProgresBackground : UserControl
    {
        private bool cargandoDatos;

        public bool MostrarTiempoCarga { get; set; } = false;
        private DateTime HoraInicio = new DateTime();

        public cCircularProgresBackground()
        {
            InitializeComponent();
            circularProgressBar.Maximum = 100;
            circularProgressBar.Value = 0;
            this.Visible = false;
        }

        public cCircularProgresBackground(CircularProgressBar._TextMode mode= CircularProgressBar._TextMode.None) :base()
        {
            this.circularProgressBar.TextMode = mode;
        }

        public void Start()
        {
            HoraInicio = DateTime.Now;

            this.Visible = true;
            cargandoDatos = true;
            lbl.Visible = true;
            lblTiempo.Visible = false;
            circularProgressBar.Visible = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            do
            {
                for (int j = 0; j < 100; j = j + 1)
                {
                    if (cargandoDatos)
                    {
                        Thread.Sleep(100);
                        backgroundWorker.ReportProgress(j);
                    }
                    else
                    {
                        backgroundWorker.ReportProgress(0);
                        break;
                    }
                }
            }
            while (cargandoDatos);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            circularProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            TimeSpan ts = DateTime.Now - HoraInicio;
            lblTiempo.Text = ts.TotalMilliseconds.ToString() + " ms";


            if (MostrarTiempoCarga)
            {
                lbl.Visible = false;

                circularProgressBar.Visible = false;
                lblTiempo.Visible = true;
            }
            else
            {
                this.Visible = false;
            }
        }


        public void End()
        {
            cargandoDatos = false;
        }
/*
        private void cCircularProgresBackground_SizeChanged(object sender, EventArgs e)
        {
            base.OnSizeChanged(e);
           // SetStandardSize();
        }

        private void SetStandardSize()
        {
            int _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }*/
    }
}
