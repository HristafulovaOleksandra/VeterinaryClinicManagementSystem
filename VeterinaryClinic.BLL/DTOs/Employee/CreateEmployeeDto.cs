using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.BLL.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
        public int DepartmentId { get; set; }
        public int? SpecialtyId { get; set; }
    }
}
