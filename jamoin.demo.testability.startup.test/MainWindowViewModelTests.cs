using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace jamoin.demo.testability.startup.test
{
    [TestClass]
    public class MainWindowViewModelTests
    {


        [TestMethod]
        public void LogCommandExecute_TestThatItRuns()
        {
            // setup
            var sut = new MainWindowViewModel();

            // act
            sut.LogCommand.Execute(null);

            // assert
            // TODO what to assert? Assert that the file has been written?
            //      That would be an integration test. Unit tests must not not use shared resources such as file system...
            //      And... what if the user chose to cancel?
            //      For now we say ... well... nothing.
            Assert.Inconclusive();
        }
    }
}
