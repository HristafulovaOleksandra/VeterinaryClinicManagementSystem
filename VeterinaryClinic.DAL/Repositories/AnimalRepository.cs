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
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(VeterinaryClinicManagmentContext context) : base(context) { }

        public async Task<IEnumerable<Animal>> GetAnimalsByOwnerIdAsync(int ownerId)
        {
            return await _dbSet.Where(a => a.OwnerId == ownerId).ToListAsync();
        }

        public override async Task<Animal> GetCompleteEntityAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Owner)
                .Include(a => a.AnimalType)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public IQueryable<Animal> GetAllQueryable()
        {
            return _dbSet.AsQueryable();
        }
    }

}
