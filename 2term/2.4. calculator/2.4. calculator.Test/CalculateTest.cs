using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasedOnArraysStackNamespace;
using StackNamespace;

namespace _2._4.calculator.Test
{
    [TestClass]
    public class CalculateTest
    {
        [TestInitialize]
        public void Initialize()
        {
            stack = new Stack();
            Calculator1 = new Calculator(stack);

            arrayStack = new BasedOnArraysStack();
            Calculator2 = new Calculator(arrayStack);
        }

        [TestMethod]
        public void ArrayStackSumTest()
        {
            arrayStack.Push(70);
            arrayStack.Push(30);

            Assert.AreEqual(100, Calculator2.Sum());
        }
        
        [TestMethod]
        public void ArrayStackDifferenceTest()
        {
            arrayStack.Push(20);
            arrayStack.Push(35);

            Assert.AreEqual(15, Calculator2.Difference());
        }

        [TestMethod]
        public void ArrayStackQuotientTest()
        {
            arrayStack.Push(3);
            arrayStack.Push(99);

            Assert.AreEqual(33, Calculator2.Quotient());
        }

        [TestMethod]
        public void ArrayStackProductTest()
        {
            arrayStack.Push(3);
            arrayStack.Push(15);

            Assert.AreEqual(45, Calculator2.Product());
        }

        [TestMethod]
        public void StackSumTest()
        {
            stack.Push(15);
            stack.Push(25);

            Assert.AreEqual(40, Calculator1.Sum());
        }

        [TestMethod]
        public void StackDifferenceTest()
        {
            stack.Push(8);
            stack.Push(78);

            Assert.AreEqual(70, Calculator1.Difference());
        }

        [TestMethod]
        public void StackQuotientTest()
        {
            stack.Push(2);
            stack.Push(1024);

            Assert.AreEqual(512, Calculator1.Quotient());
        }

        [TestMethod]
        public void StackProductTest()
        {
            stack.Push(10);
            stack.Push(87);

            Assert.AreEqual(870, Calculator1.Product());
        }
        
        private MainStack stack;
        private MainStack arrayStack;
        private Calculator Calculator1;
        private Calculator Calculator2;
    }
}
