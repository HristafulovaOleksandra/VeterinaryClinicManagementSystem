﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.DAL.Entities;

namespace VeterinaryClinic.DAL.Repositories.Interfaces
{
    public interface IAnimalMedicalRecordRepository : IGenericRepository<AnimalMedicalRecord> 
    {
        IQueryable<AnimalMedicalRecord> GetAllQueryable();
        Task<AnimalMedicalRecord> GetCompleteEntityAsync(int id);
    }
}
