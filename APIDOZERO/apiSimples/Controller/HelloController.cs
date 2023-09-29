using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apiSimples.HttpObjects;
using apiSimples.Filters;
using System.Web.Http.Filters;

namespace apiSimples.Controller
{
    public class HelloController : ApiController
    {
        public string Get()
        {
            Decimal Nova = 1.99M;
            return Nova.ToString();
        }

        [Route("api/Hello/TesteResponse")]
        [HttpPost]
        public CustomResult TesteResponse()
        {
            CustomResult response = new CustomResult("teste", Request);
            return response;
        }

        [Route("api/Hello/TesteActionFilters")]
        [Log]
        public CustomResult TesteActionFilters()
        {
            CustomResult response = new CustomResult("teste", Request);
            return response;
        }
    }
}
