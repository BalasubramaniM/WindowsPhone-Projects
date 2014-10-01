using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbDiary.Model
{
    #region USER BASIC INFO CLASS
    public class UserBasicInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("hometown")]
        public Hometown Hometown { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("timezone")]
        public double Timezone { get; set; }

        [JsonProperty("updated_time")]
        public string UpdatedTime { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }
    }

    public class Location
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Hometown
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
    #endregion

    #region USER PROFILE PICTURE CLASS

    /// <summary>
    /// Gets user Profile Picture
    /// </summary>
    public class Data
    {

        [JsonProperty("is_silhouette")]
        public bool IsSilhouette { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Picture
    {

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class UserProfilePicture
    {
        [JsonProperty("picture")]
        public Picture Picture { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
    #endregion
}
