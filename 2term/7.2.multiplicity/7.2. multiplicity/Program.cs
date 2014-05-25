using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2.multiplicity
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Multiplicity<int> Multiplicity1 = new Multiplicity<int>();
            Multiplicity1.Incert(1);
            Multiplicity1.Incert(2);
            Multiplicity1.Incert(3);

            Multiplicity<int> Multiplicity2 = new Multiplicity<int>();
            //Multiplicity2.Incert(1);
            //Multiplicity2.Incert(2);

            Multiplicity<int> Result = new Multiplicity<int>();
            //Result.Intersection(Multiplicity1, Multiplicity2);
            Result.Union(Multiplicity1, Multiplicity2);

            //Multiplicity.RemovingOfElement(2);
            //Multiplicity.RemovingOfElement(5);

            //bool exCh1 = Multiplicity.ExistenceChecking(5);

            //if (exCh1)
            //    System.Console.WriteLine("5 is here");
            //else
            //    System.Console.WriteLine("5 isn't here");


            System.Console.WriteLine("{0}", Result.Print());
        }
    }
}
