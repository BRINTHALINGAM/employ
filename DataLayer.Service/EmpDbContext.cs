using System;
using System.Collections.Generic;
using DataLayer.Service.DQ;
using employ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace DataLayer.Service;

public partial class EmpDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public EmpDbContext(IConfiguration configuration)
    {
        _configuration = configuration;

    }

    public EmpDbContext(DbContextOptions<EmpDbContext> options, IConfiguration configuration)
             : base(options)
    {
        _configuration = configuration;
    }
 

    public DbSet<EmpDTO> Employees { get; set; }
    public DbSet<DeptDTO> Department { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("EmpDbConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 

        modelBuilder.Entity<EmpDTO>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmployeeName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(e => e.Department)
             .WithMany(d => d.Employees)
             .HasForeignKey(e => e.DepartmentId)
             .HasConstraintName("FK_Employee_Department");
        });

        modelBuilder.Entity<DeptDTO>(entity =>
        {
            entity.HasKey(d => d.DepartmentId);
            entity.ToTable("Department");

            entity.Property(d => d.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(d => d.DepartmentName).HasMaxLength(100).IsRequired();
            entity.Property(d => d.DepartmentDescription).HasMaxLength(250);
            entity.Property(d => d.CreatedDate).HasColumnType("DateOnly");
        });
        base.OnModelCreating(modelBuilder);
    }
}
