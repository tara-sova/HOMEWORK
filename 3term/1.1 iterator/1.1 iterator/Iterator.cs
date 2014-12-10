using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_iterator
{
    /// <summary>
    /// Class for travelsal of list (with a binary tree values).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Iterator<T> : IEnumerator<T>
    {
        /// <summary>
        /// Desription of Iterator.
        /// </summary>
        /// <param name="list"></param>
        public Iterator(BinaryTree<T> tree)
        {
            binaryTree = tree;
            List<T> listForCompiling = new List<T>();
            list = listForCompiling;
            recursiveDescendingOutput(binaryTree.GetFirst());
            Reset();
        }

        private BinaryTree<T> binaryTree;
        private List<T> list;
        int current;

        /// <summary>
        /// Get current value.
        /// </summary>
        public T Current 
        { 
            get 
            { 
                return list[current]; 
            } 
        }

        /// <summary>
        /// Without it, this doesn't work. It is all my knowlege about that stuff.
        /// </summary>
        public void Dispose()
        {
        }

        ///// <summary>
        ///// Get current element with some object type.
        ///// </summary>
        object System.Collections.IEnumerator.Current
        {
            get
            {
               return list[current];
            }
        }

        /// <summary>
        /// Start of tree tree traversal.
        /// </summary>
        public void Reset()
        {
           current = -1;
        }

        /// <summary>
        /// Move Iterator's pointer on the next element.
        /// </summary>
        /// <returns></returns>
        public bool MoveNext() 
        {
            if (current < list.Count)
                ++current;

            if (current == list.Count)
                return false;

            return true;
        }

        /// <summary>
        /// Traversal tree in recursive way.
        /// </summary>
        /// <param name="element"></param>
        void recursiveDescendingOutput(BinaryTree<T>.BinaryTreeElement element)
        {
            if (element.Right != null)
            {
                recursiveDescendingOutput(element.Right);
            }

            list.Add(element.Value);

            if (element.Left != null)
            {
                recursiveDescendingOutput(element.Left);
            }
        }

    }

}
