using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._6.matrix;

namespace _1._6.matrix.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// We compare something that should turn in a result and result of my task's interpritation. 
        /// (you may be surprised, but it work)
        /// </summary>
        [TestMethod] 
        public void TestMethod1()
        {
            int[,] matrix = new int[5, 5];
            int value = 0;
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    matrix[i, j] = value;
                    ++value;
                }
            }

            string resultOfTheTest = Program.GoRountOfMatrix(matrix);
            Assert.AreEqual("12 13 18 17 16 11 6 7 8 9 14 19 24 23 22 21 20 15 10 5 0 1 2 3 4 ", resultOfTheTest);
        }
    }
}
