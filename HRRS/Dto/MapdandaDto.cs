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
        public int? anusuchiId { get; set; }
        public int? parichhedId { get; set; }
        public int? subParichhedId { get; set; }
        public int? formType { get; set; }
        public bool? hasBedCount { get; set; }
        public string subSubParixed { get; set; }
        public ICollection<GroupedMapdandaByGroupName> list { get; set; } = new List<GroupedMapdandaByGroupName>();
    }

    public class GroupedMapdandaByGroupName
    {
        public int? formType { get; set; }
        public bool hasBedCount { get; set; }
        public string groupName { get; set; }
        public List<GroupedAdmimMapdanda> groupedMapdanda { get; set; } = new List<GroupedAdmimMapdanda>();

    }

    public class GroupedAdmimMapdanda
    {
        public int id { get; set; }
        public string name { get; set; }
        public string serialNumber { get; set; }
        public string parimaad { get; set; }
        public bool is25Active { get; set; }
        public bool is50Active { get; set; }
        public bool is100Active { get; set; }
        public bool is200Active { get; set; }
        public bool isAvailableDivided { get; set; }
        public bool status { get; set; }
        public string group { get; set; }
        public string value25 { get; set; }
        public string value50 { get; set; }
        public string value100 { get; set; }
        public string value200 { get; set; }
        public string col5 { get; set; }
        public string col6 { get; set; }
        public string col7 { get; set; }
        public string col8 { get; set; }
        public string col9 { get; set; }
        public bool isCol5Active { get; set; }
        public bool isCol6Active { get; set; }
        public bool isCol7Active { get; set; }
        public bool isCol8Active { get; set; }
        public bool isCol9Active { get; set; }
        public int entryId { get; set; }
        public bool? isAvailable { get; set; }
        public string filePath { get; set; }


    }

    public class MapdandaQueryParams
    {
        public int? anusuchiId { get; set; }
        public int? parichhedId { get; set; }
        public int? subParichhedId { get; set; }
    }
}