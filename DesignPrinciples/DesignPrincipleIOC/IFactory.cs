using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPrincipleIOC.IObjects;

namespace DesignPrincipleIOC
{
    public class IFactory
    {
        public static Abstraction GetObject()
        {
            return new B();
        }
    }
}
