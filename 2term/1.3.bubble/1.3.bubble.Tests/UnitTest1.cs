using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._3.bubble;

namespace _1._3.bubble.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Compare a result that we should have and result of my trying to write someting working.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            int numberOfArrayElements = 5;
            int[] array = new int[numberOfArrayElements];
            array[0] = 7; 
            array[1] = 8;
            array[2] = 3;
            array[3] = 9;
            array[4] = 1;
            string result = Program.PrintArrayInResult(array);
            Assert.AreEqual("1 3 7 8 9 ", result);
        }
    }
}
