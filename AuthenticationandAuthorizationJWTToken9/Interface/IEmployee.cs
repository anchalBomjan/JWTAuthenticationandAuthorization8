using AuthenticationandAuthorizationJWTToken9.Models;

namespace AuthenticationandAuthorizationJWTToken9.Interface
{
    public interface IEmployee
    {
        //    public List<Employee> GetEmployeeDetails();

        //    //Note*** here we return all the collection of employee so we use List
        //    //Since you're retrieving multiple employee records, the method returns a List<Employee>.
        //    //This allows you to get a collection of employee objects that can be iterated over, accessed by index,
        //    //or manipulated further.
        //    public Employee GetEmployeeDetails(int id);
        //    //here in this function  we get only one   details of the the give id details
        //    public void AddEmployee(Employee employee);
        //    // no need to return  type this function because here only we have to  post 
        //    //ust the action of adding an employee
        //    public void UpdateEmployee(Employee employee);

        //    // same like as above  only post
        //    // this method is for updating an existing employee's details.

        //    public Employee DeleteEmployee(int id);
        //    // This method deletes an employee record based on the provided id, but before it deletes the record, it likely returns the employee data that was deleted.
        //    // This can be useful for logging or confirmation purposes.here delete so after delete we have to show 
        //    public bool CheckEmployee(int id);
        //    //This method checks if an employee exists based on the provided id.
        //    //The method returns a boolean (true or false) indicating whether the employee exists or not.


        // Note*********  InputOutPut bound and and CPU Bound so use Task for async and await

        //Note**********************************


        //What the caller expects to receive.
        //That decide method should have to return type or not ? 



        Task< List<Employee>>GetEmployeeDetailsAsync();
        //In this methods return type is needed for Frontend
         Task<Employee> GetEmployeeDetailsAsync(int id);
        // needed for fronend

         Task<Employee> AddEmployeeAsync(Employee employee);
        //optionals
        //This also helps to show the added entity after method execuate and show Swagger in the response :
         Task<Employee> UpdateEmployeeAsync(Employee employee);
        //This helps to show  the updated entity  after the operation : Not necessary to this methods to return types
         Task <Employee?>DeleteEmployeeAsync(int id);
        // this return type helps to  show  the  delete entity tables and also  for Frontend:::::->This can be useful for logging or confirmation purposes.here delete so after delete we have to show 
        //This method deletes an employee record based on the provided id, but before it deletes the record, it likely returns the employee data that was deleted.
        // if no return types then in frontend dynamically  deleted 
        // Not null symbole is placed beacuse there is no change to get null during  delete

        Task<bool> checkEmployeeAsync(int id);
        //needed  return type to check 



    }
}


