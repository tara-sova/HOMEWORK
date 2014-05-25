using ListNamespace;

namespace HashNamespace
{
    /// <summary>
    /// Hash.
    /// </summary>
    public class Hash  
    {
        const int size = 100;
        
        /// <summary>
        /// Elements of a hashtable are lists.
        /// </summary>
        private List[] bucket = new List[size];

        /// <summary>
        /// Create internal lists ih a hashtable.
        /// </summary>
        public Hash()
        {
            for (int i = 0; i < size; ++i)
            {
                bucket[i] = new List();
            }
        }

        /// <summary>
        /// Try to create a random number for indexing fields of hashtable.
        /// </summary>
        /// <param name="newElement"></param>
        /// <returns></returns>
        private int HashFunction(int newElement)
        {
            int sum = 0;
            for (int i = 0; i < newElement; ++i)
            {
                sum = sum + i * i;
            }
            sum = sum % 100;
            return sum;
        }

        /// <summary>
        /// Insert value in hashtable.
        /// </summary>
        /// <param name="newElement"></param>
        public void InsertToHashTable(int newElement)
        {
            bucket[HashFunction(newElement)].Push(newElement);
        }

        /// <summary>
        /// Check of element's exictence in a hashtable. 
        /// </summary>
        /// <param name="newElement"></param>
        /// <returns></returns>
        public bool Exist(int newElement)
        {
            return bucket[HashFunction(newElement)].Exist(newElement);
        }

        /// <summary>
        /// Analogue of Exist method but it is more comfortable for using in Main.cs.
        /// </summary>
        /// <param name="newElement"></param>
        public void ExistenceInPrinting(int newElement)
        {
            bool result = Exist(newElement);
            if (result)
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
            bucket[HashFunction(newElement)].RemovingByPosition(bucket[HashFunction(newElement)].GettingOfPositionByValue(newElement));
        }

        /// <summary>
        /// Print hashtable.
        /// </summary>
        public void PrintHashTable()
        {
            string result = "";
            for (int i = 0; i < size; ++i)
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
            for (int i = 0; i < size; ++i)
            {
                bucket[i].Removing();
            }
        }
    }
}
