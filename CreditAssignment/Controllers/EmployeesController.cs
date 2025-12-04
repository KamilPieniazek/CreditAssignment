//using CreditAssignment.Exceptions;
//using CreditAssignment.Models;
//using CreditAssignment.Models.Entities;
//using CreditAssignment.Repository;
//using CreditAssignment.Services;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace CreditAssignment.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmployeesController : ControllerBase
//    {
//        private readonly EmployeeService employeeService;
//        public EmployeesController(
//            EmployeeService employeeService)
//        {
//            this.employeeService = employeeService;
//        }

//        [HttpGet]
//        public IActionResult getAllEmployees()
//        {
//            return Ok(employeeService.getAllEmployees());
//        }

//        [HttpPost]
//        public IActionResult addEmployee([FromBody] EmployeeDTO employee)
//        { 
//            return Ok(employeeService.addEmployee(employee));
//        }

//        [HttpPatch("{id:guid}")]
//        public IActionResult UpdateEmployee(Guid id, [FromBody] EmployeeDTO dto)
//        {
//            var employee = employeeService.UpdateEmployee(id, dto);

//            if (employee is null)
//                return NotFound();

//            return Ok(employee);
//        }
//        //        [HttpPut]
//        //        [Route("{id:guid}")]
//        //        public IActionResult updateEmployee(Guid id, EmployeeDTO employee)
//        //        {
//        //            var employeeFromDb = context.Employees.Find(id);

//        //            if (employeeFromDb == null)
//        //            {
//        //                return NotFound();
//        //            }

//        //            employee.Name = employeeFromDb.Name;
//        //            employee.Email = employeeFromDb.Email;
//        //            employee.Phone = employeeFromDb.Phone;
//        //            employee.Salary = employeeFromDb.Salary;

//        //            context.SaveChanges();

//        //            return Ok(employeeFromDb);
//        //        }

//        [HttpDelete]
//        [Route("{id:guid}")]
//        public IActionResult deleteEmployee(Guid id)
//        {
//            try
//            {
//                employeeService.DeleteEmployee(id);
//                return NoContent(); // 204 - OK, usunięto
//            }
//            catch (NotFoundException ex)
//            {
//                return NotFound(new { message = ex.Message });
//            }
//            catch (Exception)
//            {
//                return StatusCode(500, new { message = "Unexpected error occurred." });
//            }
//        }
//    }
//}
 