using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Src.Views;

namespace Src.ViewModels.Commands
{
    public class NewTaskCommand : ICommand
    {
        private MainWindowViewModel MWVM { get; set; }

        public NewTaskCommand(MainWindowViewModel mwvm) 
        {
            MWVM = mwvm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AddTaskView tv = new AddTaskView();
            tv.ShowDialog();
            MWVM.ReadTaskDatabase();
        }
    }
}
