using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkyEuropeJobs.Core.Entities;

namespace SkyEuropeJobs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("seed-user")]
        public async Task<IActionResult> SeedUser()
        {
            var roleName = "Administrator";

            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
            var defaultUser = new ApplicationUser
            {
                UserName = "admin@skyeuropejobs.com",
                Email = "admin@skyeuropejobs.com",
                EmailConfirmed = true,
                FirstName = "SEJ",
                LastName = "Admin",
                FullName = "SEJ Admin"
            };

            var currentlist = new List<ApplicationUser>() 
            {
               
                new ApplicationUser
                {
                    UserName = "hr@skyeuropejobs.com",
                    Email = "hr@skyeuropejobs.com",
                    EmailConfirmed = true,
                    FirstName = "SEJ",
                    LastName = "HR",
                    FullName = "SEJ HR"
                },
                new ApplicationUser
                {
                    UserName = "accounts@skyeuropejobs.com",
                    Email = "accounts@skyeuropejobs.com",
                    EmailConfirmed = true,
                    FirstName = "SEJ",
                    LastName = "Accounts",
                    FullName = "SEJ Accounts"
                },
                new ApplicationUser
                {
                    UserName = "visa@skyeuropejobs.com",
                    Email = "visa@skyeuropejobs.com",
                    EmailConfirmed = true,
                    FirstName = "SEJ",
                    LastName = "Visa",
                    FullName = "SEJ Visa"
                },
                new ApplicationUser{
                    UserName = "cristina@skyeuropejobs.com",
                    Email = "cristina@skyeuropejobs.com",
                    EmailConfirmed = true,
                    FirstName = "Cristina",
                    LastName = "Dragomirescu",
                    FullName = "Cristina Dragomirescu"
                },
                new ApplicationUser{
                    UserName = "niroshan@skyeuropejobs.com",
                    Email = "niroshan@skyeuropejobs.com",
                    EmailConfirmed = true,
                    FirstName = "Niroshan",
                    LastName = "Gunarathna",
                    FullName = "Niroshan Gunarathna"
                },
                new ApplicationUser{
                    UserName = "chamika@skyeuropejobs.com",
                    Email = "chamika@skyeuropejobs.com",
                    EmailConfirmed = true,
                    FirstName = "Chamika",
                    LastName = "Perera",
                    FullName = "Chamika Perera"
                },
                new ApplicationUser{
                    UserName = "anuradhi@skyeuropejobs.com",
                    Email = "anuradhi@skyeuropejobs.com",
                    EmailConfirmed = true,
                    FirstName = "Anuradhi",
                    LastName = "Fernando",
                    FullName = "Anuradhi Fernando"
                },
                new ApplicationUser{
                    UserName = "nirmani@skyeuropejobs.com",
                    Email = "nirmani@skyeuropejobs.com",
                    EmailConfirmed = true,
                    FirstName = "Nirmani",
                    LastName = "Fernando",
                    FullName = "Nirmani Fernando"
                },
                new ApplicationUser{
                    UserName = "akila@skyeuropejobs.com",
                    Email = "akila@skyeuropejobs.com",
                    EmailConfirmed = true,
                    FirstName = "Akila",
                    LastName = "Dananjayao",
                    FullName = "Akila Dananjayao"
                }
            };

            try
            {
                foreach (var user in currentlist)
                {
                    if (await _userManager.FindByEmailAsync(user.Email) == null)
                    {
                        var result = await _userManager.CreateAsync(user, "Sky@123");
                    }
                }
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            if (await _userManager.FindByEmailAsync(defaultUser.Email) == null)
            {
                var result = await _userManager.CreateAsync(defaultUser, "Sky@123");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(defaultUser, roleName);
                    return Ok("Users seeded successfully");
                }
                return BadRequest(result.Errors);
            }

            return Ok("User seeded successfully");
        }
    }

}
