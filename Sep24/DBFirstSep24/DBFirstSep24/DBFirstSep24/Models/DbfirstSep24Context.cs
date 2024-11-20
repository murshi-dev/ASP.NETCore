using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirstSep24.Models;

public partial class DbfirstSep24Context : DbContext
{
    public DbfirstSep24Context()
    {
    }

    public DbfirstSep24Context(DbContextOptions<DbfirstSep24Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    //delete OnCongiguring() method

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED49E5BF03");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentName).HasMaxLength(255);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F1101A02300");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeName).HasMaxLength(255);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Employee__Depart__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
