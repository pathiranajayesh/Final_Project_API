using AutoMapper;
using SkyEuropeJobs.Application.DTOs;
using SkyEuropeJobs.Application.Interfaces;
using SkyEuropeJobs.Core.Entities;
using SkyEuropeJobs.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyEuropeJobs.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public PaymentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentsAsync()
        {
            var payments = await _unitOfWork.Payments.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<PaymentDto> GetPaymentByIdAsync(string id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<List<PaymentDto>> GetPaymentsByApplicantIdAsync(string applicantId)
        {
            var payments = await _unitOfWork.Payments.GetPaymentsByApplicantIdAsync(applicantId);
            return _mapper.Map<List<PaymentDto>>(payments);
        }

        public async Task AddPaymentAsync(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _unitOfWork.Payments.AddAsync(payment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdatePaymentAsync(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            _unitOfWork.Payments.Update(payment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(string id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payment != null)
            {
                _unitOfWork.Payments.Delete(payment);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
