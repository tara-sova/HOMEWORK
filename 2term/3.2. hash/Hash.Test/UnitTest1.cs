using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashNamespace;
using _2._3.hash;

namespace Hash1.Test
{
    [TestClass]  
    public class UnitTest1
    {
        [TestInitialize]
        public void Initialize()
        {
            HashFunction hashFunction = new HashFunction1();
            hash = new Hash(hashFunction);
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

        [TestMethod]
        public void TestChangeHashFunction()
        {
            HashFunction hashfunction2 = new HashFunction2();
            hash.InsertToHashTable(20);
            hash.InsertToHashTable(15);

            hash.ChangeHashfunction(hashfunction2);

            Assert.IsTrue(hash.Exist(15));
        }

        private Hash hash;
    }
}
