using System;
using System.Collections.Generic;
using System.Text;

namespace DemoServices.Services
{
    public class ServiceTest:IServiceTest
    {
        private readonly IDemoService _demoService;
        public ServiceTest(IDemoService demoService)
        {
            _demoService = demoService;
        }
        public void ServicoTeste()
        {
            for (int i = 0; i < 10; i++)
            {
                _demoService.ServicoDemo(i);
            }
        }
    }

}
