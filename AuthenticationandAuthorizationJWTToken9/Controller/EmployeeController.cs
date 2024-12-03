//using AuthenticationandAuthorizationJWTToken9.Interface;
//using AuthenticationandAuthorizationJWTToken9.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections;
//using System.Runtime.InteropServices;

//namespace AuthenticationandAuthorizationJWTToken9.Controller
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmployeeController : ControllerBase
//    {
//        private readonly IEmployee _IEmployee;
//        public EmployeeController(IEmployee employee)
//        {
//            _IEmployee = employee;

//        }

//        //GET:api/employee>
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Employee>>> Get()
//        {
//            //  return  await Task.FromResult(_IEmployee.GetEmployeeDetails());
//            // if  we have async and await only in Controller not in interface and its repose then we Use Task.FromResult
//            //this is bad practise

//            var employees = await _IEmployee.GetEmployeeDetailsAsync();
//            return  employees;

//        }
//        // GET: api/emmployee/5
//        [HttpGet]
//        public async Task<ActionResult<Employee>> Get(int id)
//        {
//            var employee = await _IEmployee.GetEmployeeDetailsAsync(id);
//            if(employee == null)
//            {
//                return NotFound();
//            }
//            return Ok(employee);

//        }

//        [HttpPost]
//        public async Task<ActionResult<Employee>>Post(Employee employee)
//        {
//             var  employees=await _IEmployee.AddEmployeeAsync(employee);
//            return Ok(employees);
//        }

//        [HttpPut]
//        public async Task<ActionResult<Employee>> Put(int id,Employee employee)
//        {
//            if (id != employee.EmployeeID)
//            {
//                return BadRequest();
//            }
//            try
//            {
//                 await _IEmployee.UpdateEmployeeAsync(employee);
//            }
//            catch(DbUpdateConcurrencyException)
//            {
//                if (!EmployeeExists(id))
//                {
//                    return NotFound();
//                }
//                else {
//                    throw;
//                }
//            }

//            return  Ok(employee);
//        }





//        private bool EmployeeExists(int id)
//        {
//            return _IEmployee.checkEmployeeExists(id);
//        }

//    }
//}

using AuthenticationandAuthorizationJWTToken9.Interface;
using AuthenticationandAuthorizationJWTToken9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationandAuthorizationJWTToken9.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var employees = await _employeeService.GetEmployeeDetailsAsync();
            return Ok(employees); // Middleware handles any unexpected errors
        }

        // GET: api/employee/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await _employeeService.GetEmployeeDetailsAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found."); // Middleware handles this
            }
            return Ok(employee);
        }

        // POST: api/employee
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            await _employeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.EmployeeID }, employee);
        }

        // PUT: api/employee/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest(new { message = "ID mismatch" });
            }

            // Update the employee
            await _employeeService.UpdateEmployeeAsync(employee);

            return NoContent(); // Indicates the update was successful
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = await _employeeService.DeleteEmployeeAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found."); // Middleware handles this
            }
            return Ok(employee);
        }
    }
}

