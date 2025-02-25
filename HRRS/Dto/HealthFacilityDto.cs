using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRRS.Models;

namespace HRRS.Dto
{
    public class HealthFacilityDto
    {
        public string username { get; set; }
        public string password { get; set; }
        public HealthFacility healthFacility { get; set; }
    }
}