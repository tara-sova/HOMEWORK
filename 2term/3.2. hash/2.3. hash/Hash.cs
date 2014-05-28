using ListNamespace;
using _2._3.hash;

namespace HashNamespace
{
    /// <summary>
    /// Hash.
    /// </summary>
    public class Hash
    {
        /// <summary>
        /// Elements of a hashtable are lists.
        /// </summary>
        private List[] bucket = new List[100];

        /// <summary>
        /// Main hashfunction.
        /// </summary>
        private HashFunction HashFunction;

        /// <summary>
        /// Create internal lists ih a hashtable.
        /// </summary>
        public Hash(HashFunction hashFunction)
        {
            for (int i = 0; i < 100; ++i)
            {
                bucket[i] = new List();
            }

            this.HashFunction = hashFunction;
        }

        /// <summary>
        /// Insert value in hashtable.
        /// </summary>
        /// <param name="newElement"></param>
        public void InsertToHashTable(int newElement)
        {
            bucket[HashFunction.HashFunction(newElement)].Push(newElement);
        }

        /// <summary>
        /// Check of element's exictence in a hashtable. 
        /// </summary>
        /// <param name="newElement"></param>
        /// <returns></returns>
        public bool Exist(int newElement)
        {
            return bucket[HashFunction.HashFunction(newElement)].Exist(newElement);
        }

        /// <summary>
        /// Analogue of Exist method but it is more comfortable for using in Main.cs.
        /// </summary>
        /// <param name="newElement"></param>
        public void ExistenceInPrinting(int newElement)
        {
            bool result = Exist(newElement);
            if (result == true)
            {
                System.Console.WriteLine("{0} is here!", newElement);
            }
            else
            {
                System.Console.WriteLine("{0} is not here!", newElement);
            }
        }

        /// <summary>
        /// Remove element from hashtable.
        /// </summary>
        /// <param name="newElement"></param>
        public void Remove(int newElement)
        {
            bucket[HashFunction.HashFunction(newElement)].RemovingByPosition(bucket[HashFunction.HashFunction(newElement)].GettingOfPositionByValue(newElement));
        }

        /// <summary>
        /// Print hashtable.
        /// </summary>
        public void PrintHashTable()
        {
            string result = "";
            for (int i = 0; i < 100; ++i)
            {
                result = bucket[i].Print();
                if (result != "-")
                {
                    System.Console.WriteLine("{0}", bucket[i].Print());
                }
            }
        }

        /// <summary>
        /// Delete a hashtable.
        /// </summary>
        public void DeleteHashTable()
        {
            for (int i = 0; i < 100; ++i)
            {
                bucket[i].Removing();
            }
        }

        /// <summary>
        /// Change hashfunction.
        /// </summary>
        public void ChangeHashfunction(HashFunction hashfunction)
        {
            List newList = new List();
            for (int i = 0; i < 100; ++i)
            {
                var tempElement = bucket[i];
                while (!tempElement.IsEmpty())
                {
                    newList.Push(tempElement.GetHead());
                    tempElement.DeleteHead();
                }
            }

            this.HashFunction = hashfunction;
            while (!newList.IsEmpty())
            {
                int value = newList.GetHead();
                newList.DeleteHead();
                bucket[HashFunction.HashFunction(value)].Push(value);
            }
        }
    }
}
