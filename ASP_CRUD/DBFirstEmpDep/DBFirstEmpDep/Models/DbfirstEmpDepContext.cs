using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirstEmpDep.Models;

public partial class DbfirstEmpDepContext : DbContext
{
    public DbfirstEmpDepContext()
    {
    }

    public DbfirstEmpDepContext(DbContextOptions<DbfirstEmpDepContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepId).HasName("PK__Departme__DB9CAA5FF308752D");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentName).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F116213ED91");

            entity.ToTable("Employee");

            entity.Property(e => e.DateOfJoin).HasColumnType("date");
            entity.Property(e => e.EmployeeName).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Dep).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepId)
                .HasConstraintName("FK__Employee__DepId__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
