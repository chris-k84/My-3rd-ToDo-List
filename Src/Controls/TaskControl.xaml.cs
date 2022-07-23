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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Src.Models;

namespace Src.Controls
{
    /// <summary>
    /// Interaction logic for TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        public UserTask Task
        {
            get { return (UserTask)GetValue(TaskProperty); }
            set { SetValue(TaskProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Task.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TaskProperty =
            DependencyProperty.Register("Task", typeof(UserTask), typeof(TaskControl), new PropertyMetadata(new UserTask()
            {
                Title = "title",
                Description = "none",
                Comments = "none"
            }, SetText));



        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TaskControl task = d as TaskControl;
            if (task != null)
            {
                task.titleTB.Text = (e.NewValue as UserTask).Title;
                task.DescriptionTB.Text = (e.NewValue as UserTask).Description;
                task.priority.Text = (e.NewValue as UserTask).Priority.ToString();
                task.iscomplete.IsChecked = (e.NewValue as UserTask).IsComplete;
            }
        }

        public TaskControl()
        {
            InitializeComponent();
        }
    }
}
