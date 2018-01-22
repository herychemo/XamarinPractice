using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phoneword_BLL
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
