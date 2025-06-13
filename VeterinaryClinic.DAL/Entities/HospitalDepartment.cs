using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Entities
{
    public class HospitalDepartment
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<HospitalRoom> HospitalRooms { get; set; } = new List<HospitalRoom>();
    }

}
