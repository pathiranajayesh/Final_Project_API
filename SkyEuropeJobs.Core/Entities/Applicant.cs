using SkyEuropeJobs.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEuropeJobs.Core.Entities
{
    public class Applicant : ApplicationUser, BaseEntity
    {
        public string? NameWithInitials { get; set; }
        public string? NICNumber { get; set; }
        public string? PassportNumber { get; set; }
        public DateTime? DOB { get; set; }
        public CivilStatus? civilStatus { get; set; }
        public int? NumberOfDependants { get; set; }
        public bool? IsActive { get; set; } = true;

        // Address based props
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? Area { get; set; }
        public string? City { get; set;}
        public string? District { get; set;}
        public string? Province { get; set;}
        public string? PoliceArea { get; set;}
        public string? PostalCode { get; set;}
        public string? PhoneMobile { get; set;}
        public string? PhoneMobile2 { get; set;}
        public string? PhoneFixed { get; set; }
        public string? WhatsAppMobile { get; set;}

        // Spouse details
        public string? Spouse_Fullname { get; set;}
        public string? Spouse_NICNumber { get; set; }
        public string? Spouse_PhoneMobile { get; set; }
        public string? Spouse_AddressLine1 { get; set; }
        public string? Spouse_AddressLine2 { get; set; }
        public string? Spouse_AddressLine3 { get; set; }

        // Mother's details
        public string? Mother_Fullname { get; set; }
        public string? Mother_NICNumber { get; set; }
        public string? Mother_PhoneMobile { get; set; }
        public string? Mother_AddressLine1 { get; set; }
        public string? Mother_AddressLine2 { get; set; }
        public string? Mother_AddressLine3 { get; set; }

        // Father's details
        public string? Father_Fullname { get; set; }
        public string? Father_NICNumber { get; set; }
        public string? Father_PhoneMobile { get; set; }
        public string? Father_AddressLine1 { get; set; }
        public string? Father_AddressLine2 { get; set; }
        public string? Father_AddressLine3 { get; set; }

        //Dates
        public DateTime? RegisterdOn { get; set; }
        public string? RegisterdBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //Notes
        public string? Notes { get; set; }
    }
}
