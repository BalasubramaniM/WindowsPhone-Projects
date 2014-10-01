using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbDiary.Shared
{
    /// <summary>
    /// Contains App Url's
    /// </summary>
    /// <param name="sealed">
    /// No class should be derieved from AppUrl 
    /// </param>
    public sealed class AppUrl
    {
        /// <summary>
        /// FACEBOOK BASE URL
        /// </summary>
        private static readonly string BASE_URL                 = "https://www.facebook.com/";
        /// <summary>
        /// FACEBOOK GRAPH BASE URL
        /// </summary>
        private static readonly string GRAPH_BASE_URL           = "https://graph.facebook.com/";
        /// <summary>
        /// GET SCOPES
        /// </summary>
        private static readonly string URL_CONNECT              = "connect/login_success.html&";
        private static readonly string CLIENT_SECRET            = "client_secret=";
        private static readonly string CODE_VALUE               = "&code=";
        private static readonly string ACCESS_TOKEN_URL         = "&access_token=";
        private static readonly string FIELDS_URL               = "fields=";
        private static readonly string ME                       = "me?";
        private static readonly string PictureType              = "picture.type(large)";
        private static readonly string SUB_APP_ID               = "dialog/oauth?client_id=";
        private static readonly string GRAPH_ACCESSTOKEN_URL    = "oauth/access_token?client_id=";
        private static readonly string REDIRECT_URI             = "&redirect_uri=";
        private static readonly string BASE_SCOPE_URL           = "scope=email,user_location,friends_location,user_hometown,friends_hometown,publish_stream,offline_access,read_stream,user_status,user_photos,friends_photos,friends_status,user_checkins,friends_checkins,user_events,publish_checkins&display=wap";
        private static readonly string USER_STATUS_SCOPE        = "feed.limit(50){description,likes,comments,caption,message,full_picture,privacy}";
        /// <summary>
        /// GET BASE URL CONNECT LINK
        /// </summary>
        private static readonly string BASE_URL_CONNECT         = BASE_URL + URL_CONNECT;
        /// <summary>
        /// GET USER ACCESS TOKEN LINK
        /// </summary>
        private static readonly string GET_ACCESSTOKEN_URL      = GRAPH_BASE_URL + GRAPH_ACCESSTOKEN_URL;
        /// <summary>
        /// GET USER APP ID & SECRET LINK
        /// </summary>
        private static readonly string URL_APP_ID               = BASE_URL + SUB_APP_ID;
        private static readonly string URL_APP_SECRET           = BASE_URL_CONNECT + CLIENT_SECRET;
        /// <summary>
        /// GET USER BASE LOGIN URL LINK
        /// </summary>
        public static readonly string BASE_URL_LOGIN            = URL_APP_ID + AppConstants.AppID + REDIRECT_URI + BASE_URL_CONNECT + BASE_SCOPE_URL;
        /// <summary>
        /// GET USER BASE ACCESS TOKEN LINK
        /// </summary>
        public static readonly string BASE_ACCESS_TOKEN_URL     = GRAPH_BASE_URL + GRAPH_ACCESSTOKEN_URL + AppConstants.AppID + REDIRECT_URI + BASE_URL_CONNECT + CLIENT_SECRET + AppConstants.AppSecretID + CODE_VALUE;
        /// <summary>
        /// GET USER BASIC INFO LINK
        /// </summary>
        public static readonly string USER_BASIC_INFO_URL       = GRAPH_BASE_URL + ME + ACCESS_TOKEN_URL;
        /// <summary>
        /// GET USER PROFILE PIC LINK LINK
        /// </summary>
        public static readonly string USER_PROFILE_PIC_URL      = GRAPH_BASE_URL + ME + FIELDS_URL + PictureType + ACCESS_TOKEN_URL;
        /// <summary>
        /// GET USER STATUS INFO LINK
        /// </summary>
        public static readonly string USER_STATUS_INFO_URL      = GRAPH_BASE_URL + ME + FIELDS_URL + USER_STATUS_SCOPE + ACCESS_TOKEN_URL;
    }
}
