using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Entities.HelpModels
{
    public class AnimalParameters : QueryStringParameters
    {
        public string? Name { get; set; }

        // Count BirthDate by age
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        // Filter by Animal Type
        public int? AnimalTypeId { get; set; }

        // Filter by Owneer
        public int? OwnerId { get; set; }
    }
}
