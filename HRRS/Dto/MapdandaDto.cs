using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRRS.Dto
{
    public class MapdandaDto
    {
        public int id { get; set; }
        public string serialNumber { get; set; }
        public string name { get; set; }
        public string parimaad { get; set; } = string.Empty;
        public string group { get; set; } = string.Empty;
        public bool isAvailableDivided { get; set; }
        public bool is25Active { get; set; }
        public bool is50Active { get; set; }
        public bool is100Active { get; set; }
        public bool is200Active { get; set; }
        public bool status { get; set; }
        public string parichhed { get; set; } = string.Empty;
        public string subParichhed { get; set; } = string.Empty;
        public string subSubParichhed { get; set; } = string.Empty;
    }

    public class GroupedSubSubParichhedAndMapdanda
    {
        public bool? hasBedCount { get; set; }
        public string subSubParixed { get; set; }
        public ICollection<GroupedMapdandaByGroupName> list { get; set; } = new List<GroupedMapdandaByGroupName>();
    }

    public class GroupedMapdandaByGroupName
    {
        public bool hasBedCount { get; set; }
        public string groupName { get; set; }
        public List<GroupedMapdanda> groupedMapdanda { get; set; } = new List<GroupedMapdanda>();

    }

    public class GroupedMapdanda
    {
        public int id { get; set; }
        public string name { get; set; }
        public string serialNumber { get; set; }
        public string parimaad { get; set; }
        public bool is100Active { get; set; }
        public bool is200Active { get; set; }
        public bool is50Active { get; set; }
        public bool is25Active { get; set; }
        public bool isAvailableDivided { get; set; }
        public bool status { get; set; }
        public string group { get; set; }

    }
}