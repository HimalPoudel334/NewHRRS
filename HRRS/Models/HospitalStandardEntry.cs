
using System;

public class HospitalStandardEntry
{
    public int Id { get; set; }
    public string Remarks { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    public EntryStatus Status { get; set; }

}

public enum EntryStatus
{
    Pending,
    Approved,
    Rejected,
    Draft
}
