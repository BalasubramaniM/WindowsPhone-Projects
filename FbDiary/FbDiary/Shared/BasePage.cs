using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace FbDiary.Shared
{
    /// <summary>
    /// BasePage inherits default PhoneApplicationPage
    /// All other pages inherits from BasePage
    /// </summary>
    public class BasePage : PhoneApplicationPage, INotifyPropertyChanged
    {
        ProgressIndicator progress;
        public BasePage()
        {
            progress = new ProgressIndicator()
            {
                Text = AppMessages.Loading,
                IsIndeterminate = false,
                IsVisible = false
            };
            SystemTray.SetProgressIndicator(this, progress);
        }

        #region ProgressBar
        protected void ShowProgress()
        {
            progress.IsIndeterminate = true;
            progress.IsVisible = true;
        }

        protected void ShowProgress(string text)
        {
            progress.Text = text;
            progress.IsIndeterminate = true;
            progress.IsVisible = true;
        }

        protected void HideProgress()
        {
            progress.IsIndeterminate = false;
            progress.IsVisible = false;
        }
        #endregion

        #region Navigate To Views
        protected void NavigateToPage(string _uri)
        {
            this.NavigationService.Navigate(new Uri(_uri, UriKind.RelativeOrAbsolute));
        }
        protected void NavigateToPage(string _uri, string _queryString)
        {
            if (_queryString.Trim().Length > 0)
                _uri += "?" + _queryString;

            NavigationService.Navigate(new Uri(_uri, UriKind.RelativeOrAbsolute));
        }
        protected string GetQueryString(string queryString)
        {
            if (NavigationContext.QueryString.ContainsKey(queryString))
            {
                return NavigationContext.QueryString[queryString];
            }
            return null;
        }
        #endregion

        #region Notify Property Change

        /// <summary>
        ///     Event raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
