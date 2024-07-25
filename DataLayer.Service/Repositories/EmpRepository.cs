using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Service.DQ;
using employ.Models;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.Service.Repositories
{

    public class EmpRepository : IEmpRepository
    {
        private readonly EmpDbContext _context;

        public EmpRepository(EmpDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EmpDTO> GetAll()
        {
            var employees = _context.Employees.Select(item => new EmpDTO
            {
                EmployeeId = item.EmployeeId,
                EmployeeName = item.EmployeeName,
                DepartmentId = item.DepartmentId,
                DepartmentName = item.Department.DepartmentName,
                Salary = item.Salary,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                UserName = item.UserName,

            }).ToList();

            return employees;
        
    }

        // public EmpDTO Get(int id) => _context.Employees.Find(id);


        public EmpDTO Get(int id)
        {
            return _context.Employees
                .Include(e => e.Department) // Ensure Department is included
                .Select(item => new EmpDTO
                {
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.EmployeeName,
                    DepartmentId = item.DepartmentId,
                    DepartmentName = item.Department.DepartmentName,
                    Salary = item.Salary,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    UserName = item.UserName,
                   
                })
                .FirstOrDefault(e => e.EmployeeId == id);
        }





        public void Insert(EmpDTO employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            var department = _context.Department.Find(employee.DepartmentId);
            if (department == null)
                throw new Exception("Department not found");

            // Attach the Department entity to the context to ensure it's not re-inserted
            _context.Attach(department);

            // Associate the department with the employee
            employee.Department = department;

            _context.Employees.Add(employee);
            _context.SaveChanges();
        }


        public void Update(EmpDTO employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

         /*   var department = _context.Department.FirstOrDefault(d => d.DepartmentId == employee.DepartmentId);

            if (department == null)
                throw new Exception("Department not found");

            // Associate the department with the employee
            employee.Department = department;*/


            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}