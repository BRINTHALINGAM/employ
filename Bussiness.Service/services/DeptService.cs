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
    public class DeptService : IDeptService
    {
        private readonly IDeptRepository _deptRepository;

        public DeptService(IDeptRepository deptRepository)
        {
            _deptRepository = deptRepository;
        }

        public IEnumerable<DeptDTO> GetAllDepartments() => _deptRepository.GetAll();

        public DeptDTO GetDepartmentById(int id) => _deptRepository.Get(id);

        public void AddDepartment(DeptDTO department) => _deptRepository.Insert(department);

        public void UpdateDepartment(DeptDTO department) => _deptRepository.Update(department);

        public void DeleteDepartment(int id) => _deptRepository.Delete(id);
    }
}