using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbDiary.Shared
{
    /// <summary>
    /// Contains App constants
    /// </summary>
    /// <param name="sealed">
    /// No class should be derieved from AppConstants
    /// </param>
    public sealed class AppConstants
    {
        /// <summary>
        ///     The facebook app id (this is the ID given by facebook in the developer portal for your app)
        /// </summary>
        public static readonly string AppID = "655372611248772";
        /// <summary>
        ///     The facebook app secret id (this is the ID given by facebook in the developer portal for your app)
        /// </summary>
        public static readonly string AppSecretID = "81adb0a0241c66cbbb93166daf426fe3";
        /// <summary>
        ///     Isolated Storage Database Name
        /// </summary>
        public static readonly string DiaryDB = "DIARYDB";
        /// <summary>
        ///     Isolated Storage Database Status Folder Name
        /// </summary>
        public static readonly string DiaryStatusFolder = "Status";
        /// <summary>
        ///     Access Token of the user
        /// </summary>
        public static string AccessToken { get; set; }
    }
}
