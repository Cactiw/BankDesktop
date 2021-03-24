using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bank.Models
{
    class Experiment
    {
        private BackgroundWorker backgroundWorker { get; set; }
        public Experiment(in BackgroundWorker backgroundWorker)
        {
            this.backgroundWorker = backgroundWorker;
            this.SetBackgroundWorker();
        }

        public void Start()
        {
            var NumWorkers = 4;
            var SpawnProbability = 10;
            var department = new Department(NumWorkers);

            backgroundWorker.RunWorkerAsync(NumWorkers);

        }

        private void SetBackgroundWorker()
        {
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }

        public void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        public void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
        }
    }
}
