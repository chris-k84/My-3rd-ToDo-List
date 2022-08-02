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
using Src.ViewModels;

namespace Src.Views
{
    /// <summary>
    /// Interaction logic for MainApp.xaml
    /// </summary>
    public partial class MainApp : Window
    {
        MainWindowViewModel viewModel;
        public MainApp()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            viewModel = grid.DataContext as MainWindowViewModel;

            taskList.MouseDoubleClick += viewModel.TaskListDoubleClick;
            ListByName.Checked += viewModel.ListByName_Checked;
            ListByPrioity.Checked += viewModel.ListByPrioity_Checked;
            ListByDueDate.Checked += viewModel.ListByDueDate_Checked;
        }
    }
}
