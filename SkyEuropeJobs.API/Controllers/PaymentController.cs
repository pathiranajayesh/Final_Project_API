using Microsoft.AspNetCore.Mvc;
using SkyEuropeJobs.Application.DTOs;
using SkyEuropeJobs.Application.Interfaces;
using SkyEuropeJobs.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyEuropeJobs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await _paymentService.GetPaymentsAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(string id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [HttpGet("applicant/{applicantId}")]
        public async Task<IActionResult> GetPaymentsByApplicantId(string applicantId)
        {
            var payments = await _paymentService.GetPaymentsByApplicantIdAsync(applicantId);
            return Ok(payments);
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody] PaymentDto payment)
        {
            try
            {
                if (string.IsNullOrEmpty(payment.Id))
                {
                    payment.Id = Guid.NewGuid().ToString(); // Generate a new ID if not provided
                }

                await _paymentService.AddPaymentAsync(payment);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(string id, [FromBody] PaymentDto payment)
        {
            if (id != payment.Id) return BadRequest();
            await _paymentService.UpdatePaymentAsync(payment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(string id)
        {
            await _paymentService.DeletePaymentAsync(id);
            return NoContent();
        }
    }
}
