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
        public static readonly string AppID = "<<AppID>>";
        /// <summary>
        ///     The facebook app secret id (this is the ID given by facebook in the developer portal for your app)
        /// </summary>
        public static readonly string AppSecretID = "<<AppSecretID>>";
        /// <summary>
        ///     Isolated Storage Database Name
        /// </summary>
        public static readonly string DiaryDB = "DIARYDB";
        /// <summary>
        ///     Isolated Storage Database Very Happy Status List Name
        /// </summary>
        public static readonly string VeryHappyStatusListName = "VeryHappyStatus";
        /// <summary>
        ///     Isolated Storage Database Happy Status List Name
        /// </summary>
        public static readonly string HappyStatusListName = "HappyStatus";
        /// <summary>
        ///     Isolated Storage Database Ok Status List Name
        /// </summary>
        public static readonly string OkStatusListName = "OkStatus";
        /// <summary>
        ///     Isolated Storage Database Sad Status List Name
        /// </summary>
        public static readonly string SadStatusListName = "SadStatus";
        /// <summary>
        ///     Isolated Storage Database Very Sad Status List Name
        /// </summary>
        public static readonly string VerySadStatusListName = "VerySadStatus";
        /// <summary>
        ///     Isolated Storage Database No Cateogry Status List Name
        /// </summary>
        public static readonly string NoCateogryStatusListName = "NoCategory";
        /// <summary>
        ///     Access Token of the user
        /// </summary>
        public static string AccessToken { get; set; }
    }
}
