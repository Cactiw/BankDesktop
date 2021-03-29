using Bank.Models;
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
    public class WorkerCell
    {
        public int Number { get; }
        public String NumberString { get; }
        public bool IsBusy { get; }
        public SolidColorBrush BackgroundColor { get; }

        public WorkerCell(int number, bool isBusy)
        {
            Number = number;
            NumberString = "Работник " + Number.ToString();
            IsBusy = isBusy;
            BackgroundColor = isBusy ? new SolidColorBrush(Color.FromArgb(150, 245, 66, 66)) : new SolidColorBrush(Color.FromArgb(100, 66, 245, 182));
        }
    }
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
            BackgroundWorker backgroundWorker = ((BackgroundWorker)this.FindResource("backgroundWorker"));
            Experiment = new Experiment(backgroundWorker);
            Experiment.Start();
            WorkerList.ItemsSource = WorkerCells;
            ExitMenuButton.Click += (s, e) => { Application.Current.Shutdown(); };

            UpdateUI();
        }

        private void StepClick(object sender, RoutedEventArgs e)
        {
            Experiment.MakeStep();
            UpdateUI();
        }

        private void UpdateUI()
        {
            TimeTextBlock.Text = Settings.DayNames[Experiment.Day] + " " + Experiment.CurrentTime.ToString();
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
            UpdateWorkersTable();
        }

        private void UpdateWorkersTable()
        {
            String text = "Клиент -> Окно\n";
            foreach (int i in System.Linq.Enumerable.Range(0, Experiment.Department.NumWorkers)) {
                int number = Experiment.Department.ClientsWent[i];
                if (number != -1)
                {
                    text += number.ToString() + " -> " + i.ToString() + "\n";
                }
            }
            TableBlock.Text = text;
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
