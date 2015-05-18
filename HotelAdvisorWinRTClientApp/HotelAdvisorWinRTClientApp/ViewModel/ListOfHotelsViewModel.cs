using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HotelAdvisorWinRTClientApp.Common;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HotelAdvisorWinRTClientApp.ViewModel
{
    public class ListOfHotelsViewModel : ViewModelBase
    {
        private string title;
        private ObservableCollection<string> hotels;
        private ICommand dislikeHotelCommand;
        private ICommand likeHotelCommand;

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
        public ObservableCollection<string> Hotels
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
        /// <summary>
        /// Initializes a new instance of the <see cref="ListOfHotelsViewModel" /> class.
        /// </summary>
        public ListOfHotelsViewModel()
        {
            Title = "List Of Hotels";

            if (IsInDesignMode)
            {
                Hotels = new ObservableCollection<string>() { "Hotel1", "Hotel2", "Hotel3", "Hotel4", "Hotel5" };
            }
            else
            {
                Hotels = new ObservableCollection<string>();
            }

            likeHotelCommand = new RelayCommand(LikeHotel, IsHotelSelected);
            dislikeHotelCommand = new RelayCommand(DislikeHotel, IsHotelSelected);
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
