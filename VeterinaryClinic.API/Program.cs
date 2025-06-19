using Microsoft.AspNetCore.Identity;
using VeterinaryClinic.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.DAL.Data;
using VeterinaryClinic.BLL;
using Serilog;
using Mapster;
using FluentValidation.AspNetCore;
using VeterinaryClinic.BLL.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation;
using VeterinaryClinic.DAL;

var builder = WebApplication.CreateBuilder(args);

var jwtSection = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSection["Key"];
if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
{
    throw new ArgumentException("JWT key must be configured and at least 32 characters long.");
}
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));


builder.Host.UseSerilog((ctx, services, cfg) =>
    cfg.ReadFrom.Configuration(ctx.Configuration)
       .ReadFrom.Services(services)
       .Enrich.FromLogContext());


builder.Services.AddDbContext<VeterinaryClinicManagmentContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<VeterinaryClinicManagmentContext>()
    .AddDefaultTokenProviders();

// 4. JWT аутентифікація
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSection["Issuer"],
            ValidateAudience = true,
            ValidAudience = jwtSection["Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key
        };
    });


builder.Services.AddAuthorization();


builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddBusinessLogic();
builder.Services.AddMapster();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateAnimalDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
