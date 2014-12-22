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

        public BinaryTree(InterfaceOfComparator<ElementType> comparator)
        {
            Comparator = comparator;
        }

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
        /// Delete tree.
        /// </summary>
        public void Remove()
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
        public void RemoveElement(ElementType value)
        {
            if ((Comparator.Compare(value, head.Value) == 0) && (head.Left == null) && (head.Right == null))
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
      
            while (Comparator.Compare(value, pointerOfValue.Value) != 0)
            {
                if (Comparator.Compare(value, pointerOfValue.Value) == 1) 
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
                    RemoveElement(pointerOfValue.Value);
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
                    RemoveElement(pointerOfValue.Value);
                    pointerOfRemoving.Value = tempValue;
                }
            }
        }

        /// <summary>
        /// Insert element by using of comparator.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparator"></param>
        public void InsertElement(ElementType value)
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
                if (Comparator.Compare(value, pointerOfValue.Value) == 0)
		        {
                    newElement = null;
			        return;
		        }
                if (Comparator.Compare(value, pointerOfValue.Value) == 1)
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
        public bool IsElementExist(ElementType value)
        {
            BinaryTreeElement pointerOfValue;
            pointerOfValue = head;

            while (true)
            {
                if (pointerOfValue == null)
                    return false;

                if (Comparator.Compare(value, pointerOfValue.Value) == 0)
                    return true;

                if (Comparator.Compare(value, pointerOfValue.Value) == 1)
                {
                    if (pointerOfValue.Right != null)
                        pointerOfValue = pointerOfValue.Right;
                    else
                        return false;
                }
                else if (Comparator.Compare(value, pointerOfValue.Value) == -1)
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
