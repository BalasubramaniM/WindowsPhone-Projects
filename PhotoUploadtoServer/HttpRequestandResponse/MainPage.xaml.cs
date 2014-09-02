using Microsoft.Phone.Controls;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HttpRequestandResponse
{
    public partial class MainPage : PhoneApplicationPage
    {
        Uri uri; // Way to get URL using Uri class

        public MainPage()
        {
            InitializeComponent();
            uri = new Uri("http://date.jsontest.com/"); // URL in which we going to upload Photo and retrieve response
            GetDatausingHttp();
        }

        private void GetDatausingHttp()
        {
            string str = BitmapToByte(btmapImage); //btmapImage is your Image which you gonna upload it to server

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
                                // Best example - Photo Upload concept. Write your photo as bytes in this function and get response.
                                writer.Write(str); // Writing(Uploading) your image to the server. 
                                writer.Flush();
                            }
                        }
                        request.BeginGetResponse(responseResult =>
                        {
                            var webResponse = request.EndGetResponse(responseResult); // get response from server in webResponse 
                            using (var responseStream = webResponse.GetResponseStream())
                            {
                                using (var streamReader = new StreamReader(responseStream)) // Read data using StreamReader Class
                                {
                                    string resultData = streamReader.ReadToEnd();
                                    var jsonData = JsonConvert.DeserializeObject<ModelClass>(resultData); // Deserializing it to ModelClass

                                    //Sample example shown below...

                                    Debug.WriteLine(jsonData.date); // jsonData is of type ModelClass and you can get values using that variable
                                    Debug.WriteLine(jsonData.time);
                                    Debug.WriteLine(jsonData.milliseconds_since_epoch); // Check output window for Date, Time & Milliseconds Value
                                }
                            }
                            
                        }, null);
                    }, null);
            
        }

        private string BitmapToByte(Image btmapImage)
        {
            Stream photoStream = ImageToStream(btmapImage);
            BitmapImage bimg = new BitmapImage();
            bimg.SetSource(photoStream);

            byte[] byteArray = null;
            using (MemoryStream ms = new MemoryStream())
            {
                WriteableBitmap wbitmp = new WriteableBitmap(bimg);
                wbitmp.SaveJpeg(ms, wbitmp.PixelWidth, wbitmp.PixelHeight, 0, 100);
                byteArray = ms.ToArray();
            }
            string str = Convert.ToBase64String(byteArray);
            return str;
        }

        private Stream ImageToStream(Image btmapImage)
        {
            WriteableBitmap wb = new WriteableBitmap(400, 400);
            wb.Render(btmapImage, new TranslateTransform { X = 400, Y = 400 });
            wb.Invalidate();
            Stream myStream = new MemoryStream();
            wb.SaveJpeg(myStream, 400, 400, 0, 70);
            return myStream;
        }

    }

    class ModelClass
    {
        public string time { get; set; }
        public long milliseconds_since_epoch { get; set; }
        public string date { get; set; }
    }
}