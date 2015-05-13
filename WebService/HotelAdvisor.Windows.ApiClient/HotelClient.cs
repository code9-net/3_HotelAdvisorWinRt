using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelAdvisor.Windows.ApiModels;

namespace HotelAdvisor.Windows.ApiClient
{
    public class HotelClient : ApiClientBase
    {
        private readonly string _baseUrl = Config.ApiBaseUrl + "Hotels/";

        public HotelClient(string username, string password) : base(username, password)
        {
        }

        public async Task<IEnumerable<HotelDetailsViewModel>> GetAll()
        {
            string url = _baseUrl + "GetAll";
            return await GetData<IEnumerable<HotelDetailsViewModel>>(url, null);
        }

        public async Task<HotelDetailsViewModel> Get(int id)
        {
            string url = _baseUrl + "Get";
            return await GetData<HotelDetailsViewModel>(url, new {id});
        }

        public async Task<Hotel> Add(Hotel model)
        {
            if (model == null) throw new ArgumentNullException("model");
            string url = _baseUrl + "Add";
            return await PostData<Hotel>(url, model);
        }

        [Obsolete("Not implemented on the server")]
        public async Task<bool> Remove(int id)
        {
            string url = _baseUrl + "Remove";
            return await PostToBool(url, new {id});
        }

        public async Task<bool> Update(Hotel model)
        {
            string url = _baseUrl + "Update";
            return await PostToBool(url, model);
        }
    }
}
