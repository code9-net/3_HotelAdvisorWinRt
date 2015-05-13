using System.Collections.Generic;
using System.Web.Http;

namespace HotelAdvisor.Controllers
{
    public class CommentsController : ApiController
    {
        public Models.Comment Add(Models.Comment item)
        {
            if (item == null)
            {
                throw new System.ArgumentNullException("item");
            }
            Managers.CommentManager manager = new Managers.CommentManager();
            manager.Create(item);
            return item;
        }
    }
}
