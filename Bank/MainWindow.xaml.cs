﻿using Bank.Models;
using Bank.Models.Cells;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Experiment Experiment { get; set; }
        private ObservableCollection<WorkerCell> WorkerCells = new ObservableCollection<WorkerCell>();
        public MainWindow()
        {
            InitializeComponent();
            Experiment = new Experiment();
            WorkerList.ItemsSource = WorkerCells;
            ExitMenuButton.Click += (s, e) => { Application.Current.Shutdown(); };
            ExitButton.Click += (s, e) => { Application.Current.Shutdown(); };

            UpdateUI();
        }
        private void ExperimentResetClick(object sender, RoutedEventArgs e)
        {
            Experiment = new Experiment();
            UpdateUI();
        }

        private void EndClick(object sender, RoutedEventArgs e)
        {
            while (!Experiment.Ended)
            {
                StepClick(sender, e);
            }
        }

        private void StepClick(object sender, RoutedEventArgs e)
        {
            if (Experiment.Started)
            {
                Experiment.MakeStep();
            } else
            {
                Experiment.Start();
            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            UpdateWorkersTable();
            UpdateStatistics();
            if (!Experiment.Started)
            {
                StepButton.Content = "Старт!";
                QueueBlock.Text = "Очередь пуста";
                WorkerCells.Clear();
                return;
            }
            StepButton.Content = "Шаг";
            if (Experiment.Day >= Settings.DayNames.Count)
            {
                TimeTextBlock.Text = "КОНЕЦ";
            }
            else
            {
                TimeTextBlock.Text = Settings.DayNames[Experiment.Day] + " " + Experiment.CurrentTime.ToString(@"hh\:mm");
            }
            int QueueCount = Experiment.Department.ClientQueue.Count();
            if (QueueCount <= 0)
            {
                QueueBlock.Text = "Очередь пуста";
            } else
            {
                QueueBlock.Text = "В очереди " + QueueCount.ToString() +  " человек";
            }
            WorkerCells.Clear();
            System.Diagnostics.Trace.WriteLine(Experiment.Department.Workers.Count().ToString());
            var newWorkersList = Experiment.Department.Workers.Select(worker => new WorkerCell(worker.Number, worker.IsBusy()));
            foreach (var workerCell in newWorkersList)
            {
                WorkerCells.Add(workerCell);
            }
        }

        private void UpdateWorkersTable()
        {
            String text = "Клиент -> Окно\n";
            if (Experiment.Started)
            {
                List<List<int>> lastClients = new List<List<int>>();
                foreach (int i in System.Linq.Enumerable.Range(0, Experiment.Department.NumWorkers))
                {
                    int number = Experiment.Department.ClientsWent[i];
                    if (number != -1)
                    {
                        var tulp = new List<int>();
                        tulp.Add(number);
                        tulp.Add(i);
                        lastClients.Add(tulp);
                    }
                }
                var sortedClients = lastClients.OrderBy(tulp => -tulp[0]);
                foreach(List<int> tulp in sortedClients)
                {
                    text += tulp[0].ToString() + " -> " + (tulp[1] + 1).ToString() + "\n";
                }
            }
            TableBlock.Text = text;
        }

        private void UpdateStatistics()
        {
            String text = "";
            if (Experiment.Started)
            {
                text += "Всего клиентов: " + Experiment.Department.ClientsTotal;
                text += "\nКлиентов обслужено: " + (Experiment.Department.ClientsTotal - Experiment.Department.ClientsLeft);
                text += "\nКлиентов ушло: " + Experiment.Department.ClientsLeft;
                text += "\nПолучено денег: " + Experiment.Department.EarnedMoney;
                text += "\nВыплачено зарплат: " + (int)Experiment.Department.SalaryPaid;
                text += "\nИтого прибыль: " + (int)(Experiment.Department.EarnedMoney - Experiment.Department.SalaryPaid);
                text += "\nКоэффициент занятости: " + Experiment.Department.GetWorkersBusyStatistics().ToString("0.00");
            }
            StatisticsBlock.Text = text;
        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            if (settingsWindow.ShowDialog() == true)
            {
            }
        }

        
    }
}
