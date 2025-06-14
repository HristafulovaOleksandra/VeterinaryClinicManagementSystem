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
    public class HospitalDepartmentRepository : GenericRepository<HospitalDepartment>, IHospitalDepartmentRepository
    {
        public HospitalDepartmentRepository(VeterinaryClinicManagmentContext context) : base(context) { }
    }

}
