using Src.Models;
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

namespace Src.Controls
{
    /// <summary>
    /// Interaction logic for ProjectControl.xaml
    /// </summary>
    public partial class ProjectControl : UserControl
    {
        public UserProject Project
        {
            get { return (UserProject)GetValue(TaskProperty); }
            set { SetValue(TaskProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Project.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TaskProperty =
            DependencyProperty.Register("Project", typeof(UserProject), typeof(ProjectControl), new PropertyMetadata(new UserProject()
            {
                Title = "title",
                Description = "none"
            }, SetText));



        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProjectControl project = d as ProjectControl;
            if (project != null)
            {
                project.titleTB.Text = (e.NewValue as UserProject).Title;
                project.DescriptionTB.Text = (e.NewValue as UserProject).Description;
            }
        }
        public ProjectControl()
        {
            InitializeComponent();
        }
    }
}
