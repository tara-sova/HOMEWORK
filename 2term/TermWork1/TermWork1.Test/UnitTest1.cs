using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TermWork1;

namespace TermWork1.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] array = new int[3];
            array[0] = 4;
            array[1] = 6;
            array[2] = 2;

            InterfaceOfComparator<int> IntCompair = new IntComparator();


            Sort<int> Bubblesort = new Sort<int>();
            Bubblesort.BubbleSort(array, IntCompair);

            Assert.AreEqual(array[0], 2);
            Assert.AreEqual(array[1], 4);
            Assert.AreEqual(array[2], 6);

        }

        [TestMethod]
        public void TestMethod2()
        {
            string[] array = new string[3];
            array[0] = "olo";
            array[1] = "ololo";
            array[2] = "o";

            InterfaceOfComparator<string> StringCompair = new StringСomparator();

            Sort<string> Bubblesort = new Sort<string>();
            Bubblesort.BubbleSort(array, StringCompair);

            Assert.AreEqual(array[0], "o");
            Assert.AreEqual(array[1], "olo");
            Assert.AreEqual(array[2], "ololo");

        }
    }
}
