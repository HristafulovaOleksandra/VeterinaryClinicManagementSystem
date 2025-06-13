using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VeterinaryClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddClinicData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalDiseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiseaseName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalDiseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimalType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSpecialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpecialtyName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSpecialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    SpecialtyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeSpecialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "EmployeeSpecialties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_HospitalDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "HospitalDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: true),
                    AnimalTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_AnimalTypes_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AnimalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HospitalRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    AnimalTypeId = table.Column<int>(type: "integer", nullable: true),
                    CurrentAnimalId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalRooms_AnimalTypes_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AnimalTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HospitalRooms_Animals_CurrentAnimalId",
                        column: x => x.CurrentAnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HospitalRooms_HospitalDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "HospitalDepartments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnimalMedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimalId = table.Column<int>(type: "integer", nullable: false),
                    DiseaseId = table.Column<int>(type: "integer", nullable: true),
                    DiagnosisDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TreatmentNotes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true),
                    RoomId = table.Column<int>(type: "integer", nullable: true),
                    AdmissionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DischargeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalMedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalMedicalRecords_AnimalDiseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "AnimalDiseases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnimalMedicalRecords_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalMedicalRecords_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnimalMedicalRecords_HospitalRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "HospitalRooms",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AnimalDiseases",
                columns: new[] { "Id", "Description", "DiseaseName" },
                values: new object[,]
                {
                    { 1, "Highly contagious viral disease affecting dogs.", "Canine Distemper" },
                    { 2, "Viral infection that can cause cancer in cats.", "Feline Leukemia" },
                    { 3, "Highly pathogenic influenza affecting birds.", "Avian Flu" },
                    { 4, "Bacterial infection common in reptiles.", "Scale Rot" },
                    { 5, "Bacterial infection affecting fish fins.", "Fin Rot" },
                    { 6, "Inflammation of the conjunctiva (eye infection).", "Conjunctivitis" },
                    { 7, "Excessive body fat accumulation.", "Obesity" },
                    { 8, "Metabolic disease affecting blood sugar levels.", "Diabetes" },
                    { 9, "Inflammation of the ear canal.", "Ear Infection" },
                    { 10, "Inflammation of the joints.", "Arthritis" },
                    { 11, "Issues with teeth and gums.", "Dental Disease" },
                    { 12, "Worms or other internal parasites.", "Parasites (Internal)" },
                    { 13, "Highly contagious respiratory disease in dogs.", "Kennel Cough" },
                    { 14, "Viral infection affecting the immune system in cats.", "Feline Immunodeficiency Virus (FIV)" },
                    { 15, "Metabolic disorder affecting joints in birds and reptiles.", "Gout" },
                    { 16, "Inflammation of the pancreas.", "Pancreatitis" }
                });

            migrationBuilder.InsertData(
                table: "AnimalTypes",
                columns: new[] { "Id", "AnimalType" },
                values: new object[,]
                {
                    { 1, "Mammals" },
                    { 2, "Birds" },
                    { 3, "Reptiles" },
                    { 4, "Fish" },
                    { 5, "Amphibians" },
                    { 6, "Invertebrates" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeSpecialties",
                columns: new[] { "Id", "SpecialtyName" },
                values: new object[,]
                {
                    { 1, "Veterinarian" },
                    { 2, "Veterinary Technician" },
                    { 3, "Receptionist" },
                    { 4, "Animal Care Assistant" },
                    { 5, "Surgeon" },
                    { 6, "Radiologist" },
                    { 7, "Dietitian" },
                    { 8, "Dog Trainer" },
                    { 9, "Physical Therapist" },
                    { 10, "Pharmacist" }
                });

            migrationBuilder.InsertData(
                table: "HospitalDepartments",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "General Practice" },
                    { 2, "Surgery" },
                    { 3, "Dermatology" },
                    { 4, "Ophthalmology" },
                    { 5, "Internal Medicine" },
                    { 6, "Emergency Care" },
                    { 7, "Diagnostics" },
                    { 8, "Rehabilitation" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 101, "123 Oak Ave, Cityville", "Alice Johnson", "555-123-4567" },
                    { 102, "456 Pine St, Townsville", "Bob Williams", "555-987-6543" },
                    { 103, "789 Maple Rd, Villagetown", "Charlie Brown", "555-555-1212" },
                    { 104, "101 Cedar Ln, Metroville", "Diana Prince", "555-333-2211" },
                    { 105, "202 Elm Ct, Suburbia", "Eve Davis", "555-777-8899" },
                    { 106, "303 Birch Dr, Countryside", "Frank White", "555-444-3322" },
                    { 107, "404 Willow Way, Lakeside", "Grace Lee", "555-111-0000" },
                    { 108, "505 Poplar Pl, Hilltop", "Henry Miller", "555-222-1111" },
                    { 109, "606 Spruce Blvd, Valleyview", "Ivy Chen", "555-666-7777" },
                    { 110, "707 Fir Cir, Forestdale", "Jack Taylor", "555-888-9999" },
                    { 111, "808 Palm Dr, Desert Springs", "Karen Green", "555-999-1122" },
                    { 112, "909 Ocean View, Coastal City", "Liam Scott", "555-000-2233" },
                    { 113, "111 Mountain Rd, Peakville", "Mia Baker", "555-112-3344" },
                    { 114, "222 Riverbend, Waterside", "Noah Hall", "555-223-4455" },
                    { 115, "333 Forest Trail, Woodlawn", "Olivia King", "555-334-5566" },
                    { 116, "444 Valley St, Greenfields", "Peter Lewis", "555-445-6677" },
                    { 117, "555 Sunset Blvd, West End", "Quinn Clark", "555-556-7788" },
                    { 118, "666 Sunrise Cir, East End", "Rachel Adams", "555-667-8899" },
                    { 119, "777 Meadow Ln, Bloomville", "Sam Turner", "555-778-9900" },
                    { 120, "888 Creek Ave, Gables", "Tina Roberts", "555-889-0011" },
                    { 121, "999 Hillside Dr, Summit", "Ursula Nelson", "555-990-1122" },
                    { 122, "1010 Pinecone Rd, Timberland", "Victor Bell", "555-001-2233" },
                    { 123, "1122 Cherry Ln, Orchards", "Wendy Cook", "555-112-3344" },
                    { 124, "1313 Elmwood St, Old Town", "Xavier Wright", "555-223-4455" },
                    { 125, "1414 Birchwood Dr, New Haven", "Yara Young", "555-334-5566" },
                    { 126, "1515 Willow Ct, Lakeside Hills", "Zoe Harris", "555-445-6677" },
                    { 127, "1616 Poplar Pl, Riverfront", "Adam Green", "555-556-7788" },
                    { 128, "1717 Spruce Blvd, Highlands", "Bella Baker", "555-667-8899" },
                    { 129, "1818 Fir Cir, Lowlands", "Caleb Carter", "555-778-9900" },
                    { 130, "1919 Cedar St, Midtown", "Daisy Dixon", "555-889-0011" },
                    { 131, "2020 Maple Rd, Uptown", "Evan Evans", "555-990-1122" },
                    { 132, "2121 Oak Hill, Countryside Est.", "Fiona Fisher", "555-001-2233" },
                    { 133, "2222 Pine Valley, Whispering Pines", "George Grant", "555-112-3344" },
                    { 134, "2323 Redwood Way, Forest Glen", "Holly Hunter", "555-223-4455" },
                    { 135, "2424 Evergreen Dr, Green Acres", "Isaac Irwin", "555-334-5566" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AnimalTypeId", "BirthDate", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Max", 101 },
                    { 2, 1, new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Whiskers", 102 },
                    { 3, 1, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Fluffy", 101 },
                    { 4, 2, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sunny", 103 },
                    { 5, 3, new DateTime(2017, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Spike", 104 },
                    { 6, 4, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Goldie", 105 },
                    { 7, 3, new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Slinky", 106 },
                    { 8, 1, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Shadow", 107 },
                    { 9, 2, new DateTime(2018, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Polly", 108 },
                    { 10, 4, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bubbles", 109 },
                    { 11, 1, new DateTime(2017, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Rex", 110 },
                    { 12, 1, new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Kitty", 102 },
                    { 13, 5, new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Dart", null },
                    { 14, 3, new DateTime(2016, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Rocky", 104 },
                    { 15, 4, new DateTime(2021, 3, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Finny", null },
                    { 16, 1, new DateTime(2019, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Buddy", 111 },
                    { 17, 1, new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Mittens", 112 },
                    { 18, 2, new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Pip", 113 },
                    { 19, 1, new DateTime(2018, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Snoopy", 114 },
                    { 20, 3, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cleo", 115 },
                    { 21, 4, new DateTime(2022, 7, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Nemo", 116 },
                    { 22, 1, new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Cuddles", 117 },
                    { 23, 3, new DateTime(2020, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Stripe", 118 },
                    { 24, 2, new DateTime(2021, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Tweety", 119 },
                    { 25, 4, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dory", 120 },
                    { 26, 1, new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Apollo", 121 },
                    { 27, 1, new DateTime(2020, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Luna", 122 },
                    { 28, 1, new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Hazel", 123 },
                    { 29, 4, new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Spuirty", 124 },
                    { 30, 2, new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Gizmo", 125 },
                    { 31, 3, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Rocky Jr.", 104 },
                    { 32, 1, new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Bella", 126 },
                    { 33, 2, new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Ollie", 127 },
                    { 34, 1, new DateTime(2018, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Smokey", 128 },
                    { 35, 3, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Zippy", 129 },
                    { 36, 4, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Finnegan", 130 },
                    { 37, 1, new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Daisy", 131 },
                    { 38, 2, new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Peanut", 132 },
                    { 39, 1, new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Koda", 133 },
                    { 40, 3, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bubba", 134 },
                    { 41, 4, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Splash", 135 },
                    { 42, 1, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Leo", null },
                    { 43, 1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Willow", null },
                    { 44, 5, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Hoppy", null },
                    { 45, 3, new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Scales", null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentId", "Name", "PhoneNumber", "SpecialtyId" },
                values: new object[,]
                {
                    { 1, "12 Main St, Cityville", 1, "Dr. Sarah Connor", "555-100-0001", 1 },
                    { 2, "34 Elm St, Townsville", 2, "Dr. John Smith", "555-100-0002", 5 },
                    { 3, "56 Pine Rd, Villagetown", 1, "Emily White", "555-100-0003", 2 },
                    { 4, "78 Oak Ave, Metroville", 3, "David Green", "555-100-0004", 1 },
                    { 5, "90 Maple Ln, Suburbia", 4, "Jessica Brown", "555-100-0005", 1 },
                    { 6, "11 Cedar Ct, Countryside", 1, "Michael Davis", "555-100-0006", 3 },
                    { 7, "22 Birch Dr, Lakeside", 6, "Olivia Wilson", "555-100-0007", 1 },
                    { 8, "33 Willow Way, Hilltop", 7, "Daniel King", "555-100-0008", 6 },
                    { 9, "44 Poplar Pl, Valleyview", 1, "Sophia Moore", "555-100-0009", 4 },
                    { 10, "55 Spruce Blvd, Forestdale", 5, "Ethan Hall", "555-100-0010", 1 },
                    { 11, "10 Elm Rd, Cityville", 1, "Dr. Laura Adams", "555-100-0011", 7 },
                    { 12, "20 Oak St, Townsville", 8, "Chris Evans", "555-100-0012", 8 },
                    { 13, "30 Pine Ave, Villagetown", 8, "Megan Fox", "555-100-0013", 9 },
                    { 14, "40 Maple Cir, Metroville", 1, "James Bond", "555-100-0014", 10 }
                });

            migrationBuilder.InsertData(
                table: "HospitalRooms",
                columns: new[] { "Id", "AnimalTypeId", "CurrentAnimalId", "DepartmentId", "RoomNumber" },
                values: new object[,]
                {
                    { 4, null, null, 2, "Room 201" },
                    { 5, null, null, 2, "Room 202" },
                    { 6, 1, null, 6, "Room 301" },
                    { 7, null, null, 6, "Room 302" },
                    { 8, null, null, 8, "Room 401" },
                    { 11, 1, null, 2, "Room 203" },
                    { 12, 2, null, 2, "Room 204" },
                    { 13, 3, null, 6, "Room 303" },
                    { 14, 4, null, 6, "Room 304" },
                    { 15, 1, null, 8, "Room 402" },
                    { 16, 2, null, 8, "Room 403" },
                    { 17, 1, null, 5, "Room 501" },
                    { 18, null, null, 5, "Room 502" },
                    { 19, null, null, 7, "Room 601" },
                    { 20, null, null, 7, "Room 602" }
                });

            migrationBuilder.InsertData(
                table: "AnimalMedicalRecords",
                columns: new[] { "Id", "AdmissionDate", "AnimalId", "DiagnosisDate", "DischargeDate", "DiseaseId", "EmployeeId", "RoomId", "TreatmentNotes" },
                values: new object[,]
                {
                    { 3, null, 3, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Routine check-up. Healthy." },
                    { 4, null, 4, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Annual wellness exam. Vaccinations given." },
                    { 6, null, 6, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, 5, 1, null, "Medicated fish food administered." },
                    { 7, null, 7, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Annual check-up. Healthy." },
                    { 9, null, 9, new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Wing clip and nail trim." },
                    { 10, null, 10, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Water quality check. Healthy." },
                    { 12, null, 12, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 12, 1, null, "Deworming medication administered." },
                    { 13, null, 13, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Rescued stray. General health check. No visible issues." },
                    { 14, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), 14, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), 15, 4, 13, "Allopurinol prescribed for gout." },
                    { 15, null, 15, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "New adoption check-up. Healthy." },
                    { 16, null, 16, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 13, 1, null, "Cough suppressants and rest advised." },
                    { 18, null, 18, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Annual check-up. Healthy." },
                    { 19, null, 19, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, 9, 1, null, "Treated with ear drops for infection." },
                    { 20, null, 20, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 4, null, "Shedding issues resolved. Proper husbandry discussed." },
                    { 21, null, 21, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "New tank setup. Water parameters stable." },
                    { 22, null, 22, new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Nail trim and dental check." },
                    { 23, null, 23, new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 4, null, "Healthy shedding, good appetite." },
                    { 24, null, 24, new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Feather health check. Good condition." },
                    { 25, null, 25, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 5, 1, null, "Antifungal treatment for fin rot." },
                    { 26, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), 26, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, 10, 10, 15, "Started pain management for arthritis." },
                    { 27, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), 27, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), 8, 10, 17, "Insulin therapy initiated for diabetes." },
                    { 28, null, 28, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Routine check-up. Healthy." },
                    { 29, null, 29, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 4, null, "Shell health examination. Good." },
                    { 30, null, 30, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Annual check-up and beak trim." },
                    { 31, null, 31, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 4, null, "New pet exam. Healthy." },
                    { 32, null, 32, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Vaccinations updated. Healthy." },
                    { 33, null, 33, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 1, null, "Wing health check. Good." },
                    { 34, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), 34, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 14, 1, 18, "FIV positive. Discussed care plan." },
                    { 35, null, 35, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 4, null, "Routine check-up. Healthy." }
                });

            migrationBuilder.InsertData(
                table: "HospitalRooms",
                columns: new[] { "Id", "AnimalTypeId", "CurrentAnimalId", "DepartmentId", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "Room 101" },
                    { 2, 1, 2, 1, "Room 102" },
                    { 3, 1, 3, 1, "Room 103" },
                    { 9, 1, 8, 1, "Room 104" },
                    { 10, 1, 11, 1, "Room 105" }
                });

            migrationBuilder.InsertData(
                table: "AnimalMedicalRecords",
                columns: new[] { "Id", "AdmissionDate", "AnimalId", "DiagnosisDate", "DischargeDate", "DiseaseId", "EmployeeId", "RoomId", "TreatmentNotes" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), 6, 1, 1, "Treated with antibiotic eye drops. Follow-up in 7 days." },
                    { 2, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Utc), 9, 1, 2, "Prescribed ear cleaner and anti-inflammatory medication." },
                    { 5, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), 4, 4, 3, "Topical antiseptic applied. Monitor for improvement." },
                    { 8, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), 11, 1, 9, "Dental cleaning scheduled. Minor gum inflammation." },
                    { 11, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc), 11, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc), null, 7, 10, 10, "Dietary changes and exercise plan recommended." },
                    { 17, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), 17, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), 2, 1, 2, "FLV positive. Discussed management options." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalMedicalRecords_AnimalId",
                table: "AnimalMedicalRecords",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalMedicalRecords_DiseaseId",
                table: "AnimalMedicalRecords",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalMedicalRecords_EmployeeId",
                table: "AnimalMedicalRecords",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalMedicalRecords_RoomId",
                table: "AnimalMedicalRecords",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalTypeId",
                table: "Animals",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_OwnerId",
                table: "Animals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SpecialtyId",
                table: "Employees",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRooms_AnimalTypeId",
                table: "HospitalRooms",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRooms_CurrentAnimalId",
                table: "HospitalRooms",
                column: "CurrentAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRooms_DepartmentId",
                table: "HospitalRooms",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalMedicalRecords");

            migrationBuilder.DropTable(
                name: "AnimalDiseases");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "HospitalRooms");

            migrationBuilder.DropTable(
                name: "EmployeeSpecialties");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "HospitalDepartments");

            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
