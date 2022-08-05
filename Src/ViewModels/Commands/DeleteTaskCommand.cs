using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Src.Models;
using Src.Views;

namespace Src.ViewModels.Commands
{
    public class DeleteTaskCommand : ICommand
    {
        private IDataBaseReader dataBaseReader;

        public DeleteTaskCommand(IDataBaseReader DataBaseReader) 
        {
            this.dataBaseReader = DataBaseReader;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DeleteTaskCheckView deleteTaskCheckView = new DeleteTaskCheckView();
            deleteTaskCheckView.ShowDialog();
            if(dataBaseReader.SelectedTask != null)
            {
                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.databasePath))
                {
                    sQLiteConnection.CreateTable<UserTask>();

                    sQLiteConnection.Delete(dataBaseReader.SelectedTask);
                }
            }
            dataBaseReader.ReadTaskDatabase();
        }
    }
}
