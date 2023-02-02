using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Src.Models;
using Src.ViewModels.Commands;
using Src.ViewModels.Helper;

namespace Src.ViewModels
{
    public class AddTaskViewModel
    {
        public RelayCommand saveNewTask { get; set; }

        public UserTask NewTask { get; set; }

        public AddTaskViewModel()
        {
            saveNewTask = new RelayCommand(SaveTask);
            NewTask = new UserTask();
            NewTask.DueTime = DateTime.Now;
        }

        public void SaveTask(object parameter)
        {
            SQLiteHelper.AddTaskToDB(NewTask);

            OnCloseEvent();
        }

        public event EventHandler CloseEvent;

        protected virtual void OnCloseEvent()
        {
            CloseEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
