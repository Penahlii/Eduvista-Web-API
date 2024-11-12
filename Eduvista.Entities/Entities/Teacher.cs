using Eduvista.Core.Repository.Abstraction;
using Eduvista.Entities.Enums;

namespace Eduvista.Entities.Entities;

public class Teacher : IEntity
{
    public int Id { get; set; }
    public DateTime DateOfJoining { get; set; }
    public string Subject { get; set; }
    public Gender Gender { get; set; }
    public string BloodGroup { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string PanNumber { get; set; }
    public string Status { get; set; }
    public CustomIdentityUser? User { get; set; }

    // Relationships
    public ICollection<ClassRoutine> ClassRoutines { get; set; } = new List<ClassRoutine>();
    public ICollection<Class> Classes { get; set; } = new List<Class>();
}
