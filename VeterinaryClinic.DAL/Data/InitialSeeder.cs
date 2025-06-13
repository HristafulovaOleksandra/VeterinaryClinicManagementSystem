using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.DAL.Entities;

namespace VeterinaryClinic.DAL.Data
{
    public static class InitialSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalType>().HasData(
                new AnimalType { Id = 1, AnimalTypeName = "Mammals" },
                new AnimalType { Id = 2, AnimalTypeName = "Birds" },
                new AnimalType { Id = 3, AnimalTypeName = "Reptiles" },
                new AnimalType { Id = 4, AnimalTypeName = "Fish" },
                new AnimalType { Id = 5, AnimalTypeName = "Amphibians" },
                new AnimalType { Id = 6, AnimalTypeName = "Invertebrates" }
            );
            modelBuilder.Entity<Owner>().HasData(
                new Owner { Id = 101, Name = "Alice Johnson", PhoneNumber = "555-123-4567", Address = "123 Oak Ave, Cityville" },
                new Owner { Id = 102, Name = "Bob Williams", PhoneNumber = "555-987-6543", Address = "456 Pine St, Townsville" },
                new Owner { Id = 103, Name = "Charlie Brown", PhoneNumber = "555-555-1212", Address = "789 Maple Rd, Villagetown" },
                new Owner { Id = 104, Name = "Diana Prince", PhoneNumber = "555-333-2211", Address = "101 Cedar Ln, Metroville" },
                new Owner { Id = 105, Name = "Eve Davis", PhoneNumber = "555-777-8899", Address = "202 Elm Ct, Suburbia" },
                new Owner { Id = 106, Name = "Frank White", PhoneNumber = "555-444-3322", Address = "303 Birch Dr, Countryside" },
                new Owner { Id = 107, Name = "Grace Lee", PhoneNumber = "555-111-0000", Address = "404 Willow Way, Lakeside" },
                new Owner { Id = 108, Name = "Henry Miller", PhoneNumber = "555-222-1111", Address = "505 Poplar Pl, Hilltop" },
                new Owner { Id = 109, Name = "Ivy Chen", PhoneNumber = "555-666-7777", Address = "606 Spruce Blvd, Valleyview" },
                new Owner { Id = 110, Name = "Jack Taylor", PhoneNumber = "555-888-9999", Address = "707 Fir Cir, Forestdale" },
                new Owner { Id = 111, Name = "Karen Green", PhoneNumber = "555-999-1122", Address = "808 Palm Dr, Desert Springs" },
                new Owner { Id = 112, Name = "Liam Scott", PhoneNumber = "555-000-2233", Address = "909 Ocean View, Coastal City" },
                new Owner { Id = 113, Name = "Mia Baker", PhoneNumber = "555-112-3344", Address = "111 Mountain Rd, Peakville" },
                new Owner { Id = 114, Name = "Noah Hall", PhoneNumber = "555-223-4455", Address = "222 Riverbend, Waterside" },
                new Owner { Id = 115, Name = "Olivia King", PhoneNumber = "555-334-5566", Address = "333 Forest Trail, Woodlawn" },
                new Owner { Id = 116, Name = "Peter Lewis", PhoneNumber = "555-445-6677", Address = "444 Valley St, Greenfields" },
                new Owner { Id = 117, Name = "Quinn Clark", PhoneNumber = "555-556-7788", Address = "555 Sunset Blvd, West End" },
                new Owner { Id = 118, Name = "Rachel Adams", PhoneNumber = "555-667-8899", Address = "666 Sunrise Cir, East End" },
                new Owner { Id = 119, Name = "Sam Turner", PhoneNumber = "555-778-9900", Address = "777 Meadow Ln, Bloomville" },
                new Owner { Id = 120, Name = "Tina Roberts", PhoneNumber = "555-889-0011", Address = "888 Creek Ave, Gables" },
                new Owner { Id = 121, Name = "Ursula Nelson", PhoneNumber = "555-990-1122", Address = "999 Hillside Dr, Summit" },
                new Owner { Id = 122, Name = "Victor Bell", PhoneNumber = "555-001-2233", Address = "1010 Pinecone Rd, Timberland" },
                new Owner { Id = 123, Name = "Wendy Cook", PhoneNumber = "555-112-3344", Address = "1122 Cherry Ln, Orchards" },
                new Owner { Id = 124, Name = "Xavier Wright", PhoneNumber = "555-223-4455", Address = "1313 Elmwood St, Old Town" },
                new Owner { Id = 125, Name = "Yara Young", PhoneNumber = "555-334-5566", Address = "1414 Birchwood Dr, New Haven" },
                new Owner { Id = 126, Name = "Zoe Harris", PhoneNumber = "555-445-6677", Address = "1515 Willow Ct, Lakeside Hills" },
                new Owner { Id = 127, Name = "Adam Green", PhoneNumber = "555-556-7788", Address = "1616 Poplar Pl, Riverfront" },
                new Owner { Id = 128, Name = "Bella Baker", PhoneNumber = "555-667-8899", Address = "1717 Spruce Blvd, Highlands" },
                new Owner { Id = 129, Name = "Caleb Carter", PhoneNumber = "555-778-9900", Address = "1818 Fir Cir, Lowlands" },
                new Owner { Id = 130, Name = "Daisy Dixon", PhoneNumber = "555-889-0011", Address = "1919 Cedar St, Midtown" },
                new Owner { Id = 131, Name = "Evan Evans", PhoneNumber = "555-990-1122", Address = "2020 Maple Rd, Uptown" },
                new Owner { Id = 132, Name = "Fiona Fisher", PhoneNumber = "555-001-2233", Address = "2121 Oak Hill, Countryside Est." },
                new Owner { Id = 133, Name = "George Grant", PhoneNumber = "555-112-3344", Address = "2222 Pine Valley, Whispering Pines" },
                new Owner { Id = 134, Name = "Holly Hunter", PhoneNumber = "555-223-4455", Address = "2323 Redwood Way, Forest Glen" },
                new Owner { Id = 135, Name = "Isaac Irwin", PhoneNumber = "555-334-5566", Address = "2424 Evergreen Dr, Green Acres" }
            );
            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, Name = "Max", BirthDate = new DateTime(2020, 03, 15, 0, 0, 0, DateTimeKind.Utc), OwnerId = 101, AnimalTypeId = 1 },
                new Animal { Id = 2, Name = "Whiskers", BirthDate = new DateTime(2019, 07, 22, 0, 0, 0, DateTimeKind.Utc), OwnerId = 102, AnimalTypeId = 1 },
                new Animal { Id = 3, Name = "Fluffy", BirthDate = new DateTime(2021, 01, 10, 0, 0, 0, DateTimeKind.Utc), OwnerId = 101, AnimalTypeId = 1 },
                new Animal { Id = 4, Name = "Sunny", BirthDate = new DateTime(2018, 05, 01, 0, 0, 0, DateTimeKind.Utc), OwnerId = 103, AnimalTypeId = 2 },
                new Animal { Id = 5, Name = "Spike", BirthDate = new DateTime(2017, 11, 20, 0, 0, 0, DateTimeKind.Utc), OwnerId = 104, AnimalTypeId = 3 },
                new Animal { Id = 6, Name = "Goldie", BirthDate = new DateTime(2022, 02, 28, 0, 0, 0, DateTimeKind.Utc), OwnerId = 105, AnimalTypeId = 4 },
                new Animal { Id = 7, Name = "Slinky", BirthDate = new DateTime(2020, 09, 05, 0, 0, 0, DateTimeKind.Utc), OwnerId = 106, AnimalTypeId = 3 },
                new Animal { Id = 8, Name = "Shadow", BirthDate = new DateTime(2019, 04, 12, 0, 0, 0, DateTimeKind.Utc), OwnerId = 107, AnimalTypeId = 1 },
                new Animal { Id = 9, Name = "Polly", BirthDate = new DateTime(2018, 06, 25, 0, 0, 0, DateTimeKind.Utc), OwnerId = 108, AnimalTypeId = 2 },
                new Animal { Id = 10, Name = "Bubbles", BirthDate = new DateTime(2021, 12, 01, 0, 0, 0, DateTimeKind.Utc), OwnerId = 109, AnimalTypeId = 4 },
                new Animal { Id = 11, Name = "Rex", BirthDate = new DateTime(2017, 08, 08, 0, 0, 0, DateTimeKind.Utc), OwnerId = 110, AnimalTypeId = 1 },
                new Animal { Id = 12, Name = "Kitty", BirthDate = new DateTime(2020, 10, 30, 0, 0, 0, DateTimeKind.Utc), OwnerId = 102, AnimalTypeId = 1 },
                new Animal { Id = 13, Name = "Dart", BirthDate = new DateTime(2022, 04, 18, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 5 },
                new Animal { Id = 14, Name = "Rocky", BirthDate = new DateTime(2016, 02, 14, 0, 0, 0, DateTimeKind.Utc), OwnerId = 104, AnimalTypeId = 3 },
                new Animal { Id = 15, Name = "Finny", BirthDate = new DateTime(2021, 03, 20, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 4 },
                new Animal { Id = 16, Name = "Buddy", BirthDate = new DateTime(2019, 01, 20, 0, 0, 0, DateTimeKind.Utc), OwnerId = 111, AnimalTypeId = 1 },
                new Animal { Id = 17, Name = "Mittens", BirthDate = new DateTime(2020, 05, 05, 0, 0, 0, DateTimeKind.Utc), OwnerId = 112, AnimalTypeId = 1 },
                new Animal { Id = 18, Name = "Pip", BirthDate = new DateTime(2022, 06, 12, 0, 0, 0, DateTimeKind.Utc), OwnerId = 113, AnimalTypeId = 2 },
                new Animal { Id = 19, Name = "Snoopy", BirthDate = new DateTime(2018, 09, 10, 0, 0, 0, DateTimeKind.Utc), OwnerId = 114, AnimalTypeId = 1 },
                new Animal { Id = 20, Name = "Cleo", BirthDate = new DateTime(2021, 03, 01, 0, 0, 0, DateTimeKind.Utc), OwnerId = 115, AnimalTypeId = 3 },
                new Animal { Id = 21, Name = "Nemo", BirthDate = new DateTime(2022, 07, 25, 0, 0, 0, DateTimeKind.Utc), OwnerId = 116, AnimalTypeId = 4 },
                new Animal { Id = 22, Name = "Cuddles", BirthDate = new DateTime(2019, 11, 11, 0, 0, 0, DateTimeKind.Utc), OwnerId = 117, AnimalTypeId = 1 },
                new Animal { Id = 23, Name = "Stripe", BirthDate = new DateTime(2020, 02, 14, 0, 0, 0, DateTimeKind.Utc), OwnerId = 118, AnimalTypeId = 3 },
                new Animal { Id = 24, Name = "Tweety", BirthDate = new DateTime(2021, 04, 03, 0, 0, 0, DateTimeKind.Utc), OwnerId = 119, AnimalTypeId = 2 },
                new Animal { Id = 25, Name = "Dory", BirthDate = new DateTime(2022, 09, 01, 0, 0, 0, DateTimeKind.Utc), OwnerId = 120, AnimalTypeId = 4 },
                new Animal { Id = 26, Name = "Apollo", BirthDate = new DateTime(2018, 12, 01, 0, 0, 0, DateTimeKind.Utc), OwnerId = 121, AnimalTypeId = 1 },
                new Animal { Id = 27, Name = "Luna", BirthDate = new DateTime(2020, 08, 18, 0, 0, 0, DateTimeKind.Utc), OwnerId = 122, AnimalTypeId = 1 },
                new Animal { Id = 28, Name = "Hazel", BirthDate = new DateTime(2021, 06, 05, 0, 0, 0, DateTimeKind.Utc), OwnerId = 123, AnimalTypeId = 1 },
                new Animal { Id = 29, Name = "Spuirty", BirthDate = new DateTime(2022, 01, 30, 0, 0, 0, DateTimeKind.Utc), OwnerId = 124, AnimalTypeId = 4 },
                new Animal { Id = 30, Name = "Gizmo", BirthDate = new DateTime(2019, 03, 22, 0, 0, 0, DateTimeKind.Utc), OwnerId = 125, AnimalTypeId = 2 },
                new Animal { Id = 31, Name = "Rocky Jr.", BirthDate = new DateTime(2023, 01, 15, 0, 0, 0, DateTimeKind.Utc), OwnerId = 104, AnimalTypeId = 3 },
                new Animal { Id = 32, Name = "Bella", BirthDate = new DateTime(2020, 11, 20, 0, 0, 0, DateTimeKind.Utc), OwnerId = 126, AnimalTypeId = 1 },
                new Animal { Id = 33, Name = "Ollie", BirthDate = new DateTime(2021, 02, 10, 0, 0, 0, DateTimeKind.Utc), OwnerId = 127, AnimalTypeId = 2 },
                new Animal { Id = 34, Name = "Smokey", BirthDate = new DateTime(2018, 07, 07, 0, 0, 0, DateTimeKind.Utc), OwnerId = 128, AnimalTypeId = 1 },
                new Animal { Id = 35, Name = "Zippy", BirthDate = new DateTime(2022, 04, 01, 0, 0, 0, DateTimeKind.Utc), OwnerId = 129, AnimalTypeId = 3 },
                new Animal { Id = 36, Name = "Finnegan", BirthDate = new DateTime(2023, 03, 10, 0, 0, 0, DateTimeKind.Utc), OwnerId = 130, AnimalTypeId = 4 },
                new Animal { Id = 37, Name = "Daisy", BirthDate = new DateTime(2019, 10, 25, 0, 0, 0, DateTimeKind.Utc), OwnerId = 131, AnimalTypeId = 1 },
                new Animal { Id = 38, Name = "Peanut", BirthDate = new DateTime(2020, 12, 12, 0, 0, 0, DateTimeKind.Utc), OwnerId = 132, AnimalTypeId = 2 },
                new Animal { Id = 39, Name = "Koda", BirthDate = new DateTime(2021, 05, 18, 0, 0, 0, DateTimeKind.Utc), OwnerId = 133, AnimalTypeId = 1 },
                new Animal { Id = 40, Name = "Bubba", BirthDate = new DateTime(2022, 08, 01, 0, 0, 0, DateTimeKind.Utc), OwnerId = 134, AnimalTypeId = 3 },
                new Animal { Id = 41, Name = "Splash", BirthDate = new DateTime(2023, 04, 05, 0, 0, 0, DateTimeKind.Utc), OwnerId = 135, AnimalTypeId = 4 },
                new Animal { Id = 42, Name = "Leo", BirthDate = new DateTime(2018, 04, 01, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 1 },
                new Animal { Id = 43, Name = "Willow", BirthDate = new DateTime(2020, 06, 01, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 1 },
                new Animal { Id = 44, Name = "Hoppy", BirthDate = new DateTime(2021, 09, 10, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 5 },
                new Animal { Id = 45, Name = "Scales", BirthDate = new DateTime(2022, 11, 15, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 3 }
            );
            modelBuilder.Entity<AnimalDisease>().HasData(
                new AnimalDisease { Id = 1, DiseaseName = "Canine Distemper", Description = "Highly contagious viral disease affecting dogs." },
                new AnimalDisease { Id = 2, DiseaseName = "Feline Leukemia", Description = "Viral infection that can cause cancer in cats." },
                new AnimalDisease { Id = 3, DiseaseName = "Avian Flu", Description = "Highly pathogenic influenza affecting birds." },
                new AnimalDisease { Id = 4, DiseaseName = "Scale Rot", Description = "Bacterial infection common in reptiles." },
                new AnimalDisease { Id = 5, DiseaseName = "Fin Rot", Description = "Bacterial infection affecting fish fins." },
                new AnimalDisease { Id = 6, DiseaseName = "Conjunctivitis", Description = "Inflammation of the conjunctiva (eye infection)." },
                new AnimalDisease { Id = 7, DiseaseName = "Obesity", Description = "Excessive body fat accumulation." },
                new AnimalDisease { Id = 8, DiseaseName = "Diabetes", Description = "Metabolic disease affecting blood sugar levels." },
                new AnimalDisease { Id = 9, DiseaseName = "Ear Infection", Description = "Inflammation of the ear canal." },
                new AnimalDisease { Id = 10, DiseaseName = "Arthritis", Description = "Inflammation of the joints." },
                new AnimalDisease { Id = 11, DiseaseName = "Dental Disease", Description = "Issues with teeth and gums." },
                new AnimalDisease { Id = 12, DiseaseName = "Parasites (Internal)", Description = "Worms or other internal parasites." },
                new AnimalDisease { Id = 13, DiseaseName = "Kennel Cough", Description = "Highly contagious respiratory disease in dogs." },
                new AnimalDisease { Id = 14, DiseaseName = "Feline Immunodeficiency Virus (FIV)", Description = "Viral infection affecting the immune system in cats." },
                new AnimalDisease { Id = 15, DiseaseName = "Gout", Description = "Metabolic disorder affecting joints in birds and reptiles." },
                new AnimalDisease { Id = 16, DiseaseName = "Pancreatitis", Description = "Inflammation of the pancreas." }
            );
            modelBuilder.Entity<HospitalDepartment>().HasData(
                new HospitalDepartment { Id = 1, DepartmentName = "General Practice" },
                new HospitalDepartment { Id = 2, DepartmentName = "Surgery" },
                new HospitalDepartment { Id = 3, DepartmentName = "Dermatology" },
                new HospitalDepartment { Id = 4, DepartmentName = "Ophthalmology" },
                new HospitalDepartment { Id = 5, DepartmentName = "Internal Medicine" },
                new HospitalDepartment { Id = 6, DepartmentName = "Emergency Care" },
                new HospitalDepartment { Id = 7, DepartmentName = "Diagnostics" },
                new HospitalDepartment { Id = 8, DepartmentName = "Rehabilitation" }
            );
            modelBuilder.Entity<EmployeeSpecialty>().HasData(
                new EmployeeSpecialty { Id = 1, SpecialtyName = "Veterinarian" },
                new EmployeeSpecialty { Id = 2, SpecialtyName = "Veterinary Technician" },
                new EmployeeSpecialty { Id = 3, SpecialtyName = "Receptionist" },
                new EmployeeSpecialty { Id = 4, SpecialtyName = "Animal Care Assistant" },
                new EmployeeSpecialty { Id = 5, SpecialtyName = "Surgeon" },
                new EmployeeSpecialty { Id = 6, SpecialtyName = "Radiologist" },
                new EmployeeSpecialty { Id = 7, SpecialtyName = "Dietitian" },
                new EmployeeSpecialty { Id = 8, SpecialtyName = "Dog Trainer" },
                new EmployeeSpecialty { Id = 9, SpecialtyName = "Physical Therapist" },
                new EmployeeSpecialty { Id = 10, SpecialtyName = "Pharmacist" }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Dr. Sarah Connor", PhoneNumber = "555-100-0001", Address = "12 Main St, Cityville", DepartmentId = 1, SpecialtyId = 1 },
                new Employee { Id = 2, Name = "Dr. John Smith", PhoneNumber = "555-100-0002", Address = "34 Elm St, Townsville", DepartmentId = 2, SpecialtyId = 5 },
                new Employee { Id = 3, Name = "Emily White", PhoneNumber = "555-100-0003", Address = "56 Pine Rd, Villagetown", DepartmentId = 1, SpecialtyId = 2 },
                new Employee { Id = 4, Name = "David Green", PhoneNumber = "555-100-0004", Address = "78 Oak Ave, Metroville", DepartmentId = 3, SpecialtyId = 1 },
                new Employee { Id = 5, Name = "Jessica Brown", PhoneNumber = "555-100-0005", Address = "90 Maple Ln, Suburbia", DepartmentId = 4, SpecialtyId = 1 },
                new Employee { Id = 6, Name = "Michael Davis", PhoneNumber = "555-100-0006", Address = "11 Cedar Ct, Countryside", DepartmentId = 1, SpecialtyId = 3 },
                new Employee { Id = 7, Name = "Olivia Wilson", PhoneNumber = "555-100-0007", Address = "22 Birch Dr, Lakeside", DepartmentId = 6, SpecialtyId = 1 },
                new Employee { Id = 8, Name = "Daniel King", PhoneNumber = "555-100-0008", Address = "33 Willow Way, Hilltop", DepartmentId = 7, SpecialtyId = 6 },
                new Employee { Id = 9, Name = "Sophia Moore", PhoneNumber = "555-100-0009", Address = "44 Poplar Pl, Valleyview", DepartmentId = 1, SpecialtyId = 4 },
                new Employee { Id = 10, Name = "Ethan Hall", PhoneNumber = "555-100-0010", Address = "55 Spruce Blvd, Forestdale", DepartmentId = 5, SpecialtyId = 1 },
                new Employee { Id = 11, Name = "Dr. Laura Adams", PhoneNumber = "555-100-0011", Address = "10 Elm Rd, Cityville", DepartmentId = 1, SpecialtyId = 7 },
                new Employee { Id = 12, Name = "Chris Evans", PhoneNumber = "555-100-0012", Address = "20 Oak St, Townsville", DepartmentId = 8, SpecialtyId = 8 },
                new Employee { Id = 13, Name = "Megan Fox", PhoneNumber = "555-100-0013", Address = "30 Pine Ave, Villagetown", DepartmentId = 8, SpecialtyId = 9 },
                new Employee { Id = 14, Name = "James Bond", PhoneNumber = "555-100-0014", Address = "40 Maple Cir, Metroville", DepartmentId = 1, SpecialtyId = 10 }
            );
            modelBuilder.Entity<HospitalRoom>().HasData(
            new HospitalRoom { Id = 1, RoomNumber = "Room 101", DepartmentId = 1, AnimalTypeId = 1, CurrentAnimalId = 1 },
            new HospitalRoom { Id = 2, RoomNumber = "Room 102", DepartmentId = 1, AnimalTypeId = 1, CurrentAnimalId = 2 },
            new HospitalRoom { Id = 3, RoomNumber = "Room 103", DepartmentId = 1, AnimalTypeId = 1, CurrentAnimalId = 3 },
            new HospitalRoom { Id = 4, RoomNumber = "Room 201", DepartmentId = 2, AnimalTypeId = null, CurrentAnimalId = null },
            new HospitalRoom { Id = 5, RoomNumber = "Room 202", DepartmentId = 2, AnimalTypeId = null, CurrentAnimalId = null },
            new HospitalRoom { Id = 6, RoomNumber = "Room 301", DepartmentId = 6, AnimalTypeId = 1, CurrentAnimalId = null },
            new HospitalRoom { Id = 7, RoomNumber = "Room 302", DepartmentId = 6, AnimalTypeId = null, CurrentAnimalId = null },
            new HospitalRoom { Id = 8, RoomNumber = "Room 401", DepartmentId = 8, AnimalTypeId = null, CurrentAnimalId = null },
            new HospitalRoom { Id = 9, RoomNumber = "Room 104", DepartmentId = 1, AnimalTypeId = 1, CurrentAnimalId = 8 },
            new HospitalRoom { Id = 10, RoomNumber = "Room 105", DepartmentId = 1, AnimalTypeId = 1, CurrentAnimalId = 11 },
            new HospitalRoom { Id = 11, RoomNumber = "Room 203", DepartmentId = 2, AnimalTypeId = 1, CurrentAnimalId = null },
            new HospitalRoom { Id = 12, RoomNumber = "Room 204", DepartmentId = 2, AnimalTypeId = 2, CurrentAnimalId = null },
            new HospitalRoom { Id = 13, RoomNumber = "Room 303", DepartmentId = 6, AnimalTypeId = 3, CurrentAnimalId = null },
            new HospitalRoom { Id = 14, RoomNumber = "Room 304", DepartmentId = 6, AnimalTypeId = 4, CurrentAnimalId = null },
            new HospitalRoom { Id = 15, RoomNumber = "Room 402", DepartmentId = 8, AnimalTypeId = 1, CurrentAnimalId = null },
            new HospitalRoom { Id = 16, RoomNumber = "Room 403", DepartmentId = 8, AnimalTypeId = 2, CurrentAnimalId = null },
            new HospitalRoom { Id = 17, RoomNumber = "Room 501", DepartmentId = 5, AnimalTypeId = 1, CurrentAnimalId = null },
            new HospitalRoom { Id = 18, RoomNumber = "Room 502", DepartmentId = 5, AnimalTypeId = null, CurrentAnimalId = null },
            new HospitalRoom { Id = 19, RoomNumber = "Room 601", DepartmentId = 7, AnimalTypeId = null, CurrentAnimalId = null },
            new HospitalRoom { Id = 20, RoomNumber = "Room 602", DepartmentId = 7, AnimalTypeId = null, CurrentAnimalId = null }
            );
            modelBuilder.Entity<AnimalMedicalRecord>().HasData(
            new AnimalMedicalRecord { Id = 1, AnimalId = 1, DiseaseId = 6, DiagnosisDate = new DateTime(2023, 01, 05, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Treated with antibiotic eye drops. Follow-up in 7 days.", EmployeeId = 1, RoomId = 1, AdmissionDate = new DateTime(2023, 01, 05, 0, 0, 0, DateTimeKind.Utc), DischargeDate = new DateTime(2023, 01, 08, 0, 0, 0, DateTimeKind.Utc) },
            new AnimalMedicalRecord { Id = 2, AnimalId = 2, DiseaseId = 9, DiagnosisDate = new DateTime(2023, 02, 10, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Prescribed ear cleaner and anti-inflammatory medication.", EmployeeId = 1, RoomId = 2, AdmissionDate = new DateTime(2023, 02, 10, 0, 0, 0, DateTimeKind.Utc), DischargeDate = new DateTime(2023, 02, 12, 0, 0, 0, DateTimeKind.Utc) },
            new AnimalMedicalRecord { Id = 3, AnimalId = 3, DiseaseId = null, DiagnosisDate = new DateTime(2023, 03, 01, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Routine check-up. Healthy.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 4, AnimalId = 4, DiseaseId = null, DiagnosisDate = new DateTime(2023, 04, 15, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Annual wellness exam. Vaccinations given.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 5, AnimalId = 5, DiseaseId = 4, DiagnosisDate = new DateTime(2023, 03, 01, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Topical antiseptic applied. Monitor for improvement.", EmployeeId = 4, RoomId = 3, AdmissionDate = new DateTime(2023, 03, 01, 0, 0, 0, DateTimeKind.Utc), DischargeDate = new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc) },
            new AnimalMedicalRecord { Id = 6, AnimalId = 6, DiseaseId = 5, DiagnosisDate = new DateTime(2023, 05, 10, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Medicated fish food administered.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 7, AnimalId = 7, DiseaseId = null, DiagnosisDate = new DateTime(2023, 04, 15, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Annual check-up. Healthy.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 8, AnimalId = 8, DiseaseId = 11, DiagnosisDate = new DateTime(2023, 06, 01, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Dental cleaning scheduled. Minor gum inflammation.", EmployeeId = 1, RoomId = 9, AdmissionDate = new DateTime(2023, 06, 01, 0, 0, 0, DateTimeKind.Utc), DischargeDate = new DateTime(2023, 06, 02, 0, 0, 0, DateTimeKind.Utc) },
            new AnimalMedicalRecord { Id = 9, AnimalId = 9, DiseaseId = null, DiagnosisDate = new DateTime(2023, 07, 07, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Wing clip and nail trim.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 10, AnimalId = 10, DiseaseId = null, DiagnosisDate = new DateTime(2023, 08, 12, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Water quality check. Healthy.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 11, AnimalId = 11, DiseaseId = 7, DiagnosisDate = new DateTime(2023, 05, 20, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Dietary changes and exercise plan recommended.", EmployeeId = 10, RoomId = 10, AdmissionDate = new DateTime(2023, 05, 20, 0, 0, 0, DateTimeKind.Utc), DischargeDate = null },
            new AnimalMedicalRecord { Id = 12, AnimalId = 12, DiseaseId = 12, DiagnosisDate = new DateTime(2023, 09, 01, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Deworming medication administered.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 13, AnimalId = 13, DiseaseId = null, DiagnosisDate = new DateTime(2023, 06, 01, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Rescued stray. General health check. No visible issues.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 14, AnimalId = 14, DiseaseId = 15, DiagnosisDate = new DateTime(2023, 10, 10, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Allopurinol prescribed for gout.", EmployeeId = 4, RoomId = 13, AdmissionDate = new DateTime(2023, 10, 10, 0, 0, 0, DateTimeKind.Utc), DischargeDate = new DateTime(2023, 10, 14, 0, 0, 0, DateTimeKind.Utc) },
            new AnimalMedicalRecord { Id = 15, AnimalId = 15, DiseaseId = null, DiagnosisDate = new DateTime(2023, 11, 05, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "New adoption check-up. Healthy.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 16, AnimalId = 16, DiseaseId = 13, DiagnosisDate = new DateTime(2023, 12, 01, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Cough suppressants and rest advised.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 17, AnimalId = 17, DiseaseId = 2, DiagnosisDate = new DateTime(2024, 01, 15, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "FLV positive. Discussed management options.", EmployeeId = 1, RoomId = 2, AdmissionDate = new DateTime(2024, 01, 15, 0, 0, 0, DateTimeKind.Utc), DischargeDate = new DateTime(2024, 01, 16, 0, 0, 0, DateTimeKind.Utc) },
            new AnimalMedicalRecord { Id = 18, AnimalId = 18, DiseaseId = null, DiagnosisDate = new DateTime(2024, 02, 20, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Annual check-up. Healthy.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 19, AnimalId = 19, DiseaseId = 9, DiagnosisDate = new DateTime(2024, 03, 05, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Treated with ear drops for infection.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 20, AnimalId = 20, DiseaseId = null, DiagnosisDate = new DateTime(2024, 04, 10, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Shedding issues resolved. Proper husbandry discussed.", EmployeeId = 4, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 21, AnimalId = 21, DiseaseId = null, DiagnosisDate = new DateTime(2024, 05, 01, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "New tank setup. Water parameters stable.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 22, AnimalId = 22, DiseaseId = null, DiagnosisDate = new DateTime(2024, 06, 08, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Nail trim and dental check.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 23, AnimalId = 23, DiseaseId = null, DiagnosisDate = new DateTime(2024, 07, 14, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Healthy shedding, good appetite.", EmployeeId = 4, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 24, AnimalId = 24, DiseaseId = null, DiagnosisDate = new DateTime(2024, 08, 22, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Feather health check. Good condition.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 25, AnimalId = 25, DiseaseId = 5, DiagnosisDate = new DateTime(2024, 09, 01, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Antifungal treatment for fin rot.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 26, AnimalId = 26, DiseaseId = 10, DiagnosisDate = new DateTime(2024, 10, 05, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Started pain management for arthritis.", EmployeeId = 10, RoomId = 15, AdmissionDate = new DateTime(2024, 10, 05, 0, 0, 0, DateTimeKind.Utc), DischargeDate = null },
            new AnimalMedicalRecord { Id = 27, AnimalId = 27, DiseaseId = 8, DiagnosisDate = new DateTime(2024, 11, 11, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Insulin therapy initiated for diabetes.", EmployeeId = 10, RoomId = 17, AdmissionDate = new DateTime(2024, 11, 11, 0, 0, 0, DateTimeKind.Utc), DischargeDate = new DateTime(2024, 11, 15, 0, 0, 0, DateTimeKind.Utc) },
            new AnimalMedicalRecord { Id = 28, AnimalId = 28, DiseaseId = null, DiagnosisDate = new DateTime(2024, 12, 01, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Routine check-up. Healthy.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 29, AnimalId = 29, DiseaseId = null, DiagnosisDate = new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Shell health examination. Good.", EmployeeId = 4, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 30, AnimalId = 30, DiseaseId = null, DiagnosisDate = new DateTime(2025, 02, 01, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Annual check-up and beak trim.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 31, AnimalId = 31, DiseaseId = null, DiagnosisDate = new DateTime(2025, 03, 01, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "New pet exam. Healthy.", EmployeeId = 4, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 32, AnimalId = 32, DiseaseId = null, DiagnosisDate = new DateTime(2025, 04, 05, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Vaccinations updated. Healthy.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 33, AnimalId = 33, DiseaseId = null, DiagnosisDate = new DateTime(2025, 05, 12, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Wing health check. Good.", EmployeeId = 1, RoomId = null, AdmissionDate = null, DischargeDate = null },
            new AnimalMedicalRecord { Id = 34, AnimalId = 34, DiseaseId = 14, DiagnosisDate = new DateTime(2025, 06, 01, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "FIV positive. Discussed care plan.", EmployeeId = 1, RoomId = 18, AdmissionDate = new DateTime(2025, 06, 01, 0, 0, 0, DateTimeKind.Utc), DischargeDate = null },
            new AnimalMedicalRecord { Id = 35, AnimalId = 35, DiseaseId = null, DiagnosisDate = new DateTime(2025, 06, 10, 0, 0, 0, DateTimeKind.Utc), TreatmentNotes = "Routine check-up. Healthy.", EmployeeId = 4, RoomId = null, AdmissionDate = null, DischargeDate = null }
            );

        }
    }
}