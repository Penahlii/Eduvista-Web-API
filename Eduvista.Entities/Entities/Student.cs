using Eduvista.Core.Repository.Abstraction;
using Eduvista.Entities.Enums;

namespace Eduvista.Entities.Entities;

public class Student : IEntity
{
    public int Id { get; set; }
    public string AdmissionNumber { get; set; }
    public DateTime AdmissionDate { get; set; }
    public string Status { get; set; }
    public string ClassName { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string BloodGroup { get; set; }
    public string Sector { get; set; }
    public string CurrentAddress { get; set; }
    public CustomIdentityUser? User { get; set; }

    // Relationships
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public ICollection<Parent> Parents { get; set; } = new List<Parent>();
}
