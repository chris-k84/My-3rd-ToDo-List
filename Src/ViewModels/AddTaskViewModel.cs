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
        private static int instances = 0;
        public SaveNewTaskCommand saveNewTask { get; set; }

        public UserTask NewTask { get; set; }

        public AddTaskViewModel()
        {
            saveNewTask = new SaveNewTaskCommand(this);
            NewTask = new UserTask();

            instances++;
        }

        public void SaveTask()
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
