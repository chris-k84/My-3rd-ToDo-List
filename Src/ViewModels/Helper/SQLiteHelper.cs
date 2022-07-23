using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Src.Models;

namespace Src.ViewModels.Helper
{
    public class SQLiteHelper
    {
        public static void AddTaskToDB(UserTask userTask)
        {
            using (SQLiteConnection newConnection = new SQLiteConnection(App.databasePath))
            {
                newConnection.CreateTable<UserTask>();
                newConnection.Insert(userTask);
            }
        }


        public static void DeleteTaskFromDB(UserTask userTask)
        {
            using (SQLiteConnection newConnection = new SQLiteConnection(App.databasePath))
            {
                newConnection.CreateTable<UserTask>();
                newConnection.Delete(userTask);
            }
        }


        public static void UpdateTaskInDB(UserTask userTask)
        {
            using (SQLiteConnection newConnection = new SQLiteConnection(App.databasePath))
            {
                newConnection.CreateTable<UserTask>();
                newConnection.Update(userTask);
            }
        }

    }
}
