using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _3._1.robots
{
    [TestClass]
    public class TestForRobots
    {
        [TestMethod]
        public void FirstKindOfDataTest()
        {
            StuffClass stuff = new StuffClass("info.txt");
            Graph graph = new Graph(stuff.GetMatrix(), stuff.GetArrayWhithRobots());
            Assert.IsFalse(graph.GetCheckOfKilling());
        }

        [TestMethod]
        public void SecondKindOfDataTest()
        {
            StuffClass stuff = new StuffClass("info1.txt");
            Graph graph = new Graph(stuff.GetMatrix(), stuff.GetArrayWhithRobots());
            Assert.IsFalse(graph.GetCheckOfKilling());
        }

        [TestMethod]
        public void ThirdKindOfDataTest()
        {
            StuffClass stuff = new StuffClass("info2.txt");
            Graph graph = new Graph(stuff.GetMatrix(), stuff.GetArrayWhithRobots());
            Assert.IsTrue(graph.GetCheckOfKilling());
        }
    }
}
