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
        public int TimeToProcessBegin { get; set; } = 5;
        public int TimeToProcessEnd { get; set; } = 30;
        public int ProfitStart { get; set; } = 10;
        public int ProfitEnd { get; set; } = 100;
        public int StepMinutes { get; set; } = 30;
        public int NumWorkers { get; internal set; }

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
    }
}
