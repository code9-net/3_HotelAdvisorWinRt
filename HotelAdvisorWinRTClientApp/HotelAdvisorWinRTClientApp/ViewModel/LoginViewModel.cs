using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelAdvisor.Windows.ApiClient;
using Windows.UI.Popups;
using HotelAdvisorWinRTClientApp.Services;
using HotelAdvisorWinRTClientApp.View;

namespace HotelAdvisorWinRTClientApp.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public LoginViewModel(INavigationService navService)
        {
            _navigationService = navService;
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { 
                _username = value;
                RaisePropertyChanged(() => Username);
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { 
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                    {
                        var msg = "Please enter your username and password.";
                        MessageDialog dialog = new MessageDialog(msg);
                        await dialog.ShowAsync();
                        return;
                    }
                    var client = new AuthClient(Username, Password);
                    if (await client.Login())
                    {
                        Services.WebClients.SetUsernameAndPassword(Username, Password);
                        _navigationService.Navigate(typeof(ListOfHotelsView));
                    }
                    else
                    {
                        var msg = "Wrong combination of username/password.";
                        MessageDialog dialog = new MessageDialog(msg);
                        await dialog.ShowAsync();
                    }
                });
            }
        }

    }
}
