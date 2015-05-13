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

        [HttpGet]
        public ICollection<Models.HotelDetailsViewModel> GetAll()
        {
            return manager.GetHotels();
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri]int id)
        {
            HotelDetailsViewModel item = manager.GetHotelDetails(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public Models.Hotel Add([FromBody]Models.Hotel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            manager.Create(item);
            return item;
        }

        [HttpPost]
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public bool Update([FromBody]Models.Hotel item)
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
