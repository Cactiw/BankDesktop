using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models
{
    public class Settings
    {
        static Settings()
        {
            Instance = new Settings();
        }

        private Settings()
        {

        }

        public static Settings Instance { get; }
        public int WorkersNum { get; set; } = 4;
        public int WorkersSalary { get; set; } = 50;
        public int TimeToProcessBegin { get; set; } = 5;
        public int TimeToProcessEnd { get; set; } = 15;
        public int ProfitStart { get; set; } = 10;
        public int ProfitEnd { get; set; } = 100;
        public int StepMinutes { get; set; } = 30;
    }
}
