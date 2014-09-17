using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ReadXMLintoObjects.Resources;
using System.Xml.Serialization;
using System.IO;

namespace ReadXMLintoObjects
{
    public partial class MainPage : PhoneApplicationPage
    {
        WebClient client;
        public MainPage()
        {
            InitializeComponent();
            client = new WebClient();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Uri uri = new Uri("http://www.w3schools.com/xml/simple.xml"); // Proper way of getting url

            client.DownloadStringAsync(uri); // Downloading string asynchronously
            client.DownloadStringCompleted+=client_DownloadStringCompleted; 
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string result = e.Result.ToString(); // getting xml string
             
            var instance = breakfast_menu.FromXmlString(result.ToString()); //check your values in instance and use it as per your needs
        }
    }

    [XmlRoot("breakfast_menu")]
    public class breakfast_menu
    {
        [XmlElement("food", Type = typeof(food))]
        public food[] foods { get; set; }

        public breakfast_menu()
        {
            foods = null;
        }

        public static breakfast_menu FromXmlString(string xmlString)
        {
            var reader = new StringReader(xmlString);
            var serializer = new XmlSerializer(typeof(breakfast_menu));
            var instance = (breakfast_menu)serializer.Deserialize(reader);

            return instance;
        }
    }


    public class food
    {
        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("price")]
        public string price { get; set; }

        [XmlElement("description")]
        public string description { get; set; }

        [XmlElement("calories")]
        public string calories { get; set; }
    }
}