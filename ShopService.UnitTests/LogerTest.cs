using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace TheShop.UnitTests
{
    [TestFixture]
    class LogerTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]       
        public void Log_WhenCalledIfMessageParamterIsNullOrEmpty_ThrowArgumentNullException(string message)
        {
            var logger = new Logger();
            Assert.That(() => logger.Log(LogMessageType.Info, message), Throws.ArgumentNullException);            
        }
    }
}
