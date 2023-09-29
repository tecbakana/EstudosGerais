using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTipoGenerico.Model
{
    public class Cliente
    {
        public string Nome { get; set; }

        public void QuemSou()
        {
            Console.WriteLine($"Olá, eu sou {Nome}");
        }
    }
}
