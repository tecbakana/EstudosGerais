using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    public class multiplosObjetos
    {

    }

    public abstract class Elemento
    {
        public abstract string tipo();
    }

    public class Elemento1:Elemento
    {
        public override string tipo()
        {
            return tipo();
        }
    }

    public class Elemento2:Elemento1
    {
        private Elemento1 _elemento1;
        public void SetElemento(Elemento1 elemento1)
        {
            this._elemento1 = elemento1;
        }
    }

    public class Elemento3:Elemento1
    {
        private Elemento1 _elemento1;
        public void SetElemento(Elemento1 elemento1)
        {
            this._elemento1 = elemento1;
        }
    }

    public class Elemento4:Elemento1
    {
        private Elemento1 _elemento1;
        public void SetElemento(Elemento1 elemento1)
        {
            this._elemento1 = elemento1;
        }
    }
}
