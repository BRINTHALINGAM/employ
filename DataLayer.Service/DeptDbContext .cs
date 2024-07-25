using employ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DataLayer.Service.DQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Service
{
    public class DeptDbContext : DbContext
    {
        public DeptDbContext(DbContextOptions<DeptDbContext> options) : base(options) { }

        public DbSet<DeptDTO> Department { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
               v => new DateTime(v.Year, v.Month, v.Day),
               v => new DateOnly(v.Year, v.Month, v.Day));


            modelBuilder.Entity<DeptDTO>(entity =>
            {

                entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD18B1E556");

                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.DepartmentName).HasMaxLength(100);
            });




            modelBuilder.Entity<DeptDTO>()
                .Property(e => e.CreatedDate)
                .HasConversion(dateOnlyConverter);
        }
    }

}
