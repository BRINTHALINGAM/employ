using DataLayer.Service.DQ;
using employ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Service.Repositories
{
    public interface IEmpRepository
    {
        IEnumerable<EmpDTO> GetAll();
        EmpDTO Get(int id);
        void Insert(EmpDTO employees);
        void Update(EmpDTO employees);
        void Delete(int id);
    }
}