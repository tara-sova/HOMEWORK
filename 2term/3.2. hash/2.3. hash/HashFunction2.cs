using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3.hash
{
    class HashFunction2 : HashFunction
    {
        /// <summary>
        /// Try to create a random number for indexing fields of hashtable.
        /// </summary>
        /// <param name="newElement"></param>
        /// <returns></returns>
        public int HashFunction(int newElement)
        {
            int sum = 0;
            for (int i = 0; i < newElement; ++i)
            {
                sum = sum + i * i * i * (sum + 1);
            }
            sum = sum % 100;
            return sum;
        }
    }
}
