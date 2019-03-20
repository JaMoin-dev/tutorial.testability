using jamoin.demo.testability.startup.Repository;

namespace jamoin.demo.testability.startup.Utils
{
    public class ViewModelLocator
    {
        private static readonly IMessageBoxProxy MessageBoxProxy = new MessageBoxProxy();
        private static readonly IProcessProxy ProcessProxy = new ProcessProxy();
        private static readonly IFileProxy FileProxy = new FileProxy();
        private static readonly ICarLogger CarLogger = new CarLogger(FileProxy);
        private static readonly ICarRepo CarRepo = new CarRepo();

        public static MainWindowViewModel MainWindowViewModel => new MainWindowViewModel(MessageBoxProxy, ProcessProxy, CarLogger, CarRepo);
    }
}