using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _5._1.Map;

namespace MapTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FoldTest()
        {
            List list = new List();
            list.InsertToTheEnd(1);
            list.InsertToTheEnd(2);
            list.InsertToTheEnd(3);

            ClassForUsing Fo = new ClassForUsing();

            int result = Fo.Fold(list, 1, (acc, elem) => acc = acc * elem.GettingFirstValue());

            Assert.AreEqual(result, 6);
        }
    }
}