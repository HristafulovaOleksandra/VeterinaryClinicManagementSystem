using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VeterinaryClinic.DAL.Entities.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animals");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(30).IsRequired();

            builder.HasOne(a => a.Owner)
                   .WithMany(o => o.Animals)
                   .HasForeignKey(a => a.OwnerId);

            builder.HasOne(a => a.AnimalType)
                   .WithMany(t => t.Animals)
                   .HasForeignKey(a => a.AnimalTypeId);
        }
    }
}
