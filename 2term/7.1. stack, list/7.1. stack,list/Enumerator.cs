using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1.stack_list
{
    /// <summary>
    /// Class for go-round into a list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Enumerator<T> : IEnumerator<T>
    {
        /// <summary>
        /// Desription of Enumerator.
        /// </summary>
        /// <param name="list"></param>
        public Enumerator(List<T> list)
        {
            this.list = list;
            Reset();
        }

        /// <summary>
        /// Special Enumerator's pointer.
        /// </summary>
        private List<T>.ListElement position;

        /// <summary>
        /// Get current value.
        /// </summary>
        public T Current
        {
            get
            {
                return position.Value;
            }
        }

        /// <summary>
        /// Without it, this doesn't work. It is all my knowlege about that stuff.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Get current element with some object type.
        /// </summary>
        object System.Collections.IEnumerator.Current
        {
            get
            {
                return position.Value;
            }
        }

        /// <summary>
        /// Move our special Enumerator's pointer to next cell.
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            position = position.Next;
            return position != null;
        }

        /// <summary>
        /// Add new element into list and make Enumerator's pointer indicate on it.
        /// </summary>
        public void Reset()
        {
            var newElement = new List<T>.ListElement()
            {
                Next = list.GetFirst(),
                Previous = null
            };
            position = newElement;
        }
        private List<T> list;
    }
}
