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
    public class HospitalRoomRepository : GenericRepository<HospitalRoom>, IHospitalRoomRepository
    {
        public HospitalRoomRepository(VeterinaryClinicManagmentContext context) : base(context) { }
        public IQueryable<HospitalRoom> GetAllQueryable()
        {
            return _dbSet.AsQueryable();
        }
    }

}
