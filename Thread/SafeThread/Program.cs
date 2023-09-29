using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SafeThread
{
    public class Program
    {
        static bool ok;
        static int status = 0;
        static readonly object bloqueio = new object();
        public static void Main(string[] args)
        {
            new Thread(novaThread).Start();
             novaThread();

            Console.ReadKey();
            novaThread();
            Console.ReadKey();
        }

        public static void novaThread()
        {
           /* lock(bloqueio)
            {*/
                if(!ok)
                {
                    Console.WriteLine(string.Format("executando thread {0}",status));
                   
                    ok = true;
                }
                else
                {
                    Console.WriteLine(string.Format("executando thread {0}", status));

                    //ok = true;

                }
                status++;
           /*}*/

        }
    }
}
