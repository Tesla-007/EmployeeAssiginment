using Employee.Data.DbContextData;
using EmployeeAssiginment.Filters;
using EmployeeAssiginment.Models;
using EmployeeAssiginment.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAssiginment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(LoggingFilter))]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public AccountController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UserModel user)
        {
            try
            {
                await identityService.SignUpAsync(user);

                if (user.Errors.Count >= 1)
                {
                    var errors = new ModelStateDictionary();
                    foreach (var error in user.Errors)
                    {
                        errors.AddModelError("User Exists", error);
                    }
                    return ValidationProblem(errors);
                }
                return Ok(new
                {
                    message = "Account Created"
                });

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserModel user)
        {
            try
            {
                await identityService.SignInAsync(user);

                if (user.Errors.Count >= 1)
                {
                    var errors = new ModelStateDictionary();
                    foreach (var error in user.Errors)
                    {
                        errors.AddModelError("User does not Exists", error);
                    }
                    return ValidationProblem(errors);
                }
                return Ok(new
                {
                    message = "Sign In successfull",
                    token = user.Token
                });

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
