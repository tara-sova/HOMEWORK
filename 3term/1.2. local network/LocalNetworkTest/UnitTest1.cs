using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _1._2.local_network
{
    [TestClass]
    public class TestForLocalNetwork
    {
        private Random index = new Random();

        [TestMethod]
        public void NewTest()
        {
            int extraIndex = index.Next(71, 80);
            StuffClass stuff = new StuffClass("info1.txt");
            Behavior behavior = new Behavior(stuff.GetMatrix(), stuff.GetArrayOfComputers());
            behavior.InternalInfection(behavior.GetArray(), stuff.GetMatrix(), extraIndex);
            Assert.IsFalse(behavior.GetComputerHealthCondition(2));
            Assert.IsTrue(behavior.GetComputerHealthCondition(1));
        }

        [TestMethod]
        public void NewTest1()
        {
            int extraIndex = index.Next(71, 80);
            StuffClass stuff = new StuffClass("info.txt");
            Behavior behavior = new Behavior(stuff.GetMatrix(), stuff.GetArrayOfComputers());
            for (int i = 0; i < 5; ++i)
            {
                behavior.InternalInfection(behavior.GetArray(), stuff.GetMatrix(), extraIndex);
            }
            Assert.IsFalse(!behavior.GetComputerHealthCondition(4));
        }

        [TestMethod]
        public void WeekInfectionTest()
        {
            int extraIndex = index.Next(25, 45);
            StuffClass stuff = new StuffClass("info.txt");
            Behavior behavior = new Behavior(stuff.GetMatrix(), stuff.GetArrayOfComputers());
            for (int i = 0; i < 10; ++i)
            {
                behavior.InternalInfection(behavior.GetArray(), stuff.GetMatrix(), extraIndex);
            }

            bool conditionOfFirst = behavior.GetComputerHealthCondition(1);
            bool conditionOfSecond = behavior.GetComputerHealthCondition(2);
            bool conditionOfFourth = behavior.GetComputerHealthCondition(4);
            bool result = true;

            if ((!conditionOfFirst) && (!conditionOfSecond) && (!conditionOfFourth))
                result = false;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToInfectLinuxTest()
        {
            int extraIndex = index.Next(55, 69);
            StuffClass stuff = new StuffClass("info.txt");
            Behavior behavior = new Behavior(stuff.GetMatrix(), stuff.GetArrayOfComputers());
            for (int i = 0; i < 10; ++i)
            {
                behavior.InternalInfection(behavior.GetArray(), stuff.GetMatrix(), extraIndex);
            }

            bool conditionOfFirst = behavior.GetComputerHealthCondition(1);
            bool conditionOfFourth = behavior.GetComputerHealthCondition(4);
            bool result = true;

            if ((!conditionOfFirst) && (!conditionOfFourth))
                result = false;

            Assert.IsFalse(result);
        }
    }
}
