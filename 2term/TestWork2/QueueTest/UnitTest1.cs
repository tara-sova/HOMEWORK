using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWork2;

namespace QueueTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Initialize()
        {
            Queue = new PriorityQueue();
        }

        [TestMethod]
        public void EnqueueForFew()  
        {
            Queue.Enqueue(10, 1);
            Queue.Enqueue(20, 2);
            Queue.Enqueue(30, 3);
            Queue.Enqueue(40, 4);

            int a = Queue.Dequeue();

            Assert.AreEqual(40, a);
        }

        [TestMethod]
        public void EnqueueForOne()
        {
            Queue.Enqueue(10, 1);
            int a = Queue.Dequeue();

            Assert.AreEqual(10, a);
        }

        [TestMethod]
        public void EmptyTest()
        {
            Queue.Enqueue(10, 1);
            int a = Queue.Dequeue();

            Assert.IsTrue(Queue.IsEmpty());
        }

        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void QueueTest()
        {
            Queue.Dequeue();
        }
        
        private PriorityQueue Queue;
    }
}
