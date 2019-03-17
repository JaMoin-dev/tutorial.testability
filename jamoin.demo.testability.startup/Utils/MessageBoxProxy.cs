using System.Windows;

namespace jamoin.demo.testability.startup.Utils
{
    public class MessageBoxProxy : IMessageBoxProxy
    {
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
        {
            return MessageBox.Show(messageBoxText, caption, button);
        }
    }
}