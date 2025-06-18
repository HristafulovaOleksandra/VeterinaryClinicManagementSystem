using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.DAL.Entities;

namespace VeterinaryClinic.DAL.Repositories.Interfaces
{
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        Task<IEnumerable<Animal>> GetAnimalsByOwnerIdAsync(int ownerId);
        IQueryable<Animal> GetAllQueryable();
    }
}
