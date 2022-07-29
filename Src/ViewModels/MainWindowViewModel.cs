using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Src.Models;
using Src.ViewModels.Commands;
using Src.Views;
using System.Windows;

namespace Src.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<UserTask> Tasks { get; set; }
        public ObservableCollection<UserProject> Projects { get; set; }
        public UserTask SelectedTask { get; set; }
        public UserProject SelectedProject { get; set; }
        public NewTaskCommand NewTask { get; set; }
        public DeleteTaskCommand DeleteTask { get; set; }
        public SetCompleteCommand SetComplete { get; set; }

        private bool listByPrio = false;
        public MainWindowViewModel()
        {
            NewTask = new NewTaskCommand(this);
            Tasks = new ObservableCollection<UserTask>();
            DeleteTask = new DeleteTaskCommand(this);
            SetComplete = new SetCompleteCommand();
            ReadTaskDatabase();
        }
        public void ReadTaskDatabase()
        {
            List<UserTask> list = new List<UserTask>();
            using (SQLiteConnection newConnection = new SQLiteConnection(App.databasePath))
            {
                newConnection.CreateTable<UserTask>();
                if (listByPrio)
                {
                    list = newConnection.Table<UserTask>().ToList().OrderBy(c => c.Priority).ToList();
                }
                else
                {
                    list = newConnection.Table<UserTask>().ToList().OrderBy(c => c.Title).ToList();
                }
                
            }
            Tasks.Clear();
            foreach(UserTask ut in list)
            {
                if (ut.ProjectId == 0)
                {
                    Tasks.Add(ut);
                }

            }
        }
        public void TaskListDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedTask != null)
            {
                TaskEditWindow taskEdit = new TaskEditWindow(SelectedTask);
                taskEdit.ShowDialog();
                ReadTaskDatabase();
            }
        }
        public void ListByName_Checked(object sender, RoutedEventArgs e)
        {
            listByPrio = false;
            ReadTaskDatabase();
        }
        public void ListByPrioity_Checked(object sender, RoutedEventArgs e)
        {
            listByPrio = true;
            ReadTaskDatabase();
        } 
    }
}
