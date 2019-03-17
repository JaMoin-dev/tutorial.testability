using System;
using System.Collections.Generic;
using System.Windows;
using jamoin.demo.testability.startup.Entities;
using jamoin.demo.testability.startup.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace jamoin.demo.testability.startup.test
{
    [TestClass]
    public class MainWindowViewModelTests
    {

        [TestMethod]
        public void LogCommandExecute_WithUserCancel_CallsNothing()
        {
            // setup
            var messageBoxProxyMock = CreateMessageBoxProxyWithUserResult(MessageBoxResult.Cancel);
            var processProxyMock = new Mock<IProcessProxy>();
            var carRepoMock = CreateCarRepoMockWithResult(new List<Car>());
            var carLoggerMock = new Mock<ICarLogger>();
            var sut = new MainWindowViewModel(messageBoxProxyMock.Object, processProxyMock.Object, carLoggerMock.Object, carRepoMock.Object);

            // act
            sut.LogCommand.Execute(null);

            // assert that if user clicks "cancel" nothing else is used
            carRepoMock.Verify(c => c.LoadAllCars(), Times.Never);
            carLoggerMock.Verify(c => c.LogAllCarsAsync(It.IsAny<string>(), It.IsAny<Car[]>()), Times.Never);
            processProxyMock.Verify(c => c.Start(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void LogCommandExecute_WithUserYes_CallsRepo()
        {
            // setup
            var messageBoxProxyMock = CreateMessageBoxProxyWithUserResult(MessageBoxResult.Yes);
            var processProxyMock = new Mock<IProcessProxy>();
            var carRepoMock = CreateCarRepoMockWithResult(new List<Car>());
                
            var carLoggerMock = new Mock<ICarLogger>();
            var sut = new MainWindowViewModel(messageBoxProxyMock.Object, processProxyMock.Object, carLoggerMock.Object, carRepoMock.Object);

            // act
            sut.LogCommand.Execute(null);

            // assert that if user clicks "yes" the CarRepo is called and the carLogger is called, too
            carRepoMock.Verify(c => c.LoadAllCars(), Times.Once);
            carLoggerMock.Verify(c => c.LogAllCarsAsync(It.IsAny<string>(), It.IsAny<Car[]>()), Times.Once);
            processProxyMock.Verify(c => c.Start(It.IsAny<string>()), Times.Once);
        }

        

        [TestMethod]
        public void LogCommandExecute_WithUserNo_DoesntCallRepoButStillLogs()
        {
            // setup
            var messageBoxProxyMock = CreateMessageBoxProxyWithUserResult(MessageBoxResult.No);
            var processProxyMock = new Mock<IProcessProxy>();
            var carRepoMock = CreateCarRepoMockWithResult(new List<Car>());
            var carLoggerMock = new Mock<ICarLogger>();
            var sut = new MainWindowViewModel(messageBoxProxyMock.Object, processProxyMock.Object, carLoggerMock.Object, carRepoMock.Object);

            // act
            sut.LogCommand.Execute(null);

            // assert that if user clicks "yes" the CarRepo is called and the carLogger is called, too
            carRepoMock.Verify(c => c.LoadAllCars(), Times.Never);
            carLoggerMock.Verify(c => c.LogAllCarsAsync(It.IsAny<string>(), It.IsAny<Car[]>()), Times.Once);
            processProxyMock.Verify(c => c.Start(It.IsAny<string>()), Times.Once);
        }

        private Mock<ICarRepo> CreateCarRepoMockWithResult(List<Car> cars)
        {
            var result = new Mock<ICarRepo>();
            result.Setup(m => m.LoadAllCars()).Returns(() => cars);
            return result;
        }

        private Mock<IMessageBoxProxy> CreateMessageBoxProxyWithUserResult(MessageBoxResult userResult)
        {
            var messageBoxMock = new Mock<IMessageBoxProxy>();
            messageBoxMock.Setup(m => m.Show(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MessageBoxButton>()))
                .Returns(userResult);

            return messageBoxMock; 
        }
    }
}
