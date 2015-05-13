using System.Threading.Tasks;
using HotelAdvisor.Windows.ApiModels;

namespace HotelAdvisor.Windows.ApiClient
{
    public class CommentsClient : ApiClientBase
    {

        public CommentsClient(string username, string password) : base(username, password)
        { }
        
        public async Task<Comment> Add(Comment model)
        {
            string url = Config.ApiBaseUrl = "Add";
            return await PostData<Comment>(url, model);
        }
    }
}
