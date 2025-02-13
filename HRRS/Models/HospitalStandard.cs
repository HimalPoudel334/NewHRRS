using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRRS.Models
{
    public class HospitalStandard
    {
        public int id { get; set; }
        public int healthFacilityId { get; set; }
        public int mapdandaId { get; set; }
        public bool isAvailable { get; set; }
        public bool has25 { get; set; }
        public bool has50 { get; set; }
        public bool has100 { get; set; }
        public bool has200 { get; set; }
        public string remarks { get; set; }
        public string filePath { get; set; }
        public string fiscalYear { get; set; }
        public DateTime createdAt { get; set; }
        public bool status { get; set; }
        public DateTime updatedAt { get; set; }
    }
}