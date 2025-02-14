public class Anusuchi
{
    public int id { get; set; }
    public string serialNo { get; set; }
    public string name { get; set; }
    public string dafaNo { get; set; }
}

namespace HRRS.Models.Parichhed 
{
    public class Parichhed
    {
        public int id { get; set; }
        public string name { get; set; }
        public string serialNo { get; set; }
        public int anusuchiId { get; set; }
    }

    public class SubParichhed
    {
        public int id { get; set; }
        public string name { get; set; }
        public string serialNo { get; set; }
        public int parichhedId { get; set; }
    }

    public class SubSubParichhed
    {
        public int id { get; set; }
        public string name { get; set; }
        public string serialNo { get; set; }
        public int subParichhedId { get; set; }

    }
}
