using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRRS.Models;

namespace HRRS.Dto.HospitalStandard
{
    public class HospitalStandardDto
    {
        public int id { get; set; }
        public int healthFacilityId { get; set; }
        public int mapdandaId { get; set; }
        public bool isAvailable { get; set; }
        public bool isActive { get; set; }
        public string value { get; set; }
        public string remarks { get; set; }
        public string filePath { get; set; }
        public string fiscalYear { get; set; }
        public DateTime createdAt { get; set; }
        public bool status { get; set; }
        public DateTime updatedAt { get; set; }
        public string subSubParixed { get; set; }
        public int anusuchiId { get; set; }
        public int parichhedId { get; set; }
        public int subParichhedId { get; set; }
        public int subSubParichhedId { get; set; }
        public FormType formType { get; set; }
        public string group { get; set; }
        public string mapdandaName { get; set; }
        public string serialNumber { get; set; }
        public string parimaad { get; set; }
    }


    public class GroupedSubSubParichhedAndMapdanda
    {
        public int? anusuchiId { get; set; }
        public int? parichhedId { get; set; }
        public int? subParichhedId { get; set; }
        public FormType? formType { get; set; }
        public bool? hasBedCount { get; set; }
        public string subSubParixed { get; set; }
        public ICollection<GroupedMapdandaByGroupName> list { get; set; } = new List<GroupedMapdandaByGroupName>();
    }

    public class GroupedMapdandaByGroupName
    {
        public int? formType { get; set; }
        public bool hasBedCount { get; set; }
        public string groupName { get; set; }
        public List<GroupedUserMapdanda> groupedMapdanda { get; set; } = new List<GroupedUserMapdanda>();

    }

    public class GroupedUserMapdanda
    {
        public int id { get; set; }
        public string name { get; set; }
        public string serialNumber { get; set; }
        public string parimaad { get; set; }
        public bool status { get; set; }
        public string group { get; set; }
        public int entryId { get; set; }
        public bool? isAvailable { get; set; }
        public string filePath { get; set; }
        public bool isActive { get; set; }
        public string value { get; set; }
    }

    public class HospitalMapdandasDto
    {
        public int mapdandaId { get; set; }
        public int? entryId { get; set; }
        public string serialNumber { get; set; }
        public string mapdandaName { get; set; }
        public bool? isAvailable { get; set; }
        public string remarks { get; set; }
        public string filePath { get; set; }
        public string fiscalYear { get; set; }
        public bool status { get; set; }
    }

    public class HospitalStandardEntryDto
    {
        public Guid submissionCode { get; set; }
        public ICollection<HospitalMapdandasDto> mapdandas { get; set; } = new List<HospitalMapdandasDto>();
    }

    public class HospitalEntryDto
    {
        public int id { get; set; }
        public EntryStatus status { get; set; }
        public string parichhed { get; set; }
        public string subParichhed { get; set; }
        public string anusuchi { get; set; }
        public string remarks { get; set; }
        public SubmissionType submissionType { get; set; }

    }

    public class StandardGroupModel
    {
        public string groupName { get; set; }
        public List<MapdandaModel> groupedMapdanda { get; set; }
    }

    public class MapdandaModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string serialNumber { get; set; }
        public bool? isAvailable { get; set; }
        public string filePath { get; set; }
        public string parimaad { get; set; }
        public string group { get; set; }
        public string value { get; set; }
        public int entryId { get; set; }
        public bool? isAvailableDivided { get; set; }
    }

    public class HospitalStandardModel
    {
        public int? anusuchiId { get; set; }
        public int? parichhedId { get; set; }
        public int? subParichhedId { get; set; }
        public FormType formType { get; set; }
        public bool? hasBedCount { get; set; }
        public string subSubParixed { get; set; }
        public List<StandardGroupModel> list { get; set; }


    }
}

