using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._1.factorial;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test program by compare a value of method and 24.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(24, Program.Factorial(4));
        }

        /// <summary>
        /// Test program by compare a value of method and 720.
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(720, Program.Factorial(6));
        }

        /// <summary>
        /// Test program by compare a value of method and this really big number = 3628800.
        /// </summary>
        [TestMethod]
        public void TestMethod3()  
        {
            Assert.AreEqual(3628800, Program.Factorial(10));
        }

        /// <summary>
        /// Check the Exception.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void FactorialTest()
        {
            Program.Factorial(-1);
        }
    }
}
