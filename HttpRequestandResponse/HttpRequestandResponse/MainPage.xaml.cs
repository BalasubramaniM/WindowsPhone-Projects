using Microsoft.Phone.Controls;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;
namespace HttpRequestandResponse
{
    public partial class MainPage : PhoneApplicationPage
    {
        Uri uri; // Way to get URL using Uri class
        ModelClass Value;

        public MainPage()
        {
            InitializeComponent();
            uri = new Uri("http://date.jsontest.com/"); // URL in which we going to read JSON data
            GetDatausingHttp();
        }

        private void GetDatausingHttp()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);  // Create a request
            request.Method = "POST"; // request method will be in "POST" or "GET" as per URL

            request.BeginGetRequestStream
                    (result =>
                    {
                        using (var requestStream = request.EndGetRequestStream(result))
                        {
                            using (StreamWriter writer = new StreamWriter(requestStream))
                            {
                                // write value if you need using writer.Write() function
                                writer.Flush();
                            }
                        }
                        request.BeginGetResponse(responseResult =>
                        {
                            var webResponse = request.EndGetResponse(responseResult); // get response in webResponse
                            using (var responseStream = webResponse.GetResponseStream())
                            {
                                using (var streamReader = new StreamReader(responseStream)) // Read data using StreamReader Class
                                {
                                    string resultData = streamReader.ReadToEnd();
                                    var jsonData = JsonConvert.DeserializeObject<ModelClass>(resultData); // Deserializing it to ModelClass

                                    Debug.WriteLine(jsonData.date); // jsonData is of type ModelClass and you can get values using that variable
                                    Debug.WriteLine(jsonData.time);
                                    Debug.WriteLine(jsonData.milliseconds_since_epoch); // Check output window for Date, Time & Milliseconds Value
                                }
                            }
                            
                        }, null);
                    }, null);
            
        }
    }

    class ModelClass
    {
        public string time { get; set; }
        public long milliseconds_since_epoch { get; set; }
        public string date { get; set; }
    }
}