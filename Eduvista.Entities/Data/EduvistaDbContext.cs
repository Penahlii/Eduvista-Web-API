using Eduvista.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eduvista.Entities.Data;

public class EduvistaDbContext : IdentityDbContext<CustomIdentityUser>
{
    public EduvistaDbContext(DbContextOptions<EduvistaDbContext> options) : base(options) { }

    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Class> Classes { get; set; }
    public virtual DbSet<ClassRoom> ClassRooms { get; set; }
    public virtual DbSet<ClassRoutine> ClassRoutines { get; set; }
    public virtual DbSet<Parent> Parents { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Teacher> Teachers { get; set; }
    public virtual DbSet<Subject> Subjects { get; set; }   
}
