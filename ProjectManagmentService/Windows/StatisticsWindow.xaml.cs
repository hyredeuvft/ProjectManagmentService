using System;
using System.Collections;
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
using Syncfusion.UI.Xaml.Charts;

namespace ProjectManagmentService.Windows
{
    /// <summary>
    /// Логика взаимодействия для StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        public class ViewModel
        {
            public List<VW_JobInfo> Data { get; set; }

            public ViewModel()
            {
                Data = new List<VW_JobInfo>();
                Data = Context.VW_JobInfo.ToList();
            }
        }

        public StatisticsWindow()
        {
            InitializeComponent();

            SfChart chart = new SfChart() { Header = "Количество отработанных часов"};

            //Adding horizontal axis to the chart 
            CategoryAxis primaryAxis = new CategoryAxis();
            primaryAxis.Header = "Почта сотрудника";
            primaryAxis.FontSize = 14;
            chart.PrimaryAxis = primaryAxis;

            //chart.PrimaryAxis = new CategoryAxis()
            //{

            //    EnableScrollBar = true

            //};

            //Adding vertical axis to the chart 
            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Header = "Количество часов";
            secondaryAxis.FontSize = 14;
            chart.SecondaryAxis = secondaryAxis;

            //Initializing column series
            ColumnSeries series = new ColumnSeries();
            series.ItemsSource = (new ViewModel()).Data;
            series.XBindingPath = "Email";
            series.YBindingPath = "CountHour";
            series.ShowTrackballInfo = true;
            series.ShowTooltip = true;
            series.Label = "Heights";


            //Adding Series to the Chart Series Collection
            chart.Series.Add(series);
            this.Content = chart;
        }
    }
}
