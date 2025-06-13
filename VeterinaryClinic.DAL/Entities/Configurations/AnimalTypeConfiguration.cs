using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VeterinaryClinic.DAL.Entities.Configurations
{
    public class AnimalTypeConfiguration : IEntityTypeConfiguration<AnimalType>
    {
        public void Configure(EntityTypeBuilder<AnimalType> builder)
        {
            builder.ToTable("AnimalTypes");
            builder.HasKey(at => at.Id);
            builder.Property(at => at.AnimalTypeName)
                   .HasColumnName("AnimalType")
                   .IsRequired()
                   .HasMaxLength(30);
        }
    }
}
