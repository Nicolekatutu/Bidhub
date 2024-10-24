using Bidhub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bidhub.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bidhub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserContext _userContext;

        public AdminController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, UserContext userContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userContext = userContext;
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromForm] AddUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Step 1: Check if the company exists or create a new one
            var company = await _userContext.Companies
                .FirstOrDefaultAsync(c => c.CompanyUrl == model.CompanyUrl);

            if (company == null)
            {
                company = new Company
                {
                    CompanyUrl = model.CompanyUrl
                };
                _userContext.Companies.Add(company);
                await _userContext.SaveChangesAsync();
            }

            var auctioneer = new Auctioneer
            {
                User = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email
                },
                StaffNo = model.StaffNo,
                CompanyId = company.CompanyId,  
                Role = model.Role
            };

            // Step 3: Save the auctioneer to the UserManager
            var result = await _userManager.CreateAsync(auctioneer.User); 
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Step 4: Save the photo if it exists
            if (model.Photo != null && model.Photo.Length > 0)
            {
                var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }

                var fileName = Path.GetFileName(model.Photo.FileName);
                var filePath = Path.Combine("Uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(stream);
                }

                auctioneer.PhotoUrl = $"/Uploads/{fileName}"; // Save relative URL to the user
                await _userManager.UpdateAsync(auctioneer.User);
            }

            if (!string.IsNullOrEmpty(model.Role))
            {
                await _userManager.AddToRoleAsync(auctioneer.User, model.Role);
            }

            // Step 6: Save auctioneer to the database
            _userContext.Auctioneers.Add(auctioneer);
            await _userContext.SaveChangesAsync();

            return Ok(new { message = "Auctioneer added successfully", auctioneer.User });
        }


        //[HttpPost("create-role")]
        //public async Task<IActionResult> CreateRole([FromBody] AddRoleDto model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // Check if the role already exists
        //    var roleExists = await _roleManager.RoleExistsAsync(model.RoleName);
        //    if (roleExists)
        //    {
        //        return BadRequest(new { message = "Role already exists" });
        //    }

        //    // Create the new role
        //    var role = new IdentityRole(model.RoleName);
        //    var result = await _roleManager.CreateAsync(role);

        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }

        //    // Save additional role info in your custom Role entity
        //    var roleInfo = new Role
        //    {
        //        RoleName = model.RoleName,
        //        RoleDescription = model.RoleDescription
        //    };

        //    _userContext.Roles.Add(roleInfo);
        //    await _userContext.SaveChangesAsync();

        //    return Ok(new { message = "Role created successfully" });
        //}

        //[HttpPost("assign-role")]
        //public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto model)
        //{
        //    var user = await _userManager.FindByIdAsync(model.UserId.ToString());

        //    if (user == null)
        //    {
        //        return NotFound(new { message = "User not found" });
        //    }

        //    // Check if the role exists
        //    var roleExists = await _roleManager.RoleExistsAsync(model.Role);
        //    if (!roleExists)
        //    {
        //        return BadRequest(new { message = "Role does not exist" });
        //    }

        //    // Assign the role to the user
        //    var result = await _userManager.AddToRoleAsync(user, model.Role);
        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }

        //    // Optionally, update the `UserRoles` table in your custom context if required
        //    var userRole = new UserRoles
        //    {
        //        UserId = user.UserId,
        //        RoleId = (await _userContext.Roles.SingleOrDefaultAsync(r => r.RoleName == model.Role)).RoleId
        //    };
        //    _userContext.UserRoles.Add(userRole);
        //    await _userContext.SaveChangesAsync();

        //    return Ok(new { message = "Role assigned successfully" });
        //}
    }

}

