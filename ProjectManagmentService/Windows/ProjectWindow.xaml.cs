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
using ProjectManagmentService.Windows;
using ProjectManagmentService.DB;
using static ProjectManagmentService.ClassHelper.EFClass;
using ProjectManagmentService.ClassHelper;

namespace ProjectManagmentService.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        public ProjectWindow()
        {
            InitializeComponent();
            if (EmployeeDataClass.Employee.IdPost == 3)
            {
                btnEdit.Visibility = Visibility.Collapsed;
                btnStatistics.Visibility = Visibility.Collapsed;
            }
            GetSortList();
        }

        private void GetSortList()
        {
            List<Project> projects = new List<Project>();
            projects = EFClass.Context.Project.ToList();
            projects = projects.Where(i => i.Title.Contains(tbSearch.Text) || i.Description.Contains(tbSearch.Text)).ToList();

            LvList.ItemsSource = projects;
        }

        private void btnLk_Click(object sender, RoutedEventArgs e)
        {
            LKWindow lKWindow = new LKWindow();
            lKWindow.ShowDialog();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetSortList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvList.SelectedItem is Project)
            {
                var employee = LvList.SelectedItem as Project;
                AddEditProjectWindow addEditProjectWindow = new AddEditProjectWindow(employee);
                addEditProjectWindow.Show();
                this.Close();
            }
            else
            {
                AddEditProjectWindow addEditProjectWindow = new AddEditProjectWindow();
                addEditProjectWindow.Show();
                this.Close();
            }
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            this.Close();
        }

        private void btnProject_Click(object sender, RoutedEventArgs e)
        {
            ProjectWindow projectWindow = new ProjectWindow();
            projectWindow.Show();
            this.Close();
        }

        private void btnTask_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.Show();
            this.Close();
        }

        private void btnEntity_Click(object sender, RoutedEventArgs e)
        {
            EntityWindow entityWindow = new EntityWindow();
            entityWindow.Show();
            this.Close();
        }

        private void btnTimer_Click(object sender, RoutedEventArgs e)
        {
            TimerWindow timerWindow = new TimerWindow();
            timerWindow.Show();
            this.Close();
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statisticsWindow = new StatisticsWindow();
            statisticsWindow.ShowDialog();
        }
    }
}