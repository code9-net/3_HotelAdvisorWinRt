using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace HotelAdvisorWinRTClientApp.Common
{
    public class NotificationHelper
    {
        public const string ToastTextTagName = "text";
        public const string ToastImageTagName = "image";

        /// <summary>
        /// Sends the toast notification using template <see cref="ToastTemplateType.ToastText01"/>.
        /// The template A single string wrapped across three lines of text.
        /// </summary>
        /// <param name="text">The text which will be shown.</param>
        public static void SendSingleTextToastNotification(string text)
        {
            var toastTemplate = ToastTemplateType.ToastText01;
            var toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTextElements = toastXml.GetElementsByTagName(ToastTextTagName);
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(text));

            FireToast(toastXml);
        }


        /// <summary>
        /// Sents the text with a title using template <see cref="ToastTemplateType.ToastText02"/>. 
        /// First line will be bold (title) the secone line will be wrapped two lines.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        public static void SentTextWithTitle(string title, string text)
        {
            var toastTemplate = ToastTemplateType.ToastText02;
            var toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTextElements = toastXml.GetElementsByTagName(ToastTextTagName);
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(title));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(text));
            FireToast(toastXml);
        }

        /// <summary>
        /// Sents the image and text with title using template <see cref="ToastTemplateType.ToastText02"/>.
        /// Toast with one image one bold text and one body text.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <param name="imageUrl">The image URL.</param>
        public static void SentImageAndTextWithTitle(string title, string text, string imageUrl)
        {
            var toastTemplate = ToastTemplateType.ToastImageAndText02;
            var toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            var toastTextElements = toastXml.GetElementsByTagName(ToastTextTagName);
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(title));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(text));

            XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName(ToastImageTagName);
            ((XmlElement)toastImageAttributes[0]).SetAttribute("src", imageUrl);
            ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "Toeast image description");
            FireToast(toastXml);
        }

        /// <summary>
        /// Fires the toast.
        /// </summary>
        /// <param name="toastXml">The toast XML.</param>
        private static void FireToast(XmlDocument toastXml)
        {
            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

    }
}
