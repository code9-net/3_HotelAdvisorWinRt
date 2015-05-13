using System;

namespace HotelAdvisor.Windows.ApiModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public decimal Rating { get; set; }

        public DateTime DateAdded { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }
    }
}