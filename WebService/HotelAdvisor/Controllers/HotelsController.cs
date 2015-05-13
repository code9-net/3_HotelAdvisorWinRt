using System;
using System.Collections.Generic;
using System.Web.Http;

namespace HotelAdvisor.Controllers
{
    public class HotelsController : ApiController
    {
        Managers.HotelManager manager = new Managers.HotelManager();

        public ICollection<Models.HotelDetailsViewModel> GetAll()
        {
            return manager.GetHotels();
        }

        public IHttpActionResult Get(int id)
        {
            var item = manager.GetHotelDetails(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        public Models.Hotel Add(Models.Hotel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            manager.Create(item);
            return item;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Models.Hotel item)
        {
            if (item == null)
            {
                return false;
            }
            manager.Edit(item);
            return true;
        }
    }
}
