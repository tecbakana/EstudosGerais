using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPrincipleIOC
{
    public class Factory
    {
        public static B GetObject()
        {
            return new B();
        }
    }
}
