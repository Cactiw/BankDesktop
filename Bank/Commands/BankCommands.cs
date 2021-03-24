using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Bank.Commands
{
    public class BankCommands
    {
        public static RoutedUICommand SettingsDialogOkClick
                            = new RoutedUICommand("Ok button click in Settings dialog",
                                                  "SettingsDialogOkClick",
                                                  typeof(BankCommands));
    }
}
