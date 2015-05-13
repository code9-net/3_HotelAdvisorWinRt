using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using Newtonsoft.Json;
using HttpStatusCode = Windows.Web.Http.HttpStatusCode;
using UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding;

namespace HotelAdvisor.Windows.ApiClient
{
    public abstract class ApiClientBase
    {
        private readonly string _username;
        private readonly string _password;
        private readonly HttpClient _client = new HttpClient();

        protected ApiClientBase(string username, string password)
        {
            if (username == null) throw new ArgumentNullException("username");
            if (password == null) throw new ArgumentNullException("password");

            _username = username;
            _password = password;
        }

        public async Task<T> GetData<T>(string url, object data)
            where T: class 
        {
            if (url == null) throw new ArgumentNullException("url");
           
            var response = await InvokeHttpClient(url, HttpMethod.Get, data);
            
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                if (typeof (T) == typeof (string))
                {
                    return responseData as T;
                }
                return JsonConvert.DeserializeObject<T>(responseData);
            }
            throw new WebException();
        }
        
        public async Task<T> PostData<T>(string url, object data)
        {
            if (url == null) throw new ArgumentNullException("url");

            var response = await InvokeHttpClient(url, HttpMethod.Post, data);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            throw new WebException();
        }

        public async Task<T> PutData<T>(string url, object data)
        {
            if (url == null) throw new ArgumentNullException("url");

            var response = await InvokeHttpClient(url, HttpMethod.Put, data);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            throw new WebException();
        }

        public async Task<bool> GetToBool(string url, object data)
        {
            return await InvokeHttpClientToBool(url, HttpMethod.Get, data);
        }

        public async Task<bool> PostToBool(string url, object data)
        {
            return await InvokeHttpClientToBool(url, HttpMethod.Post, data);
        }

        public async Task<bool> PutToBool(string url, object data)
        {
            return await InvokeHttpClientToBool(url, HttpMethod.Put, data);
        }

        private async Task<bool> InvokeHttpClientToBool(string url, HttpMethod method, object data)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, new Uri(url));
            if (data != null)
            {
                if (method == HttpMethod.Get)
                {
                    url = FormatUrl(url, data);
                    request = new HttpRequestMessage(method, new Uri(url));
                }
                else
                {
                    request.Content = new HttpStringContent(JsonConvert.SerializeObject(data), UnicodeEncoding.Utf8, "application/json");
                }
            }
            request.Headers.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", _username, _password)));
            request.Headers.Authorization = new HttpCredentialsHeaderValue("Basic", token);
            request.Headers.Add("X-Requested-With", "WinClient");

            var response = await _client.SendRequestAsync(request);
            
            return response.StatusCode == HttpStatusCode.Ok;
        }

        private async Task<HttpResponseMessage> InvokeHttpClient(string url, HttpMethod method, object data)
        {
            if (method != HttpMethod.Get)
            {
                url = AddUniqueValidableToUrl(url);
            }
            HttpRequestMessage request = new HttpRequestMessage(method, new Uri(url));
            if (data != null)
            {
                if (method == HttpMethod.Get)
                {
                    url = FormatUrl(url, data);
                    url = AddUniqueValidableToUrl(url);
                    request = new HttpRequestMessage(method, new Uri(url));
                }
                else
                {
                    request.Content = new HttpStringContent(JsonConvert.SerializeObject(data));
                }
            }
            else
            {
                url = AddUniqueValidableToUrl(url);
                request = new HttpRequestMessage(method, new Uri(url));
            }
            request.Headers.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", _username, _password)));
            request.Headers.Authorization = new HttpCredentialsHeaderValue("Basic", token);
            request.Headers.Add("X-Requested-With", "WinClient");
            return await _client.SendRequestAsync(request);
        }
        
        private string FormatUrl(string url, object data)
        {
            if (url == null) throw new ArgumentNullException("url");

            Action<string, object> appendNameAndValue = (name, value) =>
            {
                if (name == null || value == null)
                {
                    return;
                }
                // ReSharper disable AccessToModifiedClosure
                if (!url.EndsWith("?"))
                {
                    url += "&";
                }
                url += (name + "=" + value);
                // ReSharper restore AccessToModifiedClosure
            };

            if (!url.Contains("?"))
            {
                url += "?";
            }
            var type = data.GetType();
            var props = type.GetRuntimeProperties().Where(x => x.CanRead);
            foreach (var prop in props)
            {
                appendNameAndValue(prop.Name, prop.GetValue(data));
            }

            //var fields = type.GetRuntimeFields().Where(x => x.IsPublic);
            //foreach (var field in fields)
            //{
            //    appendNameAndValue(field.Name, field.GetValue(type));
            //}
            return url;
        }

        private string AddUniqueValidableToUrl(string url)
        {
            if (!url.Contains("?"))
            {
                url += "?";
            }
            else
            {
                url += "&";
            }
            url = url + "_t_=" + Guid.NewGuid();
            return url;
        }
    }
}
