using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VeterinaryClinic.DAL.Entities.Configurations
{
    public class AnimalMedicalRecordConfiguration : IEntityTypeConfiguration<AnimalMedicalRecord>
    {
        public void Configure(EntityTypeBuilder<AnimalMedicalRecord> builder)
        {
            builder.ToTable("AnimalMedicalRecords");
            builder.HasKey(mr => mr.Id);

            builder.Property(mr => mr.DiagnosisDate).IsRequired();
            builder.Property(mr => mr.TreatmentNotes).HasMaxLength(500);

            builder.HasOne(mr => mr.Animal)
                   .WithMany(a => a.MedicalRecords)
                   .HasForeignKey(mr => mr.AnimalId);

            builder.HasOne(mr => mr.Disease)
                   .WithMany(d => d.MedicalRecords)
                   .HasForeignKey(mr => mr.DiseaseId);

            builder.HasOne(mr => mr.Employee)
                   .WithMany(e => e.MedicalRecords)
                   .HasForeignKey(mr => mr.EmployeeId);

            builder.HasOne(mr => mr.Room)
                   .WithMany(r => r.MedicalRecords)
                   .HasForeignKey(mr => mr.RoomId);
        }
    }
}
