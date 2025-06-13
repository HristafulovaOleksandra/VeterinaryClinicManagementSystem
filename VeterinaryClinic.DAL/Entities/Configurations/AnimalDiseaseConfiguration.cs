using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VeterinaryClinic.DAL.Entities.Configurations
{
    public class AnimalDiseaseConfiguration : IEntityTypeConfiguration<AnimalDisease>
    {
        public void Configure(EntityTypeBuilder<AnimalDisease> builder)
        {
            builder.ToTable("AnimalDiseases");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.DiseaseName).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Description).HasMaxLength(255);
        }
    }
}
