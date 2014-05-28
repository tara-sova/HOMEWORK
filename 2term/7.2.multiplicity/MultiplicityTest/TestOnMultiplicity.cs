using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _7._2.multiplicity;

namespace MultiplicityTest
{
    [TestClass]
    public class TestOnMultiplicity
    {
        [TestMethod]
        public void AddIntElementTest()
        {
            Multiplicity<int> multiplicity = new Multiplicity<int>();
            multiplicity.Insert(1);
            Assert.IsTrue(multiplicity.ExistenceChecking(1));
        }

        [TestMethod]
        public void AddStringElementTest()
        {
            Multiplicity<string> multiplicity = new Multiplicity<string>();
            multiplicity.Insert("ololo");
            Assert.IsTrue(multiplicity.ExistenceChecking("ololo"));
        }

        [TestMethod]
        public void RemovingOfElementTest()
        {
            Multiplicity<int> multiplicity = new Multiplicity<int>();
            multiplicity.Insert(1);
            multiplicity.RemovingOfElement(1);
            Assert.IsTrue(multiplicity.IsEmpty());
        }

        [TestMethod]
        public void DetectionOfEmptinessTest()
        {
            Multiplicity<int> multiplicity = new Multiplicity<int>();
            Assert.IsTrue(multiplicity.IsEmpty());
        }

        [TestMethod]
        public void Intersection1Test()
        {
            Multiplicity<int> multiplicity1 = new Multiplicity<int>();
            multiplicity1.Insert(1);
            Multiplicity<int> multiplicity2 = new Multiplicity<int>();
            Multiplicity<int> result = new Multiplicity<int>();
            result.Intersection(multiplicity1, multiplicity2);
            Assert.IsTrue(result.IsEmpty());
        }

        [TestMethod]
        public void Intersection2Test()
        {
            Multiplicity<int> multiplicity1 = new Multiplicity<int>();
            multiplicity1.Insert(1);
            Multiplicity<int> multiplicity2 = new Multiplicity<int>();
            multiplicity2.Insert(1);
            Multiplicity<int> result = new Multiplicity<int>(); 
            result.Intersection(multiplicity1, multiplicity2);
            Assert.IsFalse(result.IsEmpty());
        }

        [TestMethod]
        public void UnionTest()
        {
            Multiplicity<int> multiplicity1 = new Multiplicity<int>();
            multiplicity1.Insert(1);
            Multiplicity<int> multiplicity2 = new Multiplicity<int>();
            Multiplicity<int> result = new Multiplicity<int>();
            result.Union(multiplicity1, multiplicity2);
            Assert.IsFalse(result.IsEmpty());
        }
    }
}
