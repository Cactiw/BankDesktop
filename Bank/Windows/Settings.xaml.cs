using Bank.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bank
{
    public partial class SettingsWindow : Window
    {
        //private TextBox WorkersBox { get; set; }
        //private TextBox WorkersSalaryBox { get; set; }
        //private TextBox TimeToProcessBeginBox { get; set; }
        //private TextBox TimeToProcessEndBox { get; set; }
        //private TextBox ProfitStartBox { get; set; }
        //private TextBox ProfitEndBox { get; set; }
        //private TextBox StepMinutesBox { get; set; }
        private Settings SettingsInstance { get; }
        public SettingsWindow()
        {
            InitializeComponent();
            SettingsInstance = Settings.Instance;
            this.DataContext = SettingsInstance;
        }

        public void OkClick(object sender, RoutedEventArgs e) {
            Trace.WriteLine("OK");
            Trace.WriteLine(this.WorkersBox.Text);
            this.DialogResult = true;
        }

        private void CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = IsValid(sender as DependencyObject);
        }

        private bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors and all
            // of its children (that are dependency objects) are error-free.
            return !Validation.GetHasError(obj) &&
            LogicalTreeHelper.GetChildren(obj)
            .OfType<DependencyObject>()
            .All(IsValid);
        }
    }
}