using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HotelAdvisorWinRTClientApp.Common;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HotelAdvisor.Windows.ApiClient;
using HotelAdvisor.Windows.ApiModels;
using HotelAdvisorWinRTClientApp.Services;

namespace HotelAdvisorWinRTClientApp.ViewModel
{
    public class ListOfHotelsViewModel : ViewModelBase
    {

        private string title;
        private ObservableCollection<HotelDetailsViewModel> hotels;
        private ICommand dislikeHotelCommand;
        private ICommand likeHotelCommand;
        private ICommand changeTitle;

        private HotelClient hotelClient;
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get { return title; }
            set { Set(() => Title, ref title, value); }
        }

        /// <summary>
        /// The hotels
        /// </summary>
        public ObservableCollection<HotelDetailsViewModel> Hotels
        {
            get { return hotels; }
            set { Set(() => Hotels, ref hotels, value); }
        }

        /// <summary>
        /// Gets or sets the dislike hotel command.
        /// </summary>
        /// <value>
        /// The dislike hotel command.
        /// </value>
        public ICommand DislikeHotelCommand
        {
            get
            {
                return dislikeHotelCommand;
            }

            set
            {
                dislikeHotelCommand = value;
            }
        }

        /// <summary>
        /// Gets or sets the like hotel command.
        /// </summary>
        /// <value>
        /// The like hotel command.
        /// </value>
        public ICommand LikeHotelCommand
        {
            get
            {
                return likeHotelCommand;
            }

            set
            {
                likeHotelCommand = value;
            }
        }

        public ICommand ChangeTitle
        {
            get 
            {
                return changeTitle;
            }

            set 
            {
                changeTitle = value;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ListOfHotelsViewModel" /> class.
        /// </summary>
        public ListOfHotelsViewModel()
        {
            Title = "List Of Hotels";
            hotelClient = WebClients.HotelClient;

            if (IsInDesignMode)
            {
                Hotels = new ObservableCollection<HotelDetailsViewModel>() 
                { 
                    new HotelDetailsViewModel(){City="Novi Sad", HouseNumber=1,HotelId=1,HotelName="Hotel1", Image=@"ms-appx:///assets/StoreLogo.scale-100.png",Description="Ovaj hotel je hotel koji je hotel da bi bio hotel test test test"},
                    new HotelDetailsViewModel(){City="Ruma", HouseNumber=12,HotelId=2,HotelName="Hotel2",Image=@"ms-appx:///assets/StoreLogo.scale-100.png",Description="Ovaj hotel je hotel koji je hotel da bi bio hotel test test test"},
                    new HotelDetailsViewModel(){City="Zrenjanin", HouseNumber=23,HotelId=3,HotelName="Hotel3",Image=@"ms-appx:///assets/StoreLogo.scale-100.png",Description="Ovaj hotel je hotel koji je hotel da bi bio hotel test test test"},
                    new HotelDetailsViewModel(){City="Subotica", HouseNumber=44,HotelId=4,HotelName="Hotel4",Image=@"ms-appx:///assets/StoreLogo.scale-100.png",Description="Ovaj hotel je hotel koji je hotel da bi bio hotel test test test"}
                };
            }
            else
            {
                Hotels = new ObservableCollection<HotelDetailsViewModel>();
            }

            LoadHotels();

            likeHotelCommand = new RelayCommand(LikeHotel);
            dislikeHotelCommand = new RelayCommand(DislikeHotel, IsHotelSelected);
            changeTitle = new RelayCommand(ChangeTitleCommand);
        }

        private void ChangeTitleCommand()
        {
            Title = Title + "_1";
        }

        /// <summary>
        /// Loads the hotels.
        /// </summary>
        private async void LoadHotels()
        {
            var listOfHotels = await hotelClient.GetAll();
            //foreach (var h in listOfHotels)
            //{
            //    h.Image = @"http://code9-2015-api.azurewebsites.net" + h.Image;
            //}
            Hotels = new ObservableCollection<HotelDetailsViewModel>(listOfHotels);
        }

        /// <summary>
        /// Dislikes the hotel.
        /// </summary>
        private void DislikeHotel()
        {
            NotificationHelper.SendSingleTextToastNotification("Dislike Hotel!");
        }

        /// <summary>
        /// Likes the hotel.
        /// </summary>
        private void LikeHotel()
        {
            NotificationHelper.SendSingleTextToastNotification("Like Hotel!");
        }

        /// <summary>
        /// Determines whether [is hotel selected].
        /// </summary>
        /// <returns></returns>
        private bool IsHotelSelected()
        {
            return true;
        }

    }
}
