using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using jamoin.demo.testability.startup.Entities;
using jamoin.demo.testability.startup.Repository;

namespace jamoin.demo.testability.startup
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LogAllCars_Click(object sender, RoutedEventArgs e)
        {
            // ask user what to log
            var result = MessageBox.Show("'Yes' to log cars from Database and 'No' to log one special car.", "What cars shall be logged?", MessageBoxButton.YesNoCancel);

            // load data to be logged
            var carsToLog = new List<Car>();
            switch (result)
            {
                case MessageBoxResult.Yes:
                    carsToLog.AddRange(CarRepo.LoadAllCars());
                    break;
                case MessageBoxResult.No:
                    carsToLog.Add(new Car()
                    {
                        WheelSize = 1,
                        RevolutionsPerMinute = 8000,
                        MaxTransmission = 2
                    });
                    break;
                case MessageBoxResult.Cancel:
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            // log data and show results
            var logPath = System.IO.Path.GetTempFileName() + ".txt";
            await CarLogger.LogAllCarsAsync(logPath, carsToLog.ToArray());
            Process.Start(logPath);
        }
    }
}
