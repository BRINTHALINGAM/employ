using employ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Service.DQ;
namespace Bussiness.Service.services
{
    public interface IDeptService
    {
        IEnumerable<DeptDTO> GetAllDepartments();
        DeptDTO GetDepartmentById(int id);
        void AddDepartment(DeptDTO department);
        void UpdateDepartment(DeptDTO department);
        void DeleteDepartment(int id);
    }
}
