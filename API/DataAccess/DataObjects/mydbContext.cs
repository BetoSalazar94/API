using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.DataAccess.DataObjects
{
    public partial class mydbContext : DbContext
    {
        public mydbContext()
        {
        }

        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<DepartmentsEmployees> DepartmentsEmployees { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Enterprises> Enterprises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;database=mydb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>(entity =>
            {
                entity.ToTable("departments");

                entity.HasIndex(e => e.EnterprisesId)
                    .HasName("fk_departments_enterprises_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(80);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.EnterprisesId)
                    .HasColumnName("enterprises_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEnterprise)
                    .HasColumnName("id_enterprise")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(45);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(15);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.Enterprises)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.EnterprisesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_departments_enterprises");
            });

            modelBuilder.Entity<DepartmentsEmployees>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.EmployeesId })
                    .HasName("PRIMARY");

                entity.ToTable("departments_employees");

                entity.HasIndex(e => e.DepartmentsId)
                    .HasName("fk_departments_employees_departments1_idx");

                entity.HasIndex(e => e.EmployeesId)
                    .HasName("fk_departments_employees_Employees1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmployeesId)
                    .HasColumnName("Employees_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(80);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("date");

                entity.Property(e => e.DepartmentsId)
                    .HasColumnName("departments_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdDepartment)
                    .HasColumnName("id_department")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEmployee)
                    .HasColumnName("id_employee")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(45);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.Departments)
                    .WithMany(p => p.DepartmentsEmployees)
                    .HasForeignKey(d => d.DepartmentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_departments_employees_departments1");

                entity.HasOne(d => d.Employees)
                    .WithMany(p => p.DepartmentsEmployees)
                    .HasForeignKey(d => d.EmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_departments_employees_Employees1");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(80);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(45);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Enterprises>(entity =>
            {
                entity.ToTable("enterprises");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(400);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(80);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(45);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(15);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(4)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
