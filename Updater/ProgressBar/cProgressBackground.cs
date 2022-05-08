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
    public partial class cProgressBackground : UserControl
    {
        private bool cargandoDatos;

        public bool MostrarTiempoCarga { get; set; } = false;
        private DateTime HoraInicio= new DateTime();


        public cProgressBackground()
        {
            
            InitializeComponent();
            progressBar.Maximum = 1000;
            progressBar.Step = 100;
            progressBar.Value = 0;
            this.Visible = false;
        }

        public void Start()
        {
            HoraInicio = DateTime.Now;

            this.Visible = true;
            cargandoDatos = true;
            lbl.Visible = true;
            lblTiempo.Visible = false;
            progressBar.Visible = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            do
            {
                for (int j = 0; j < 1000; j = j + 10)
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
            progressBar.Value = e.ProgressPercentage;
            progressBar.PerformStep();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            TimeSpan ts = DateTime.Now - HoraInicio;
            lblTiempo.Text = ts.TotalMilliseconds.ToString() + " ms";
           

            if (MostrarTiempoCarga)
            {
                lbl.Visible = false;
                progressBar.Visible = false;

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
    }
}
