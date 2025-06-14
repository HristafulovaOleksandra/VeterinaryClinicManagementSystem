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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(VeterinaryClinicManagmentContext context) : base(context) { }
    }

}
