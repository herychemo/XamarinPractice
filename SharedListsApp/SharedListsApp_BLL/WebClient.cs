using System;
using System.Net.Http;

namespace SharedListsApp
{
    public class WebClient
    {

        private HttpClient httpClient;
        public RestClient(HttpMessageHandler handler)
        {
            httpClient = new HttpClient(handler);
        }
    }
}
