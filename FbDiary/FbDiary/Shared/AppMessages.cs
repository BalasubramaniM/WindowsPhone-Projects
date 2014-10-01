using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbDiary.Shared
{
    /// <summary>
    /// Contains App Messages
    /// </summary>
    /// <param name="sealed">
    /// No class should be derieved from AppMessages
    /// </param>
    public sealed class AppMessages
    {
        /// <param name="readonly">
        /// String value cannot be changed further
        /// </param>

        /// <summary>
        /// Messages to display in Message Box and in Progress Bar
        /// </summary>
        public static readonly string Loading   = "Loading...";
        public static readonly string Fetching  = "Fetching details from Facebook...";
        public static readonly string Error     = "Error fetching user data";

        public static readonly string AccessTokenString = "access_token";
    }

    /*
     * user_checkins
     *  user_events
     * name = Name of the user
     * id = Id of the post
     * created_time = gives post created time
     * feed{message} = Message of the feed (Caption) or (Content)
     * feed{full_picture} = Gives picture of the feed [doubt]
     * feed{picture} = Gives picture that the user post
     * feed{place} = Gives location of that post (check ins - place) // id, name, location available in place
     * feed{privacy} = Gives privacy of that post
     * feed{status_type} = Gives whether its user wall post or tagged in post
     * feed.limit(150){} = Limits post
     * fields=picture.type(small) - gives small picture and large gives large picture
    */
}
