using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRRS.Controllers
{
    public class TestController : ApiController
    {
        [Route("api/test")]
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok("Hello World");
        }
    }
}
