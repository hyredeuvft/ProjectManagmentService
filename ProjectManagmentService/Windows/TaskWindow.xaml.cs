﻿using System;
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
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        public TaskWindow()
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
            List<DB.Task> tasks = new List<DB.Task>();
            tasks = EFClass.Context.Task.ToList();
            tasks = tasks.Where(i => i.Title.Contains(tbSearch.Text)).ToList();

            LvList.ItemsSource = tasks;
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
            if (LvList.SelectedItem is DB.Task)
            {
                var task = LvList.SelectedItem as DB.Task;
                AddEditTaskWindow addEditTaskWindow = new AddEditTaskWindow(task);
                addEditTaskWindow.Show();
                this.Close();
            }
            else
            {
                AddEditTaskWindow addEditTaskWindow = new AddEditTaskWindow();
                addEditTaskWindow.Show();
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