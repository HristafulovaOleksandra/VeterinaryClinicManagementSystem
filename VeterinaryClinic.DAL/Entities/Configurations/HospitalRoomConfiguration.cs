using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VeterinaryClinic.DAL.Entities.Configurations
{
    public class HospitalRoomConfiguration : IEntityTypeConfiguration<HospitalRoom>
    {
        public void Configure(EntityTypeBuilder<HospitalRoom> builder)
        {
            builder.ToTable("HospitalRooms");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.RoomNumber).IsRequired().HasMaxLength(10);

            builder.HasOne(r => r.Department)
                   .WithMany(d => d.HospitalRooms)
                   .HasForeignKey(r => r.DepartmentId);

            builder.HasOne(r => r.AnimalType)
                   .WithMany(t => t.HospitalRooms)
                   .HasForeignKey(r => r.AnimalTypeId);

            builder.HasOne(r => r.CurrentAnimal)
                   .WithMany()
                   .HasForeignKey(r => r.CurrentAnimalId);
        }
    }
}
