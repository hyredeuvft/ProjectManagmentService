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
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();


            GetSortList();
        }

        private void GetSortList()
        {
            List<DB.Task> tasks = new List<DB.Task>();
            tasks = Context.Task.ToList();
            tasks = tasks.Where(i => i.Title.Contains(tbSearch.Text) && i.IsClose is false).ToList();

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
            else {
                AddEditTaskWindow addEditTaskWindow = new AddEditTaskWindow();
                addEditTaskWindow.Show();
                this.Close();
            }
        }
    }
}
