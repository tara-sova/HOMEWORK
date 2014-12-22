using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._1_iterator;

namespace BinaryTreeTraversalByIteratorTest
{
    [TestClass]
    public class TestForIterator
    {
        [TestMethod]
        public void ExistenceOfIntTreeTest()
        {
            InterfaceOfComparator<int> comparator = new IntComparator();
            BinaryTree<int> tree = new BinaryTree<int>(comparator);
            Assert.IsTrue(tree.IsEmpty());
        }

        [TestMethod]
        public void InsertToIntTreeTest()
        {
            InterfaceOfComparator<int> comparator = new IntComparator();
            BinaryTree<int> tree = new BinaryTree<int>(comparator);
            tree.InsertElement(1);
            Assert.IsFalse(tree.IsEmpty());
        }

        [TestMethod]
        public void IsElementExistInIntTreeTest()
        {
            InterfaceOfComparator<int> comparator = new IntComparator();
            BinaryTree<int> tree = new BinaryTree<int>(comparator);
            tree.InsertElement(1);
            Assert.IsTrue(tree.IsElementExist(1));
        }

        [TestMethod]
        public void RemoveInIntTreeTest()
        {
            InterfaceOfComparator<int> comparator = new IntComparator();
            BinaryTree<int> tree = new BinaryTree<int>(comparator);
            tree.InsertElement(1);
            tree.RemoveElement(1);
            Assert.IsFalse(tree.IsElementExist(1));
        }

        [TestMethod]
        public void EnumeratorIntTest()
        {
            InterfaceOfComparator<int> comparator = new IntComparator();
            BinaryTree<int> tree = new BinaryTree<int>(comparator);
            tree.InsertElement(1);
            tree.InsertElement(2);
            string elements = "";
            foreach (int i in tree)
                elements += i.ToString() + "  ";
            Assert.AreEqual("2  1  ", elements);
        }

        [TestMethod]
        public void ExistenceOfStringTreeTest()
        {
            InterfaceOfComparator<string> comparator = new StringComparator();
            BinaryTree<string> tree = new BinaryTree<string>(comparator);
            Assert.IsTrue(tree.IsEmpty());
        }

        [TestMethod]
        public void InsertToStringTreeTest()
        {
            InterfaceOfComparator<string> comparator = new StringComparator();
            BinaryTree<string> tree = new BinaryTree<string>(comparator);
            tree.InsertElement("ololo");
            Assert.IsFalse(tree.IsEmpty());
        }

        [TestMethod]
        public void IsElementExistInStringTreeTest()
        {
            InterfaceOfComparator<string> comparator = new StringComparator();
            BinaryTree<string> tree = new BinaryTree<string>(comparator);
            tree.InsertElement("ololo");
            Assert.IsTrue(tree.IsElementExist("ololo"));
        }

        [TestMethod]
        public void RemoveInStringTreeTest()
        {
            InterfaceOfComparator<string> comparator = new StringComparator();
            BinaryTree<string> tree = new BinaryTree<string>(comparator);
            tree.InsertElement("ololo");
            tree.RemoveElement("ololo");
            Assert.IsFalse(tree.IsElementExist("ololo"));
        }

        [TestMethod]
        public void EnumeratorStringTest()
        {
            InterfaceOfComparator<string> comparator = new StringComparator();
            BinaryTree<string> tree = new BinaryTree<string>(comparator);
            tree.InsertElement("ololo");
            tree.InsertElement("trololo");
            string elements = "";
            foreach (string i in tree)
                elements += i + "  ";
            Assert.AreEqual("trololo  ololo  ", elements);
        }

        [TestMethod]
        public void RemoveFromRootTest()
        {
            InterfaceOfComparator<string> comparator = new StringComparator();
            BinaryTree<string> tree = new BinaryTree<string>(comparator);
            tree.InsertElement("3");
            tree.InsertElement("1");
            tree.InsertElement("5"); 
            tree.RemoveElement("3");

            Assert.IsTrue(tree.IsElementExist("1"));
            Assert.IsTrue(tree.IsElementExist("5"));
            Assert.IsFalse(tree.IsElementExist("3"));
        }
    }
}
