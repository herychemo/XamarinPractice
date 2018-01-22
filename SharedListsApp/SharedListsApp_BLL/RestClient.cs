
using Newtonsoft.Json;
using SharedListsApp.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SharedListsApp
{
    public class RestClient
    {

        private HttpClient httpClient;
        public RestClient(HttpMessageHandler handler)
        {
            httpClient = new HttpClient(handler);
        }


        public async Task<Post> GetPost(int id)
        {
            string json_string = await httpClient.GetStringAsync(Constants.SINGLE_POST_URL.Replace("_ID_", id.ToString()));
            return JsonConvert.DeserializeObject<Post>(json_string);
        }

        public async Task<List<Post>> GetTestPostList()
        {
            string json_string = await httpClient.GetStringAsync(Constants.POST_LIST_URL);
            return JsonConvert.DeserializeObject<List<Post>>(json_string);
        }


    }
}
