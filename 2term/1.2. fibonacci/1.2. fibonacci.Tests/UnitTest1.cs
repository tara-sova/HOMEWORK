using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _1._2.fibonacci.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Compare a value of 4 member of Fibonacci sequence and result of our suffering.
        /// </summary>
        [TestMethod] 
        public void TestMethod1()
        {
            long result = Program.Fibonacci(4);
            Assert.AreEqual(3, result);
        }
    }
}
