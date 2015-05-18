using HotelAdvisorWinRTClientApp.Common;
using HotelAdvisorWinRTClientApp.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HotelAdvisorWinRTClientApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ToastTemplate01_Click(object sender, RoutedEventArgs e)
        {
            // 
            var toastText = @"Toast Toast Text 01 template. The text will be wrapped three lines.";
            NotificationHelper.SendSingleTextToastNotification(toastText);
        }

        private void ToastTemplate02_Click(object sender, RoutedEventArgs e)
        {
            var toastTitle = "This is bold text";
            var toastText = @"Toast Toast Text 02 template. The text will be wrapped two lines.";
            NotificationHelper.SentTextWithTitle(toastTitle, toastText);
        }

        private void ToastTemplate03_Click(object sender, RoutedEventArgs e)
        {
            var imageUri = @"ms-appx:///assets/ToastImages/Logo Levi9 93x75.jpg";
            var toastTitle = "This is bold text";
            var toastText = @"Toast Toast Text 02 template. The text will be wrapped two lines.";
            NotificationHelper.SentImageAndTextWithTitle(toastTitle, toastText, imageUri);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListOfHotelsView));
        }
    }
}
