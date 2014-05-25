using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashNamespace;
using _2._3.hash;

namespace Hash1.Test
{
    [TestClass] 
    public class UnitTest1
    {
        [TestMethod]
        public void ExistTrueTest()
        {
            HashFunction hashFunction = new HashFunction1();
            var hash = new Hash(hashFunction);
             
            hash.InsertToHashTable(10);
            hash.InsertToHashTable(20);
            hash.InsertToHashTable(30);
            
            Assert.IsTrue(hash.Exist(20));
        }

        [TestMethod]
        public void ExistFalseTest()
        {
            HashFunction hashFunction = new HashFunction1();
            var hash = new Hash(hashFunction);
            
            hash.InsertToHashTable(10);
            hash.InsertToHashTable(20);
            hash.InsertToHashTable(30);

            Assert.IsFalse(hash.Exist(500));
        }

        [TestMethod]
        public void RemovingOfElement()
        {
            HashFunction hashFunction = new HashFunction1();
            var hash = new Hash(hashFunction);

            hash.InsertToHashTable(20);
            hash.InsertToHashTable(20);
            hash.InsertToHashTable(30);

            hash.Remove(30);
            Assert.IsFalse(hash.Exist(30));
        }
    }
}
