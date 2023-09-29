using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace apiSimples.HttpObjects
{
    public class CustomResult : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;
        public CustomResult(string value,HttpRequestMessage message)
        {
            _value = value;
            _request = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage
            {
                Content = new StringContent(_value),
                RequestMessage = _request
            };

            return Task.FromResult(response);
        }
    }
}