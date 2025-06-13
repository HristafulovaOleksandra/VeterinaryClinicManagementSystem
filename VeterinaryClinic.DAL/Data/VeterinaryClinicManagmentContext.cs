using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.Data;

namespace VeterinaryClinic.DAL.Data
{
    public partial class VeterinaryClinicManagmentContext : DbContext
    {
        public VeterinaryClinicManagmentContext()
        {

        }
        public VeterinaryClinicManagmentContext(DbContextOptions<VeterinaryClinicManagmentContext> options)
            : base(options) { }
        
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AnimalDisease> AnimalDiseases { get; set; }
        public virtual DbSet<AnimalMedicalRecord> AnimalMedicalRecords { get; set; }
        public virtual DbSet<AnimalType> AnimalTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSpecialty> EmployeeSpecialtys { get; set; }
        public virtual DbSet<HospitalDepartment> HospitalDepartments { get; set; }
        public virtual DbSet<HospitalRoom> HospitalRooms { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VeterinaryClinic;Username=postgres;Password=postgres;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VeterinaryClinicManagmentContext).Assembly);
            InitialSeeder.Seed(modelBuilder);
        }

    }

}
