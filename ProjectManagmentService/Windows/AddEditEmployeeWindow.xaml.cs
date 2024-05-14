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

namespace ProjectManagmentService.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditEmployeeWindow.xaml
    /// </summary>
    public partial class AddEditEmployeeWindow : Window
    {
        private bool isChange = false;
        private Employee editEmployee; 

        public AddEditEmployeeWindow()
        {
            InitializeComponent();

            cmbGender.ItemsSource = Context.Gender.ToList();
            cmbGender.DisplayMemberPath = "Title";
            cmbGender.SelectedIndex = 0;

            cmbPost.ItemsSource = Context.Post.ToList();
            cmbPost.DisplayMemberPath = "Title";
            cmbPost.SelectedIndex = 0;
        }

        public AddEditEmployeeWindow(Employee employee)
        {
            InitializeComponent();

            cmbGender.ItemsSource = Context.Gender.ToList();
            cmbGender.DisplayMemberPath = "Title";

            cmbPost.ItemsSource = Context.Post.ToList();
            cmbPost.DisplayMemberPath = "Title";

            cmbGender.SelectedItem = Context.Gender.Where(i => i.GenderCode == employee.GenderCode).FirstOrDefault();
            cmbPost.SelectedItem = Context.Post.Where(i => i.IdPost == employee.IdPost).FirstOrDefault();
            tbLastName.Text = employee.LastName;
            tbFirstName.Text = employee.FirstName;
            tbPatronymic.Text = employee.Patronymic;
            dpBirthday.Text = employee.Birthday.ToString();
            dpRegistrationDay.Text = employee.RegistrationDate.ToString();
            tbPhone.Text = employee.Phone;
            tbEmail.Text = employee.Email;
            tbLogin.Text = employee.Login;
            pbPassword.Password = employee.Password;
            if (employee.IsBlock)
            {
                rbTrue.IsChecked = true;
            }
            else { rbFalse.IsChecked = true;}

            isChange = true;
            editEmployee = employee;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (isChange)
            {
                editEmployee.LastName = tbLastName.Text;
                editEmployee.FirstName = tbFirstName.Text;
                editEmployee.Patronymic = tbPatronymic.Text;
                editEmployee.Birthday = Convert.ToDateTime(dpBirthday.Text);
                editEmployee.RegistrationDate = Convert.ToDateTime(dpRegistrationDay.Text);     
                editEmployee.Phone = tbPhone.Text;
                editEmployee.GenderCode = (cmbGender.SelectedItem as Gender).GenderCode;
                editEmployee.IdPost = (cmbPost.SelectedItem as Post).IdPost;
                editEmployee.Email = tbEmail.Text;  
                editEmployee.Login = tbLogin.Text;
                editEmployee.Password = pbPassword.Password;
                if (rbTrue.IsChecked == true)
                {
                    editEmployee.IsBlock = true;
                }
                else if (rbFalse.IsChecked == true) 
                { 
                    editEmployee.IsBlock = false;
                }
                Context.SaveChanges();
                MessageBox.Show("Запись успешно обновлена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                HomeWindow homeWindow = new HomeWindow();
                homeWindow.Show();
                this.Close();
            }
            else
            {
                Employee employee = new Employee();
                employee.LastName = tbLastName.Text;
                employee.FirstName = tbFirstName.Text;
                employee.Patronymic = tbPatronymic.Text;
                employee.Birthday = Convert.ToDateTime(dpBirthday.Text);
                employee.RegistrationDate = Convert.ToDateTime(dpRegistrationDay.Text);
                employee.Phone = tbPhone.Text;
                employee.Email = tbEmail.Text;
                employee.Login = tbLogin.Text;
                employee.GenderCode = (cmbGender.SelectedItem as Gender).GenderCode;
                employee.IdPost = (cmbPost.SelectedItem as Post).IdPost;
                employee.Password = pbPassword.Password;
                if (rbTrue.IsChecked == true)
                {
                    employee.IsBlock = true;
                }
                else if (rbFalse.IsChecked == true) { employee.IsBlock = false; }
                Context.Employee.Add(employee);
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
    }
}
