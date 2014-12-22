using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _1._2.local_network
{
    [TestClass]
    public class TestForLocalNetwork
    {
        private Random index = new Random();

        [TestMethod]
        public void Infect4Test()
        {
            int extraIndex = index.Next(71, 80);
            StuffClass stuff = new StuffClass();
            Behavior behavior = new Behavior(stuff.GetMatrix(), stuff.GetArrayOfComputers(), extraIndex);
            Assert.IsFalse(!behavior.GetComputerHealthCondition(4));
        }

        [TestMethod]
        public void WeekInfectionTest()
        {
            int extraIndex = index.Next(25, 45);
            StuffClass stuff = new StuffClass();
            Behavior behavior = new Behavior(stuff.GetMatrix(), stuff.GetArrayOfComputers(), extraIndex);

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
            StuffClass stuff = new StuffClass();
            Behavior behavior = new Behavior(stuff.GetMatrix(), stuff.GetArrayOfComputers(), extraIndex);

            bool conditionOfFirst = behavior.GetComputerHealthCondition(1);
            bool conditionOfFourth = behavior.GetComputerHealthCondition(4);
            bool result = true;

            if ((!conditionOfFirst) && (!conditionOfFourth))
                result = false;

            Assert.IsFalse(result);
        }
    }
}
