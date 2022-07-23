using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Src.Models;
using Src.ViewModels;

namespace Src.Views
{
    /// <summary>
    /// Interaction logic for TaskEditWindow.xaml
    /// </summary>
    public partial class TaskEditWindow : Window
    {
        TaskEditViewModel taskEditView;

        public TaskEditWindow(UserTask userTask)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            taskEditView = new TaskEditViewModel(userTask);
            DataContext = taskEditView;
            taskEditView.CloseEvent += TaskEditView_CloseEvent;
        }

        private void TaskEditView_CloseEvent(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
