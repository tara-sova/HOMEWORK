using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _5._1.Map;

namespace MapTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MapTest()
        {
            List list1 = new List();
            list1.InsertToTheEnd(1);
            list1.InsertToTheEnd(2);
            list1.InsertToTheEnd(3);

            List list2 = new List();

            ClassForUsing M = new ClassForUsing();
            list2 = M.Map1(list1, x => x + 5);

            Assert.AreEqual(list2.Print(), "6  7  8  ");
        }
    }
}
