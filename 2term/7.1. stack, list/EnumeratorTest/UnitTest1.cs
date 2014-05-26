using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _7._1.stack_list;

namespace EnumeratorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Intialize()
        {
            list = new List<int>();
        }
        [TestMethod]
        public void EnumeratorInList()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            int counter = 0;

            foreach (var i in list)
            {
                ++counter;
                Assert.AreEqual(i, counter);
            }
            Assert.AreEqual(counter, 3);
        }

        [TestMethod]
        public void EnumeratorInEmptyList()
        {
            int counter = 0;

            foreach (var i in list)
            {
                ++counter;
                Assert.AreEqual(i, counter);
            }
            Assert.AreEqual(counter, 0);
        }
        private List<int> list;
    }
}
