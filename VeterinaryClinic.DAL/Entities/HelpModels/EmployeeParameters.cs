using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Entities.HelpModels
{
    public class EmployeeParameters : QueryStringParameters
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int? DepartmentId { get; set; }
        public int? SpecialtyId { get; set; }
    }
}
