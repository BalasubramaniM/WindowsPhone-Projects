using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FbDiary.Resources;
using FbDiary.Shared;

namespace FbDiary.Views
{
    public partial class MainPage : BasePage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            login.Click += login_Click;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        void login_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage(AppPages.FACEBOOK_LOGIN_PAGE);
        }
    }
}