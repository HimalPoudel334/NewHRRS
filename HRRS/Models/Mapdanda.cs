
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
        public bool isCol5Active { get; set; }
        public bool isCol6Active { get; set; }
        public bool isCol7Active { get; set; }
        public bool isCol8Active { get; set; }
        public bool isCol9Active { get; set; }
        public bool status { get; set; } = true;
        public int anusuchiId { get; set; }
        public string Value25 { get; set; }
        public string Value50 { get; set; }
        public string Value100 { get; set; }
        public string Value200 { get; set; }
        public string Col5 { get; set; }
        public string Col6 { get; set; }
        public string Col7 { get; set; }
        public string Col8 { get; set; }
        public string Col9 { get; set; }
        public int? parichhedId { get; set; }

        public int? subParichhedId { get; set; }

        public int? subSubParichhedId { get; set; }
        public FormType formType { get; set; }

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

    public enum FormType
    {
        A1, //A1 to A3
        A4, //A4 all
        A5P3, //A5p1 to p3 
        A5P4,
        A5P8,
        A5P8_10,
        A5P10,

    }
}


