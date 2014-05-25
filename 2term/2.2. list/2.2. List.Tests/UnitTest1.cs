namespace ListNamespace.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ListNamespace;

    [TestClass]
    public class ListTest
    {
        [TestInitialize]
        public void Initialize()
        {
            list = new List();
        }

        [TestMethod]
        public void PushTest()
        {
            list.Push(1);
            list.Push(2);
            list.Push(3);
            list.Push(4);
            list.Push(5);
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void InsertTest()
        {
            list.Push(1);
            list.Push(2);
            list.Push(3);
            list.Push(4);
            list.Push(5);

            list.Insert(100, 2);
            list.Insert(300, 1);
            list.Insert(200, 0);

            Assert.AreEqual("200  5  300  4  100  3  2  1  ", list.Print());
        }

        
        [TestMethod]
        public void GettingOfValueByPositionTest()
        {
            list.Push(1);
            list.Push(2);
            list.Push(3);
            list.Push(4);
            list.Push(5);

            Assert.AreEqual(3, list.GettingOfValueByPosition(2));
        }

        [TestMethod]
        public void GettingOfPositionByValue()
        {
            list.Push(1);
            list.Push(2);
            list.Push(3);
            list.Push(4);
            list.Push(5);

            Assert.AreEqual(2, list.GettingOfValueByPosition(3));
        }

        [TestMethod]
        public void RemovingTest()
        {
            list.Push(1);
            list.Push(2);
            list.Push(3);
            list.Push(4);
            list.Push(5);

            list.Removing();

            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void RemovingByPositionTest()
        {
            list.Push(1);
            list.Push(2);
            list.Push(3);
            list.Push(4);
            list.Push(5);

            list.RemovingByPosition(1);

            Assert.AreEqual("5  3  2  1  ", list.Print());
        }

        private List list;
    }
}
