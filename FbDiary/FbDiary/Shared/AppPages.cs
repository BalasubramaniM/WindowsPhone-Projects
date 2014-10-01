using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbDiary.Shared
{
    /// <summary>
    /// Contains App Pages
    /// </summary>
    /// <param name="sealed">
    /// No class should be derieved from AppPages
    /// </param>
    public sealed class AppPages
    {
        /// <summary>
        /// Basic "Views" Folder extension
        /// </summary>
        private const string Views                          = "/Views/";
        /// <summary>
        /// Basic "Page" string extension
        /// </summary>
        private const string XamlExtension                  = "Page.xaml";

        public static readonly string MAIN_PAGE             = Views + "Main" + XamlExtension;
        public static readonly string FACEBOOK_LOGIN_PAGE   = Views + "FacebookLogin" + XamlExtension;
    }
}
