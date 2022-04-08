using Employee.Data.DbContextData;
using Employee.Data.Entities;
using EmployeeAssiginment.Filters;
using EmployeeAssiginment.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAssiginment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(LoggingFilter))]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeesController(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllUsers(string name)
        {
            try
            {
                if (name != null)
                {
                    var res = dbContext.Employees.Where(x => x.FirstName == name || x.LastName == name);
                    return Ok(res);
                }

                return Ok(dbContext.Employees);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeModel employee)
        {
            try
            {
                var emp = employee.BindModel();
                dbContext.Employees.Add(emp);
                await dbContext.SaveChangesAsync();
                return Ok("Created");
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
