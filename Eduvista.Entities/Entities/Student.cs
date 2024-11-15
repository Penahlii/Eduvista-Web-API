using Eduvista.Core.Repository.Abstraction;
using Eduvista.Entities.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Eduvista.Entities.Entities;

public class Student : IEntity
{
    public int Id { get; set; }
    public string AdmissionNumber { get; set; }
    public DateTime AdmissionDate { get; set; }
    public bool Status { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    [AllowNull]
    public string? Sector { get; set; }
    public string CurrentAddress { get; set; }
    public CustomIdentityUser? User { get; set; }

    // Relationships
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public ICollection<Parent> Parents { get; set; } = new List<Parent>();
}
