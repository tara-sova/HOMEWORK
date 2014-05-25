using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._4.cursor
{
    /// <summary>
    /// Describe all of the cursor's ways of moving.
    /// </summary>
    public class Moving
    {
        private int x;
        private int y;

        /// <summary>
        /// Desription of replacement.
        /// </summary>
        /// <param name="valueX"></param>
        /// <param name="valueY"></param>
        public Moving(int valueX, int valueY)
        {
            x = valueX;
            y = valueY;
        }

        /// <summary>
        /// Let's move to the left.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void MovingLeft(object sender, EventArgs eventArgs)
        {
            if (Console.CursorLeft < 1)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            }
            else
            {
                Console.SetCursorPosition(--Console.CursorLeft, Console.CursorTop);
            }
        }

        /// <summary>
        /// Let's move to the right.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void MovingRight(object sender, EventArgs eventArgs)
        {
            if (Console.CursorLeft < Console.WindowWidth - 1)
            {
                Console.SetCursorPosition(++Console.CursorLeft, Console.CursorTop);
            }
            else
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            }
        }
        
        /// <summary>
        /// Let's move to the up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void MovingUp(object sender, EventArgs eventArgs)
        {
            if (Console.CursorTop < 1)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            }
            else
            {
                Console.SetCursorPosition(Console.CursorLeft, --Console.CursorTop);
            }
        }

        /// <summary>
        /// Let's move to the down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void MovingDown(object sender, EventArgs eventArgs)
        {
            if (Console.CursorTop < Console.WindowHeight - 1)
            {
                Console.SetCursorPosition(Console.CursorLeft, ++Console.CursorTop);
            }
            else
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            }
        }
    }
}
