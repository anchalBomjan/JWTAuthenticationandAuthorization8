using AuthenticationandAuthorizationJWTToken9.Data;
using AuthenticationandAuthorizationJWTToken9.Interface;
using AuthenticationandAuthorizationJWTToken9.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationandAuthorizationJWTToken9.Repositories
{
    public class EmployeeRepository: IEmployee
    {
        /// <summary>
        /// //
        /// </summary>
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _context=dbContext;
        }

        public async Task<List<Employee>> GetEmployeeDetailsAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeDetailsAsync(int id)
        {
            var existingEmployee=  await _context.Employees.FindAsync(id);
            if(existingEmployee == null)
            {
                throw new KeyNotFoundException($"Not Found Employee");
            }
            return existingEmployee;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {

            /////For database operations, clarity and correctness are more important than reducing the number of await calls. In this case,
            //sticking with two explicit await calls is a best practice.
            // await When.AllTask  not use

             await _context.Employees.AddAsync(employee);
             await _context.SaveChangesAsync();
             return employee;

        }

        public async  Task <Employee> UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.EmployeeID);
            if(existingEmployee == null)
            {
                throw new KeyNotFoundException ($"Employee with ID {employee.EmployeeID} Not FOund");
            }
            _context.Entry(existingEmployee).CurrentValues.SetValues(employee);
            return existingEmployee;

        }

        public async Task<Employee?> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return employee;// This will be null if the employee was not found.
        }
        public bool checkEmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }

    }
}
