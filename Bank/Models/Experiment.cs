﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Bank.Models
{
    class Experiment
    {
        public bool Started { get; set; } = false;
        private BackgroundWorker backgroundWorker { get; set; }
        private Random Rnd { get; set; }
        private int NextClientSpawn { get; set; }
        public Department Department { get; set; }
        public int Day { get; set; }
        public TimeSpan CurrentTime { get; set; }
        public int ClientNum { get; set; } = 1;
        public Experiment(in BackgroundWorker backgroundWorker)
        {
            this.backgroundWorker = backgroundWorker;
            //this.SetBackgroundWorker();
            Rnd = new Random();
        }

        public void Start()
        {
            Started = true;
            Department = new Department(Settings.Instance.WorkersNum, Settings.Instance.QueueLimit);
            NextClientSpawn = 1;
            Day = 0;
            CurrentTime = Settings.GetDayStartTime(Day);

            //backgroundWorker.RunWorkerAsync(department);
        }

        public void MakeStep()
        {
            foreach (int i in System.Linq.Enumerable.Range(0, Settings.Instance.StepMinutes))
            {
                NextClientSpawn -= 1;
                if (NextClientSpawn <= 0)
                {
                    Client NewClient = new Client(ClientNum, Rnd.Next(0, Settings.Instance.TimeToProcessEnd - Settings.Instance.TimeToProcessBegin) + Settings.Instance.TimeToProcessBegin);
                    ClientNum += 1;
                    Trace.WriteLine("Spawned Client with " + NewClient.TimeToSolve.ToString());
                    Department.NewClient(NewClient);

                    NextClientSpawn = Rnd.Next(0, 15 - ((Settings.Instance.CustomerFlow - 50) / 10));
                }
                Department.Tick(1);
                CurrentTime = CurrentTime.Add(new TimeSpan(0, 1, 0));
                Trace.WriteLine("Minute passed, CurrentTime = " + CurrentTime.ToString());

                if (CurrentTime.CompareTo(Settings.GetDayEndTime(Day)) >= 0)
                {
                    NextDay();
                    break;
                }
            }
        }

        private void NextDay()
        {
            Day += 1;
            if (Day >= Settings.DayNames.Count)
            {
                Trace.WriteLine("End of expiriment!");
            }
            else
            {
                CurrentTime = Settings.GetDayStartTime(Day);
                Department.ClearState();
            }
        }

    //    private void SetBackgroundWorker()
    //    {
    //        backgroundWorker.DoWork += backgroundWorker_DoWork;
    //        backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
    //        backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
    //    }

    //    public void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    //    {
    //        Department department = (Department)e.Result;
    //        Trace.WriteLine("In work");
    //        var rnd = new Random();
    //        while (true)
    //        {
    //            if (rnd.Next(100) <= Settings.Instance.CustomerFlow)
    //            {
    //                department.NewClient(new Client(rnd.Next(Settings.Instance.TimeToProcessEnd - Settings.Instance.TimeToProcessBegin) + Settings.Instance.TimeToProcessBegin));
    //            }
    //        }
    //    }

    //    public void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    //    {

    //    }

    //    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    //    {
    //        //update ui once worker complete his work
    //    }
    }
}
