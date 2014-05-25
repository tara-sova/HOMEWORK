using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HashNamespace;

namespace _2._3.hash
{
    class Program
    {
        static void Main(string[] args)
        {
            var hash = new Hash();
            hash.InsertToHashTable(10);
            hash.InsertToHashTable(20);
            hash.InsertToHashTable(30);

            hash.ExistenceInPrinting(20);
        }

    }
}
