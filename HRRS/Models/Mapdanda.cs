
using System.Collections.Generic;

namespace HRRS.Models
{

    public class Mapdanda
    {
        public int id { get; set; }
        public string serialNumber { get; set; }
        public string name { get; set; }
        public string parimaad { get; set; } = null;
        public string group { get; set; } = null;
        public bool isAvailableDivided { get; set; }
        public bool is25Active { get; set; }
        public bool is50Active { get; set; }
        public bool is100Active { get; set; }
        public bool is200Active { get; set; }
        public bool status { get; set; } = true;
        public int anusuchiId { get; set; }

        public int? parichhedId { get; set; }

        public int? subParichhedId { get; set; }

        public int? subSubParichhedId { get; set; }

    }

    public class SubMapdanda
    {
        public int id { get; set; }
        public string serialNumber { get; set; }
        public string name { get; set; }
        public string parimaad { get; set; } = null;
        public int mapdandaId { get; set; }
        public bool status { get; set; }

    }
}


