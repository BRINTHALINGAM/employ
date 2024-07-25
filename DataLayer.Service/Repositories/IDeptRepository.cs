using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using employ.Models;
using DataLayer.Service.DQ;

namespace DataLayer.Service.Repositories
{
    public interface IDeptRepository
    {
        IEnumerable<DeptDTO> GetAll();
        DeptDTO Get(int id);
        void Insert(DeptDTO department);
        void Update(DeptDTO department);
        void Delete(int id);
    }
}