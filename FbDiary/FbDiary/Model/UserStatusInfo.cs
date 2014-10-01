using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbDiary.Model
{
    public class UserStatusInfo
    {
        [JsonProperty("feed")]
        public Feed Feed { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Privacy
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("friends")]
        public string Friends { get; set; }

        [JsonProperty("networks")]
        public string Networks { get; set; }

        [JsonProperty("allow")]
        public string Allow { get; set; }

        [JsonProperty("deny")]
        public string Deny { get; set; }
    }

    public class Datum
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("full_picture")]
        public string FullPicture { get; set; }

        [JsonProperty("privacy")]
        public Privacy Privacy { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }
    }
    public class Paging
    {
        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }

    public class Feed
    {
        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}
