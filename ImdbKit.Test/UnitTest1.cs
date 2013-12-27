using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImdbKit;

namespace ImdbKit.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client  = new ImdbClient();
            var output = client.testJsonConnection();

            Assert.IsNotNull(output);
        }
    }
}
