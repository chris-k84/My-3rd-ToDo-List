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
    /// Interaction logic for TaskView.xaml
    /// </summary>
    public partial class AddTaskView : Window
    {
        public AddTaskViewModel AddTaskViewModel { get; set; }

        public AddTaskView()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            AddTaskViewModel = new AddTaskViewModel();
            DataContext = AddTaskViewModel;

            Loaded += OnWindowLoaded;
        }
    
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            if(AddTaskViewModel != null)
            {
                AddTaskViewModel.CloseEvent += TaskViewModel_CloseEvent;
            }
        }

        private void TaskViewModel_CloseEvent(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
