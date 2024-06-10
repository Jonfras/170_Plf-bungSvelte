using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DepartmentsDb;

public partial class DepartmentsContext : DbContext
{
    public DepartmentsContext()
    {
    }

    public DepartmentsContext(DbContextOptions<DepartmentsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\mssqllocaldb;attachdbfilename=C:\\Temp\\departments\\departments.mdf;integrated security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentEmployee>(entity =>
        {
            entity.HasIndex(e => e.DepartmentId, "IX_DepartmentEmployees_DepartmentId");

            entity.HasIndex(e => e.EmployeeId, "IX_DepartmentEmployees_EmployeeId");

            entity.HasOne(d => d.Department).WithMany(p => p.DepartmentEmployees).HasForeignKey(d => d.DepartmentId);

            entity.HasOne(d => d.Employee).WithMany(p => p.DepartmentEmployees).HasForeignKey(d => d.EmployeeId);
        });

        modelBuilder.Entity<EmployeeSkill>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_EmployeeSkills_EmployeeId");

            entity.HasIndex(e => e.SkillId, "IX_EmployeeSkills_SkillId");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeSkills).HasForeignKey(d => d.EmployeeId);

            entity.HasOne(d => d.Skill).WithMany(p => p.EmployeeSkills).HasForeignKey(d => d.SkillId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
