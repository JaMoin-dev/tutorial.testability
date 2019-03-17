using System;
using System.Windows;
using jamoin.demo.testability.startup.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace jamoin.demo.testability.startup.test
{
    [TestClass]
    public class MainWindowViewModelTests
    {


        [TestMethod]
        public void LogCommandExecute_WithUserCancel_StillInconclusive()
        {
            // setup
            var messageBoxProxyMock = CreateMessageBoxProxyWithUserResult(MessageBoxResult.Cancel);
            var sut = new MainWindowViewModel(messageBoxProxyMock.Object);

            // act
            sut.LogCommand.Execute(null);

            // assert
            // TODO what to assert? Assert that the file has been written?
            //      That would be an integration test. Unit tests must not not use shared resources such as file system...
            //      And... what if the user chose to cancel?
            //      For now we say ... well... nothing.
            Assert.Inconclusive();
        }

        [TestMethod]
        public void LogCommandExecute_WithUserYes_StillInconclusive()
        {
            // setup
            var messageBoxProxyMock = CreateMessageBoxProxyWithUserResult(MessageBoxResult.Yes);
            var sut = new MainWindowViewModel(messageBoxProxyMock.Object);

            // act
            sut.LogCommand.Execute(null);

            // assert
            // TODO what to assert? Assert that the file has been written?
            //      That would be an integration test. Unit tests must not not use shared resources such as file system...
            //      And... what if the user chose to cancel?
            //      For now we say ... well... nothing.
            Assert.Inconclusive();
        }

        [TestMethod]
        public void LogCommandExecute_WithUserNo_StillInconclusive()
        {
            // setup
            var messageBoxProxyMock = CreateMessageBoxProxyWithUserResult(MessageBoxResult.Yes);
            var sut = new MainWindowViewModel(messageBoxProxyMock.Object);

            // act
            sut.LogCommand.Execute(null);

            // assert
            // TODO what to assert? Assert that the file has been written?
            //      That would be an integration test. Unit tests must not not use shared resources such as file system...
            //      And... what if the user chose to cancel?
            //      For now we say ... well... nothing.
            Assert.Inconclusive();
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
