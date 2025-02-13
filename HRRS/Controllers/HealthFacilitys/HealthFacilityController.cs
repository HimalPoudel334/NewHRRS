using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRRS.Helpers;

namespace HRRS.Controllers.HealthFacilitys
{
    [Route("api/[Controller]")]
    public class HealthFacilityController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok();
        }
    }
}
