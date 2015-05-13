using System;
using System.Collections.Generic;
using System.Web.Http;
using HotelAdvisor.Auth;
using HotelAdvisor.Models;

namespace HotelAdvisor.Controllers
{
    [BasicAuth]
    public class HotelsController : ApiController
    {
        Managers.HotelManager manager = new Managers.HotelManager();

        public ICollection<Models.HotelDetailsViewModel> GetAll()
        {
            return manager.GetHotels();
        }

        public IHttpActionResult Get(int id)
        {
            HotelDetailsViewModel item = manager.GetHotelDetails(id);
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
