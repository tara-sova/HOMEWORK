using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_iterator
{
    /// <summary>
    /// Class presents a binary tree and operations with it.
    /// </summary>
    /// <typeparam name="ElementType"></typeparam>
    public class BinaryTree<ElementType> : IEnumerable<ElementType>
    {
        public InterfaceOfComparator<ElementType> Comparator;

        /// <summary>
        /// Description of binary tree's element.
        /// </summary>
        public class BinaryTreeElement
        {
            /// <summary>
            /// Meaning of the List's element.
            /// </summary>
            public ElementType Value { get; set; }

            /// <summary>
            /// Field that point on the left element.
            /// </summary>
            public BinaryTreeElement Left { get; set; }

            /// <summary>
            /// Field that point on the right element.
            /// </summary>
            public BinaryTreeElement Right { get; set; }

        }

        private BinaryTreeElement head = null;

        /// <summary>
        /// Add new value in tree by concrete position.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="position"></param>
        public void Insert(ElementType value, int position)
        {
            if (position == 0)
            {
                Push(value);
                return;
            }
            var newElement = new BinaryTreeElement()
            {
                Value = value,
                Left = head,
                Right = null
            };

            if (IsEmpty())
            {
                head = newElement;
                return;
            }

            BinaryTreeElement tempElement = head;

            for (int i = 1; i < position; ++i)
            {

                if (tempElement.Left == null)
                {
                    return;
                }
                tempElement = tempElement.Left;
            }

            if (tempElement.Left == null)
            {
                tempElement.Left = newElement;
                newElement.Right = tempElement;
                newElement.Left = null;
                return;
            }

            BinaryTreeElement elementAfterTemp = tempElement.Left;
            tempElement.Left = newElement;
            newElement.Right = tempElement;
            elementAfterTemp.Right = newElement;
            newElement.Left = elementAfterTemp;
        }

        /// <summary>
        /// Auxiliary method for insertion.
        /// </summary>
        /// <param name="value"></param>
        public void Push(ElementType value)
        {
            var newElement = new BinaryTreeElement()
            {
                Left = head,
                Value = value,
                Right = null
            };

            head = newElement;
        }

        /// <summary>
        /// Delete element by position.
        /// </summary>
        /// <param name="position"></param>
        public void RemovingByPosition(int position)
        {
            BinaryTreeElement tempElement = head;

            if ((position == 0) && (head.Left == null))
            {
                this.head = null;
                return;
            }

            if (position == 0)
            {
                head.Value = head.Left.Value;
                head = head.Left;
                head.Right = null;
                return;
            }

            for (int i = 0; i < position; ++i)
            {
                BinaryTreeElement beforeTemp = tempElement;
                tempElement = tempElement.Left;
                tempElement.Right = beforeTemp;
                if (tempElement == null)
                {
                    return;
                }
            }

            tempElement.Right.Left = tempElement.Left;
            tempElement.Left.Right = tempElement.Right;
        }

        /// <summary>
        /// Delete tree.
        /// </summary>
        public void Removing()
        {
            head = null;
        }

        /// <summary>
        /// Check elements's existence in tree.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return head == null;
        }

        /// <summary>
        /// Print all tree's values.
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            string result = "";
            if (IsEmpty())
            {
                result = "No elemenets in the list.";
                return result;
            }

            BinaryTreeElement tempElement = head;
            while (tempElement != null)
            {
                result = result + tempElement.Value + "  ";
                tempElement = tempElement.Left;
            }
            return result;
        }

        /// <summary>
        /// Get head's value.
        /// </summary>
        /// <returns></returns>
        public BinaryTreeElement GetFirst()
        {
            return head;
        }

        /// <summary>
        /// Getting of Enumerator for our list.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<ElementType> GetEnumerator()
        {
            var enumerator = new Iterator<ElementType>(this);
            return enumerator;
        }

        /// <summary>
        /// Getting of Enumerator for our list but with some object type.
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            var enumerator = new Iterator<ElementType>(this);
            return enumerator;
        }

        /// <summary>
        /// Delete element by using of comparator.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparator"></param>
        public void RemoveElement(ElementType value, InterfaceOfComparator<ElementType> comparator)
        {
            if (comparator.Compair(value, head.Value) == 0)
            {
                head = null;
                return;
            }
            BinaryTreeElement pointerOfValue;
            pointerOfValue = head;

            BinaryTreeElement pointerOfParent;
            pointerOfParent = head;

            BinaryTreeElement previousPointer;
            previousPointer = head;
      
            while (comparator.Compair(value, pointerOfValue.Value) != 0)
            {
                if (comparator.Compair(value, pointerOfValue.Value) == 1) 
                {
                    if (pointerOfValue.Right != null)
                    {
                        pointerOfParent = pointerOfValue;
                        pointerOfValue = pointerOfValue.Right;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (pointerOfValue.Left != null)
                    {
                        pointerOfParent = pointerOfValue;
                        pointerOfValue = pointerOfValue.Left;
                    }
                    else
                    {
                        return;
                    }
                }

            }

            if (pointerOfParent == pointerOfValue)
            {
                pointerOfValue = pointerOfValue.Right;
                while (pointerOfValue.Left != null)
                {
                    previousPointer = pointerOfValue;
                    pointerOfValue = pointerOfValue.Left;
                }
                if (pointerOfValue.Right != null)
                {
                    previousPointer.Left = pointerOfValue.Right;
                    pointerOfParent.Value = pointerOfValue.Value;
                    pointerOfValue = null;
                }
                else
                {
                    pointerOfParent.Value = pointerOfValue.Value;
                    pointerOfValue = null;
                    previousPointer.Left = null;
                }
                return;
            }

            if (pointerOfParent.Right == pointerOfValue)
            {
                if ((pointerOfValue.Right != null) && (pointerOfValue.Left == null))
                {
                    pointerOfParent.Right = pointerOfValue.Right;
                    pointerOfValue = null;
                }
                else if ((pointerOfValue.Right == null) && (pointerOfValue.Left != null))
                {
                    pointerOfParent.Right = pointerOfValue.Left;
                    pointerOfValue = null;
                }
                else if ((pointerOfValue.Right == null) && (pointerOfValue.Left == null))
                {
                    pointerOfValue = null;
                    pointerOfParent.Right = null;
                }
                else if ((pointerOfValue.Right != null) && (pointerOfValue.Left != null))
                {
                    BinaryTreeElement pointerOfRemoving;
                    pointerOfRemoving = pointerOfValue;
                    pointerOfValue = pointerOfValue.Right;
                    while (pointerOfValue.Left != null)
                    {
                        pointerOfValue = pointerOfValue.Left;
                    }

                    ElementType tempValue = pointerOfValue.Value;
                    RemoveElement(pointerOfValue.Value, comparator);
                    pointerOfRemoving.Value = tempValue;
                }
            }
             
            if ((pointerOfParent.Left == pointerOfValue) && (pointerOfParent.Left != null))
            {
                if ((pointerOfValue.Right != null) && (pointerOfValue.Left == null))
                {
                    pointerOfParent.Left = pointerOfValue.Right;
                    pointerOfValue = null;
                }
                else if ((pointerOfValue.Right == null) && (pointerOfValue.Left != null))
                {
                    pointerOfParent.Left = pointerOfValue.Left;
                    pointerOfValue = null;
                }
                else if ((pointerOfValue.Right == null) && (pointerOfValue.Left == null))
                {
                    pointerOfParent.Left = null;
                    pointerOfValue = null;
                }
                else if ((pointerOfValue.Right != null) && (pointerOfValue.Left != null))
                {
                    BinaryTreeElement pointerOfRemoving;
                    pointerOfRemoving = pointerOfValue;
                    pointerOfValue = pointerOfValue.Right;
                    while (pointerOfValue.Left != null)
                    {
                        pointerOfValue = pointerOfValue.Left;
                    }

                    ElementType tempValue = pointerOfValue.Value;
                    RemoveElement(pointerOfValue.Value, comparator);
                    pointerOfRemoving.Value = tempValue;
                }
            }
        }

        /// <summary>
        /// Insert element by using of comparator.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparator"></param>
        public void InsertElement(ElementType value, InterfaceOfComparator<ElementType> comparator)
        {
            BinaryTreeElement pointerOfValue;
	        BinaryTreeElement newElement = new BinaryTreeElement();
	        pointerOfValue = head;

	        newElement.Value = value;
	        newElement.Right = null;
	        newElement.Left = null;

	        if (pointerOfValue == null)
	        {
		        head = newElement;
		        return;
	        }
	
	        while (true)
	        {
                if (comparator.Compair(value, pointerOfValue.Value) == 0)
		        {
                    newElement = null;
			        return;
		        }
                if (comparator.Compair(value, pointerOfValue.Value) == 1)
		        {
			        if (pointerOfValue.Right == null)
			        {
				        pointerOfValue.Right = newElement;
				        return;
			        }

			        pointerOfValue = pointerOfValue.Right;
		        }
		        else
		        {
			        if (pointerOfValue.Left == null)
			        {
				        pointerOfValue.Left = newElement;
				        return;
			        }
			        pointerOfValue = pointerOfValue.Left;
		        }
	        }
        }

        /// <summary>
        /// Check existence of element.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparator"></param>
        /// <returns></returns>
        public bool IsElementExist(ElementType value, InterfaceOfComparator<ElementType> comparator)
        {
            BinaryTreeElement pointerOfValue;
            pointerOfValue = head;

            while (true)
            {
                if (pointerOfValue == null)
                    return false;

                if (comparator.Compair(value, pointerOfValue.Value) == 0)
                    return true;

                if (comparator.Compair(value, pointerOfValue.Value) == 1)
                {
                    if (pointerOfValue.Right != null)
                        pointerOfValue = pointerOfValue.Right;
                    else
                        return false;
                }
                else if (comparator.Compair(value, pointerOfValue.Value) == -1)
                {
                    if (pointerOfValue.Left != null)
                        pointerOfValue = pointerOfValue.Left;
                    else
                        return false;
                }
            }
        }

    }
}
