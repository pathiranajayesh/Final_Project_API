using SkyEuropeJobs.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkyEuropeJobs.Core.Entities;
using SkyEuropeJobs.Application.DTOs;

namespace SkyEuropeJobs.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetPaymentsAsync();
        Task<PaymentDto> GetPaymentByIdAsync(string id);
        Task<List<PaymentDto>> GetPaymentsByApplicantIdAsync(string applicantId);
        Task AddPaymentAsync(PaymentDto payment);
        Task UpdatePaymentAsync(PaymentDto payment);
        Task DeletePaymentAsync(string id);
    }
}
