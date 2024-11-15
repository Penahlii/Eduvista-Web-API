using Eduvista.Business.Abstraction;
using Eduvista.Business.Concrete;
using Eduvista.DataAccess.Abstraction;
using Eduvista.DataAccess.Concrete.EFEntityFramework;
using Eduvista.Entities.Data;
using Eduvista.Entities.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Assigning The DataBase

builder.Services.AddDbContext<EduvistaDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<CustomIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<EduvistaDbContext>()
    .AddDefaultTokenProviders();

// Add Authentication for JWT Token

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Add Data Accesses

builder.Services.AddScoped<IAdminDA, EFAdminDA>();
builder.Services.AddScoped<IClassDA, EFClassDA>();
builder.Services.AddScoped<IClassRoomDA, EFClassRoomDA>();
builder.Services.AddScoped<IClassRoutineDA, EFClassRoutineDA>();
builder.Services.AddScoped<IParentDA, EFParentDA>();
builder.Services.AddScoped<IStudentDA, EFStudentDA>();
builder.Services.AddScoped<ITeacherDA, EFTeacherDA>();
builder.Services.AddScoped<ISubjectDA, EFSubjectDA>();

// Add Services

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IClassRoomService, ClassRoomService>();
builder.Services.AddScoped<IClassRoutineService, ClassRoutineService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IParentService, ParentService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
