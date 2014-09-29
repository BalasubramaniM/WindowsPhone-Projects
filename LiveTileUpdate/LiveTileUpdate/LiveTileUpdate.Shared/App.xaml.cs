using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace LiveTileUpdate
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
#if WINDOWS_PHONE_APP
        private TransitionCollection transitions;
#endif

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
            LiveTiles(); // Call the Method
        }

        /*
         * Source : http://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh868253.aspx
         */
        /// <summary>
        /// Live Tiles Implementation - Universal Apps Windows
        /// </summary>
        public void LiveTiles()
        {
            /// <summary>
            /// GetTemplateContent gets type of template based upon Windows 8 or Windows Phone deployment
            /// GetTemplateContent method retrieves an XmlDocument.
            /// </summary>
            /// <param name = "TileWide310x150ImageAndText01"> Returns type of template which is wide and has image and text in it.</param>
            XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150ImageAndText01);

            /// <summary>
            /// XmlNodeList - Since LiveTile Template class will be in XML format
            /// </summary>
            /// <param name = "GetElementsByTagName("text")">  Retrieves all elements in the template with a tag name of "text"</param>

            /// <param name = "Hello World! My very own tile notification">  Writes this text into the Xml document</param> 
            XmlNodeList tileTextAttributes = tileXml.GetElementsByTagName("text");
            tileTextAttributes[0].InnerText = "Hello World! My very own tile notification";

            /// <summary>
            /// Same as Text process, see above.
            /// </summary>
            XmlNodeList tileImageAttributes = tileXml.GetElementsByTagName("image");
            ((XmlElement)tileImageAttributes[0]).SetAttribute("src", "ms-appx:///Assets/wide-picture.png");

            /// <param name = "alt"> Writes text "red graphic" as an alternative text for Image </param> 
            ((XmlElement)tileImageAttributes[0]).SetAttribute("alt", "red graphic");

            /// <param name = "TileSquare150x150Text04"> Creates separate tile for Windows Phone since its for Universal Apps </param> 
            XmlDocument squareTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text04);

            /// <summary>
            /// Same as Text process, see above.
            /// </summary>
            XmlNodeList squareTileTextAttributes = squareTileXml.GetElementsByTagName("text");
            squareTileTextAttributes[0].AppendChild(squareTileXml.CreateTextNode("Hello World! My very own tile notification"));

            /// <summary>
            /// Get content of the Square Tile and binding its text to Wide Tile
            /// </summary>
            IXmlNode node = tileXml.ImportNode(squareTileXml.GetElementsByTagName("binding").Item(0), true);
            tileXml.GetElementsByTagName("visual").Item(0).AppendChild(node);

            /// <summary>
            /// Creates new Tile Notification with "tileXml"
            /// </summary>
            TileNotification tileNotification = new TileNotification(tileXml);

            /// <summary>
            /// Optional - Set ExpirationTime if you want to update tile only for certain interval
            /// </summary>
            tileNotification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);

            /// <summary>
            /// Update the Tile finally
            /// </summary>
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);

            /// <summary>
            /// Use only if you wish to clear the contents in the tile
            /// This line is commented currently, use to clear the tile contents
            /// </summary>
            //Windows.UI.Notifications.TileUpdateManager.CreateTileUpdaterForApplication().Clear();

            /// <summary>
            /// GetTemplateContent retrieves this XML document and insert data in further process
            /// </summary>
            /// <param name = "TileWide310x150ImageAndText01"> XML document of Tile "TileWide310x150ImageAndText01" </param>
            /*
               <tile>
                <visual version="2">
                    <binding template="TileWide310x150ImageAndText01" fallback="TileWideImageAndText01">
                        <image id="1" src=""/>
                        <text id="1"></text>
                    </binding>
                </visual>
               </tile>
            */
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 1;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
#if WINDOWS_PHONE_APP
                // Removes the turnstile navigation for startup.
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;
#endif

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

#if WINDOWS_PHONE_APP
        /// <summary>
        /// Restores the content transitions after the app has launched.
        /// </summary>
        /// <param name="sender">The object where the handler is attached.</param>
        /// <param name="e">Details about the navigation event.</param>
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }
#endif

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}