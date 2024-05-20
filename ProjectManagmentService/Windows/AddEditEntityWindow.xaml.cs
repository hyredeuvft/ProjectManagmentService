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
    /// Логика взаимодействия для AddEditEntityWindow.xaml
    /// </summary>
    public partial class AddEditEntityWindow : Window
    {
        private bool isChange = false;
        private Entity editEntity;

        public AddEditEntityWindow()
        {
            InitializeComponent();
            if (EmployeeDataClass.Employee.IdPost == 3)
            {
                btnStatistics.Visibility = Visibility.Collapsed;
            }
        }

        public AddEditEntityWindow(Entity entity)
        {
            InitializeComponent();

            tbINN.Text = entity.INN;
            tbKPP.Text = entity.KPP;
            tbOGRN.Text = entity.OGRN;
            tbCheckingAccount.Text = entity.CheckingAccount;
            tbCorrespondentAccount.Text = entity.CorrespondentAccount;
            if (entity.IsBlock)
            {
                rbTrue.IsChecked = true;
            }
            else { rbFalse.IsChecked = true; }

            isChange = true;
            editEntity = entity;

            if (EmployeeDataClass.Employee.IdPost == 3)
            {
                btnStatistics.Visibility = Visibility.Collapsed;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (isChange)
            {
                editEntity.INN = tbINN.Text;
                editEntity.KPP = tbKPP.Text;
                editEntity.OGRN = tbOGRN.Text;
                editEntity.CheckingAccount = tbCheckingAccount.Text;
                editEntity.CorrespondentAccount = tbCorrespondentAccount.Text;
                if (rbTrue.IsChecked == true)
                {
                    editEntity.IsBlock = true;
                }
                else if (rbFalse.IsChecked == true)
                {
                    editEntity.IsBlock = false;
                }
                Context.SaveChanges();
                MessageBox.Show("Запись успешно обновлена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                HomeWindow homeWindow = new HomeWindow();
                homeWindow.Show();
                this.Close();
            }
            else
            {
                Entity entity = new Entity();
                entity.INN = tbINN.Text;
                entity.KPP = tbKPP.Text;
                entity.OGRN = tbOGRN.Text;
                entity.CheckingAccount = tbCheckingAccount.Text;
                entity.CorrespondentAccount = tbCorrespondentAccount.Text;
                if (rbTrue.IsChecked == true)
                {
                    entity.IsBlock = true;
                }
                else if (rbFalse.IsChecked == true) { entity.IsBlock = false; }
                Context.Entity.Add(entity);
                Context.SaveChanges();
                MessageBox.Show("Запись успешно добавлена", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                HomeWindow homeWindow = new HomeWindow();
                homeWindow.Show();
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