using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.DAL.Data;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.Entities.HelpModels;
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
        public IQueryable<AnimalMedicalRecord> GetAllQueryable()
        {
            return _dbSet.AsQueryable();
        }
        public async Task<IEnumerable<AnimalMedicalRecord>> GetAllAsync(AnimalMedicalRecordParameters parameters)
        {
            return await _context.AnimalMedicalRecords.ToListAsync();
        }
    }

}
