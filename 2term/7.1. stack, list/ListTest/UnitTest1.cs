using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _7._1.stack_list;

namespace ListTest
{   
    [TestClass]
    public class ListTest
    {
        [TestInitialize]
        public void Initialize()
        {
            intList = new List<int>();
            stringList = new List<string>();
        }

        [TestMethod]
        public void InsertIntListTest()
        {
            intList.Insert(1, 0);
            Assert.IsFalse(intList.IsEmpty());
        }

        [TestMethod]
        public void InsertStringListTest()
        {
            stringList.Insert("ololo", 0);
            Assert.IsFalse(stringList.IsEmpty());
        }
        
        [TestMethod]
        public void RemovingTest()
        {
            intList.Insert(1, 0);

            intList.RemovingByPosition(0);

            Assert.IsTrue(intList.IsEmpty());
        }

        private List<int> intList;
        private List<string> stringList;
    }
}
