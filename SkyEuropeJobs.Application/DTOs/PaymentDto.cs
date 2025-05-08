namespace SkyEuropeJobs.Application.DTOs
{
    public class PaymentDto
    {
        public string? Id { get; set; }
        public string ApplicantId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; }
        public string Notes { get; set; }
        public string Currency { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
