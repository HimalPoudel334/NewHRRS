using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRRS.Models
{
    public class MasterStandardEntry
    {
        [Key]
        public Guid submissionCode { get; set; }
        public int bedCount { get; set; }
        public int healthFacilityId { get; set; }
        public EntryStatus entryStatus { get; set; } = EntryStatus.Draft;
        public string remarks { get; set; }
        public SubmissionType submissionType { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public DateTime? updatedAt { get; set; }
    }
}