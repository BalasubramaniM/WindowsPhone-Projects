using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ReadJSON.Resources;
using Newtonsoft.Json;

namespace ReadJSON
{
    public partial class MainPage : PhoneApplicationPage
    {
        WebClient client; // Used to retrieve data from URL
        Uri uri; // Proper way to assign URL using Uri Class
        ProgressIndicator progress; // Used to get progress level

        public MainPage()
        {
            InitializeComponent();
            client = new WebClient();
            uri = new Uri("http://date.jsontest.com/"); // Sample JSON link

            progress = new ProgressIndicator()
            {
                IsIndeterminate = true,
                IsVisible = true,
                Text = "loading ..."
            };

            ReadJSONData();
        }

        private void ReadJSONData()
        {
            client.DownloadStringAsync(uri); // Asynchronously download string from Uri
            client.DownloadStringCompleted += client_DownloadStringCompleted; // Invokes when string download completes
            SystemTray.SetProgressIndicator(this, progress);
        }

        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            progress.IsVisible = false;
            string data = e.Result; // Get result from link
            var obj = JsonConvert.DeserializeObject<ModelClass>(data);  // Deserialize objects in ModelClass
            ContentPanel.DataContext = obj; // Assigning objects to ContentPanel using DataContext
        }
    }

    class ModelClass
    {
        public string time { get; set; }
        public long milliseconds_since_epoch { get; set; }
        public string date { get; set; }
    }
}