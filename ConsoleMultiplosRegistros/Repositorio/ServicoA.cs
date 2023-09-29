using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMultiplosRegistros.Repositorio
{
    public class ServicoA:IServico
    {
        public string Servico()
        {
            return "Sou o serviço A";
        }
    }
}
