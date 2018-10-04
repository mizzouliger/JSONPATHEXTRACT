using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonPath
{   
    [TestClass]
    public class UnitTestJsonPath : GetCityForState
    {

        [TestMethod]
        public void testForValidState()
        {
            string[] input = new string[] { "Guam" };
            Main(input);
            int consoleOutput = Console.Read();
            Assert.AreEqual(0, consoleOutput);
        }

        [TestMethod]
        public void testForBlankStateValue()
        {
            string[] input = new string[] { "" };
            Main(input);
            int consoleOutput = Console.Read();
            Assert.AreEqual(1, consoleOutput);
        }

        [TestMethod]
        public void testForInvalidStateValue()
        {
            string[] input = new string[] { "MO" };
            Main(input);
            int consoleOutput = Console.Read();
            Assert.AreEqual(1, consoleOutput);
        }


    }
}
