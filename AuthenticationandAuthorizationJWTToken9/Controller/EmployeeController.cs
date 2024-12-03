using AuthenticationandAuthorizationJWTToken9.Interface;
using AuthenticationandAuthorizationJWTToken9.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace AuthenticationandAuthorizationJWTToken9.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _IEmployee;
        public EmployeeController(IEmployee employee)
        {
            _IEmployee = employee;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            // return  await Task.FromResult(_IEmployee.GetEmployeeDetails());
            //we can write this in another forms

            var employees = _IEmployee.GetEmployeeDetails();
            return  employees;



        }
       
            

    }
}
