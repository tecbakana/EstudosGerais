using System;
using Lessons.Implementacao;
using System.Linq.Expressions;

namespace Lessons
{
    public class lessons
    {
        public static void Main(string[] args)
        {
            //instanciando a base
            /*Concreto.concreteClass simple = new Concreto.concreteClass();
            classeConcreta1 concreta1 = new classeConcreta1(simple);
            classeConcreta2 concreta2 = new classeConcreta2(concreta1);
            classeConcreta1 concreta1a = new classeConcreta1(concreta2);
            client cclient = new client();


            Console.WriteLine(concreta1.Description());
            Console.WriteLine(concreta2.Description());
            cclient.ClientCode(concreta1a);
            Console.ReadKey();

            Elemento2 elm2 = new Elemento2(new Elemento1() { tipo = "00" });*/
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("CFOP", "698");
            dict.Add("xMunIni", "123");
            dict.Add("xMunFim", "123");
            dict.Add("CST", "999");

        }
    }
}