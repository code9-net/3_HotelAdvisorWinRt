using GalaSoft.MvvmLight.Ioc;
using HotelAdvisorWinRTClientApp.Services;
using Microsoft.Practices.ServiceLocation;

namespace HotelAdvisorWinRTClientApp.ViewModel
{
    /// <summary>
    /// View model locator.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Gets the list of hotels view.
        /// </summary>
        /// <value>
        /// The list of hotels view.
        /// </value>
        public ListOfHotelsViewModel ListOfHotelsView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListOfHotelsViewModel>();
            }
        }

        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        /// <summary>
        /// Initializes the <see cref="ViewModelLocator"/> class.
        /// </summary>
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ListOfHotelsViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>(() =>
                {
                    return new LoginViewModel(new NavigationService());
                });
        }
    }
}
