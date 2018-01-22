using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Phoneword_BLL
{
    public class RestClient
    {

        private HttpClient httpClient;
        public RestClient(HttpMessageHandler handler)
        {
            httpClient = new HttpClient(handler);
        }

        public async Task<string> GetPublicIp()
        {
            return await httpClient.GetStringAsync(Helper.EXTERNAL_IP_URL);
        }

        public async Task<Post> GetTestPost()
        {
            string json_string = await httpClient.GetStringAsync(Helper.SINGLE_POST_URL);
            return JsonConvert.DeserializeObject<Post>(json_string);
        }

        public async Task<List<Post>> GetTestPostList()
        {
            string json_string = await httpClient.GetStringAsync(Helper.POST_LIST_URL);
            return JsonConvert.DeserializeObject<List<Post>>(json_string);
        }


    }
}
