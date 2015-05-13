using System.Collections.Generic;

namespace HotelAdvisor.Windows.ApiModels
{
    public class HotelDetailsViewModel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Image { get; set; }

        public decimal AverageRating { get; set; }

        public int TotalReviews { get; set; }
        public List<CommentViewModel> Comments { get; set; }

        public string Address { get; set; }

        public int HouseNumber { get; set; }

        public string City { get; set; }

        public string Description { get; set; }
    }
}
