using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Bank.Models
{
    class Experiment
    {
        public bool Started { get; set; } = false;
        public bool Ended { get; set; } = false;
        private Random Rnd { get; set; }
        private int NextClientSpawn { get; set; }
        public Department Department { get; set; }
        public int Day { get; set; }
        public TimeSpan CurrentTime { get; set; }
        public int ClientNum { get; set; } = 1;
        public Experiment()
        {
            Rnd = new Random();
        }

        public void Start()
        {
            Started = true;
            Department = new Department(Settings.Instance.WorkersNum, Settings.Instance.WorkersSalary, Settings.Instance.QueueLimit);
            NextClientSpawn = 1;
            Day = 0;
            CurrentTime = Settings.GetDayStartTime(Day);

            //backgroundWorker.RunWorkerAsync(department);
        }

        public void MakeStep()
        {
            if (Ended)
            {
                return;
            }
            foreach (int i in System.Linq.Enumerable.Range(0, Settings.Instance.StepMinutes))
            {
                NextClientSpawn -= 1;
                if (NextClientSpawn <= 0)
                {
                    Client NewClient = new Client(
                        ClientNum, 
                        Rnd.Next(0, Settings.Instance.TimeToProcessEnd - Settings.Instance.TimeToProcessBegin) + Settings.Instance.TimeToProcessBegin, 
                        Rnd.Next(Settings.Instance.ProfitStart, Settings.Instance.ProfitEnd)
                    );
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
                Ended = true;
            }
            else
            {
                CurrentTime = Settings.GetDayStartTime(Day);
                Department.ClearState();
            }
        }
    }
}
