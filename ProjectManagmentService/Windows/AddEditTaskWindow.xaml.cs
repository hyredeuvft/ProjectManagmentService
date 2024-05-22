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
    /// Логика взаимодействия для AddEditTaskWindow.xaml
    /// </summary>
    public partial class AddEditTaskWindow : Window
    {
        private bool isChange = false;
        private DB.Task editTask;
        private DB.Timer editTimer;
        private int MyIdTask;
        public AddEditTaskWindow()
        {
            InitializeComponent();

            cmbResponsiblePerson.ItemsSource = Context.Employee.ToList();
            cmbResponsiblePerson.DisplayMemberPath = "LastName";
            cmbResponsiblePerson.SelectedIndex = 0;

            cmbStage.ItemsSource = Context.Stage.ToList();
            cmbStage.DisplayMemberPath = "Title";
            cmbStage.SelectedIndex = 0;

            //TaskClass.MyIdTask = Context.Task.Last().IdTask + 1;
            MyIdTask = ClassHelper.TaskClass.MyIdTask;

            if (EmployeeDataClass.Employee.IdPost == 3)
            {
                btnStatistics.Visibility = Visibility.Collapsed;
            }
        }
        
        public AddEditTaskWindow(DB.Task task)
        {
            InitializeComponent();

            cmbResponsiblePerson.ItemsSource = Context.Employee.ToList();
            cmbResponsiblePerson.DisplayMemberPath = "LastName";

            cmbStage.ItemsSource = Context.Stage.ToList();
            cmbStage.DisplayMemberPath = "Title";

            cmbResponsiblePerson.SelectedItem = Context.Employee.Where(i => i.IdEmployee == task.ResponsiblePerson).FirstOrDefault();
            cmbStage.SelectedItem = Context.Stage.Where(i => i.IdStage == task.IdStage).FirstOrDefault();
            tbTitle.Text = task.Title;
            tbComment.Text = task.Comment;
            tbDescription.Text = task.Description;
            dpDateStart.Text = task.DateStart.ToString();
            dpDateEnd.Text = task.DateEnd.ToString();
            if (task.IsClose)
            {
                rbTrue.IsChecked = true;
            }
            else { rbFalse.IsChecked = true; }

            isChange = true;
            editTask = task;

            TaskClass.MyIdTask = task.IdTask;
            MyIdTask = ClassHelper.TaskClass.MyIdTask;

            if (EmployeeDataClass.Employee.IdPost == 3)
            {
                btnStatistics.Visibility = Visibility.Collapsed;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var haveTimer = Context.Timer.Where(i => i.IdTask == MyIdTask).ToList();
                if (haveTimer.Count > 0)
                {
                    editTimer = haveTimer.First();
                    editTimer.TimeEnd = Convert.ToDateTime(dpStart.Text);
                    Context.SaveChanges();
                }
                else
                {
                    Timer timer = new Timer();
                    timer.IdEmployee = EmployeeDataClass.Employee.IdEmployee;
                    timer.IdTask = MyIdTask;
                    timer.TimeStart = Convert.ToDateTime(dpStart.Text);
                    Context.Timer.Add(timer);
                    Context.SaveChanges();
                }
                if (isChange)
                {
                    editTask.Comment = tbComment.Text;
                    editTask.Title = tbTitle.Text;
                    editTask.Description = tbDescription.Text;
                    editTask.ResponsiblePerson = (cmbResponsiblePerson.SelectedItem as Employee).IdEmployee;
                    editTask.DateStart = Convert.ToDateTime(dpDateStart.Text);
                    editTask.DateEnd = Convert.ToDateTime(dpDateEnd.Text);
                    editTask.IdStage = (cmbStage.SelectedItem as Stage).IdStage;
                    if (rbTrue.IsChecked == true)
                    {
                        editTask.IsClose = true;
                    }
                    else if (rbFalse.IsChecked == true)
                    {
                        editTask.IsClose = false;
                    }
                    Context.SaveChanges();
                    MessageBox.Show("Запись успешно обновлена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    HomeWindow homeWindow = new HomeWindow();
                    homeWindow.Show();
                    this.Close();
                }
                else
                {
                    DB.Task task = new DB.Task();
                    task.Comment = tbComment.Text;
                    task.Title = tbTitle.Text;
                    task.Description = tbDescription.Text;
                    task.ResponsiblePerson = (cmbResponsiblePerson.SelectedItem as Employee).IdEmployee;
                    task.DateStart = Convert.ToDateTime(dpDateStart.Text);
                    task.DateEnd = Convert.ToDateTime(dpDateEnd.Text);
                    task.IdStage = (cmbStage.SelectedItem as Stage).IdStage;
                    if (rbTrue.IsChecked == true)
                    {
                        task.IsClose = true;
                    }
                    else if (rbFalse.IsChecked == true)
                    {
                        task.IsClose = false;
                    }
                    Context.Task.Add(task);
                    Context.SaveChanges();
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

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            dpStart.Text = DateTime.Now.ToString();
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
