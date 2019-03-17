using System.Windows;

namespace jamoin.demo.testability.startup.Utils
{
    public interface IMessageBoxProxy
    {
        MessageBoxResult Show(string yesToLogCarsFromDatabaseAndNoToLogOneSpecialCar, string whatCarsShallBeLogged, MessageBoxButton yesNoCancel);
    }
}