using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashNamespace;

namespace Hash1.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Initialize()
        {
            hash = new Hash();
        }

        [TestMethod]
        public void ExistTrueTest()
        {
            hash.InsertToHashTable(10);
            hash.InsertToHashTable(20);
            hash.InsertToHashTable(30);
            
            Assert.IsTrue(hash.Exist(20));
        }

        [TestMethod]
        public void ExistFalseTest()
        {
            hash.InsertToHashTable(10);
            hash.InsertToHashTable(20);
            hash.InsertToHashTable(30);

            Assert.IsFalse(hash.Exist(500));
        }

        [TestMethod]
        public void RemovingOfElement()
        {
            hash.InsertToHashTable(20);
            hash.InsertToHashTable(20);
            hash.InsertToHashTable(30);

            hash.Remove(30);
            Assert.IsFalse(hash.Exist(30));
        }

        private Hash hash;
    }
}
