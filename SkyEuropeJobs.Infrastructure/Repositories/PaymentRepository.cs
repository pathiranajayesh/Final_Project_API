using Microsoft.EntityFrameworkCore;
using SkyEuropeJobs.Core.Entities;
using SkyEuropeJobs.Core.Interfaces;
using SkyEuropeJobs.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyEuropeJobs.Infrastructure.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Payment>> GetPaymentsByApplicantIdAsync(string applicantId)
        {
            return await _context.Payments
                .Where(p => p.Applicant.Id == applicantId)
                .ToListAsync();
        }
    }
}
