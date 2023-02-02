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
    public interface IDataBaseReader
    {
        void ReadTaskDatabase();
        UserTask SelectedTask { get; set; }
    }
    class MainWindowViewModel : IDataBaseReader
    {
        public ObservableCollection<UserTask> Tasks { get; set; }

        public UserTask SelectedTask { get; set; }
        public RelayCommand AddNewTask {get; set; }

        public RelayCommand DeleteSelectedTask { get; set; }

        public RelayCommand SetTaskComplete { get; set; }

        private int listBy = 0;

        public MainWindowViewModel()
        {
            AddNewTask = new RelayCommand(AddNewTaskCommand);
            Tasks = new ObservableCollection<UserTask>();
            DeleteSelectedTask = new RelayCommand(DeleteSelectedTaskCommand);
            SetTaskComplete = new RelayCommand(SetTaskCompleteCommand);
            ReadTaskDatabase();
        }

        public void AddNewTaskCommand(object parameter)
        {
            AddTaskView tv = new AddTaskView();
            tv.ShowDialog();
            ReadTaskDatabase();
        }
        public void DeleteSelectedTaskCommand(object parameter)
        {
            DeleteTaskCheckView deleteTaskCheckView = new DeleteTaskCheckView();
            deleteTaskCheckView.ShowDialog();
            if (SelectedTask != null)
            {
                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.databasePath))
                {
                    sQLiteConnection.CreateTable<UserTask>();

                    sQLiteConnection.Delete(SelectedTask);
                }
            }
            ReadTaskDatabase();
        }
        public void SetTaskCompleteCommand(object parameter)
        {
            UserTask task = parameter as UserTask;
            task.IsComplete = true;
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.databasePath))
            {
                sQLiteConnection.CreateTable<UserTask>();

                sQLiteConnection.Delete(task);
            }
            ReadTaskDatabase();
        }
        public void ReadTaskDatabase()
        {
            List<UserTask> list = new List<UserTask>();
            using (SQLiteConnection newConnection = new SQLiteConnection(App.databasePath))
            {
                newConnection.CreateTable<UserTask>();
                switch (listBy)
                {
                    case 0:
                        list = newConnection.Table<UserTask>().ToList().OrderBy(c => c.Priority).ToList();
                        break;

                    case 1:
                        list = newConnection.Table<UserTask>().ToList().OrderBy(c => c.Title).ToList();
                        break;

                    default:
                        list = newConnection.Table<UserTask>().ToList().OrderBy(c => c.DueTime).ToList();
                        break;
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
            listBy = 1;
            ReadTaskDatabase();
        }
        public void ListByPrioity_Checked(object sender, RoutedEventArgs e)
        {
            listBy = 0;
            ReadTaskDatabase();
        }
        public void ListByDueDate_Checked(object sender, RoutedEventArgs e)
        {
            listBy = 2;
            ReadTaskDatabase();
        }
    }
}
