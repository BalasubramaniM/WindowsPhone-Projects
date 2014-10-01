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

        [JsonProperty("likes")]
        public Likes Likes { get; set; }

        [JsonProperty("comments")]
        public Comments Comments { get; set; }
    }

    #region Likes Class 
    public class Likes
    {
        [JsonProperty("data")]
        public Datum2[] Data { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
    public class Datum2
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class Paging
    {
        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
    #endregion

    #region Comments Class
    public class Comments
    {
        [JsonProperty("data")]
        public Datum3[] Data { get; set; }

        [JsonProperty("paging")]
        public Paging2 Paging { get; set; }
    }
    public class Datum3
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("from")]
        public From From { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("can_remove")]
        public bool CanRemove { get; set; }

        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }

        [JsonProperty("like_count")]
        public int LikeCount { get; set; }

        [JsonProperty("user_likes")]
        public bool UserLikes { get; set; }

        [JsonProperty("message_tags")]
        public MessageTag[] MessageTags { get; set; }
    }
    public class Paging2
    {
        [JsonProperty("cursors")]
        public Cursors2 Cursors { get; set; }
    }
    public class From
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
    public class MessageTag
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }
    }
    public class Cursors2
    {
        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }
    }
    #endregion
    public class Feed
    {
        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}
