using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._4.cursor
{
    class Program
    {
        static void Main(string[] args)
        {       
            var eventLoop = new EventLoop();

            var movingLeft = new Moving(Console.CursorLeft, Console.CursorTop);
            var movingRight = new Moving(Console.CursorLeft, Console.CursorTop);
            var movingUp = new Moving(Console.CursorLeft, Console.CursorTop);
            var movingDown = new Moving(Console.CursorLeft, Console.CursorTop);


            eventLoop.LeftHandler += movingLeft.MovingLeft;
            eventLoop.RightHandler += movingRight.MovingRight;
            eventLoop.UpHandler += movingUp.MovingUp;
            eventLoop.DownHandler += movingDown.MovingDown;

            var log = new List<string>();

            eventLoop.Run();
        }
    }
}
