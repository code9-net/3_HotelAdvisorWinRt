using System;
using System.Web.Http;
using HotelAdvisor.Auth;
using HotelAdvisor.Managers;
using HotelAdvisor.Models;

namespace HotelAdvisor.Controllers
{
    [BasicAuth]
    public class CommentsController : ApiController
    {
        [HttpPost]
        public Comment Add([FromBody]Comment item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.User = BasicAuthUser.GetCurrent();
            item.UserId = item.User.Id;
            CommentManager manager = new CommentManager();
            manager.Create(item);
            return item;
        }
    }
}
