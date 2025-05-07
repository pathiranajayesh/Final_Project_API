using SkyEuropeJobs.Core.Entities;
using SkyEuropeJobs.Core.Interfaces;
using SkyEuropeJobs.Infrastructure.Data;
using SkyEuropeJobs.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEuropeJobs.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IApplicantRepository Applicants { get; private set; }
        public IPaymentRepository Payments { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Applicants = new ApplicantRepository(_context);
            Payments = new PaymentRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
