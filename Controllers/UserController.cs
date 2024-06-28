using AutoMapper;
using HarshaApi1.Data;
using HarshaApi1.DTO;
using HarshaApi1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;
using System.Security.Claims;

namespace HarshaApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> UserManagerList;//data inserted into the AspNetUsers
        public RoleManager<ApplicationRoles> RoleManager { get; }//data inserted into the AspNetRoles //signingManager,signoutManager,
        public IMapper Mapper { get; }
        public IDiagnosticContext DiagnosticContext { get; }

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRoles> roleManager, IMapper mapper, IDiagnosticContext diagnosticContext)
        {
            UserManagerList = userManager;
            RoleManager = roleManager;
            Mapper = mapper;
            DiagnosticContext = diagnosticContext;
        }


        [HttpGet]   
        public async Task<IActionResult> GetUsers()
        {
            List<ApplicationUser> applicationUser = UserManagerList.Users.ToList();

            List<UserDetails> userDetails = Mapper.Map<List<UserDetails>>(applicationUser);
            DiagnosticContext.Set("UserDetails", userDetails);
            SentrySdk.ConfigureScope(o =>
            {
                o.SetExtra("response",userDetails);
                });
            throw new ArgumentNullException("exceptio is thrown by the Laxman");
            return Ok(userDetails);
        }
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> InsertRoleAndUsers(UserDetails userDetails)
        {
            try
            {

                // ApplicationUser applicationUser = new ApplicationUser { UserName = userDetails.UserName, Email = userDetails.Email, PhoneNumber = userDetails.PhoneNumber,CompayName=userDetails.CompayName };
                ApplicationUser applicationUser = Mapper.Map<ApplicationUser>(userDetails);
                IdentityResult result = await UserManagerList.CreateAsync(applicationUser, userDetails.Password);//create the user
                if (result.Succeeded)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                             new Claim("userPassword", userDetails.Password),
                             new Claim(ClaimTypes.MobilePhone, userDetails.PhoneNumber)
                    };

                    IdentityResult identityResult = await UserManagerList.AddClaimsAsync(applicationUser, claims);//Data inserted into AspNetUserClaims

                    if (identityResult.Succeeded)
                    {
                        ApplicationRoles applicationRoles = new ApplicationRoles { Name = userDetails.UserRole };
                        await RoleManager.CreateAsync(applicationRoles);
                        await UserManagerList.AddToRoleAsync(applicationUser, userDetails.UserRole);//data inserted into the AspnetUserRoles
                        Claim roleClaim = new Claim("Role description", userDetails.RoleDescription);
                        await RoleManager.AddClaimAsync(applicationRoles, roleClaim);
                        return Ok("success fully create the user");
                    }
                    return Ok("success fully create the user");
                }
                return BadRequest(result.Errors.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
