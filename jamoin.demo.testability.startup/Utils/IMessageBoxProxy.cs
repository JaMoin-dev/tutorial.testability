using System.Windows;

namespace jamoin.demo.testability.startup.Utils
{
    public interface IMessageBoxProxy
    {
        MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button);
    }
}