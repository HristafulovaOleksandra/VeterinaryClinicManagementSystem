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
    public class AnimalTypeRepository : GenericRepository<AnimalType>, IAnimalTypeRepository
    {
        public AnimalTypeRepository(VeterinaryClinicManagmentContext context) : base(context) { }
    }
}
