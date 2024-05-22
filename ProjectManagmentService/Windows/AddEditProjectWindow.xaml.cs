using ProjectManagmentService.ClassHelper;
using ProjectManagmentService.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для AddEditProjectWindow.xaml
    /// </summary>
    public partial class AddEditProjectWindow : Window
    {
        private bool isChange = false;
        private DB.Project editProject;
        public AddEditProjectWindow()
        {
            InitializeComponent();

            cmbResponsiblePerson.ItemsSource = EFClass.Context.Employee.ToList();
            cmbResponsiblePerson.DisplayMemberPath = "LastName";
            cmbResponsiblePerson.SelectedIndex = 0;

            cmbCustomer.ItemsSource = EFClass.Context.Entity.ToList();
            cmbCustomer.DisplayMemberPath = "Title";
            cmbCustomer.SelectedIndex = 0;

            cmbStage.ItemsSource = EFClass.Context.Stage.ToList();
            cmbStage.DisplayMemberPath = "Title";
            cmbStage.SelectedIndex = 0;

            if (EmployeeDataClass.Employee.IdPost == 3)
            {
                btnStatistics.Visibility = Visibility.Collapsed;
            }
        }

        public AddEditProjectWindow(Project project)
        {
            InitializeComponent();

            cmbResponsiblePerson.ItemsSource = EFClass.Context.Employee.ToList();
            cmbResponsiblePerson.DisplayMemberPath = "LastName";

            cmbCustomer.ItemsSource = EFClass.Context.Entity.ToList();
            cmbCustomer.DisplayMemberPath = "INN";

            cmbStage.ItemsSource = EFClass.Context.Stage.ToList();
            cmbStage.DisplayMemberPath = "Title";

            cmbResponsiblePerson.SelectedItem = EFClass.Context.Employee.Where(i => i.IdEmployee == project.ResponsiblePerson).FirstOrDefault();
            cmbCustomer.SelectedItem = EFClass.Context.Entity.Where(i => i.IdEntity == project.IdCustomer).FirstOrDefault();
            cmbStage.SelectedItem = EFClass.Context.Stage.Where(i => i.IdStage == project.IdStage).FirstOrDefault();
            tbTitle.Text = project.Title;
            tbDescription.Text = project.Description;
            dpDateStart.Text = project.DateStart.ToString();
            dpDateEnd.Text = project.DateEnd.ToString();
            tbBudget.Text = project.Budget.ToString();
            if (project.IsClose)
            {
                rbTrue.IsChecked = true;
            }
            else { rbFalse.IsChecked = true; }

            isChange = true;
            editProject = project;

            if (EmployeeDataClass.Employee.IdPost == 3)
            {
                btnStatistics.Visibility = Visibility.Collapsed;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isChange)
                {
                    editProject.Title = tbTitle.Text;
                    editProject.Description = tbDescription.Text;
                    editProject.ResponsiblePerson = (cmbResponsiblePerson.SelectedItem as Employee).IdEmployee;
                    editProject.IdCustomer = (cmbCustomer.SelectedItem as Entity).IdEntity;
                    editProject.DateStart = Convert.ToDateTime(dpDateStart.Text);
                    editProject.DateEnd = Convert.ToDateTime(dpDateEnd.Text);
                    editProject.Budget = Convert.ToDecimal(tbBudget.Text);
                    editProject.IdStage = (cmbStage.SelectedItem as Stage).IdStage;
                    if (rbTrue.IsChecked == true)
                    {
                        editProject.IsClose = true;
                    }
                    else if (rbFalse.IsChecked == true)
                    {
                        editProject.IsClose = false;
                    }
                    EFClass.Context.SaveChanges();
                    MessageBox.Show("Запись успешно обновлена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    HomeWindow homeWindow = new HomeWindow();
                    homeWindow.Show();
                    this.Close();
                }
                else
                {
                    Project project = new Project();
                    project.Title = tbTitle.Text;
                    project.Description = tbDescription.Text;
                    project.ResponsiblePerson = (cmbResponsiblePerson.SelectedItem as Employee).IdEmployee;
                    project.IdCustomer = (cmbCustomer.SelectedItem as Entity).IdEntity;
                    project.DateStart = Convert.ToDateTime(dpDateStart.Text);
                    project.DateEnd = Convert.ToDateTime(dpDateEnd.Text);
                    project.Budget = Convert.ToDecimal(tbBudget.Text);
                    project.IdStage = (cmbStage.SelectedItem as Stage).IdStage;
                    if (rbTrue.IsChecked == true)
                    {
                        project.IsClose = true;
                    }
                    else if (rbFalse.IsChecked == true)
                    {
                        project.IsClose = false;
                    }
                    EFClass.Context.Project.Add(project);
                    EFClass.Context.SaveChanges();
                    MessageBox.Show("Запись успешно добавлена", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    HomeWindow homeWindow = new HomeWindow();
                    homeWindow.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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