namespace jamoin.demo.testability.startup.Utils
{
    public class ViewModelLocator
    {
        private static readonly IMessageBoxProxy MessageBoxProxy = new MessageBoxProxy();

        public static MainWindowViewModel MainWindowViewModel => new MainWindowViewModel(MessageBoxProxy);
    }
}