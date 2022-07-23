using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Src.Models;
using Src.ViewModels.Commands;
using Src.ViewModels.Helper;

namespace Src.ViewModels
{
    public class TaskEditViewModel
    {
        public UserTask UserTask { get; set; }

        public TaskEditViewModel(UserTask userTask)
        {
            UserTask = userTask;
            UpdateTaskCommand = new UpdateTaskCommand(this);
        }

        public UpdateTaskCommand UpdateTaskCommand { get; set; }

        public void UpdateTask()
        {

            SQLiteHelper.UpdateTaskInDB(UserTask);

            OnCloseEvent();
        }

        public event EventHandler CloseEvent;

        protected virtual void OnCloseEvent()
        {
            CloseEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
