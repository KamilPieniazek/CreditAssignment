//using CreditAssignment.Exceptions;
//using CreditAssignment.Models;
//using CreditAssignment.Models.Entities;
//using CreditAssignment.Repository;

//namespace CreditAssignment.Services
//{
//    public class EmployeeService
//    {
//        private readonly ApplicationDbContext context;
//        public EmployeeService(ApplicationDbContext context)
//        {
//            this.context = context;
//        }

//        public List<Employee> getAllEmployees()
//        {
//            return [.. context.Employees];
//        }

//        public Employee addEmployee(EmployeeDTO dto)
//        {
//            var employee = Employee.FromDto(dto);

//            context.Employees.Add(employee);
//            context.SaveChanges();

//            return employee;
//        }

//        public Employee? UpdateEmployee(Guid id, EmployeeDTO dto)
//        {
//            var employee = context.Employees.FirstOrDefault(e => e.Id == id);
//            if (employee is null)
//            {
//                return null; // albo wyjątek, zależy jak wolisz
//            }

//            employee.UpdateFromDto(dto);
//            context.SaveChanges();

//            return employee;
//        }

//        public void DeleteEmployee(Guid id)
//        {
//            var employee = context.Employees.Find(id);

//            if (employee == null)
//            {
//                throw new NotFoundException($"User with id '{id}' not found.");
//            }

//            context.Employees.Remove(employee);
//            context.SaveChanges();
//        }
//    }
//}
            
      
