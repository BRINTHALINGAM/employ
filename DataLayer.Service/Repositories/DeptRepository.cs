using DataLayer.Service.DQ;
using employ.Models;
using System;
using System.Collections.Generic;

namespace DataLayer.Service.Repositories
{
    public class DeptRepository : IDeptRepository
    {
        private readonly DeptDbContext _context;

        public DeptRepository(DeptDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DeptDTO> GetAll() => _context.Department.ToList();

        public DeptDTO Get(int id) => _context.Department.Find(id);

        public void Insert(DeptDTO department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department));


            _context.Department.Add(department);
            _context.SaveChanges();
        }


        public void Update(DeptDTO department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department));

            _context.Department.Update(department);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dept = _context.Department.Find(id);
            if (dept != null)
            {
                _context.Department.Remove(dept);
                _context.SaveChanges();
            }
        }
    }
}

