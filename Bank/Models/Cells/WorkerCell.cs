using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Bank.Models.Cells
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
}
