using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _4._2.UniqueList;

namespace UniqueListTest
{
    [TestClass]
    public class ListTest
    {
        [TestInitialize]
        public void Initialize()
        {
            var list = new List();
            var uniqueList = new UniqueList();
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Exception1Test()
        {
            uniqueList.Push1(1);
            uniqueList.Push1(1);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Exception2Test()
        {
            uniqueList.Insert1(1, 0);
            uniqueList.Insert1(1, 1);
        }

        [TestMethod]
        public void Insert1Test()
        {
            uniqueList.Insert1(1, 0);
            uniqueList.Insert1(2, 1);
            uniqueList.Insert1(3, 2);

            list.Insert1(4, 0);
            list.Insert1(5, 1);
            list.Insert1(2, 2);

            Assert.AreEqual(list.GettingOfValueByPosition(1), uniqueList.GettingOfValueByPosition(2));
        }

        [TestMethod]
        public void Push1Test1()
        {
            uniqueList.Push1(1);
            uniqueList.Push1(2);
            uniqueList.Push1(3);

            Assert.AreEqual(3, uniqueList.GettingFirst());
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Remove1Test()
        {
            uniqueList.Insert1(1, 0);
            uniqueList.Insert1(2, 1);

            uniqueList.Removing1(1);

            Assert.AreEqual(1, uniqueList.Size());
        }

        private UniqueList uniqueList;
        private List list;
    }
}
