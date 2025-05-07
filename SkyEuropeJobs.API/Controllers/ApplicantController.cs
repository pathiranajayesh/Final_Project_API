using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyEuropeJobs.Application.Interfaces;
using SkyEuropeJobs.Core.Entities;

namespace SkyEuropeJobs.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [AllowAnonymous]
        [HttpGet("ping")]
        public IActionResult Index()
        {
            return Ok("API is running");
        }

        /// <summary>
        /// Get all applicants.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllApplicants()
        {
            var applicants = await _applicantService.GetApplicantsAsync();
            return Ok(applicants);
        }

        /// <summary>
        /// Get an applicant by ID.
        /// </summary>
        [HttpGet("{id}")] // api/Applicant/:id
        public async Task<IActionResult> GetApplicantById(string id)
        {
            var applicant = await _applicantService.GetApplicantByIdAsync(id);
            if (applicant == null)
            {
                return NotFound(new { Message = $"Applicant with ID {id} not found." });
            }
            return Ok(applicant);
        }

        /// <summary>
        /// Add a new applicant.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddApplicant([FromBody] Applicant applicant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _applicantService.AddApplicantAsync(applicant);
            return CreatedAtAction(nameof(GetApplicantById), new { id = applicant.Id }, applicant);
        }

        /// <summary>
        /// Update an existing applicant.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicant(string id, [FromBody] Applicant applicant)
        {
            if (id != applicant.Id)
                return BadRequest(new { Message = "Applicant ID mismatch." });

            var existingApplicant = await _applicantService.GetApplicantByIdAsync(id);
            if (existingApplicant == null)
                return NotFound(new { Message = $"Applicant with ID {id} not found." });

            await _applicantService.UpdateApplicantAsync(applicant, existingApplicant);
            return NoContent();
        }

        /// <summary>
        /// Delete an applicant by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicant(string id)
        {
            var existingApplicant = await _applicantService.GetApplicantByIdAsync(id);
            if (existingApplicant == null)
                return NotFound(new { Message = $"Applicant with ID {id} not found." });

            await _applicantService.DeleteApplicantAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Search applicants by keyword.
        /// </summary>
        [HttpGet("search")]
        public async Task<IActionResult> SearchApplicants([FromQuery] string keyword)
        {
            var applicants = await _applicantService.SearchApplicantsAsync(keyword);
            return Ok(applicants);
        }
    }
}
