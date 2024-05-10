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
    /// Логика взаимодействия для LKWindow.xaml
    /// </summary>
    public partial class LKWindow : Window
    {
        public LKWindow()
        {
            InitializeComponent();
            txtLastName.Text = ClassHelper.EmployeeDataClass.Employee.LastName;
            txtFirstName.Text = ClassHelper.EmployeeDataClass.Employee.FirstName;
            txtPatronymic.Text = ClassHelper.EmployeeDataClass.Employee.Patronymic;
        }

        private void Edit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var DialogResult = MessageBox.Show("Вы уверены, что хотите выйти?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (DialogResult == MessageBoxResult.Yes)
            {
                AuthorizationWindow authWindow = new AuthorizationWindow();
                authWindow.Show();
                this.Close();
                //Environment.Exit(0);
            }
        }
    }
}
