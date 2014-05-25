using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._4.cursor
{
    public class Moving
    {
        private int x;
        private int y;

        public Moving(int valueX, int valueY)
        {
            x = valueX;
            y = valueY;
        }

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
