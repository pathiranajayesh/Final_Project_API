using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SkyEuropeJobs.Core.Entities
{
    public class Payment : BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string ApplicantId { get; set; }

        [ForeignKey("ApplicantId")]
        [JsonIgnore]
        public Applicant Applicant { get; set; }

        public int Amount { get; set; }
        public string Currency { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; }
        public string Notes { get; set; }

      
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
