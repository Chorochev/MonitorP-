using LibMonitorPC;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonitorPC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingDataForm bindingDataForm;

        public MainWindow()
        {
            InitializeComponent();
            loadDataStart();
        }

        private void loadDataStart()
        {
            bindingDataForm = new BindingDataForm();
            DataContext = bindingDataForm;
            bindingDataForm.Logs.AddLog("Load data...");
            Task.Run(() =>
            {
                bindingDataForm.LoadData();
                //foreach (var item in bindingDataForm.ListCPU)
                //{
                //    //item.GetProcessorInfo();
                //}                
                bindingDataForm.Logs.AddLog("Load data is complete.");
            });


        }
    }
}
