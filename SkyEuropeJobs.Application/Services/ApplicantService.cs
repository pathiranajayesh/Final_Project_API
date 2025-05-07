using SkyEuropeJobs.Application.Interfaces;
using SkyEuropeJobs.Core.Entities;
using SkyEuropeJobs.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEuropeJobs.Application.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Applicant>> GetApplicantsAsync()
        {
            return await _unitOfWork.Applicants.GetAllAsync();
        }

        public async Task<Applicant> GetApplicantByIdAsync(string id)
        {
            return await _unitOfWork.Applicants.GetByIdAsync(id);
        }

        public async Task AddApplicantAsync(Applicant applicant)
        {
            await _unitOfWork.Applicants.AddAsync(applicant);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateApplicantAsync(Applicant applicant, Applicant existingApplicant)
        {
            // Update properties manually
            existingApplicant.FirstName = applicant.FirstName;
            existingApplicant.LastName = applicant.LastName;
            existingApplicant.FullName = applicant.FullName;
            existingApplicant.NameWithInitials = applicant.NameWithInitials;
            existingApplicant.NICNumber = applicant.NICNumber;
            existingApplicant.PassportNumber = applicant.PassportNumber;
            existingApplicant.DOB = applicant.DOB;
            existingApplicant.Email = applicant.Email;
            existingApplicant.civilStatus = applicant.civilStatus;
            existingApplicant.NumberOfDependants = applicant.NumberOfDependants;
            existingApplicant.IsActive = applicant.IsActive;

            // Address based props
            existingApplicant.AddressLine1 = applicant.AddressLine1;
            existingApplicant.AddressLine2 = applicant.AddressLine2;
            existingApplicant.AddressLine3 = applicant.AddressLine3;
            existingApplicant.Area = applicant.Area;
            existingApplicant.City = applicant.City;
            existingApplicant.District = applicant.District;
            existingApplicant.Province = applicant.Province;
            existingApplicant.PoliceArea = applicant.PoliceArea;
            existingApplicant.PostalCode = applicant.PostalCode;
            existingApplicant.PhoneMobile = applicant.PhoneMobile;
            existingApplicant.PhoneMobile2 = applicant.PhoneMobile2;
            existingApplicant.PhoneFixed = applicant.PhoneFixed;
            existingApplicant.WhatsAppMobile = applicant.WhatsAppMobile;

            // Spouse details
            existingApplicant.Spouse_Fullname = applicant.Spouse_Fullname;
            existingApplicant.Spouse_NICNumber = applicant.Spouse_NICNumber;
            existingApplicant.Spouse_PhoneMobile = applicant.Spouse_PhoneMobile;
            existingApplicant.Spouse_AddressLine1 = applicant.Spouse_AddressLine1;
            existingApplicant.Spouse_AddressLine2 = applicant.Spouse_AddressLine2;
            existingApplicant.Spouse_AddressLine3 = applicant.Spouse_AddressLine3;

            // Mother's details
            existingApplicant.Mother_Fullname = applicant.Mother_Fullname;
            existingApplicant.Mother_NICNumber = applicant.Mother_NICNumber;
            existingApplicant.Mother_PhoneMobile = applicant.Mother_PhoneMobile;
            existingApplicant.Mother_AddressLine1 = applicant.Mother_AddressLine1;
            existingApplicant.Mother_AddressLine2 = applicant.Mother_AddressLine2;
            existingApplicant.Mother_AddressLine3 = applicant.Mother_AddressLine3;

            // Father's details
            existingApplicant.Father_Fullname = applicant.Father_Fullname;
            existingApplicant.Father_NICNumber = applicant.Father_NICNumber;
            existingApplicant.Father_PhoneMobile = applicant.Father_PhoneMobile;
            existingApplicant.Father_AddressLine1 = applicant.Father_AddressLine1;
            existingApplicant.Father_AddressLine2 = applicant.Father_AddressLine2;
            existingApplicant.Father_AddressLine3 = applicant.Father_AddressLine3;

            // Dates
            existingApplicant.RegisterdOn = applicant.RegisterdOn;
            existingApplicant.RegisterdBy = applicant.RegisterdBy;
            existingApplicant.CreatedAt = applicant.CreatedAt;
            existingApplicant.UpdatedAt = applicant.UpdatedAt;

            // Notes
            existingApplicant.Notes = applicant.Notes;


            _unitOfWork.Applicants.Update(existingApplicant);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteApplicantAsync(string id)
        {
            var applicant = await _unitOfWork.Applicants.GetByIdAsync(id);
            if (applicant != null)
            {
                _unitOfWork.Applicants.Delete(applicant);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        public async Task<List<Applicant>> SearchApplicantsAsync(string searchKeyword)
        {
            return await _unitOfWork.Applicants.SearchApplicantsAsync(searchKeyword);
        }

        // Applicant-related payment methods
        public async Task<List<Payment>> GetPaymentsByApplicantIdAsync(string applicantId)
        {
            return await _unitOfWork.Payments.GetPaymentsByApplicantIdAsync(applicantId);
        }
    }
}
