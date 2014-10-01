using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FbDiary.Model;
using FbDiary.Shared;
using System.IO;
using Newtonsoft.Json;
using FbDiary.ViewModel;

namespace FbDiary.Views
{
    public partial class FacebookLoginPage : BasePage
    {
        WebClient basic_info_client, profile_pic_client, user_status_client;
        public FacebookLoginPage()
        {
            InitializeComponent();
            basic_info_client = new WebClient();
            profile_pic_client = new WebClient();
            user_status_client = new WebClient();
            this.Loaded += FacebookLoginPage_Loaded;
            BrowserInit();            
        }

        void FacebookLoginPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void BrowserInit()
        {
            Browser.Navigate(new Uri(AppUrl.BASE_URL_LOGIN));
            Browser.Navigated += Browser_Navigated;
            ShowProgress(AppMessages.Loading);
        }

        void Browser_Navigated(object sender, NavigationEventArgs e)
        {
            HideProgress();
            if (e.Uri.IsAbsoluteUri)
            {
                string code = e.Uri.Query.ToString();
                /// <summary>
                /// Split the code using "=" to separate code value
                /// </summary>
                string[] split = code.Split(new Char[] { '=' });

                Dispatcher.BeginInvoke(() =>
                {
                    try
                    {
                        string codeString = split.GetValue(0).ToString();
                        string codeValue = split.GetValue(1).ToString();

                        if (codeValue.Length > 0)
                        {
                            var url = AppUrl.BASE_ACCESS_TOKEN_URL + codeValue;

                            /// call access token
                            WebRequest request = WebRequest.Create(url); //FB access token  Link
                            request.BeginGetResponse(new AsyncCallback(this.ResponseCallback_AccessToken), request);
                        }
                    }
                    catch (Exception)
                    {
                    }
                });

            }
            else
                return;
        }

        private void ResponseCallback_AccessToken(IAsyncResult asynchronousResult)
        {
            try
            {
                var request = (HttpWebRequest)asynchronousResult.AsyncState;

                using (var resp = (HttpWebResponse)request.EndGetResponse(asynchronousResult))
                {
                    using (var streamResponse = resp.GetResponseStream())
                    {
                        using (var streamRead = new StreamReader(streamResponse))
                        {
                            string responseString = streamRead.ReadToEnd();
                            string[] splitAccessToken = responseString.Split(new Char[] { '=', '&' });

                            string accessTokenString = splitAccessToken.GetValue(0).ToString();
                            string accessTokenValue = splitAccessToken.GetValue(1).ToString();
                            string accessTokenValueTemp = splitAccessToken.GetValue(2).ToString();

                            if (accessTokenString == AppMessages.AccessTokenString)
                                AppConstants.AccessToken = accessTokenValue;

                            CheckAccessToken();
                        }
                    }
                }
            }
            catch (WebException)
            {
            }
        }
        private void CheckAccessToken()
        {
            Dispatcher.BeginInvoke(() =>
            {
                /// <summary>
                /// Check Access Token whether its null or not.
                /// </summary>
                if (string.IsNullOrEmpty(AppConstants.AccessToken))
                    MessageBox.Show("AccessToken null");
                else
                    LoadUserProfile();
            });            
        }
        void LoadUserProfile()
        {
            /// <summary>
            /// Gives User Basic Informations URL
            /// </summary>
            var UserBasicInfo = AppUrl.USER_BASIC_INFO_URL + AppConstants.AccessToken;

            /// <summary>
            /// Gives User Profile Picture URL
            /// </summary>
            var UserProfilePic = AppUrl.USER_PROFILE_PIC_URL + AppConstants.AccessToken;

            /// <summary>
            /// Gives User Status Informations URL
            /// </summary>
            var UserStatusInfo = AppUrl.USER_STATUS_INFO_URL + AppConstants.AccessToken;

            /// <summary>
            /// Getting all the URL into Proper URI's
            /// </summary>
            Uri UserBasicInfoUri = new Uri(UserBasicInfo);
            Uri UserProfilePicUri = new Uri(UserProfilePic);
            Uri UserStatusInfoUri = new Uri(UserStatusInfo);

            /// <summary>
            /// Download strings in all URL's
            /// </summary>
            basic_info_client.DownloadStringAsync(UserBasicInfoUri);
            profile_pic_client.DownloadStringAsync(UserProfilePicUri);
            user_status_client.DownloadStringAsync(UserStatusInfoUri);

            /// <summary>
            /// Proceed further when downloading string's completed
            /// </summary>
            basic_info_client.DownloadStringCompleted += client_DownloadStringCompleted;
            profile_pic_client.DownloadStringCompleted += profile_pic_client_DownloadStringCompleted;
            user_status_client.DownloadStringCompleted += user_status_client_DownloadStringCompleted;
        }

        void user_status_client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string result = e.Result.ToString();
            if (result != null)
                App.UserStatusInfo = JsonConvert.DeserializeObject<UserStatusInfo>(result);

            ReadStatusViewModel s = new ReadStatusViewModel();
            s.ReadStatus(App.UserStatusInfo);
        }

        void profile_pic_client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string result = e.Result.ToString();
            if (result != null)
                App.UserProfilePic = JsonConvert.DeserializeObject<UserProfilePicture>(result);
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string result = e.Result.ToString();
            if (result != null)
                App.UserBasicInfo = JsonConvert.DeserializeObject<UserBasicInfo>(result);
        }

        
    }
}