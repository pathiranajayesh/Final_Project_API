using SkyEuropeJobs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEuropeJobs.Core.Interfaces
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        Task<Applicant> GetByIdAsync(string ApplicantId);
        Task<List<Applicant>> SearchApplicantsAsync(string searchKeyword);
    }
}
