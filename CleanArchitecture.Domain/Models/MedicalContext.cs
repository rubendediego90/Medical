using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CleanArchitecture.Domain.ModelTEST
{
    public partial class MedicalContext : DbContext
    {
        public MedicalContext()
        {
        }

        public MedicalContext(DbContextOptions<MedicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Availability> Availabilities { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<PersonRole> PersonRoles { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<ScheduleWork> ScheduleWorks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-5RMEKHD;Database=Medical;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConsultationReason).HasMaxLength(100);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Appointme__Emplo__35BCFE0A");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__Appointme__Perso__34C8D9D1");
            });

            modelBuilder.Entity<Availability>(entity =>
            {
                entity.ToTable("Availability");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Availabilities)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Availabil__Emplo__38996AB5");
            });


            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Dni)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email).HasMaxLength(75);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName1).HasMaxLength(50);

                entity.Property(e => e.LastName2).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.Property(e => e.Password).HasMaxLength(10);
            });

            modelBuilder.Entity<PersonRole>(entity =>
            {
                entity.ToTable("PersonRole");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonRoles)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__PersonRol__Perso__286302EC");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PersonRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__PersonRol__RoleI__29572725");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DRole)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ScheduleWork>(entity =>
            {
                entity.ToTable("ScheduleWork");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DayWeek)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ScheduleWorks)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__ScheduleW__Emplo__31EC6D26");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
