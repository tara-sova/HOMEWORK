using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4.calculator
{
    /// <summary>
    /// Main class for stack.
    /// </summary>
    public interface MainStack
    {
        /// <summary>
        /// Input element in stack.
        /// </summary>
        /// <param name="value"></param>
        void Push(int value);

        /// <summary>
        /// Output element from stack.
        /// </summary>
        /// <returns></returns>
        int Pop();
    }
}
