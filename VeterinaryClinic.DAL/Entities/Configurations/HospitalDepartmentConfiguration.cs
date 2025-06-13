using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VeterinaryClinic.DAL.Entities.Configurations
{
    public class HospitalDepartmentConfiguration : IEntityTypeConfiguration<HospitalDepartment>
    {
        public void Configure(EntityTypeBuilder<HospitalDepartment> builder)
        {
            builder.ToTable("HospitalDepartments");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.DepartmentName).IsRequired().HasMaxLength(50);
        }
    }
}
