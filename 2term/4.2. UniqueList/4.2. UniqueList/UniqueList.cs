using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2.UniqueList
{
    public class UniqueList : List
    {
        public override void Push1(int value)
        {
            if (TheExistChecking(value))
            {
                throw new MyException("LOSER");
            }
            else
            {
                this.Push(value);
            }
        }

        public override void Insert1(int value, int position)
        {
            if (TheExistChecking(value))
            {
                throw new MyException("LOSER");
            }
            else
            {
                this.Insert(value, position);
            }
        }

        public virtual void Removing1(int position)
        {
            if (TheExistChecking(this.GettingOfValueByPosition(position)))
            {
                throw new MyException("LOSER");
            }
            else
            {
                this.RemovingByPosition(position);
            }
        }

    }
}
