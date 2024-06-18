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
    /// Логика взаимодействия для AddEditTimerWindow.xaml
    /// </summary>
    public partial class AddEditTimerWindow : Window
    {
        private bool isChange = false;
        private DB.Timer editTimer;
        public AddEditTimerWindow()
        {
            InitializeComponent();

            cmbEmployee.ItemsSource = EFClass.Context.Employee.ToList();
            cmbEmployee.DisplayMemberPath = "LastName";
            cmbEmployee.SelectedIndex = 0;

            cmbTask.ItemsSource = EFClass.Context.Task.ToList();
            cmbTask.DisplayMemberPath = "Title";
            cmbTask.SelectedIndex = 0;

            if (EmployeeDataClass.Employee.IdPost == 3)
            {
                btnStatistics.Visibility = Visibility.Collapsed;
            }
        }

        public AddEditTimerWindow(Timer timer)
        {
            InitializeComponent();

            try
            {
                cmbEmployee.ItemsSource = EFClass.Context.Employee.ToList();
                cmbEmployee.DisplayMemberPath = "LastName";

                cmbTask.ItemsSource = EFClass.Context.Task.ToList();
                cmbTask.DisplayMemberPath = "Title";

                cmbEmployee.SelectedItem = EFClass.Context.Employee.Where(i => i.IdEmployee == timer.IdEmployee).FirstOrDefault();
                cmbTask.SelectedItem = EFClass.Context.Task.Where(i => i.IdTask == timer.IdTask).FirstOrDefault();
                dpDateStart.Text = timer.TimeStart.ToString();
                dpDateEnd.Text = timer.TimeEnd.ToString();
                tbHourJob.Text = timer.HourJob.ToString();

                isChange = true;
                editTimer = timer;

                if (EmployeeDataClass.Employee.IdPost == 3)
                {
                    btnStatistics.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(dpDateStart.Text) || string.IsNullOrEmpty(dpDateEnd.Text) || string.IsNullOrEmpty(tbHourJob.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (isChange)
                    {
                        editTimer.IdEmployee = (cmbEmployee.SelectedItem as Employee).IdEmployee;
                        editTimer.IdTask = (cmbTask.SelectedItem as DB.Task).IdTask;
                        editTimer.TimeStart = Convert.ToDateTime(dpDateStart.Text);
                        editTimer.TimeEnd = Convert.ToDateTime(dpDateEnd.Text);
                        editTimer.HourJob = Convert.ToDecimal(tbHourJob.Text);
                        EFClass.Context.SaveChanges();
                        MessageBox.Show("Запись успешно обновлена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                        HomeWindow homeWindow = new HomeWindow();
                        homeWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        Timer timer = new Timer();
                        timer.IdEmployee = (cmbEmployee.SelectedItem as Employee).IdEmployee;
                        timer.IdTask = (cmbTask.SelectedItem as DB.Task).IdTask;
                        timer.TimeStart = Convert.ToDateTime(dpDateStart.Text);
                        timer.TimeEnd = Convert.ToDateTime(dpDateEnd.Text);
                        timer.HourJob = Convert.ToDecimal(tbHourJob.Text);
                        EFClass.Context.Timer.Add(timer);
                        EFClass.Context.SaveChanges();
                        MessageBox.Show("Запись успешно добавлена", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                        HomeWindow homeWindow = new HomeWindow();
                        homeWindow.Show();
                        this.Close();
                    }
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