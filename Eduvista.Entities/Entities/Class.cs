using Eduvista.Core.Repository.Abstraction;
using Eduvista.Entities.Enums;

namespace Eduvista.Entities.Entities;

public class Class : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Section Section { get; set; } 
    public int NoOfStudents { get; set; }
    public int NoOfSubjects { get; set; }
    public bool Status { get; set; }

    // Relationships
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
