using SkyEuropeJobs.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyEuropeJobs.Core.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<List<Payment>> GetPaymentsByApplicantIdAsync(string applicantId);
    }
}
