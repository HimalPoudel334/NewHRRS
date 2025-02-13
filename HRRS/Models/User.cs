
namespace HRRS.Models
{
    public class User
    {

        public long userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string userType { get; set; } = "Hospital";
        public int? HealthFacilityId { get; set; }
    }
}
