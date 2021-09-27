using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection.Infrastructure
{
    public abstract class BaseHttpClientWithFactory
    {
        private readonly IHttpClientFactory _factory;
        public Uri BaseAddress { get; set; }
        public string BasePath { get; set; }

        public BaseHttpClientWithFactory(IHttpClientFactory factory) => _factory = factory;
    }
}
