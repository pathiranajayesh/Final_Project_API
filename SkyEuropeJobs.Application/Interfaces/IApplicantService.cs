using SkyEuropeJobs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEuropeJobs.Application.Interfaces
{
    public interface IApplicantService
    {
        Task<IEnumerable<Applicant>> GetApplicantsAsync();
        Task<Applicant> GetApplicantByIdAsync(string id);
        Task AddApplicantAsync(Applicant applicant);
        Task UpdateApplicantAsync(Applicant applicant, Applicant existingApplicant);
        Task DeleteApplicantAsync(string id);
        Task<List<Applicant>> SearchApplicantsAsync(string searchKeyword);

    }
}
