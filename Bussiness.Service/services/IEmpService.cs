using DataLayer.Service.DQ;
using employ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Service.services
{
    public interface IEmpService
    {
        IEnumerable<EmpDTO> GetAllEmployees();
        EmpDTO GetEmployeeById(int id);
        void AddEmployee(EmpDTO employee);
        void UpdateEmployee(EmpDTO employee);
        void DeleteEmployee(int id);
    }
}