using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using jamoin.demo.testability.startup.Entities;
using jamoin.demo.testability.startup.Repository;
using jamoin.demo.testability.startup.Utils;

namespace jamoin.demo.testability.startup
{
    public class MainWindowViewModel
    {
        private readonly IMessageBoxProxy _messageBox;
        private readonly IProcessProxy _processProxy;
        private readonly ICarLogger _carLogger;
        private readonly ICarRepo _carRepo;

        public MainWindowViewModel(IMessageBoxProxy messageBox, IProcessProxy processProxy, ICarLogger carLogger, ICarRepo carRepo)
        {
            _messageBox = messageBox;
            _processProxy = processProxy;
            _carLogger = carLogger;
            _carRepo = carRepo;
            LogCommand = new DelegateCommand(ExecuteLogCommand);
        }

        private async void ExecuteLogCommand(object obj)
        {
            // ask user what to log
            var result = _messageBox.Show("'Yes' to log cars from Database and 'No' to log one special car.", "What cars shall be logged?", MessageBoxButton.YesNoCancel);

            // load data to be logged
            var carsToLog = new List<Car>();
            switch (result)
            {
                case MessageBoxResult.Yes:
                    carsToLog.AddRange(_carRepo.LoadAllCars());
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
            await _carLogger.LogAllCarsAsync(logPath, carsToLog.ToArray());
            _processProxy.Start(logPath);
        }

        public ICommand LogCommand { get; set; }
    }

    
}