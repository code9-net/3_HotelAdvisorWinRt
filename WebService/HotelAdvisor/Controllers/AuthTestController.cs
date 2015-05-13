using System;
using System.Web.Http;
using HotelAdvisor.Auth;
using HotelAdvisor.Models;
using Newtonsoft.Json;

namespace HotelAdvisor.Controllers
{
    public class AuthTestController : ApiController
    {
        [HttpPost]
        public bool TestAuthNoAuth()
        {
            //var param =  Request.Headers.Authorization.Parameter;
            //var scheme = Request.Headers.Authorization.Scheme;

            //var dbContext = new HotelAdvisorContext();
            //dbContext.TestLogs.Add(new TestLog
            //{
            //    LogText = param ?? "-null-",
            //    LogTime = DateTime.Now,
            //    TraceKey = "auth param"
            //});
            //dbContext.TestLogs.Add(new TestLog
            //{
            //    LogText = scheme ?? "-null-",
            //    LogTime = DateTime.Now,
            //    TraceKey = "auth scheme"
            //});
            //dbContext.SaveChanges();

            var model = BasicAuthHelper.GetCurrent();
            //AddTestLog(model);
            return true;
        }

        [BasicAuth, HttpPost]
        public bool TestAuthWithAuth()
        {
            return true;
        }

        //private void AddTestLog(BasicAuthModel model)
        //{
        //    string log = model == null ? "-null-" : JsonConvert.SerializeObject(model);
        //    var dbContext = new HotelAdvisorContext();
        //    dbContext.TestLogs.Add(new TestLog
        //    {
        //        LogText = log,
        //        LogTime = DateTime.Now,
        //        TraceKey = "auth log"
        //    });
        //    dbContext.SaveChanges();
        //}
    }
}