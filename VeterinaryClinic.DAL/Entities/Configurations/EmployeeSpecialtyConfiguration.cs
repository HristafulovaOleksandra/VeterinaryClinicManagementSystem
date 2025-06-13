using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VeterinaryClinic.DAL.Entities.Configurations
{
    public class EmployeeSpecialtyConfiguration : IEntityTypeConfiguration<EmployeeSpecialty>
    {
        public void Configure(EntityTypeBuilder<EmployeeSpecialty> builder)
        {
            builder.ToTable("EmployeeSpecialties");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.SpecialtyName).IsRequired().HasMaxLength(50);
        }
    }
}
