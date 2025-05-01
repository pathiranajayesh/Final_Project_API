using Microsoft.EntityFrameworkCore;
using SkyEuropeJobs.Core.Entities;
using SkyEuropeJobs.Core.Interfaces;
using SkyEuropeJobs.Infrastructure.Data;

namespace SkyEuropeJobs.Infrastructure.Repositories
{
    public class ApplicantRepository :Repository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Applicant>> SearchApplicantsAsync(string searchKeyword)
        {
            if (string.IsNullOrWhiteSpace(searchKeyword))
                return await _context.Applicants.ToListAsync();

            var keyword = searchKeyword.ToLower();

            return await _context.Applicants
                .Where(a =>
                    (a.FirstName != null && a.FirstName.ToLower().Contains(keyword)) ||
                    (a.LastName != null && a.LastName.ToLower().Contains(keyword)) ||
                    (a.NameWithInitials != null && a.NameWithInitials.ToLower().Contains(keyword)) ||
                    (a.NICNumber != null && a.NICNumber.ToLower().Contains(keyword)) ||
                    (a.PassportNumber != null && a.PassportNumber.ToLower().Contains(keyword)) ||
                    (a.PhoneMobile != null && a.PhoneMobile.ToLower().Contains(keyword)) ||
                    (a.AddressLine1 != null && a.AddressLine1.ToLower().Contains(keyword)) ||
                    (a.AddressLine2 != null && a.AddressLine2.ToLower().Contains(keyword)) ||
                    (a.AddressLine3 != null && a.AddressLine3.ToLower().Contains(keyword)) ||
                    (a.Email!= null && a.Email.ToLower().Contains(keyword))
                )
                .ToListAsync();
        }
    }
}
