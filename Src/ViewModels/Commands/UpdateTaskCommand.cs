using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Src.ViewModels.Commands
{
    public class UpdateTaskCommand : ICommand
    {
        private TaskEditViewModel TEVM { get; set; }

        public UpdateTaskCommand(TaskEditViewModel tevm)
        {
            TEVM = tevm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            TEVM.UpdateTask();
        }
    }
}
