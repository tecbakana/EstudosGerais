using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AplicacaoComThread
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread t = new Thread(ThreadPai);
            for (int i = 0; i < 10000; i++) Console.Write(string.Format("item {0}, ", i));
            t.Start();
        }

        public static void ThreadPai()
        {

            for (int i = 0; i < 10000; i++) Console.WriteLine(i);
        }


    }
}
