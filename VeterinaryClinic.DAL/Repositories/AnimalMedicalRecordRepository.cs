using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.DAL.Data;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.Repositories.Interfaces;

namespace VeterinaryClinic.DAL.Repositories
{
    public class AnimalMedicalRecordRepository : GenericRepository<AnimalMedicalRecord>, IAnimalMedicalRecordRepository
    {
        public AnimalMedicalRecordRepository(VeterinaryClinicManagmentContext context) : base(context) { }

        public override async Task<AnimalMedicalRecord> GetCompleteEntityAsync(int id)
        {
            return await _dbSet
                .Include(r => r.Animal)
                .Include(r => r.Disease)
                .Include(r => r.Employee)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }

}
