using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Src.ViewModels.Commands
{
    public class SaveNewTaskCommand : ICommand
    {
        private AddTaskViewModel atvm { set; get; }

        public SaveNewTaskCommand(AddTaskViewModel ATVM) 
        {
            atvm = ATVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            atvm.SaveTask();
        }
    }
}
