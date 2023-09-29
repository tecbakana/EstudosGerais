using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Client
    {
        public void ClientCode(Component comp)
        {
            Console.WriteLine($"ClientCode({comp.Operation()})");
        }
    }
}
