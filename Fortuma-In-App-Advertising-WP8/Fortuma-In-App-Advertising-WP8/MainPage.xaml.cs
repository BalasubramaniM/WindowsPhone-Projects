using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Fortuma_In_App_Advertising_WP8.Resources;
/// <summary>
/// Fortumo namespaces.
/// </summary> 
using FortumoWindowsPhone;
using Fortumo;

/// <summary>
/// Download library packages for Fortumo.
/// Source : http://fortumo.com/services/ec02f7546c11329c058b957499e7b914/setup
/// </summary> 

/// <summary>
/// Create your service i.e. Register your service to get ServiceID and Secret.
/// Source : http://fortumo.com/services
/// </summary> 
 
/// <summary>
/// Check "ID_CAP_IDENTITY_USER" in Capabilities Section in WMApManifest.xml.
/// </summary>


namespace Fortuma_In_App_Advertising_WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            InAppAdButton.Click += InAppAdButton_Click;
        }
        /// <summary>
        /// Ad button click function.
        /// </summary>
        void InAppAdButton_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Create the Fortumo object, use your Service ID and sercet.
            /// </summary>            
            Payment pay = new Payment("<<SERVICE-ID>>", "<<SECRET-ID>>");

            /// <summary>
            /// Subscribe to the Completed event (see PaymentCompleted function below).
            /// </summary>
            pay.Completed += PaymentCompleted;

            /// <summary>
            /// Add a “test” parameter to enable testing the payment flow without making an actual payment.
            /// Make sure you remove this before going live!
            /// </summary>
            pay.AddParameter("test", "ok");

            /// <summary>
            /// You can use the "cuid" value to tie the payment with specific user on your serverside
            /// </summary>
            pay.AddParameter("cuid", "game-user-id");

            /// <summary>
            /// Show the payment window. You should not call any UI specific code
            /// After this until the “Completed” event is triggered.
            /// </summary>
            pay.Show();
        }

        /// <summary>
        /// Invokes when Payment Windows Completed.
        /// </summary>
        private void PaymentCompleted(object sender, PaymentEventArgs e)
        {
            /// <summary>
            /// When going live, also make sure that it’s not a test payment!
            /// </summary>
            if (e.status == PaymentStatus.Billed)
            {
                //Payment OK
                int credits = 0;
                if (e.amount != null)
                {
                    Int32.TryParse(e.amount, out credits);
                }
                /// <summary>
                /// Add credits to users account. It is also recommended to keep track of users' credits amount on server side.
                /// </summary>                
                // usercoins += credits;
            }
            else if (e.status == Fortumo.PaymentStatus.Failed)
            {
                /// <summary>
                /// Payment failed.
                /// </summary> 
            }
            else if (e.status == Fortumo.PaymentStatus.Pending)
            {
                /// <summary>
                /// Payment is pending. The SDK will automatically check the status of pendng payments. 
                /// See the pending payments section for more information.
                /// </summary>                
            }
        }
    }
}