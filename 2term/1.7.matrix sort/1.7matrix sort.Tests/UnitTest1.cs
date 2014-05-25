using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._7.array_s_sort;

namespace _1._7matrix_sort.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Write in matrix numbers in some strage way. And then we compare. Again. 
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            int size = 3;
            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (j == 0) 
                    {
                        matrix[i, j] = 1;
                    }
                    if (j == 1)
                    {
                        matrix[i, j] = 5;
                    }
                    if (j == 2)
                    {
                        matrix[i, j] = 3;
                    }
                }
            }
            string resultOfTheTest = Program.PrintOfTheMatrixInResult(matrix);
            Assert.AreEqual("1 3 5 1 3 5 1 3 5 ", resultOfTheTest);
        }
    }
}
