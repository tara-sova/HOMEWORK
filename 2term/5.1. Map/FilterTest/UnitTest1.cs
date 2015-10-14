using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _5._1.Map;

namespace MapTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FilterTest()
        {
            List list1 = new List();
            list1.InsertToTheEnd(5);
            list1.InsertToTheEnd(10);
            list1.InsertToTheEnd(15);
            list1.InsertToTheEnd(1);
            list1.InsertToTheEnd(8);

            List list2 = new List();

            ClassForUsing F = new ClassForUsing();
            list2 = F.Filter(list1, x => x > 5);
            System.Console.WriteLine(list2.Print());

            Assert.AreEqual(list2.Print(), "10  15  8  ");
        }
    }
}