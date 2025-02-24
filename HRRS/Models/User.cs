
namespace HRRS.Models
{
    public class User
    {

        public long userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string userType { get; set; } = "Hospital";
        public int? healthFacilityId { get; set; }
    }
}
