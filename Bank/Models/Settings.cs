using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

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

        public ICommand CancelCommand { get; set; }
        public ICommand OkCommand { get; set; }

        public static Settings Instance { get; }
        public int WorkersNum { get; set; } = 4;
        public int WorkersSalary { get; set; } = 50;
        public int CustomerFlow { get; set; } = 50;
        public int QueueLimit { get; set; } = 15;
        public int TimeToProcessBegin { get; set; } = 5;
        public int TimeToProcessEnd { get; set; } = 30;
        public int ProfitStart { get; set; } = 10;
        public int ProfitEnd { get; set; } = 100;
        public int StepMinutes { get; set; } = 30;
        public int NumWorkers { get; internal set; }


        static readonly int WorkersNumLimit = 100;
        static readonly int WorkersSalaryLimit = 100;
        static readonly int CustomerFlowLimit = 1000;
        static readonly int QueueLimitLimit = 10000;
        static readonly int TimeToProcessBeginLimit = 100;
        static readonly int TimeToProcessEndLimit = 100;
        static readonly int ProfitStartLimit = 100000;
        static readonly int ProfitEndLimit = 100000;
        static readonly int StepMinutesLimit = 10000;

        public static List<String> DayNames { get; } = new List<string>
        {
            "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"
        };
        public static List<List<TimeSpan>> WorkTimes { get; } = new List<List<TimeSpan>>
        {
            new List<TimeSpan> {new TimeSpan(10, 0, 0), new TimeSpan(18, 0, 0)},
            new List<TimeSpan> {new TimeSpan(10, 0, 0), new TimeSpan(18, 0, 0)},
            new List<TimeSpan> {new TimeSpan(10, 0, 0), new TimeSpan(18, 0, 0)},
            new List<TimeSpan> {new TimeSpan(10, 0, 0), new TimeSpan(18, 0, 0)},
            new List<TimeSpan> {new TimeSpan(10, 0, 0), new TimeSpan(18, 0, 0)},
            new List<TimeSpan> {new TimeSpan(10, 0, 0), new TimeSpan(16, 0, 0)},
        };
        public static TimeSpan GetDayStartTime(int DayOfWeek)
        {
            var Times = WorkTimes[DayOfWeek];
            return Times[0];
        }
        public static TimeSpan GetDayEndTime(int DayOfWeek)
        {
            var Times = WorkTimes[DayOfWeek];
            return Times[1];
        }

        public void ValidateData()
        {
            if (WorkersNum < 1)
            {
                WorkersNum = 1;
            } else if (WorkersNum > WorkersNumLimit)
            {
                WorkersNum = WorkersNumLimit;
            }
            
            if (WorkersSalary < 1)
            {
                WorkersSalary = 1;
            } else if (WorkersSalary > WorkersSalaryLimit)
            {
                WorkersSalary = WorkersSalaryLimit;
            }
            
            if (CustomerFlow < 1)
            {
                CustomerFlow = 1;
            } else if (CustomerFlow > CustomerFlowLimit)
            {
                CustomerFlow = CustomerFlowLimit;
            }
            
            if (QueueLimit < 1)
            {
                QueueLimit = 1;
            } else if (QueueLimit > QueueLimitLimit)
            {
                QueueLimit = QueueLimitLimit;
            }
            
            if (TimeToProcessBegin < 1)
            {
                TimeToProcessBegin = 1;
            } else if (TimeToProcessBegin > TimeToProcessBeginLimit)
            {
                TimeToProcessBegin = TimeToProcessBeginLimit;
            }
            
            
            if (TimeToProcessEnd < 1)
            {
                TimeToProcessEnd = 1;
            } else if (TimeToProcessEnd > TimeToProcessEndLimit)
            {
                TimeToProcessEnd = TimeToProcessEndLimit;
            }
            
            
            if (ProfitStart < 1)
            {
                ProfitStart = 1;
            } else if (ProfitStart > ProfitStartLimit)
            {
                ProfitStart = ProfitStartLimit;
            }
            
            
            if (ProfitEnd < 1)
            {
                ProfitEnd = 1;
            } else if (ProfitEnd > ProfitEndLimit)
            {
                ProfitEnd = ProfitEndLimit;
            }
            
            
            
            if (StepMinutes < 1)
            {
                StepMinutes = 1;
            } else if (StepMinutes > StepMinutesLimit)
            {
                StepMinutes = StepMinutesLimit;
            }

        }
    }
}
