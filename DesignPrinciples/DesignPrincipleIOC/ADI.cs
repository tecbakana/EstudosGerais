using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPrincipleIOC
{
    public class ADI
    {
        IObjects.Abstraction _iObj;

        /// <summary>
        /// Dependency injection by Constructor
        /// </summary>
        /// <param name="objX"></param>
        public ADI(IObjects.Abstraction objX)
        {
            _iObj = objX;
        }

        public void Task1(string parm)
        {
            _iObj.ReturnSomething(parm);
        }
    }
}
