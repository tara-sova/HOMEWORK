using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._1_iterator;

namespace BinaryTreeTraversalByIteratorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExistenceOfIntTreeTest()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            Assert.IsTrue(tree.IsEmpty());
        }

        [TestMethod]
        public void InsertToIntTreeTest()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            InterfaceOfComparator<int> comparator = new IntComparator();
            tree.InsertElement(1, comparator);
            Assert.IsFalse(tree.IsEmpty());
        }

        [TestMethod]
        public void IsElementExistInIntTreeTest()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            InterfaceOfComparator<int> comparator = new IntComparator();
            tree.InsertElement(1, comparator);
            Assert.IsTrue(tree.IsElementExist(1, comparator));
        }

        [TestMethod]
        public void RemoveInIntTreeTest()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            InterfaceOfComparator<int> comparator = new IntComparator();
            tree.InsertElement(1, comparator);
            tree.RemoveElement(1, comparator);
            Assert.IsFalse(tree.IsElementExist(1, comparator));
        }

        [TestMethod]
        public void EnumeratorIntTest()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            InterfaceOfComparator<int> comparator = new IntComparator();
            tree.InsertElement(1, comparator);
            tree.InsertElement(2, comparator);
            string elements = "";
            foreach (int i in tree)
                elements += i.ToString() + "  ";
            Assert.AreEqual("2  1  ", elements);
        }

        [TestMethod]
        public void ExistenceOfStringTreeTest()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            Assert.IsTrue(tree.IsEmpty());
        }

        [TestMethod]
        public void InsertToStringTreeTest()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            InterfaceOfComparator<string> comparator = new StringComparator();
            tree.InsertElement("ololo", comparator);
            Assert.IsFalse(tree.IsEmpty());
        }

        [TestMethod]
        public void IsElementExistInStringTreeTest()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            InterfaceOfComparator<string> comparator = new StringComparator();
            tree.InsertElement("ololo", comparator);
            Assert.IsTrue(tree.IsElementExist("ololo", comparator));
        }

        [TestMethod]
        public void RemoveInStringTreeTest()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            InterfaceOfComparator<string> comparator = new StringComparator();
            tree.InsertElement("ololo", comparator);
            tree.RemoveElement("ololo", comparator);
            Assert.IsFalse(tree.IsElementExist("ololo", comparator));
        }

        [TestMethod]
        public void EnumeratorStringTest()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            InterfaceOfComparator<string> comparator = new StringComparator();
            tree.InsertElement("ololo", comparator);
            tree.InsertElement("trololo", comparator);
            string elements = "";
            foreach (string i in tree)
                elements += i + "  ";
            Assert.AreEqual("trololo  ololo  ", elements);
        }
    }
}
