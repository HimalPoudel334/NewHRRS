

namespace HRRS.Models
{
    public class HealthFacility
    {
        public int id { get; set; }
        public string facilityName { get; set; }

        public string facilityType { get; set; }

        public string panNumber { get; set; }

        public int bedCount { get; set; }

        public int specialistCount { get; set; }

        public string availableServices { get; set; }

        public string district { get; set; }

        public string localLevel { get; set; }

        public int wardNumber { get; set; }

        public string tole { get; set; }

        public string dateOfInspection { get; set; }

        public string facilityEmail { get; set; } = null;


        public string facilityPhoneNumber { get; set; }

        public string facilityHeadName { get; set; }


        public string facilityHeadPhone { get; set; } = null;

        public string facilityHeadEmail { get; set; } = null;

        public string executiveHeadName { get; set; } = null;


        public string executiveHeadMobile { get; set; } = null;

        public string executiveHeadEmail { get; set; } = null;


        public string permissionReceivedDate { get; set; } = null;


        public string lastRenewedDate { get; set; } = null;

        public string apporvingAuthority { get; set; } = null;

        public string renewingAuthority { get; set; } = null;


        public string approvalValidityTill { get; set; } = null;


        public string renewalValidityTill { get; set; } = null;


        public string upgradeDate { get; set; } = null;

        public string upgradingAuthority { get; set; } = null;

        public bool isLetterOfIntent { get; set; } = false;

        public bool isExecutionPermission { get; set; } = false;

        public bool isRenewal { get; set; } = false;

        public bool isUpgrade { get; set; } = false;

        public bool isServiceExtension { get; set; } = false;

        public bool isBranchExtension { get; set; } = false;

        public bool isRelocation { get; set; } = false;

        public string others { get; set; } = null;

        public string applicationSubmittedDate { get; set; } = null;

        public string applicationSubmittedAuthority { get; set; }
    }
}
