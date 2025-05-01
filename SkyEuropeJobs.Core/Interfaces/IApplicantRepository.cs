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
        //Task<IEnumerable<Applicant>> GetApplicantsByCountryAsync(int countryId);
        Task<List<Applicant>> SearchApplicantsAsync(string searchKeyword);

    }
}
