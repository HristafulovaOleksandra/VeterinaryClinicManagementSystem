using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Entities
{
    public class EmployeeSpecialty
    {
        public int Id { get; set; }
        public string SpecialtyName { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

}
