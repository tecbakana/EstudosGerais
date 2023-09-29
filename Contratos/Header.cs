using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    [DataContract]
    public class Header
    {
        [DataMember (Order =1)]
        public string user
        {
            get;
            set;
        }
    }
}
