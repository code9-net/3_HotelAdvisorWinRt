using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using HotelAdvisor.Models;
using Newtonsoft.Json;

namespace HotelAdvisor.Auth
{
    public class BasicAuthAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var user = BasicAuthUser.GetCurrent();
            //using (var db = new HotelAdvisorContext())
            //{
            //    string log = user != null ? JsonConvert.SerializeObject(user) : "-null-";
            //    db.TestLogs.Add(new TestLog
            //    {
            //        LogTime = DateTime.Now,
            //        TraceKey = "GetApplicationUser",
            //        LogText = log
            //    });
            //    db.SaveChanges();
            //}
            return user != null;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("X-Auth", "401");
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

    }
}