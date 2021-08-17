using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.NET.Patterns
{
    public class HasFinalizerPolicy : IFinalizerPolicy
    {
        public bool ImplementsFinalizer => true;
    }
}
