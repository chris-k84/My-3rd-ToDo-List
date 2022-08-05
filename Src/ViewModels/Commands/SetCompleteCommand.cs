using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Src.Models;

namespace Src.ViewModels.Commands
{
    public class SetCompleteCommand : ICommand
    {
        private IDataBaseReader dataBaseReader;
        public SetCompleteCommand(IDataBaseReader DataBaseReader)
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
            UserTask task = parameter as UserTask;
            task.IsComplete = true;
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.databasePath))
            {
                sQLiteConnection.CreateTable<UserTask>();

                sQLiteConnection.Delete(task);
            }
            this.dataBaseReader.ReadTaskDatabase();
        }
    }
}
