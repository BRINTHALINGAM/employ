using DataLayer.Service.DQ;
using DataLayer.Service.Repositories;
using employ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Service.services
{
    public class EmpService : IEmpService
    {
        private readonly IEmpRepository _empRepository;
        private readonly IDeptRepository _deptRepository;
        public EmpService(IEmpRepository empRepository, IDeptRepository deptRepository)
        {
            _empRepository = empRepository ?? throw new ArgumentNullException(nameof(empRepository));
            _deptRepository = deptRepository ?? throw new ArgumentNullException(nameof(deptRepository));
        }

        public IEnumerable<EmpDTO> GetAllEmployees() => _empRepository.GetAll();

        public EmpDTO GetEmployeeById(int id) => _empRepository.Get(id);

        public void AddEmployee(EmpDTO employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            var department = _deptRepository.Get(employee.DepartmentId);

            if (department == null)
                throw new Exception("Department not found");

            employee.Department = department;

            _empRepository.Insert(employee);
        }

        public void UpdateEmployee(EmpDTO employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            var department = _deptRepository.Get(employee.DepartmentId);

            if (department == null)
                throw new Exception("Department not found");

            employee.Department = department;

            _empRepository.Update(employee);
        }

        public void DeleteEmployee(int id) => _empRepository.Delete(id);
    }
}
