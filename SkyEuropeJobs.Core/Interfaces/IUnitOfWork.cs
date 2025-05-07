using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEuropeJobs.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicantRepository Applicants { get; }
        IPaymentRepository Payments { get; }
        Task<int> SaveChangesAsync();
    }
}
