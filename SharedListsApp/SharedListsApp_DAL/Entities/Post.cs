using System;
using Newtonsoft.Json;

namespace SharedListsApp.Entities
{
    public class Post
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

    }
}
