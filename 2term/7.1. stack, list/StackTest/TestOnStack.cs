using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _7._1.stack_list;

namespace StackTest
{
    [TestClass]
    public class TestOnStack
    {
        [TestInitialize]
        public void Initialize()
        {
            intStack = new Stack<int>();
            stringStack = new Stack<string>();
        }

        [TestMethod]
        public void PushIntTest()
        {
            intStack.Push(1);
            Assert.IsFalse(intStack.IsEmpty());
        }

        [TestMethod]
        public void PushStringTest()
        {
            stringStack.Push("ololo");
            Assert.IsFalse(stringStack.IsEmpty());
        }

        [TestMethod]
        public void PopIntTest()
        {
            intStack.Push(1);
            Assert.AreEqual(intStack.Pop(), 1);
        }

        [TestMethod]
        public void PopStringTest()
        {
            stringStack.Push("ololo");
            Assert.AreEqual(stringStack.Pop(), "ololo");
        }

        private Stack<int> intStack;
        private Stack<string> stringStack;
    }
}
