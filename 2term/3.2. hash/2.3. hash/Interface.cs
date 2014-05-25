using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3.hash
{
    /// <summary>
    /// Interface that control using hashfunction's methods.
    /// </summary>
    public interface HashFunction
    {
        int HashFunction(int newElement);
    }
}
